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
    public partial class transaksi : Form
    {
        public transaksi()
        {
            InitializeComponent();
            load_data();
        }
        static  NpgsqlConnection koneksi ()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Bagus383`;database=kasir;");
        }
        void load_data()
        {
            NpgsqlConnection con = koneksi ();
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from public.barang", con);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public int id_barang;
        public int stock;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dataGridView1.SelectedCells[3].Value.ToString()) > 0)
            {
                stock = Convert.ToInt32(dataGridView1.SelectedCells[3].Value.ToString());
                MessageBox.Show("masukkan kuantitas anda");
                id_barang = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("barang tersebut kosong");
            }
        }
        int n=0;
        int total1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox4.Text) <= stock)
            {
                n++;
                int total = Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox4.Text);
                total1 = total + total1;
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(dataGridView2);
                dr.Cells[0].Value = n + 1;
                dr.Cells[1].Value = textBox1.Text;
                dr.Cells[2].Value = textBox2.Text;
                dr.Cells[3].Value = textBox4.Text;
                dataGridView2.Rows.Add(dr);
                label6.Text = "Rp. " + total1.ToString();
                update_item();
                load_data();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Kuantitas melebihi dari stock");
            }
        }
        private void update_item ()
        {
            int jumlah = stock - Convert.ToInt32(textBox4.Text);
            NpgsqlConnection con = koneksi();
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("update barang set stock ='"+jumlah+"' where id_barang = '"+this.id_barang+"'",con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        
    }
}
