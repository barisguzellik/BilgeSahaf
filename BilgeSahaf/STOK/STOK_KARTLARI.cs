using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BilgeSahaf.STOK
{
    public partial class STOK_KARTLARI : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public STOK_KARTLARI()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,STOK_KODU,STOK_ADI,YAZAR,YAYINEVI,GRUBU,BIRIM,BARKOD_1,FIYAT_1";

        private void STOK_KARTLARI_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "StokGrid1";
            dataHareketler.Tag = "StokGrid2";

            styleHelper.dataGridStyle(dataHareketler);
            styleHelper.dataGridStyle(dataGridView1);
            //getDefault();

            styleHelper.dataGridColWidth(dataHareketler, dataHareketler.Tag.ToString());

            Thread thread = new Thread(new ThreadStart(getDefault));
            thread.Start();

            this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);

            
            dataHareketler.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);

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
            //DataTable countDt = helper.getDataTable("SELECT count(*) from VIEW_STOK_KARTLARI");
            //int maxCount = int.Parse(countDt.Rows[0][0].ToString());

            this.Invoke((MethodInvoker)delegate
            {
                this.Cursor = Cursors.WaitCursor;
                dataGridView1.DataSource = helper.getDataTable("SELECT * FROM VIEW_STOK_KARTLARI");
                this.Cursor = Cursors.Default;
            });

        }

        public void searchProcess2()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT*FROM FUNC_STOK_KARTLARI_WITH_LIKE(N'" + toolStripTextBox1.Text + "')");
        }


        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchProcess2();

        }
        public void searchProcess()
        {
            string query = "1=1 ";
            //string[] likeColumns = helper.getColumnsNames("STOK_KARTI_V2");
            string[] likeColumns =
            {
                "STOK_KODU",
                "STOK_ADI",
                "YAZAR",
                "YAYINEVI",
                "BARKOD_1",
                "BARKOD_2",
                "BARKOD_3"
            };
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


            DataTable dt = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM STOK_KARTI_V2 WHERE " + query);
            /*dt.Columns.Add("GIREN", typeof(int));
            dt.Columns.Add("CIKAN", typeof(int));
            dt.Columns.Add("KALAN", typeof(int));

            foreach (DataRow dr in dt.Rows)
            {
                dr["GIREN"] = commonClass.getCalculateGiris(int.Parse(dr[0].ToString()));
                dr["CIKAN"] = commonClass.getCalculateCikis(int.Parse(dr[0].ToString()));
                dr["KALAN"] = int.Parse(dr["GIREN"].ToString()) - int.Parse(dr["CIKAN"].ToString());
            }*/

            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //toolStripTextBox1.Focus();

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        CommonClass commonClass = new CommonClass();
        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            STOK.YENI_STOK_KARTI frm = new STOK.YENI_STOK_KARTI();
            commonClass.openFormOnForm(frm);
            //getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            STOK.STOK_KARTI_DUZENLE frm = new STOK.STOK_KARTI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            frm.ShowDialog();
            //getDefault();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {




            /*try
            {
                getAlinanSiparisler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getVerilenSiparisler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getSatisFaturalari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getAlisFaturalari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getStokCikislari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getStokGirisleri(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {

            }*/
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            try
            {
                getTumHareketler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                
            }
            catch
            {

            }
        }
        public void getSatisFaturalari(string urunID)
        {
            string COLS = "SATIS_FATURALARI_V2.ID, SATIS_FATURALARI_V2.CARI_UNVANI,SATIS_FATURA_URUNLER.MIKTAR,SATIS_FATURA_URUNLER.BIRIM_FIYAT,SATIS_FATURA_URUNLER.KDV_ORANI,SATIS_FATURA_URUNLER.TOPLAM,SATIS_FATURALARI_V2.BELGE_NUMARASI,SATIS_FATURALARI_V2.TARIH,SATIS_FATURALARI_V2.EKLENME_TARIHI";
            //dataSatisFaturalari.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM STOK_KARTI_V2 INNER JOIN SATIS_FATURA_URUNLER ON STOK_KARTI_V2.ID=SATIS_FATURA_URUNLER.URUN_ID INNER JOIN SATIS_FATURALARI_V2 ON SATIS_FATURALARI_V2.ID=SATIS_FATURA_URUNLER.SATIS_FATURA_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY SATIS_FATURALARI_V2.ID DESC ");
        }
        public void getAlisFaturalari(string urunID)
        {
            string COLS = "ALIS_FATURALARI_V2.ID, ALIS_FATURALARI_V2.CARI_UNVANI,ALIS_FATURA_URUNLER.MIKTAR,ALIS_FATURA_URUNLER.BIRIM_FIYAT,ALIS_FATURA_URUNLER.KDV_ORANI,ALIS_FATURA_URUNLER.TOPLAM,ALIS_FATURALARI_V2.BELGE_NUMARASI,ALIS_FATURALARI_V2.TARIH,ALIS_FATURALARI_V2.EKLENME_TARIHI";
            //dataAlisFaturalari.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM STOK_KARTI_V2 INNER JOIN ALIS_FATURA_URUNLER ON STOK_KARTI_V2.ID=ALIS_FATURA_URUNLER.URUN_ID INNER JOIN ALIS_FATURALARI_V2 ON ALIS_FATURALARI_V2.ID=ALIS_FATURA_URUNLER.ALIS_FATURA_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY ALIS_FATURALARI_V2.ID DESC ");
        }
        public void getAlinanSiparisler(string urunID)
        {

            string COLS = "ALINAN_SIPARISLER_V2.ID,STOK_KODU,STOK_ADI, MIKTAR,TARIH,AD,TELEFON,EKLENME_TARIHI";
            //dataAlinanSiparisler.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM STOK_KARTI_V2  INNER JOIN ALINAN_SIPARIS_URUNLER ON STOK_KARTI_V2.ID=ALINAN_SIPARIS_URUNLER.STOK_ID INNER JOIN ALINAN_SIPARISLER_V2 ON ALINAN_SIPARISLER_V2.ID=ALINAN_SIPARIS_URUNLER.SIPARIS_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY ALINAN_SIPARISLER_V2.TARIH DESC;");

        }
        public void getVerilenSiparisler(string urunID)
        {

            string COLS = "VERILEN_SIPARISLER_V2.ID,STOK_KODU,STOK_ADI, MIKTAR,TARIH,AD,TELEFON,EKLENME_TARIHI";
            //dataVerilenSiparisler.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM STOK_KARTI_V2  INNER JOIN VERILEN_SIPARIS_URUNLER ON STOK_KARTI_V2.ID=VERILEN_SIPARIS_URUNLER.STOK_ID INNER JOIN VERILEN_SIPARISLER_V2 ON VERILEN_SIPARISLER_V2.ID=VERILEN_SIPARIS_URUNLER.SIPARIS_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY VERILEN_SIPARISLER_V2.TARIH DESC;");

        }

        public void getStokGirisleri(string urunID)
        {
            string COLS = "STOK_GIRISLERI_V2.ID,CARI_KARTLAR_V2.UNVANI,STOK_GIRIS_URUNLER.MIKTAR,STOK_GIRISLERI_V2.BELGE_NUMARASI,STOK_GIRISLERI_V2.TARIH,STOK_GIRISLERI_V2.EKLENME_TARIHI ";
            //dataStokGiris.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2  INNER JOIN STOK_GIRISLERI_V2 ON CARI_KARTLAR_V2.ID=STOK_GIRISLERI_V2.CARI INNER JOIN STOK_GIRIS_URUNLER ON STOK_GIRIS_URUNLER.STOK_GIRIS_ID=STOK_GIRISLERI_V2.ID WHERE STOK_GIRIS_URUNLER.URUN_ID=" + urunID + " ORDER BY STOK_GIRISLERI_V2.ID DESC ");

        }

        public void getStokCikislari(string urunID)
        {
            string COLS = "STOK_CIKISLARI_V2.ID,CARI_KARTLAR_V2.UNVANI,STOK_CIKIS_URUNLER.MIKTAR,STOK_CIKISLARI_V2.BELGE_NUMARASI,STOK_CIKISLARI_V2.TARIH,STOK_CIKISLARI_V2.EKLENME_TARIHI ";
            //dataStokCikis.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2  INNER JOIN STOK_CIKISLARI_V2 ON CARI_KARTLAR_V2.ID=STOK_CIKISLARI_V2.CARI INNER JOIN STOK_CIKIS_URUNLER ON STOK_CIKIS_URUNLER.STOK_CIKIS_ID=STOK_CIKISLARI_V2.ID WHERE STOK_CIKIS_URUNLER.URUN_ID=" + urunID + " ORDER BY STOK_CIKISLARI_V2.ID DESC ");
        }

        private void dataAlinanSiparisler_DoubleClick(object sender, EventArgs e)
        {
            SIPARIS.ALINAN_SIPARIS_DUZENLE frm = new SIPARIS.ALINAN_SIPARIS_DUZENLE();
            //frm.ITEM_ID = dataAlinanSiparisler.SelectedRows[0].Cells[0].Value.ToString();
            frm.ShowDialog();
            getAlinanSiparisler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataVerilenSiparisler_DoubleClick(object sender, EventArgs e)
        {
            SIPARIS.VERILEN_SIPARIS_DUZENLE frm = new SIPARIS.VERILEN_SIPARIS_DUZENLE();
            //frm.ITEM_ID = dataVerilenSiparisler.SelectedRows[0].Cells[0].Value.ToString();
            frm.ShowDialog();
            getVerilenSiparisler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataSatisFaturalari_DoubleClick(object sender, EventArgs e)
        {
            FATURA.SATIS_FATURASI_DUZENLE frm = new FATURA.SATIS_FATURASI_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataSatisFaturalari.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getSatisFaturalari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataAlisFaturalari_DoubleClick(object sender, EventArgs e)
        {
            FATURA.ALIS_FATURASI_DUZENLE frm = new FATURA.ALIS_FATURASI_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataAlisFaturalari.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getAlisFaturalari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        public void insertExtendedColumns()
        {


        }

        private void dataStokCikis_DoubleClick(object sender, EventArgs e)
        {
            FATURA.STOK_CIKISI_URUNLER frm = new FATURA.STOK_CIKISI_URUNLER();
            //frm.ITEM_ID = int.Parse(dataStokCikis.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getStokCikislari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataStokGiris_DoubleClick(object sender, EventArgs e)
        {
            FATURA.STOK_GIRISI_DUZENLE frm = new FATURA.STOK_GIRISI_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataStokGiris.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getStokGirisleri(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void sTOKENVANTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_ENVANTER frm = new RAPOR.STOK.RAPOR_STOK_ENVANTER();
            frm.STOK_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
        }

        private void sTOKMALİYETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_MALIYET frm = new RAPOR.STOK.RAPOR_STOK_MALIYET();
            frm.STOK_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
        }

        private void sTOKKARDURUMUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_KAR_DURUMU frm = new RAPOR.STOK.RAPOR_STOK_KAR_DURUMU();
            frm.STOK_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
        }

        private void tAHMİNİENVANTERKAZANÇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_TAHMINI_ENVANTER_KAZANC frm = new RAPOR.STOK.RAPOR_TAHMINI_ENVANTER_KAZANC();
            frm.STOK_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
        }

        private void sTOKHAREKETLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            STOK.STOK_KARTI_DUZENLE frm = new STOK.STOK_KARTI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            frm.ShowDialog();
            //getDefault();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridReName(dataGridView1);
            styleHelper.dataGridFormatNumber(dataGridView1);

            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);
        }

        private void dataAlisFaturalari_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataAlisFaturalari_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataAlisFaturalari);
        }

        private void dataSatisFaturalari_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataSatisFaturalari);
        }

        public void getTumHareketler(string urunID)
        {
            this.Cursor = Cursors.WaitCursor;

            dataHareketler.Rows.Clear();

            DataTable dtSatisFaturalari = helper.getDataTable("SELECT * FROM STOK_KARTI_V2 INNER JOIN SATIS_FATURA_URUNLER ON STOK_KARTI_V2.ID=SATIS_FATURA_URUNLER.URUN_ID INNER JOIN SATIS_FATURALARI_V2 ON SATIS_FATURALARI_V2.ID=SATIS_FATURA_URUNLER.SATIS_FATURA_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY SATIS_FATURALARI_V2.ID DESC ");
            foreach (DataRow dr in dtSatisFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Satış Faturası";
                drRows.Cells[1].Value =Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[3].Value = dr["CARI_UNVANI"].ToString();
                drRows.Cells[4].Value = "0";
                drRows.Cells[5].Value = dr["MIKTAR"].ToString();
                drRows.Cells[6].Value = Convert.ToDouble(dr["BIRIM_FIYAT"].ToString()).ToString("N2");
                drRows.Cells[7].Value = Convert.ToDouble(dr["ISKONTO"].ToString()).ToString("N2");
                drRows.Cells[8].Value = dr["KDV_ORANI"].ToString();
                drRows.Cells[9].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID2"].ToString();
                drRows.Cells[12].Value = "SATIS_FATURALARI";
                drRows.Cells[13].Value = dr["ACIKLAMA1"].ToString();
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtAlisFaturalari = helper.getDataTable("SELECT * FROM STOK_KARTI_V2 INNER JOIN ALIS_FATURA_URUNLER ON STOK_KARTI_V2.ID=ALIS_FATURA_URUNLER.URUN_ID INNER JOIN ALIS_FATURALARI_V2 ON ALIS_FATURALARI_V2.ID=ALIS_FATURA_URUNLER.ALIS_FATURA_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY ALIS_FATURALARI_V2.ID DESC ");
            foreach (DataRow dr in dtAlisFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Alış Faturası";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[3].Value = dr["CARI_UNVANI"].ToString();
                drRows.Cells[4].Value = dr["MIKTAR"].ToString();
                drRows.Cells[5].Value = "0";
                drRows.Cells[6].Value = Convert.ToDouble(dr["BIRIM_FIYAT"].ToString()).ToString("N2");
                drRows.Cells[7].Value = Convert.ToDouble(dr["ISKONTO"].ToString()).ToString("N2");
                drRows.Cells[8].Value = dr["KDV_ORANI"].ToString();
                drRows.Cells[9].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID2"].ToString();
                drRows.Cells[12].Value = "ALIS_FATURALARI";
                drRows.Cells[13].Value = dr["ACIKLAMA1"].ToString();
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtAlisIadeFaturalari = helper.getDataTable("SELECT * FROM STOK_KARTI_V2 INNER JOIN ALIS_IADE_FATURA_URUNLER ON STOK_KARTI_V2.ID=ALIS_IADE_FATURA_URUNLER.URUN_ID INNER JOIN ALIS_IADE_FATURALARI_V2 ON ALIS_IADE_FATURALARI_V2.ID=ALIS_IADE_FATURA_URUNLER.ALIS_FATURA_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY ALIS_IADE_FATURALARI_V2.ID DESC ");
            foreach (DataRow dr in dtAlisIadeFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Alış İade Faturası";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[3].Value = dr["CARI_UNVANI"].ToString();
                drRows.Cells[4].Value = "0";
                drRows.Cells[5].Value = dr["MIKTAR"].ToString();
                drRows.Cells[6].Value = Convert.ToDouble(dr["BIRIM_FIYAT"].ToString()).ToString("N2");
                drRows.Cells[7].Value = "0.00";
                drRows.Cells[8].Value = dr["KDV_ORANI"].ToString();
                drRows.Cells[9].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID2"].ToString();
                drRows.Cells[12].Value = "ALIS_IADE_FATURALARI";
                drRows.Cells[13].Value = dr["ACIKLAMA1"].ToString();
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtSatisIadeFaturalari = helper.getDataTable("SELECT * FROM STOK_KARTI_V2 INNER JOIN SATIS_IADE_FATURA_URUNLER ON STOK_KARTI_V2.ID=SATIS_IADE_FATURA_URUNLER.URUN_ID INNER JOIN SATIS_IADE_FATURALARI_V2 ON SATIS_IADE_FATURALARI_V2.ID=SATIS_IADE_FATURA_URUNLER.SATIS_FATURA_ID WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY SATIS_IADE_FATURALARI_V2.ID DESC ");
            foreach (DataRow dr in dtSatisIadeFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Satış İade Faturası";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[3].Value = dr["CARI_UNVANI"].ToString();
                drRows.Cells[4].Value = dr["MIKTAR"].ToString();
                drRows.Cells[5].Value = "0";
                drRows.Cells[6].Value = Convert.ToDouble(dr["BIRIM_FIYAT"].ToString()).ToString("N2");
                drRows.Cells[7].Value = Convert.ToDouble(dr["ISKONTO"].ToString()).ToString("N2");
                drRows.Cells[8].Value = dr["KDV_ORANI"].ToString();
                drRows.Cells[9].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID2"].ToString();
                drRows.Cells[12].Value = "SATIS_IADE_FATURALARI";
                drRows.Cells[13].Value = dr["ACIKLAMA1"].ToString();
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtAlinanSiparisler = helper.getDataTable("SELECT * FROM STOK_KARTI_V2  INNER JOIN ALINAN_SIPARIS_URUNLER ON STOK_KARTI_V2.ID=ALINAN_SIPARIS_URUNLER.STOK_ID INNER JOIN ALINAN_SIPARISLER_V2 ON ALINAN_SIPARISLER_V2.ID=ALINAN_SIPARIS_URUNLER.SIPARIS_ID INNER JOIN CARI_KARTLAR_V2 ON CARI_KARTLAR_V2.ID=ALINAN_SIPARISLER_V2.CARI WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY ALINAN_SIPARISLER_V2.TARIH DESC;");
            foreach (DataRow dr in dtAlinanSiparisler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Alınan Sipariş";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[3].Value = dr["UNVANI"].ToString();
                drRows.Cells[4].Value = "0";
                drRows.Cells[5].Value = dr["MIKTAR"].ToString();
                drRows.Cells[6].Value = "0.00";
                drRows.Cells[7].Value = "0.00";
                drRows.Cells[8].Value = "0";
                drRows.Cells[9].Value = "0.00";
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID2"].ToString();
                drRows.Cells[12].Value = "ALINAN_SIPARISLER";
                drRows.Cells[13].Value = dr["ACIKLAMA"].ToString();
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtVerilenSiparisler = helper.getDataTable("SELECT * FROM STOK_KARTI_V2  INNER JOIN VERILEN_SIPARIS_URUNLER ON STOK_KARTI_V2.ID=VERILEN_SIPARIS_URUNLER.STOK_ID INNER JOIN VERILEN_SIPARISLER_V2 ON VERILEN_SIPARISLER_V2.ID=VERILEN_SIPARIS_URUNLER.SIPARIS_ID INNER JOIN CARI_KARTLAR_V2 ON CARI_KARTLAR_V2.ID=VERILEN_SIPARISLER_V2.CARI WHERE STOK_KARTI_V2.ID=" + urunID + " ORDER BY VERILEN_SIPARISLER_V2.TARIH DESC;");
            foreach (DataRow dr in dtVerilenSiparisler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Verilen Sipariş";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[3].Value = dr["UNVANI"].ToString();
                drRows.Cells[4].Value = dr["MIKTAR"].ToString();
                drRows.Cells[5].Value = "0";
                drRows.Cells[6].Value = "0.00";
                drRows.Cells[7].Value = "0.00";
                drRows.Cells[8].Value = "0";
                drRows.Cells[9].Value = "0.00";
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID2"].ToString();
                drRows.Cells[12].Value = "VERILEN_SIPARISLER";
                drRows.Cells[13].Value = dr["ACIKLAMA"].ToString();
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtStokGirisleri = helper.getDataTable("SELECT * FROM CARI_KARTLAR_V2  INNER JOIN STOK_GIRISLERI_V2 ON CARI_KARTLAR_V2.ID=STOK_GIRISLERI_V2.CARI INNER JOIN STOK_GIRIS_URUNLER ON STOK_GIRIS_URUNLER.STOK_GIRIS_ID=STOK_GIRISLERI_V2.ID WHERE STOK_GIRIS_URUNLER.URUN_ID=" + urunID + " ORDER BY STOK_GIRISLERI_V2.ID DESC ");
            foreach (DataRow dr in dtStokGirisleri.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Stok Girişi";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[3].Value = dr["UNVANI"].ToString();
                drRows.Cells[4].Value = dr["MIKTAR"].ToString();
                drRows.Cells[5].Value = "0";
                drRows.Cells[6].Value = "0.00";
                drRows.Cells[7].Value = "0.00";
                drRows.Cells[8].Value = "0";
                drRows.Cells[9].Value = "0.00";
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID1"].ToString();
                drRows.Cells[12].Value = "STOK_GIRISLERI";
                drRows.Cells[13].Value = "";
                dataHareketler.Rows.Add(drRows);
            }

            DataTable dtStokCikislari = helper.getDataTable("SELECT * FROM CARI_KARTLAR_V2  INNER JOIN STOK_CIKISLARI_V2 ON CARI_KARTLAR_V2.ID=STOK_CIKISLARI_V2.CARI INNER JOIN STOK_CIKIS_URUNLER ON STOK_CIKIS_URUNLER.STOK_CIKIS_ID=STOK_CIKISLARI_V2.ID WHERE STOK_CIKIS_URUNLER.URUN_ID=" + urunID + " ORDER BY STOK_CIKISLARI_V2.ID DESC ");
            foreach (DataRow dr in dtStokCikislari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataHareketler);
                drRows.Cells[0].Value = "Stok Çıkışı";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[3].Value = dr["UNVANI"].ToString();
                drRows.Cells[4].Value = "0";
                drRows.Cells[5].Value = dr["MIKTAR"].ToString();
                drRows.Cells[6].Value = "0.00";
                drRows.Cells[7].Value = "0.00";
                drRows.Cells[8].Value = "0";
                drRows.Cells[9].Value = "0.00";
                drRows.Cells[10].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[11].Value = dr["ID1"].ToString();
                drRows.Cells[12].Value = "STOK_CIKISLARI";
                drRows.Cells[13].Value = "";
                dataHareketler.Rows.Add(drRows);
            }

            dataHareketler.Sort(EKLENME_TARIHI, ListSortDirection.Descending);

            this.Cursor = Cursors.Default;
        }

        private void dataHareketler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataHareketler);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            getDefault();

        }

        private void dataHareketler_DoubleClick(object sender, EventArgs e)
        {
            var hareket_tipi = dataHareketler.SelectedRows[0].Cells["HAREKET_TIPI"].Value.ToString();
            var hareket_id = dataHareketler.SelectedRows[0].Cells["HAREKET_ID"].Value.ToString();

            Form frm = new Form();
            if (hareket_tipi == "SATIS_FATURALARI")
            {
                FATURA.SATIS_FATURASI_DUZENLE FRM2 = new FATURA.SATIS_FATURASI_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ALIS_FATURALARI")
            {
                FATURA.ALIS_FATURASI_DUZENLE FRM2 = new FATURA.ALIS_FATURASI_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "SATIS_IADE_FATURALARI")
            {
                FATURA_IADE.SATIS_IADE_FATURASI_DUZENLE FRM2 = new FATURA_IADE.SATIS_IADE_FATURASI_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ALIS_IADE_FATURALARI")
            {
                FATURA_IADE.ALIS_IADE_FATURASI_DUZENLE FRM2 = new FATURA_IADE.ALIS_IADE_FATURASI_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ALINAN_SIPARISLER")
            {
                SIPARIS.ALINAN_SIPARIS_DUZENLE FRM2 = new SIPARIS.ALINAN_SIPARIS_DUZENLE();
                FRM2.ITEM_ID = hareket_id;
                frm = FRM2;
            }
            else if (hareket_tipi == "VERILEN_SIPARISLER")
            {
                SIPARIS.VERILEN_SIPARIS_DUZENLE FRM2 = new SIPARIS.VERILEN_SIPARIS_DUZENLE();
                FRM2.ITEM_ID = hareket_id;
                frm = FRM2;
            }
            else if (hareket_tipi == "STOK_GIRISLERI")
            {
                FATURA.STOK_GIRISI_DUZENLE FRM2 = new FATURA.STOK_GIRISI_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "STOK_CIKISLARI")
            {
                FATURA.STOK_CIKISI_URUNLER FRM2 = new FATURA.STOK_CIKISI_URUNLER();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }


            frm.ShowDialog();
        }

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                toolStripTextBox1.Text += e.KeyChar;
            }
            if (e.KeyChar == (Char)Keys.Space)
            {
                toolStripTextBox1.Text += " ";
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                toolStripTextBox1.Text = "";
            }

            if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                if (toolStripTextBox1.Text.Length > 0)
                {
                    toolStripTextBox1.Text = toolStripTextBox1.Text.Remove(toolStripTextBox1.Text.Length - 1, 1);
                }

            }
            if (e.KeyChar == (Char)Keys.Enter)
            {
                searchProcess2();

            }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                searchProcess2();

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void kARTIKOPYALAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            STOK.YENI_STOK_KARTI frm = new YENI_STOK_KARTI();
            frm.copyCardID= int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();

        }
    }
}
