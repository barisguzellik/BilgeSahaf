using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.AKTAR
{
    public partial class KIDA_ALIS_FATURASI : Form
    {
        public KIDA_ALIS_FATURASI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            
            
            String name = "Fatura Detay";
            String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                            file +
                            ";Extended Properties='Excel 8.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);

            int rowCount = data.Rows.Count;
            data.Rows[0].Delete();
            data.Rows[1].Delete();
            data.Rows[rowCount-1].Delete();
            dataGridView1.DataSource = data;
        }

        private void KIDA_ALIS_FATURASI_Load(object sender, EventArgs e)
        {
            
        }
    }
}
