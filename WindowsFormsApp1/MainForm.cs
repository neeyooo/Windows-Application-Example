using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm(string name)
        {
            InitializeComponent();
            SetName(name);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            timer1.Interval = 1000;
            timer1.Start();
        }
        public string SetName(string name) => label1.Text = "Welcome, " + name;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label2.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterMember form = new MasterMember();
            this.Hide();
            form.Show();
        }
    }
}
