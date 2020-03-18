using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA_IADE
{
    public partial class ALIS_IADE_FATURALARI : Form
    {
        public ALIS_IADE_FATURALARI()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,BELGE_NUMARASI,TARIH,CARI_UNVANI,TOPLAM,ISKONTO_TOPLAM,KDV_TOPLAM,GENEL_TOPLAM,EKLENME_TARIHI";
        private void SATIS_FATURALARI_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "AlIadGrid1";
            dataIcerik.Tag = "AlIadGrid2";

            styleHelper.dataGridStyle(dataGridView1);
            styleHelper.dataGridStyle(dataIcerik);
            getDefault();
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);

            
        }
        private void KeyEvent(object sender, KeyEventArgs e) //Keyup Event 
        {
            if (e.KeyCode == Keys.F5)
            {
                getDefault();
            }


        }
        public void getDefault()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM ALIS_IADE_FATURALARI_V2 ORDER BY ID DESC");

        }
        CommonClass commonClass = new CommonClass();
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns = helper.getColumnsNames("ALIS_IADE_FATURALARI_V2");
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM ALIS_IADE_FATURALARI_V2 WHERE " + query);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FATURA_IADE.YENI_ALIS_IADE_FATURASI frm = new FATURA_IADE.YENI_ALIS_IADE_FATURASI();
            frm.ShowDialog();
            // getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FATURA_IADE.ALIS_IADE_FATURASI_DUZENLE frm = new FATURA_IADE.ALIS_IADE_FATURASI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();

            //getDefault();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }
        public void getTahsilat(int id)
        {
            string COLS = "STOK_KARTI_V2.STOK_KODU,STOK_KARTI_V2.BARKOD_1,STOK_KARTI_V2.STOK_ADI,STOK_KARTI_V2.YAZAR,STOK_KARTI_V2.YAYINEVI,ALIS_IADE_FATURA_URUNLER.MIKTAR,ALIS_IADE_FATURA_URUNLER.BIRIM_FIYAT,ALIS_IADE_FATURA_URUNLER.ISKONTO,ALIS_IADE_FATURA_URUNLER.KDV_ORANI,ALIS_IADE_FATURA_URUNLER.TOPLAM";
            dataIcerik.DataSource = helper.getDataTable("SELECT " + COLS + " FROM ALIS_IADE_FATURA_URUNLER INNER JOIN STOK_KARTI_V2 ON ALIS_IADE_FATURA_URUNLER.URUN_ID=STOK_KARTI_V2.ID WHERE ALIS_IADE_FATURA_URUNLER.ALIS_FATURA_ID=" + id + "");
            //dataIcerik.DataSource = helper.getDataTable("SELECT * FROM SATIS_FATURA_URUNLER INNER JOIN STOK_KARTI_V2 ON SATIS_FATURA_URUNLER.URUN_ID=STOK_KART_V2.ID WHERE SATIS_FATURA_URUNLER.SATIS_FATURA_ID=" + id + "");
        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            //searchProcess();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            FATURA_IADE.ALIS_IADE_FATURASI_DUZENLE frm = new FATURA_IADE.ALIS_IADE_FATURASI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();

            //getDefault();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FATURA_IADE.YENI_ALIS_IADE_FATURASI frm = new FATURA_IADE.YENI_ALIS_IADE_FATURASI();
            frm.ShowDialog();
           // getDefault();
        }

        private void yENİTAHSİLATEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FATURA_IADE.IADE_TAHSILAT_EKLE frm = new FATURA_IADE.IADE_TAHSILAT_EKLE();
            frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.TUTAR = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            frm.ShowDialog();
        }

        private void dataTahsilat_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                getTahsilat(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            }
            catch (Exception x)
            {

            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataGridView1);

            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
            

        }

        private void dataTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataIcerik);

            styleHelper.dataGridColWidth(dataIcerik, dataIcerik.Tag.ToString());

            dataIcerik.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                searchProcess();

            }
        }
    }
}
