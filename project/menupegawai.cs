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
    public partial class menupegawai : Form
    {
        public menupegawai()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transaksi trx = new transaksi();
            trx.Show();
        }
    }
}
