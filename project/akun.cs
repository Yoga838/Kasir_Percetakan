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
    public partial class akun : Form
    {
        public akun()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;"))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into public.akun (username,password,jabatan)values(@user,@pw,@jbt)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@user", textBox1.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@pw", textBox2.Text));
                    cmd.Parameters.Add(new NpgsqlParameter("@jbt", textBox3.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Berhasil menambahkan akun");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("username yang anda buat sudah ada silahkan pilih username lainnya");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void akun_Load(object sender, EventArgs e)
        {

        }
    }
}
