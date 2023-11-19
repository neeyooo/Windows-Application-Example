using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Startup : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=MandhegParkingSystem;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand cmd;

        public Startup()
        {
            InitializeComponent();
        }

        private void Startup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myMsg = textBox2.Text;
            var hasil = "";
            var msgBytes = Encoding.ASCII.GetBytes(myMsg);
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(msgBytes);
            foreach (byte b in hash)
            {
                hasil += b.ToString("x2");
            }
            Console.WriteLine(hasil);   

            con.Open();
            string sql = "SELECT name FROM employee WHERE password='"+hasil+"' AND name='"+textBox1.Text+"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            if (!cmd.ExecuteReader().Read())
            {
                Console.WriteLine("gagal");
            }
            else
            {
                Console.WriteLine("Berhasil");
                this.Hide();
                MainForm form = new MainForm(textBox1.Text);
                form.Show();
            }
            con.Close();
        }
    }
}
