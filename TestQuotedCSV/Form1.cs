using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestQuotedCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string[] ss=SplitCSV("111,222,\"33,44,55\",666,\"$77,88.00\",\"99\",\"$888,888.88\"");
            string outs = "", dollars;
            double v;
            System.Collections.ArrayList Dollars = new System.Collections.ArrayList();
            foreach (string s in ss)
            {
                outs += s + "\r\n";
                dollars = s;
                if (s.StartsWith("\"") && s.EndsWith("\""))
                {
                    dollars = s.Substring(1, s.Length - 2);
                }
                if (dollars.StartsWith("$"))
                    dollars = dollars.Substring(1, dollars.Length - 1);
                if (double.TryParse(dollars, out v))
                {
                    Dollars.Add(v);
                }
            }
            outs += "====\r\n";
            foreach (double d in Dollars)
            {
                outs += string.Format("{0:C2}\r\n", d);
            }
            label1.Text = outs;
        }
        // http://stackoverflow.com/questions/3776458/split-a-comma-separated-string-with-both-quoted-and-unquoted-strings
        public static string[] SplitCSV(string input)
        {
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
            List<string> list = new List<string>();
            string curr = null;
            foreach (Match match in csvSplit.Matches(input))
            {
                curr = match.Value;
                if (0 == curr.Length)
                {
                    list.Add("");
                }

                list.Add(curr.TrimStart(','));
            }

            return list.ToArray<string>();
        }

    }
}
