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


/*
 TODO: Monitor last cycle for eFax TRANS. Has it stopped running?
 TODO: Monitor last cycle of ReservationServer. Has it stopped running?
 * Check the log for an entry in the last 10 minutes.
 */
namespace ConsumeWebService
{
    public partial class Form1 : Form
    {
        string[] titles = { "CaseFax Pending Count", "Court Pending Count", 
                              "Maximum Pending Days", "Max Pending Court Days",
                          "Count over 2 court days",
                          "Support Tickets","Urgent Support Tickets",
                          "Alerts",
                          "Reversals Pending", "Reversals Approved",
                          "Caller ID Issues",
                          "Time pending out of balance"
                          };
        public Form1()
        {
            InitializeComponent();
        }
        ServiceReference1.GetAlertsSoapClient sr = new ServiceReference1.GetAlertsSoapClient();
        Color OriginalDefaultBackColor = Form1.DefaultBackColor, OriginalDefaultForeColor = Form1.DefaultForeColor;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string rw in ports)
            {
                //comPortsToolStripMenuItem.Items.Add()
                ToolStripMenuItem SSSMenu = new ToolStripMenuItem(rw,null,ChildClick);
                contextMenuStrip1.Items.Add(SSSMenu);
            }
            OriginalDefaultBackColor = Form1.DefaultBackColor;
            OriginalDefaultForeColor = Form1.DefaultForeColor;
            LastBalanced = DateTime.Now;
            GetAlerts();
        }
        public void ChildClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                string s = (sender as ToolStripMenuItem).Text;
                serialPort1.Close();
                serialPort1.PortName = s;
                serialPort1.Open();
                (sender as ToolStripMenuItem).Checked = true;
            }
        }
        public DateTime LastBalanced = DateTime.Now;
        public void GetAlerts()
        {
            this.BackColor = OriginalDefaultBackColor;
            this.ForeColor = OriginalDefaultForeColor;
            bool Red = false, Yellow = false;
            Cursor = Cursors.WaitCursor;
            string s = sr.GetCounts("CaseFaxAlertsPa55word77!");
            s += ",00:00";
            string[] items = s.Split(',');
            if (items[0] == items[1])
            {
                LastBalanced = DateTime.Now;
            }
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    ListViewItem li = listView1.Items[i];
                    li.SubItems[2].Text = items[i];
                    int v = -1, v0;
                    if (int.TryParse(items[i], out v0))
                        v = v0;
                    switch (i + 1)
                    {
                        case 6:
                            if (v == 0)
                                li.BackColor = Color.White;
                            else
                            {
                                li.BackColor = Color.Yellow;
                                //li.ForeColor = Color.White;
                                Yellow = true;
                            }
                            break;
                        case 7:
                            if (v == 0)
                            {
                                li.BackColor = Color.White;
                                li.ForeColor = Color.Black;
                            }
                            else
                            {
                                li.BackColor = Color.Red;
                                li.ForeColor = Color.White;
                                Red = true;
                            }
                            break;
                        case 10:
                        case 11:
                            if (v == 0)
                            {
                                li.BackColor = Color.White;
                                li.ForeColor = Color.Black;
                            }
                            else
                            {
                                li.BackColor = Color.Red;
                                li.ForeColor = Color.White;
                                Red = true;
                            }
                            break;
                        case 12:
                            li.BackColor = Color.White;
                            li.ForeColor = Color.Black;
                            /*
                            string[] v = li.SubItems[2].Text.Split(':');
                            int j;
                            if (int.TryParse(v[1], out j))
                            {
                                if (j > 10)
                                {
                                    li.BackColor = Color.Yellow;
                                }
                                if (j > 20)
                                {
                                    li.BackColor = Color.Red;
                                    li.ForeColor = Color.White;
                                }
                            } */
                            if (MinutesOut > 10)
                            {
                                li.BackColor = Color.Yellow;
                                Yellow = true;
                            }
                            if (MinutesOut > 20)
                            {
                                li.BackColor = Color.Red;
                                li.ForeColor = Color.White;
                                Red = true;
                            }
                            break;
                    }
                }
                if (Red)
                {
                    this.BackColor = Color.Red;
                    this.ForeColor = Color.White;
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.WriteLine("R");
                    }
                }
                else
                {
                    if (Yellow)
                    {
                        this.BackColor = Color.Yellow;
                        if (serialPort1.IsOpen)
                            serialPort1.WriteLine("Y");
                    }
                    else
                    {
                        if (serialPort1.IsOpen)
                            serialPort1.WriteLine("G");
                    }
                }
            }
            else
            {
                int i = 0;
                if (items.Length == titles.Length)
                {
                    foreach (string item in items)
                    {
                        ListViewItem li = new ListViewItem();
                        li.Text = titles[i]; //string.Format("{0}", i + 1); ;
                        li.SubItems.Add(string.Format("{0}", i + 1));//titles[i]);
                        li.SubItems.Add(item);
                        listView1.Items.Add(li);
                        //listView1.Items.Add(titles[i]);

                        i++;
                    }
                }
            }
            TimeSpan ts = DateTime.Now - LastBalanced;
            MinutesOut = ts.TotalMinutes;
            if (ts.TotalSeconds > 0)
            {
                int secs = (int)ts.TotalSeconds;
                ListViewItem li = listView1.Items[listView1.Items.Count - 1];
                li.SubItems[2].Text = string.Format("{0:00}:{1:00}", secs / 60, secs % 60);
            }
            Cursor = Cursors.Default;
            AlertCount++;
        }
        double MinutesOut = 0.0;
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAlerts();
        }
        public int seconds = 0;
        public int minutes = 0;
        public int AlertCount = 0;
        public int MaxAlertMinutes = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tsnOnTimer.Checked)
            {
                seconds++;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                    if (minutes >= MaxAlertMinutes)
                    {
                        minutes = 0; 
                        GetAlerts();
                        //AlertCount++;
                        ClearSelected();
                    }
                }
            }
            label1.Text = string.Format("{0} -- {1:00}:{2:00}", AlertCount, minutes, seconds);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int i = 1;
            if (sender is ToolStripMenuItem)
            {
                string s = (sender as ToolStripMenuItem).Text;
                if (int.TryParse(s, out i))
                {
                    MaxAlertMinutes = i;
                    ClearChecks();
                    (sender as ToolStripMenuItem).Checked = true;
                }
            }
        }
        private void ClearChecks()
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
        }
        private void ClearSelected()
        {
            listView1.SelectedItems.Clear();
        }
    }
}
