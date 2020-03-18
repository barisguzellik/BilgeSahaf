using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
{
    public partial class STOK_GIRISLERI : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public STOK_GIRISLERI()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,BELGE_NUMARASI,TARIH,CARI_UNVANI,EKLENME_TARIHI";
        private void SATIS_FATURALARI_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "StokGirisGrid1";

            styleHelper.dataGridStyle2(dataGridView1);
            getDefault();

            
        }
        public void getDefault()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM STOK_GIRISLERI_V2 ORDER BY ID DESC");

        }
        CommonClass commonClass = new CommonClass();
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns = helper.getColumnsNames("STOK_GIRISLERI_V2");
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM STOK_GIRISLERI_V2 WHERE " + query);
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
        public void getTahsilat(string faturaID)
        {
            
        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            FATURA.YENI_STOK_GIRISI frm = new FATURA.YENI_STOK_GIRISI();
            frm.ShowDialog();
            getDefault();
        }

        private void toolStripTextBox1_TextChanged_2(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void dataGridView1_DoubleClick_3(object sender, EventArgs e)
        {
            FATURA.STOK_GIRISI_DUZENLE frm = new FATURA.STOK_GIRISI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
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
