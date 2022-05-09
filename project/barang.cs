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
    public partial class barang : Form
    {
        public barang()
        {
            InitializeComponent();
            dropdown_jenis();
            dropdown_supplier();
            load_data();
        }
        void load_data()
        {
            NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from public.barang", con);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void dropdown_jenis()
        {
            NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database = kasir;");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select id_jenis from jenis",con);
            cmd.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["id_jenis"].ToString());
            }
        }
        void dropdown_supplier()
        {
            NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database = kasir;");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select id_supplier from supplier", con);
            cmd.ExecuteNonQuery();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["id_supplier"].ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into barang (nama,harga,stock,id_supplier,id_jenis) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                comboBox1.Text = " ";
                comboBox2.Text = " ";
                load_data();
                MessageBox.Show("berhasil menambahkan barang");
            }
            catch (Exception x)
            {
                MessageBox.Show("gagal menambahkan barang");  
            }
           
        }
        public int id_barang;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            id_barang = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedCells[4].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedCells[5].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update barang set nama = '" + textBox1.Text + "', harga = '" + textBox2.Text + "', stock = '" + textBox3.Text + "', id_supplier = '" + comboBox1.Text + "', id_jenis = '" + comboBox2.Text + "' where id_barang = '" + this.id_barang + "' ", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                comboBox1.Text = " ";
                comboBox2.Text = " ";
                load_data();
                MessageBox.Show("berhasil mengupdate");
            }
            catch (Exception)
            {
                MessageBox.Show("gagal mengupdate");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from barang where id_barang = '" + this.id_barang + "' ",con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                load_data();
                MessageBox.Show("berhasil menghapus data");
            }
            catch (Exception)
            {
                MessageBox.Show("gagal mengapus data");
            }
          
        }
    }
}
