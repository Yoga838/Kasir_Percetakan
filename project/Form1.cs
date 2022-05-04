using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database = kasir;"))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from public.akun where username = '" + username.Text + "'and password = '" + password.Text + "'",con);
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter();
                DataTable dt = new DataTable();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    if (dr[3].ToString() == "admin")
                    {
                        Form2 fm = new Form2();
                        fm.Show();
                        con.Close();
                        this.Hide();
                    }
                    else
                    {
                        menupegawai pgw = new menupegawai();
                        pgw.Show();
                        con.Close();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("username / password salah");
                }
            }
        }
    }
}
