using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MasterMember : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=MandhegParkingSystem;Integrated Security=True;MultipleActiveResultSets=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader read;
        DataTable dt = new DataTable();
        private void inisialisasiLv()
        {
            listView1.Clear();
            listView1.Columns.Add("id", 0);

            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Email", 100);
            listView1.Columns.Add("Phone number", 100);
            listView1.Columns.Add("Address", 200);
            listView1.Columns.Add("Date of birth", 100);
            listView1.Columns.Add("Gender", 50);
            listView1.Columns.Add("Membership type", 50);
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
        }
        private void listData()
        {
            inisialisasiLv();
            con.Open();
            string sql = "SELECT *,Membership.name as membershipname FROM Member INNER JOIN Membership ON Member.membership_id=Membership.id";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem(read["id"].ToString());
                item.SubItems.Add(read["name"].ToString());
                item.SubItems.Add(read["email"].ToString());
                item.SubItems.Add(read["phone_number"].ToString());
                item.SubItems.Add(read["address"].ToString());
                item.SubItems.Add(read["date_of_birth"].ToString());
                item.SubItems.Add(read["gender"].ToString());
                item.SubItems.Add(read["membershipname"].ToString());
                listView1.Items.Add(item);
                
            }
            cmd = new SqlCommand("SELECT name FROM Membership", con);
            cmd.ExecuteNonQuery();
            read = cmd.ExecuteReader() ;
            while (read.Read())
            {
                comboBox1.Items.Add(read[0].ToString());
            }
            con.Close();
        }
        public MasterMember()
        {
            InitializeComponent();
            listData();
        }

        private void MasterMember_Load(object sender, EventArgs e)
        {

        }
        private void enDis(bool i)
        {
            if (i)
            {
                textBox1.Enabled = true; textBox2.Enabled = true; 
                textBox3.Enabled = true; textBox4.Enabled = true; 
                textBox5.Enabled = true;
                radioButton1.Enabled = true; radioButton2.Enabled = true;
                comboBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false; textBox2.Enabled = false;
                textBox3.Enabled = false; textBox4.Enabled = false;
                textBox5.Enabled = false;
                radioButton1.Enabled = false; radioButton2.Enabled = false;
                comboBox1.Enabled = false;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
                        if (listView1.SelectedItems[0].SubItems[6].Text == "Male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enDis(true);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enDis(true);

        }
    }
}
