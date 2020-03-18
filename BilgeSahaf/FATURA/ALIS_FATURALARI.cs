using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
{
    public partial class ALIS_FATURALARI : Form
    {
        public ALIS_FATURALARI()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,BELGE_NUMARASI,ACIKLAMA,TARIH,CARI_UNVANI,TOPLAM,ISKONTO_TOPLAM,KDV_TOPLAM,GENEL_TOPLAM,EKLENME_TARIHI";
        private void SATIS_FATURALARI_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "AlFatGrid1";
            dataIcerik.Tag = "AlFatGrid2";

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
            this.Cursor = Cursors.WaitCursor;
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM ALIS_FATURALARI_V2 ORDER BY ID DESC");
            this.Cursor = Cursors.Default;
        }
        CommonClass commonClass = new CommonClass();
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns = helper.getColumnsNames("ALIS_FATURALARI_V2");
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM ALIS_FATURALARI_V2 WHERE " + query);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchProcess();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FATURA.YENI_ALIS_FATURASI frm = new FATURA.YENI_ALIS_FATURASI();
            frm.Show();
            //getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FATURA.ALIS_FATURASI_DUZENLE frm = new FATURA.ALIS_FATURASI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.Show();

            //getDefault();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                //getTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {

            }
        }
        public void getTahsilat(string faturaID)
        {

        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            //searchProcess();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            FATURA.ALIS_FATURASI_DUZENLE frm = new FATURA.ALIS_FATURASI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.Show();

            //getDefault();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FATURA.YENI_ALIS_FATURASI frm = new FATURA.YENI_ALIS_FATURASI();
            frm.Show();
            
            //getDefault();
        }

        private void yENİTAHSİLATEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FATURA.ODEME_EKLE frm = new FATURA.ODEME_EKLE();
            frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.TUTAR = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            frm.ShowDialog();
            getTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataTahsilat_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataGridView1);

            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            double drToplam = 0;
            double drIskonto = 0;
            double drKdv = 0;
            double drGenelToplam = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                double toplam = double.Parse(dr.Cells["TOPLAM"].Value.ToString());
                double iskonto = double.Parse(dr.Cells["ISKONTO_TOPLAM"].Value.ToString());
                double kdv = double.Parse(dr.Cells["KDV_TOPLAM"].Value.ToString());
                double genel_toplam = double.Parse(dr.Cells["GENEL_TOPLAM"].Value.ToString());
                drToplam += toplam;
                drIskonto += iskonto;
                drKdv += kdv;
                drGenelToplam += genel_toplam;
            }

            sumToplam.Text = drToplam.ToString("N2");
            sumIskonto.Text = drIskonto.ToString("N2");
            sumKdv.Text = drKdv.ToString("N2");
            sumGenelToplam.Text = drGenelToplam.ToString("N2");

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }

        private void dataTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        public void getFaturaIcerik(int id)
        {
            string COLS = "STOK_KARTI_V2.STOK_KODU,STOK_KARTI_V2.BARKOD_1,STOK_KARTI_V2.STOK_ADI,ALIS_FATURA_URUNLER.ACIKLAMA,STOK_KARTI_V2.YAZAR,STOK_KARTI_V2.YAYINEVI,ALIS_FATURA_URUNLER.MIKTAR,ALIS_FATURA_URUNLER.BIRIM_FIYAT,ALIS_FATURA_URUNLER.ISKONTO,ALIS_FATURA_URUNLER.KDV_ORANI,ALIS_FATURA_URUNLER.TOPLAM";

            //dataIcerik.DataSource = helper.getDataTable("SELECT * FROM SATIS_FATURA_URUNLER INNER JOIN STOK_KARTI_V2 ON SATIS_FATURA_URUNLER.URUN_ID=STOK_KART_V2.ID WHERE SATIS_FATURA_URUNLER.SATIS_FATURA_ID=" + id + "");
            this.Invoke((MethodInvoker)delegate
            {
                dataIcerik.DataSource = helper.getDataTable("SELECT " + COLS + " FROM ALIS_FATURA_URUNLER INNER JOIN STOK_KARTI_V2 ON ALIS_FATURA_URUNLER.URUN_ID=STOK_KARTI_V2.ID WHERE ALIS_FATURA_URUNLER.ALIS_FATURA_ID=" + id + "");
            });
        }

        private void dataIcerik_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataIcerik_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataIcerik);

            styleHelper.dataGridColWidth(dataIcerik, dataIcerik.Tag.ToString());

           
            dataIcerik.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

            Thread thread = new Thread(new ThreadStart(threadProcess));
            thread.Start();


        }
        public void threadProcess()
        {
            try
            {
                getFaturaIcerik(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            }
            catch (Exception x)
            {

            }
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
