using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HFDrelays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AlertRefresh();
        }
        private void AlertRefresh()
        {
            DateTime start = DateTime.Now;
            ServiceReference1.GetAlertsSoapClient ws = new ServiceReference1.GetAlertsSoapClient();
            int bits = ws.GetReplicationHFDbits("rvjrvj");
            // GYR
            string s = string.Empty;
            string ss = string.Empty;
            if ((bits & 1) != 0)
            {
                s += AddString(s, "Red");
                ss += "R";
            }
            if ((bits & 2) != 0)
            {
                s += AddString(s, "Yellow");
                ss += "Y";
            }
            if ((bits & 4) != 0)
            {
                s += AddString(s, "Green");
                ss += "G";
            }
            s = s.Trim();
            if (s == string.Empty)
                s = "No alerts.";
            s += string.Format("   {0:0.0} ms", (DateTime.Now - start).TotalMilliseconds);
            label1.Text = s;
        }
        public string AddString(string s, string v)
        {
            string r=s;
            if (r.Trim() == string.Empty)
                r = v;
            else
                r = string.Format("{0}, {1}", r, s);
            return r;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            label2.Text = "";
        }
    }
}
