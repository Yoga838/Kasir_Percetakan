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
    }
}
