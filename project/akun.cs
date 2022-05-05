using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace project
{
    public partial class akun : Form
    {
        public akun()
        {
            InitializeComponent();
            load_data();
        }
        void load_data()
        {
            NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from public.akun", con);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
                    load_data();
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
        public int id_akun;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_akun = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;"))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("update akun set username = '" + textBox1.Text + "' , password = '"+textBox2.Text+"', jabatan = '"+textBox3.Text+"' where id_akun = '"+this.id_akun+"' ",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("berhasil mengedit");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("gagal mengedit");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;"))
                {
                    con.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("delete from akun where id_akun = '" + this.id_akun + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("berhasil menghapus");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("gagal menghapus");
            }
        }
    }
}

