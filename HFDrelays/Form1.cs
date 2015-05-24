using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

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
            Cursor = Cursors.WaitCursor; btnRefresh.Enabled = false;
            try
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
                if (serialPort1.IsOpen)
                    serialPort1.WriteLine(ss);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnRefresh.Enabled = true;
            }
        }
        public string AddString(string s, string v)
        {
            string r = s;
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
            cbPorts.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cbPorts.Items.Add(s);
            }
        }

        private void RefreshStatus()
        {
            label2.Text = string.Format("{0:00}:{1:00} of {2:00}:00", TimerMinutes, TimerSeconds, MaxMinutes); ;
        }

        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            try
            {
                if (cbPorts.SelectedItem is string)
                {
                    serialPort1.PortName = (string)cbPorts.SelectedItem;
                    serialPort1.Open();
                    MessageBox.Show("Serial port has been opened successfully.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        int MaxMinutes = 10;
        int TimerMinutes = 0;
        int TimerSeconds = 0;
        int TimerCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            try
            {
                TimerSeconds++;
                if (TimerSeconds >= 60)
                {
                    TimerSeconds = 0;
                    TimerMinutes++;
                    if (TimerMinutes >= MaxMinutes)
                    {
                        TimerMinutes = 0;
                        TimerCount++;
                        AlertRefresh();
                    }
                }
                RefreshStatus();
            }
            finally
            {
                timer1.Enabled = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int y1 = cbPorts.Top + cbPorts.Height;
            int y2 = y1 + (Size.Height - y1) / 2;
            int wid = (int)(y2 * 0.5);
            e.Graphics.DrawEllipse(Pens.Black, y1, y2, wid, wid);
        }
    }
}
