using System;
using System.Net.NetworkInformation;
using System.Windows;

namespace StartWifi
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ClickRemove(object sender, EventArgs e)
		{
			if (!CheckInput(host.Text))
			{
				MessageBox.Show("Wrong IP or host unavailable!");
				return;
			}

			MK mikrotik = new MK(host.Text);

			if (!CheckAuth(mikrotik)) return;

			DisableCapsMan(mikrotik);

			string Message = CreateMessages(" Remove CAPsMAN\n", mikrotik);

			RemoveCloud(mikrotik);

			Message += " Remove from cloud\n";
			Message = CreateMessages(Message, mikrotik);

			EnableWireless(mikrotik);

			Message += " Enable WiFi\n";
			Message = CreateMessages(Message, mikrotik);

			MessageBox.Show(Message, " Success");
			//Close();
		}

		private void ClickUpload(object sender, RoutedEventArgs e)
		{
			if (!CheckInput(host.Text))
			{
				MessageBox.Show("Wrong IP or host unavailable!");
				return;
			}

			MK mikrotik = new MK(host.Text);

			if (!CheckAuth(mikrotik)) return;

			string name = "sNNfvtGGjoGDeNUdH7p82Wpx";
			string user = "dznet";//"vlad";
			string password = "vjhrjdrf8728";//"vlad";
			string connect = "192.168.88.1"; // 444a0242d97d.sn.mynetname.net");

			// Add to cloud
			mikrotik.Send("/interface/l2tp-client/add");
			mikrotik.Send($"=name={name}");
			mikrotik.Send($"=connect-to={connect}");
			mikrotik.Send($"=user={user}");
			mikrotik.Send($"=password={password}");
			mikrotik.Send("=dial-on-demand=yes");
			mikrotik.Send("=add-default-route=yes");
			mikrotik.Send("=default-route-distance=1");
			mikrotik.Send("=allow-fast-path=yes");
			mikrotik.Send("=profile=default");
			mikrotik.Send("=disabled=no");
			mikrotik.Send("=comment=new company test", true);

			string Message = CreateMessages(" Connect to cloud\n", mikrotik);

			EnabledCapsMan(mikrotik);

			Message += " Enable CAPsMAN\n";
			Message = CreateMessages(Message, mikrotik);

			MessageBox.Show(Message, "Success");
			//Close();
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

		private bool CheckAuth(MK mikrotik)
		{
			if (!mikrotik.Login(login.Text, passwd.Password))
			{
				MessageBox.Show("Wrong username or password!");
				mikrotik.Close();
				return false;
			}
			return true;
		}

		private string CreateMessages(string message, MK mikrotik)
		{
			foreach (string h in mikrotik.Read())
				message += h + "\n";
			return message;
		}

		private void DisableCapsMan(MK mikrotik)
		{
			mikrotik.Send("/interface/wireless/cap/set");
			mikrotik.Send("=enabled=no", true);
		}

		private void EnabledCapsMan(MK mikrotik)
		{
			mikrotik.Send("/interface/wireless/cap/set");
			mikrotik.Send("=enabled=yes");
			mikrotik.Send("=interfaces=wlan1");
			mikrotik.Send("=discovery-interfaces=sNNfvtGGjoGDeNUdH7p82Wpx", true);
		}

		private void RemoveCloud(MK mikrotik)
		{
			mikrotik.Send("/interface/l2tp-client/remove");
			mikrotik.Send("=numbers=sNNfvtGGjoGDeNUdH7p82Wpx", true);
		}

		private void EnableWireless(MK mikrotik)
		{
			mikrotik.Send("/interface/wireless/enable");
			mikrotik.Send("=numbers=wlan1", true);
		}

	}
}
