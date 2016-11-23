using System;
using System.Windows;
using System.Net.NetworkInformation;

namespace StartWiFi
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private bool CheckInput(string host)
		{
			PingReply reply;

			if (string.IsNullOrEmpty(host))
			{
				MessageBox.Show(" Empty Host!");
				return false;
			}
			else
				reply = new Ping().Send(host, 120);

			if (reply.Status != IPStatus.Success)
			{
				MessageBox.Show(" Ping faled!\n Retry");
				return false;
			}
			else
				return true;
		}
		private void ClickRemove(object sender, EventArgs e)
		{
			if (CheckInput(host.Text))
			{
				MK mikrotik = new MK(host.Text);
				if (!mikrotik.Login(login.Text, passwd.Password))
				{
					MessageBox.Show(" Wrong username or password!");
					mikrotik.Close();
					return;
				}

				// disable CAPsMAN
				mikrotik.Send("/interface/wireless/cap/set");
				mikrotik.Send("=enabled=no", true);
				
				string Message = " Remove CAPsMAN\n";
				Message = CreateMessages(Message, mikrotik);

				// remove cloud
				mikrotik.Send("/interface/l2tp-client/remove");
				mikrotik.Send("=numbers=sNNfvtGGjoGDeNUdH7p82Wpx", true);

				Message += " Remove from cloud\n";
				Message = CreateMessages(Message, mikrotik);

				// enable wireless
				mikrotik.Send("/interface/wireless/enable");
				mikrotik.Send("=numbers=wlan1", true);
				Message += " Enable WiFi\n";
				Message = CreateMessages(Message, mikrotik);

				MessageBox.Show(Message, " Success");
				Close();
			}
		}

		private void ClickUpload(object sender, RoutedEventArgs e)
		{
			if (!CheckInput(host.Text))	return;
			
			MK mikrotik = new MK(host.Text);
			if (!mikrotik.Login(login.Text, passwd.Password))
			{
				MessageBox.Show("Wrong username or password!");
				mikrotik.Close();
				return;
			}

			string name = "sNNfvtGGjoGDeNUdH7p82Wpx";
			string user = "admin";
			string password = "admin";

			// Add to cloud
			mikrotik.Send("/interface/l2tp-client/add");
			mikrotik.Send($"=name={name}");
			mikrotik.Send("=connect-to=134.249.149.110");
			mikrotik.Send($"=user={user}");
			mikrotik.Send($"=password={password}");
			mikrotik.Send("=dial-on-demand=yes");
			mikrotik.Send("=add-default-route=yes");
			mikrotik.Send("=default-route-distance=1");
			mikrotik.Send("=allow-fast-path=yes");
			mikrotik.Send("=profile=default");
			mikrotik.Send("=disabled=no");
			mikrotik.Send("=comment=new company test", true);

			string Message = "connect to cloud\n";
			Message = CreateMessages(Message, mikrotik);

			// Enable CAPsMAN
			mikrotik.Send("/interface/wireless/cap/set");
			mikrotik.Send("=enabled=yes");
			mikrotik.Send("=interfaces=wlan1");
			mikrotik.Send("=discovery-interfaces=sNNfvtGGjoGDeNUdH7p82Wpx", true);

			Message += "enable CAPsMAN\n";
			Message = CreateMessages(Message, mikrotik);

			MessageBox.Show(Message, "Success");
			Close();
		}

		private string CreateMessages(string message, MK mikrotik)
		{
			foreach (string h in mikrotik.Read())
				message += h + "\n";
			return message;
		}

	}
}
