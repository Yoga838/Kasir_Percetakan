using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            akun ak = new akun();
            ak.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            barang brg = new barang();
            brg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jenis_barang jns = new jenis_barang();
            jns.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 frm= new Form1();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            supplier splr = new supplier();
            splr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toko tk = new toko();
            tk.Show();
        }
    }
}
