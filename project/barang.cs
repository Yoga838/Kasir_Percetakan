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
    }
}
