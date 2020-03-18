using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.INDIRIMLER
{
    public partial class INDIRIMLER_YAYINEVLERI : Form
    {
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,YAYINEVI,ISKONTO_ORANI";

        public INDIRIMLER_YAYINEVLERI()
        {
            InitializeComponent();
        }

        private void ALINAN_SIPARISLER_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "YayineviGrid1";
            //styleHelper.dataGridStyle(dataGridView1);
            getDefault();

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }
        public void getDefault()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM YAYINEVI_ISKONTO");

        }
        CommonClass commonClass = new CommonClass();
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns = { "YAYINEVI" };
            if (likeColumns.Length > 0)
            {
                for (int i = 0; i < likeColumns.Length; i++)
                {
                    if (i == 0)
                    {
                        query += " AND " + likeColumns[i] + " LIKE N'%" + toolStripTextBox1.Text + "%' ";
                    }
                    else
                    {
                        query += " OR " + likeColumns[i] + " LIKE N'%" + toolStripTextBox1.Text + "%' ";
                    }
                }
            }


            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM YAYINEVI_ISKONTO WHERE " + query);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                try
                {

                    var id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    var yayinevi = dataGridView1.Rows[e.RowIndex].Cells["YAYINEVI"].Value.ToString();
                    var oran = dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORANI"].Value.ToString();

                    string[] cols =
                    {
                    "YAYINEVI",
                    "ISKONTO_ORANI"
                };
                    string[] vals =
                    {
                    yayinevi.Trim(),
                    oran
                };


                    DataTable isRow = helper.getDataTable("SELECT ID FROM YAYINEVI_ISKONTO WHERE YAYINEVI='" + yayinevi.Trim() + "'");
                    if (isRow.Rows.Count > 0)
                    {
                        helper.setSqlCommandForUpdateWithParameters("YAYINEVI_ISKONTO", cols, vals, "ID", id);
                        getDefault();
                    }
                    else
                    {
                        helper.setSqlCommandForInsertWithParameters("YAYINEVI_ISKONTO", cols, vals);
                        getDefault();

                    }


                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Dikkat");
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void indirimiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var rowid = dataGridView1.SelectedCells[0].RowIndex;
                var id = dataGridView1.Rows[rowid].Cells["ID"].Value.ToString();

                helper.setSqlCommand("DELETE FROM YAYINEVI_ISKONTO WHERE ID=" + id + "");
                getDefault();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Dikkat");
            }
        }
    }
}
