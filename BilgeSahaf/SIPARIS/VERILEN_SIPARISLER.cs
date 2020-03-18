using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.SIPARIS
{
    public partial class VERILEN_SIPARISLER : Form
    {
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,TARIH,CARI,AD,TELEFON,DURUM,EKLENME_TARIHI";

        public VERILEN_SIPARISLER()
        {
            InitializeComponent();
        }

        private void ALINAN_SIPARISLER_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "VerSipGrid1";

            styleHelper.dataGridStyle(dataGridView1);
            getDefault();
            
        }
        public void getDefault()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM VERILEN_SIPARISLER_V2");

        }
        CommonClass commonClass = new CommonClass();
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns = helper.getColumnsNames("VERILEN_SIPARISLER_V2");
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM VERILEN_SIPARISLER_V2 WHERE " + query);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIPARIS.YENI_VERILEN_SIPARIS frm = new SIPARIS.YENI_VERILEN_SIPARIS();
            commonClass.openFormOnForm(frm);
            getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            SIPARIS.VERILEN_SIPARIS_DUZENLE frm = new SIPARIS.VERILEN_SIPARIS_DUZENLE();
            frm.ITEM_ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            frm.ShowDialog();

            getDefault();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());
            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }
    }
}
