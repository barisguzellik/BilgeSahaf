using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.KASA
{
    public partial class KASALAR : Form
    {
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public KASALAR()
        {
            InitializeComponent();
        }
        public string COLS = "ID,KASA_ADI,ACIKLAMA,ACILIS_TARIHI";
        private void KASALAR_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "KasaGrid1";
            dataTumHareketler.Tag = "KasaGrid2";

            styleHelper.dataGridStyle(dataTumHareketler);
            styleHelper.dataGridStyle(dataGridView1);

            styleHelper.dataGridColWidth(dataTumHareketler, dataTumHareketler.Tag.ToString());

            getDefault();
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);

           
            dataTumHareketler.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);

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
            dataGridView1.DataSource = helper.getDataTable("SELECT * FROM VIEW_KASALAR");
        }

        private void yENİKASAEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KASA.YENI_KASA_EKLE frm = new KASA.YENI_KASA_EKLE();
            frm.ShowDialog();
            getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            KASA.KASA_DUZENLE frm = new KASA.KASA_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getDefault();
        }
        public void getTahsilatlar()
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string COLS = "TAHSILATLAR_V2.ID,CARI_KARTLAR_V2.UNVANI,TAHSILATLAR_V2.TARIH,TAHSILATLAR_V2.TUTAR,TAHSILATLAR_V2.EKLENME_TARIHI,SATIS_FATURALARI_V2.BELGE_NUMARASI,TAHSILATLAR_V2.ACIKLAMA";
            //dataTahsilat.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 INNER JOIN SATIS_FATURALARI_V2 ON CARI_KARTLAR_V2.ID=SATIS_FATURALARI_V2.CARI INNER JOIN TAHSILATLAR_V2 ON TAHSILATLAR_V2.SATIS_FATURA_ID=SATIS_FATURALARI_V2.ID WHERE TAHSILATLAR_V2.TARIH='"+dateFormat+"'");
        }

        public void getSiparisTahsilatlar()
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string COLS = "SIPARIS_TAHSILATLAR_V2.ID,CARI_KARTLAR_V2.UNVANI,SIPARIS_TAHSILATLAR_V2.TARIH,SIPARIS_TAHSILATLAR_V2.TUTAR,SIPARIS_TAHSILATLAR_V2.EKLENME_TARIHI,SIPARIS_TAHSILATLAR_V2.ACIKLAMA";
            //dataSiparisTahsilat.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 INNER JOIN ALINAN_SIPARISLER_V2 ON CARI_KARTLAR_V2.ID=ALINAN_SIPARISLER_V2.CARI INNER JOIN SIPARIS_TAHSILATLAR_V2 ON SIPARIS_TAHSILATLAR_V2.SIPARIS_ID=ALINAN_SIPARISLER_V2.ID WHERE SIPARIS_TAHSILATLAR_V2.TARIH='" + dateFormat + "'");
        }

        public void getOdemeler()
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string COLS = "ODEMELER_V2.ID,CARI_KARTLAR_V2.UNVANI,ODEMELER_V2.TARIH,ODEMELER_V2.TUTAR,ODEMELER_V2.EKLENME_TARIHI,ALIS_FATURALARI_V2.BELGE_NUMARASI";
            //dataOdeme.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 INNER JOIN ALIS_FATURALARI_V2 ON CARI_KARTLAR_V2.ID=ALIS_FATURALARI_V2.CARI INNER JOIN ODEMELER_V2 ON ODEMELER_V2.ALIS_FATURA_ID=ALIS_FATURALARI_V2.ID WHERE ODEMELER_V2.TARIH='" + dateFormat + "'");
        }

        public void getGiderler()
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string COLS = "ID,TARIH,ACIKLAMA,TUTAR,EKLENME_TARIHI";
            //dataGider.DataSource = helper.getDataTable("SELECT " + COLS + " FROM GIDERLER_V2 WHERE TARIH='"+dateFormat+"' ORDER BY ID DESC");
        }

        public void getGelirler()
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string COLS = "ID,TARIH,ACIKLAMA,TUTAR,EKLENME_TARIHI";
            //dataGelir.DataSource = helper.getDataTable("SELECT " + COLS + " FROM GELIRLER_V2 WHERE TARIH='" + dateFormat + "' ORDER BY ID DESC");
        }

        public void getTumHareketler(int id)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            DateTime dtTime2 = Convert.ToDateTime(txtTarih2.Text);
            string dateFormat2 = dtTime2.Year + "-" + dtTime2.Month + "-" + dtTime2.Day;

            dataTumHareketler.Rows.Clear();

            DataTable dtTahsilatlar = helper.getDataTable("SELECT * FROM TAHSILATLAR_V2 INNER JOIN CARI_KARTLAR_V2 ON TAHSILATLAR_V2.CARI=CARI_KARTLAR_V2.ID WHERE KASA="+id+ " AND TAHSILATLAR_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");

            foreach (DataRow dr in dtTahsilatlar.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Tahsilat";
                drRows.Cells[1].Value =Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["UNVANI"].ToString();
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value =Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[5].Value = "0.00";
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "TAHSILATLAR";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtOdemeler = helper.getDataTable("SELECT * FROM ODEMELER_V2 INNER JOIN CARI_KARTLAR_V2 ON ODEMELER_V2.CARI=CARI_KARTLAR_V2.ID WHERE KASA=" + id + " AND ODEMELER_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtOdemeler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Ödeme";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["UNVANI"].ToString();
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = "0.00";
                drRows.Cells[5].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "ODEMELER";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtGelirler = helper.getDataTable("SELECT * FROM GELIRLER_V2 WHERE KASA=" + id + " AND GELIRLER_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtGelirler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Gelir";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "KASA";
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[5].Value = "0.00";
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "GELIRLER";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtGiderler = helper.getDataTable("SELECT * FROM GIDERLER_V2 WHERE KASA=" + id + " AND GIDERLER_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtGiderler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Gider";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "KASA";
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = "0.00";
                drRows.Cells[5].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "GIDERLER";
                dataTumHareketler.Rows.Add(drRows);
            }

           

            dataTumHareketler.Sort(EKLENME_TARIHI, ListSortDirection.Descending);

            double DrGiris = 0;
            double DrCikis = 0;
            double DrBakiye = 0;
            foreach (DataGridViewRow dr in dataTumHareketler.Rows)
            {
                double giris = double.Parse(dr.Cells[4].Value.ToString());
                double cikis = double.Parse(dr.Cells[5].Value.ToString());
                double bakiye = giris - cikis;
                DrGiris += giris;
                DrCikis += cikis;
                DrBakiye += bakiye;
            }
            DataGridViewRow drSumRows = new DataGridViewRow();
            drSumRows.DefaultCellStyle.BackColor = Color.NavajoWhite;
            drSumRows.CreateCells(dataTumHareketler);
            drSumRows.Cells[4].Value = DrGiris.ToString("N2"); ;
            drSumRows.Cells[5].Value = DrCikis.ToString("N2"); ;
            dataTumHareketler.Rows.Add(drSumRows);

            this.Cursor = Cursors.Default;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTarih_ValueChanged(object sender, EventArgs e)
        {
            getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));

        }

        private void dataTahsilat_DoubleClick(object sender, EventArgs e)
        {
            FATURA.TAHSILAT_DUZENLE frm = new FATURA.TAHSILAT_DUZENLE();
            //frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //frm.ITEM_ID = int.Parse(dataTahsilat.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getTahsilatlar();
        }

        private void dataOdeme_DoubleClick(object sender, EventArgs e)
        {
            FATURA.ODEME_DUZENLE frm = new FATURA.ODEME_DUZENLE();
            //frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //frm.ITEM_ID = int.Parse(dataOdeme.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getOdemeler();
        }

        private void yENİGİDEREKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KASA.YENI_GIDER_EKLE frm = new KASA.YENI_GIDER_EKLE();
            frm.ShowDialog();
            getGiderler();
        }

        private void yENİGELİREKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KASA.YENI_GELIR_EKLE frm = new KASA.YENI_GELIR_EKLE();
            frm.ShowDialog();
            getGelirler();
        }

        private void dataGelir_DoubleClick(object sender, EventArgs e)
        {
            KASA.GELIR_DUZENLE frm = new KASA.GELIR_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataGelir.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getGelirler();
        }

        private void dataGider_DoubleClick(object sender, EventArgs e)
        {
            KASA.GIDER_DUZENLE frm = new KASA.GIDER_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataGider.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getGiderler();
        }

        private void dataSiparisTahsilat_DoubleClick(object sender, EventArgs e)
        {
            SIPARIS.TAHSILAT_DUZENLE frm = new SIPARIS.TAHSILAT_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataSiparisTahsilat.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getSiparisTahsilatlar();
        }

        private void dataTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataTahsilat);
        }

        private void dataOdeme_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataOdeme);
        }

        private void dataGider_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataGider);
        }

        private void dataGelir_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataGelir);
        }

        private void dataSiparisTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataSiparisTahsilat);
        }

        private void dataTumHareketler_DoubleClick(object sender, EventArgs e)
        {
            var hareket_tipi = dataTumHareketler.SelectedRows[0].Cells["HAREKET_TIPI"].Value.ToString();
            var hareket_id = dataTumHareketler.SelectedRows[0].Cells["HAREKET_ID"].Value.ToString();

            Form frm = new Form();
            if (hareket_tipi == "TAHSILATLAR")
            {
                FATURA.TAHSILAT_DUZENLE FRM2 = new FATURA.TAHSILAT_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "ODEMELER")
            {
                FATURA.ODEME_DUZENLE FRM2 = new FATURA.ODEME_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "GELIRLER")
            {
                KASA.GELIR_DUZENLE FRM2 = new KASA.GELIR_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "GIDERLER")
            {
                KASA.GIDER_DUZENLE FRM2 = new KASA.GIDER_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "ODEMELER_IADE")
            {
                FATURA_IADE.IADE_ODEME_DUZENLE FRM2 = new FATURA_IADE.IADE_ODEME_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "TAHSILATLAR_IADE")
            {
                FATURA_IADE.IADE_TAHSILAT_DUZENLE FRM2 = new FATURA_IADE.IADE_TAHSILAT_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "SIPARIS_TAHSILATLAR")
            {
                SIPARIS.TAHSILAT_DUZENLE FRM2 = new SIPARIS.TAHSILAT_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "GELEN_HAVALE")
            {
                BANKA.GELEN_HAVALE_DUZENLE FRM2 = new BANKA.GELEN_HAVALE_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "GONDERILEN_HAVALE")
            {
                BANKA.GONDERILEN_HAVALE_DUZENLE FRM2 = new BANKA.GONDERILEN_HAVALE_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            frm.ShowDialog();
        }

        private void dataTumHareketler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataTumHareketler);
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataGridView1);

            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            double DrGiris = 0;
            double DrCikis = 0;
            double DrBakiye = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                double giris = double.Parse(dr.Cells["GİRİŞLER"].Value.ToString());
                double cikis = double.Parse(dr.Cells["ÇIKIŞLAR"].Value.ToString());
                double bakiye = giris - cikis;
                DrGiris += giris;
                DrCikis += cikis;
                DrBakiye += bakiye;
            }

            sumAlacak.Text = DrGiris.ToString("N2");
            sumBorc.Text = DrCikis.ToString("N2");
            sumBakiye.Text = DrBakiye.ToString("N2");

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            }
            catch { }
        }

        private void txtTarih2_ValueChanged(object sender, EventArgs e)
        {
            getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));

        }
    }
}
