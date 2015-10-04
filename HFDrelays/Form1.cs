using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//Cusing System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//using System.Web.Services;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace HFDrelays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool testing = false;
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            testing = false;
            label4.Text = "";
            AlertRefresh();
        }
        int bits = 2, lastBits = 7;
        DateTime LastAlertTime = DateTime.MinValue;
        private void AlertRefresh()
        {
            fillRed = false; fillGreen = false; fillYellow = false; fillBlue = false;
            Cursor = Cursors.WaitCursor; btnRefresh.Enabled = false;
            try
            {
                DateTime start = DateTime.Now;
                if (!testing)
                {
                    //us.classact.caweb.GetAlertsSoapClient ws = new us.classact.caweb.GetAlertsSoapClient();
                    ServiceReference1.GetAlerts ws = new ServiceReference1.GetAlerts();
                    //ServiceReference1.GetAlertsSoapClient ws = new ServiceReference1.GetAlertsSoapClient();
                    bits = ws.GetReplicationHFDbits("rvjrvj");
                }
                // GYR
                string s = string.Empty;
                string ss = string.Empty;
                if ((bits & 1) != 0)
                {
                    s += AddString(s, "Red");
                    ss += "R";
                    fillRed = true;
                    LastAlertTime = DateTime.Now;
                }
                if ((bits & 2) != 0)
                {
                    s += AddString(s, "Yellow");
                    ss += "Y";
                    fillYellow = true;
                    LastAlertTime = DateTime.Now;
                }
                if ((bits & 4) != 0)
                {
                    s += AddString(s, "Green");
                    ss += "G";
                    fillGreen = true;
                }
                if ((bits & 8) != 0)
                {
                    s += AddString(s, "Blue");
                    ss += "B";
                    fillBlue=true;
                }
                s = s.Trim();
                if (s == string.Empty)
                    s = "No alerts.";
                s += string.Format("   {0:0.0} ms", (DateTime.Now - start).TotalMilliseconds);
                label1.Text = s;
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine(ss);
                    if ((DateTime.Now - LastAlertTime).TotalHours < 12.0)
                        serialPort1.WriteLine("B");
                }
                if (bits != lastBits)
                    this.Invalidate();
                lastBits = bits;
            }
            catch(Exception ex)
            {
                label4.Text = ex.Message;
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
            string portName;
            foreach (string s in SerialPort.GetPortNames())
            {
                portName = fixPortName(s);
                cbPorts.Items.Add(portName);
            }
            label4.Text = "This is the area for error messages during processing.";
            TimerHours = 0;
        }
        public string fixPortName(string s)
        {
            string ss = s.Trim();
            string r = string.Empty; // = s.Trim();
            char lastCh = 'c';
            int numericChange = 0;
            foreach (char ch in ss)
            {
                if (ch >= ' ' && ch <= 127)
                {
                    if (char.IsNumber(ch) != char.IsNumber(lastCh))
                        numericChange++;
                    if (numericChange >= 2)
                        break;
                    r += ch;
                }
                else
                    break;
                lastCh = ch;
            }
            return r;
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
                    SendTime();
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
        int TimerHours = 0;
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
                        testing = false;
                        AlertRefresh();
                        if (TimerCount % 6 == 0) // Hour
                        {
                            if (TimerHours % 4 == 0)
                                SendTime();
                            TimerHours++;
                        }
                    }
                }
                RefreshStatus();
            }
            finally
            {
                timer1.Enabled = true;
            }
        }
        bool fillRed = false;
        bool fillGreen = true;
        bool fillYellow = true;
        bool fillBlue = false;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int y1 = cbPorts.Top; // +cbPorts.Height;
            int y2 = y1 + (this.ClientRectangle.Height - y1) / 2;
            int wid = (int)(y2 * 0.5);
            int x2 = (int)(wid * 1.1);
            x2 = label3.Left;

            Color c = Color.Green;
            if (fillGreen)
            { c = Color.Green; }
            if (fillRed)
            { c = Color.Red; }
            if (fillYellow)
            { c = Color.Yellow; }
            if (fillBlue) { c = Color.Blue; }
            using (Brush b = new SolidBrush(c))
            {
                e.Graphics.FillEllipse(b, x2, y2, wid, wid);
            }

            e.Graphics.DrawEllipse(Pens.Black, x2, y2, wid, wid);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testing = true;
            bits = 1;
            AlertRefresh();
            this.Invalidate();
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testing = true;
            bits = 2;
            AlertRefresh();
            this.Invalidate();
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testing = true;
            bits = 4;
            AlertRefresh();
            this.Invalidate();
        }
        private void SendTime()
        {
            string s = string.Format("{0:yyMMddHHmmss}", DateTime.Now);
            if (serialPort1.IsOpen)
                serialPort1.WriteLine(s);
        }

        private float getTemperatureF()
        {
            float r = 0;
            com.cdyne.wsf.Weather w = new com.cdyne.wsf.Weather();
            //com.cdyne.wsf.ForecastReturn fr = w.GetCityForecastByZIP("93306");
            com.cdyne.wsf.WeatherReturn f = w.GetCityWeatherByZIP("93301"); //.GetCityForecastByZIP("93306");
            //object o = f.ResponseText; // fr.ForecastResult.GetValue();
            
            if(!float.TryParse(f.Temperature,out r)) {

            }
            return r;
        }
        private float getTempF()
        {
            float r = 0;
            net.webservicex.www.GlobalWeather gw = new net.webservicex.www.GlobalWeather();
            string weather = gw.GetWeather("Bakersfield", "United States");
            return r;
        }
        private void btnTemp_Click(object sender, EventArgs e)
        {
            btnTemp.Enabled = false;
            float temperatureF = getKtempF();
            label5.Text = string.Format("{0:0.0} F", temperatureF);
            btnTemp.Enabled = true;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //digitalWrite(pinBlue, HIGH);
            testing = true;
            bits = 8;
            AlertRefresh();
            this.Invalidate();
        }
        private string temp = '"' + "temp" + '"'+':';
        private float getKtempF()
        {
            float f = 0;
            var request = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=93306,us");

            var postData = "zip=93305,us";
            //postData += "&thing2=world";
            postData = "";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            int pos = responseString.IndexOf(temp);
            string nums = "";
            if (pos >= 0)
            {
                char ch;
                for (int i = 0; i < 12; i++)
                {
                    ch = responseString[i + temp.Length + pos];
                    if (ch == ',')
                        break;
                    nums += ch;
                }
            }
            float k;
            if (float.TryParse(nums, out k))
            {
                
                // ° F = 9/5(K - 273) + 32
                f = (k - 273) * 9 / 5 + 32;
            }
            return f;
        }
    }
}
