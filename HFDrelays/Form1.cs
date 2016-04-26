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
        double LastDuration = 0;
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
                    fillBlue = true;
                }
                s = s.Trim();
                if (s == string.Empty)
                    s = "No alerts.";
                LastDuration = (DateTime.Now - start).TotalMilliseconds;
                s += string.Format("   {0:0.0} ms", LastDuration);
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
            catch (Exception ex)
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
            label6.Text = "";
            player = new WMPLib.WindowsMediaPlayer();
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
        bool DoChime = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DateTime n = DateTime.Now;
            bool OkToChime = false;
            try
            {
                TimerSeconds++;
                if (TimerSeconds >= 60)
                {
                    TimerSeconds = 0;
                    TimerMinutes++;

                    OkToChime = n.Minute == 0 && n.Hour >= 6 && n.Hour <= 21; // Every day of week
                    if (n.DayOfWeek == DayOfWeek.Saturday || n.DayOfWeek == DayOfWeek.Sunday)
                        OkToChime = n.Minute == 0 && n.Hour >= 9 && n.Hour <= 21; // Weekends only.
                    if (OkToChime) //n.Minute == 0 && n.Hour>=7 && n.Hour<=21)
                    {
                        if (DoChime)
                        {
                            int hr = n.Hour;
                            if (hr > 12)
                                hr -= 12;
                            if (hr == 0)
                                hr = 12;
                            PlayMP3(hr);
                            DoChime = false;
                        }
                    }
                    if (n.Minute == 10)
                    {
                        label6.Text = "";
                        DoChime = true;
                    }
                    if (TimerMinutes >= MaxMinutes)
                    {
                        TimerMinutes = 0;
                        TimerCount++;
                        testing = false;
                        AlertRefresh();
                        DoTemp();
                        if (TimerCount % 6 == 0) // Hour
                        {
                            if (TimerHours % 4 == 0)
                                SendTime();
                            TimerHours++;
                            //DoTemp();
                        }
                        //DoChime = true;
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
        public bool Set1970 = true;
        private void SendTime()
        {
            if (Set1970)
                do1970();
            else
            {
                string s = string.Format("{0:yyMMddHHmmss}", DateTime.Now);
                if (serialPort1.IsOpen)
                    serialPort1.WriteLine(s);
            }
        }

        private float getTemperatureF()
        {
            float r = 0;
            com.cdyne.wsf.Weather w = new com.cdyne.wsf.Weather();
            //com.cdyne.wsf.ForecastReturn fr = w.GetCityForecastByZIP("93306");
            com.cdyne.wsf.WeatherReturn f = w.GetCityWeatherByZIP("93301"); //.GetCityForecastByZIP("93306");
            //object o = f.ResponseText; // fr.ForecastResult.GetValue();

            if (!float.TryParse(f.Temperature, out r))
            {

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
            DoTemp();
        }
        private void DoTemp()
        {
            btnTemp.Enabled = false;
            try
            {
                float h;
                float temperatureF = getKtempF(out h);
                label5.Text = string.Format("{0:0.00}{1}F", temperatureF, (char)176);
                if (serialPort1.IsOpen)
                {
                    //serialPort1.WriteLine('"' + padleft(8, string.Format("{0:0.0}{1}F", temperatureF, (char)1)));
                    //serialPort1.WriteLine('"' + string.Format("{0:0.00}{1}F", temperatureF, (char)1));

                    //serialPort1.WriteLine('"' + pad((int)Math.Round(LastDuration/1000.0),8,string.Format("{0:0}{1}F", temperatureF, (char)1)));
                    serialPort1.WriteLine('"' + pad((int)Math.Round(h), 8, string.Format("{0:0}{1}F", temperatureF, (char)46)));
                }
            }
            finally
            {
                btnTemp.Enabled = true;
            }
        }
        public string pad(int i, int n, string s)
        {
            string r = i.ToString() + " " + s;
            string p = "";
            if (i.ToString().Length + s.Length < n)
            {
                int j = n - i.ToString().Length - s.Length;
                if (j > 1)
                {
                    for (int k = 0; k < j; k++)
                    {
                        p += " ";
                    }
                    r = string.Format("{0}{1}{2}", i.ToString(), p, s);
                }
            }
            return r;
        }
        public string padleft(int n, string s)
        {
            string r = s;
            if (r.Length < n)
            {
                while (r.Length < n)
                    r = " " + r;
            }
            return r;
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //digitalWrite(pinBlue, HIGH);
            testing = true;
            bits = 8;
            AlertRefresh();
            this.Invalidate();
        }
        private string temp = '"' + "temp" + '"' + ':';
        private string humidity = '"' + "pressure" + '"' + ':';
        // http://stackoverflow.com/questions/4015324/http-request-with-post
        public string key = "fe137525494e03c8c62641ea9e35f4cf";
        private float getKtempF(out float humidity_)
        {
            float f = 0;
            humidity_ = 0;
            try
            {
                string api = "http://api.openweathermap.org/data/2.5/forecast/city?id=524901&APPID=" + key;
                /*var request = (HttpWebRequest)WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=93306,us");*/
                api = "http://api.openweathermap.org/data/2.5/weather?q=bakersfield&APPID=fe137525494e03c8c62641ea9e35f4cf";
                var request = (HttpWebRequest)WebRequest.Create(api);
                // http://api.openweathermap.org/data/2.5/weather?zip=93306,us
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
                int pos2 = responseString.IndexOf(humidity);
                string nums = "";
                string nums2 = "";
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
                    nums2 = "";
                    for (int i = 0; i < 12; i++)
                    {
                        ch = responseString[i + humidity.Length + pos2];
                        if (ch == ',')
                            break;
                        nums2 += ch;
                    }
                }
                float k;
                if (float.TryParse(nums, out k))
                {

                    // ° F = 9/5(K - 273) + 32
                    f = (k - 273) * 9 / 5 + 32;
                }
                float h;
                if (float.TryParse(nums2, out h))
                {
                    humidity_ = h * 0.03f

                        ;
                }
            }
            catch (Exception ex)
            {
                label4.Text = ex.Message;
            }
            return f;
        }

        private void testFloatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string s = "2222";
                string o = "";
                int i = 0;
                char chr = ' ';
                foreach (char ch in s)
                {
                    chr = ch;
                    if (i == 0)
                        chr |= (char)128;
                    o += chr;
                    i++;
                }
                serialPort1.WriteLine('"' + o);
            }
        }

        private void test0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("t0");
            }
            //LastAlertTime = DateTime.Now.AddDays(-1);
        }

        private void test0ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine("t0");
            }
            //LastAlertTime = DateTime.Now.AddDays(-1);
        }

        private void testNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            do1970();
        }
        public void do1970()
        {
            if (serialPort1.IsOpen)
            {
                DateTime n = DateTime.Now;
                DateTime dt1970;
                if (DateTime.TryParse("1/1/1970", out dt1970))
                {
                    int secs = (int)(n - dt1970).TotalSeconds;
                    serialPort1.WriteLine(string.Format("t{0}", secs));
                }
            }
        }

        private void clearBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastAlertTime = DateTime.Now.AddDays(-1);
        }
        WMPLib.WindowsMediaPlayer player;
        string ChimesConst = @"C:\Users\Eric\Downloads\big ben - tower of london{0}.mp3";
        public void PlayMP3(int chimes)
        {
            if (chimes > 12 || chimes < 1)
                chimes = 1;
            label6.Text = string.Format("Play {0}", chimes);
            string fn = string.Format(ChimesConst, chimes);
            if (!System.IO.File.Exists(fn))
                fn = string.Format(ChimesConst, 1);
            //player = new WMPLib.WindowsMediaPlayer();
            player.URL = fn; //  @"C:\Users\Eric\Downloads\big ben - tower of london12b.mp3";
            player.controls.play();
        }

        private void playMP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PlayMP3(1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int v;
            if (sender is MenuItem)
            {
                MenuItem m = (sender as MenuItem);
                if (int.TryParse(m.Text, out v))
                    PlayMP3(v);
            }
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem m = (sender as ToolStripMenuItem);
                if (int.TryParse(m.Text, out v))
                    PlayMP3(v);
            }
        }
        private string GetSupportCounts()
        {
            string r = "";
            var request = (HttpWebRequest)WebRequest.Create("http://210.classact.us/pendingsupport/");

            var postData = "thing1=hello";
            postData += "&thing2=world";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            r = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return r;
        }

        private void getSupportCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime StartTime = DateTime.Now;
            string s = GetSupportCounts();
            getCounts(s);
            double ms = (DateTime.Now - StartTime).TotalMilliseconds;
            s = string.Format("{0:0.0 ms}\r\n", ms) + s;
            s += "\r\n";
            for (int i = 0; i < 3; i++)
            {
                s += string.Format("{0} = {1}, ", titleList[i], counts[i]);
            }
            MessageBox.Show(s);
        }
        int[] counts = { 0, 0, 0 };
        string[] titleList = { "", "", "" };
        string div = "<div";
        public bool getCounts(string s)
        {
            bool r = false;
            int oldPos = 0, pos = 0, mode = 0, v = 0, CorrectCount = 0;
            char ch;
            string nums = "", titles = "";
            for (int iPos = 0; iPos < 3; iPos++)
            {
                counts[iPos] = 0;
                pos = s.IndexOf(div, oldPos);
                if (pos > 0)
                {
                    nums = ""; titles = "";
                    mode = 0;
                    for (int i = pos + div.Length; i < s.Length; i++)
                    {
                        ch = s[i];
                        if (ch == '"')
                            mode++;
                        if (ch == '>')
                            mode++;
                        if (ch == '<')
                            break;
                        if(mode==1)
                        {
                            if (ch != '"' && ch != '>' && ch != '<')
                                titles += ch;
                        }
                        if (mode == 3)
                        {
                            if (ch >= '0' && ch <= '9')
                                nums += ch;
                        }
                    }
                    if (int.TryParse(nums, out v))
                    {
                        counts[iPos] = v;
                        CorrectCount++;
                    }
                    titleList[iPos] = titles;
                }

                oldPos = pos + div.Length;
            }
            r = CorrectCount == 3;
            return r;
        }
    }
}
