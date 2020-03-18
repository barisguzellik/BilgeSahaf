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
    public partial class ALINAN_SIPARISLER : Form
    {
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,TARIH,CARI,AD,TELEFON,DURUM,EKLENME_TARIHI";

        public ALINAN_SIPARISLER()
        {
            InitializeComponent();
        }

        private void ALINAN_SIPARISLER_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "AlSipGrid1";
            dataIcerik.Tag = "AlSipGrid2";

            styleHelper.dataGridStyle(dataGridView1);
            styleHelper.dataGridStyle(dataIcerik);
            getDefault();

            
            dataIcerik.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }
        public void getDefault()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM ALINAN_SIPARISLER_V2 ORDER BY ID DESC");

        }
        CommonClass commonClass = new CommonClass();
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns = helper.getColumnsNames("ALINAN_SIPARISLER_V2");
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM ALINAN_SIPARISLER_V2 WHERE " + query);
        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SIPARIS.YENI_ALINAN_SIPARIS frm = new SIPARIS.YENI_ALINAN_SIPARIS();
            commonClass.openFormOnForm(frm);
            getDefault();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            SIPARIS.ALINAN_SIPARIS_DUZENLE frm = new SIPARIS.ALINAN_SIPARIS_DUZENLE();
            frm.ITEM_ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            frm.ShowDialog();

            getDefault();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        public void getTahsilat(string id)
        {
            string COLS = "STOK_KARTI_V2.STOK_KODU,STOK_KARTI_V2.BARKOD_1,STOK_KARTI_V2.YAZAR,STOK_KARTI_V2.YAYINEVI,ALINAN_SIPARIS_URUNLER.MIKTAR,ALINAN_SIPARIS_URUNLER.DURUM,ALINAN_SIPARIS_URUNLER.BEKLEME_NEDENI,ALINAN_SIPARIS_URUNLER.TEDARIKCI,ALINAN_SIPARIS_URUNLER.TEDARIK_SURESI";
            dataIcerik.DataSource = helper.getDataTable("SELECT " + COLS + " FROM ALINAN_SIPARIS_URUNLER INNER JOIN STOK_KARTI_V2 ON ALINAN_SIPARIS_URUNLER.STOK_ID=STOK_KARTI_V2.ID WHERE ALINAN_SIPARIS_URUNLER.SIPARIS_ID=" + id + "");
            //dataIcerik.DataSource = helper.getDataTable("SELECT * FROM SATIS_FATURA_URUNLER INNER JOIN STOK_KARTI_V2 ON SATIS_FATURA_URUNLER.URUN_ID=STOK_KART_V2.ID WHERE SATIS_FATURA_URUNLER.SATIS_FATURA_ID=" + id + "");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void yENİTAHSİLATEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIPARIS.TAHSILAT_EKLE frm = new SIPARIS.TAHSILAT_EKLE();
            frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataTahsilat_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataIcerik);
        }

        private void dataIcerik_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                getTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {

            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }

        private void dataIcerik_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridColWidth(dataIcerik, dataIcerik.Tag.ToString());
        }
    }
}
