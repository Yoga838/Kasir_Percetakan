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
    public partial class jenis_barang : Form
    {
        public jenis_barang()
        {
            InitializeComponent();
            load_data();
        }
        private static NpgsqlConnection koneksi ()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
        }
        void load_data()
        {
            NpgsqlConnection con = koneksi ();
            con.Open ();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from jenis",con);
            cmd.ExecuteNonQuery ();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.Dispose (); 
            con.Close ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into jenis (nama,deskripsi) values  ('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                load_data();
                MessageBox.Show("berhasil menambahkan data");
            }
            catch (Exception)
            {
                MessageBox.Show("gagal menambahkan data");
            }
           
        }
        public int id_jenis;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_jenis = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = koneksi();
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update jenis set nama='" + textBox1.Text + "', deskripsi='" + textBox2.Text + "' where id_jenis= '" + this.id_jenis + "' ",conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                load_data();
                MessageBox.Show("berhasil mengedit data");
            }
            catch (Exception)
            {
                MessageBox.Show("gagal mengedit data");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from jenis where id_jenis = '" + this.id_jenis + "' ", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                load_data();
                MessageBox.Show("berhasil menghapus data");
            }
            catch (Exception)
            {
                MessageBox.Show("gagal menghapus data");
            }
            
        }
    }
}
