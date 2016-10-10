using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartWiFi
{
    public partial class StartWiFi : Form
    {
        public StartWiFi()
        {
            InitializeComponent();
        }
        private void remove_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(host.Text))
            {
                MessageBox.Show("Empty Host!");
                return;
            }
            MK mikrotik = new MK(host.Text);
            if (!mikrotik.Login(login.Text, passwd.Text))
            {
                MessageBox.Show("Could not login");
                mikrotik.Close();
                return;
            }
            string msg = "";
            // disable CAPsMAN
            mikrotik.Send("/interface/wireless/cap/set");
            mikrotik.Send("=enabled=no", true);
            msg += "remove CAPsMAN\n";
            foreach (string h in mikrotik.Read())
            {
                msg += h + "\n";
            }
            // remove cloud
            mikrotik.Send("/interface/l2tp-client/remove");
            mikrotik.Send("=numbers=sNNfvtGGjoGDeNUdH7p82Wpx", true);
            msg += "remove from cloud\n";
            foreach (string h in mikrotik.Read())
            {
                msg += h + "\n";
            }
            // enable wireless
            mikrotik.Send("/interface/wireless/enable");
            mikrotik.Send("=numbers=wlan1", true);
            msg += "enable WiFi\n";
            foreach (string h in mikrotik.Read())
            {
                msg += h + "\n";
            }
            MessageBox.Show(msg, "Success");
            this.Close();
        }

        private void upload_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(host.Text)) {
                MessageBox.Show("Empty Host!");
                return;
            }
            MK mikrotik = new MK(host.Text);
            if (!mikrotik.Login(login.Text, passwd.Text))
            {
                MessageBox.Show("Could not login");
                mikrotik.Close();
                return;
            }
            string msg = "";
            // Add to cloud
            mikrotik.Send("/interface/l2tp-client/add");
            mikrotik.Send("=name=sNNfvtGGjoGDeNUdH7p82Wpx");
            mikrotik.Send("=connect-to=134.249.149.110");
            mikrotik.Send("=user=username");
            mikrotik.Send("=password=routerPassword");
            mikrotik.Send("=dial-on-demand=yes");
            mikrotik.Send("=add-default-route=yes");
            mikrotik.Send("=default-route-distance=1");
            mikrotik.Send("=allow-fast-path=yes");
            mikrotik.Send("=profile=default");
            mikrotik.Send("=disabled=no");
            mikrotik.Send("=comment=new company test", true);

            msg += "connect to cloud\n";
            foreach (string h in mikrotik.Read())
            {
                msg += h + "\n";
            }
            // Enable CAPsMAN
            mikrotik.Send("/interface/wireless/cap/set");
            mikrotik.Send("=enabled=yes");
            mikrotik.Send("=interfaces=wlan1");
            mikrotik.Send("=discovery-interfaces=sNNfvtGGjoGDeNUdH7p82Wpx", true);

            msg += "enable CAPsMAN\n";
            foreach (string h in mikrotik.Read())
            {
                msg += h + "\n";
            }
            MessageBox.Show(msg,"Success");       
            this.Close();
        }
    }
}