using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mask = "*.*";
            string path = @"C:\Users\Eric\Documents";
            //path = @"c:\";
            //string[] files = Directory.GetFiles(path, mask, SearchOption.AllDirectories);
            string csv = string.Empty;
            foreach (string s in Directory.GetDirectories(path) ) //files)
            {
                csv += string.Format("{0},", s);
            }
            MessageBox.Show(csv);
        }
    }
}
