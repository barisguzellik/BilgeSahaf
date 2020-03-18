using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BilgeSahaf.CARI
{
    public partial class CARI_KARTLAR : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public CARI_KARTLAR()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public string COLS = "ID,CARI_KODU,UNVANI,CARI_TURU";

        public DataTable reportSource;
        private void CARI_KARTLAR_Load(object sender, EventArgs e)
        {
            styleHelper.dataGridStyle(dataGridView2);
            styleHelper.dataGridStyle(dataGridView1);

            styleHelper.dataGridColWidth(dataGridView2, dataGridView2.Tag.ToString());
            dataGridView2.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);

            //getDefault();

            Thread thread = new Thread(new ThreadStart(getDefault));
            thread.Start();


            //backgroundWorker1.RunWorkerAsync();

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
            //dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2");

            //reportSource= helper.getDataTable("SELECT*FROM CARI_KARTLAR_V2");
            this.Invoke((MethodInvoker)delegate
            {
                this.Cursor = Cursors.WaitCursor;
                dataGridView1.DataSource = helper.getDataTable("SELECT*FROM VIEW_CARI_KARTLAR");
                this.Cursor = Cursors.Default;
            });
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            //searchProcess2();
        }
        public void searchProcess2()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT*FROM FUNC_CARI_KARTLAR_WITH_LIKE(N'" + toolStripTextBox1.Text + "')");
            //reportSource = helper.getDataTable("SELECT * FROM CARI_KARTLAR_V2 WHERE UNVANI LIKE N'%" + toolStripTextBox1.Text + "%'");
        }
        public void searchProcess()
        {
            string query = "1=1 ";
            //string[] likeColumns = helper.getColumnsNames("CARI_KARTLAR_V2");
            string[] likeColumns =
           {
                "CARI_KODU",
                "UNVANI",
                "TELEFON",
                "CEP_TELEFON",
                "YETKILI_KISI"
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 WHERE " + query);

        }

        CommonClass commonClass = new CommonClass();
        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CARI.YENI_CARI_KART frm = new CARI.YENI_CARI_KART();
            commonClass.openFormOnForm(frm);
            //getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CARI.CARI_KART_DUZENLE frm = new CARI.CARI_KART_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            frm.ShowDialog();
            //getDefault();
        }

        public void getSatisFaturalari(string cariID)
        {
            string COLS = "SATIS_FATURALARI_V2.ID,SATIS_FATURALARI_V2.TARIH,SATIS_FATURALARI_V2.BELGE_NUMARASI,SATIS_FATURALARI_V2.TOPLAM,SATIS_FATURALARI_V2.ISKONTO_TOPLAM,SATIS_FATURALARI_V2.KDV_TOPLAM,SATIS_FATURALARI_V2.GENEL_TOPLAM";
            //dataSatisFaturalari.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 INNER JOIN SATIS_FATURALARI_V2 ON CARI_KARTLAR_V2.ID=SATIS_FATURALARI_V2.CARI WHERE SATIS_FATURALARI_V2.CARI=" + cariID + " ORDER BY SATIS_FATURALARI_V2.ID DESC;");
        }
        public void getAlisFaturalari(string cariID)
        {
            string COLS = "ALIS_FATURALARI_V2.ID,ALIS_FATURALARI_V2.TARIH,ALIS_FATURALARI_V2.BELGE_NUMARASI,ALIS_FATURALARI_V2.TOPLAM,ALIS_FATURALARI_V2.ISKONTO_TOPLAM,ALIS_FATURALARI_V2.KDV_TOPLAM,ALIS_FATURALARI_V2.GENEL_TOPLAM";
            //dataAlisFaturalari.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 INNER JOIN ALIS_FATURALARI_V2 ON CARI_KARTLAR_V2.ID=ALIS_FATURALARI_V2.CARI WHERE ALIS_FATURALARI_V2.CARI=" + cariID + " ORDER BY ALIS_FATURALARI_V2.ID DESC; ");
        }

        public void getOdemeler(string cariID)
        {
            string COLS = "ODEMELER_V2.ID,ODEMELER_V2.TARIH,ODEMELER_V2.TUTAR,ODEMELER_V2.EKLENME_TARIHI";
            //dataOdeme.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM ODEMELER_V2 INNER JOIN ALIS_FATURALARI_V2 ON ODEMELER_V2.ALIS_FATURA_ID=ALIS_FATURALARI_V2.ID WHERE ALIS_FATURALARI_V2.CARI=" + cariID + " ORDER BY ODEMELER_V2.ID DESC");

        }
        public void getTahsilat(string cariID)
        {
            string COLS = "TAHSILATLAR_V2.ID,TAHSILATLAR_V2.TARIH,TAHSILATLAR_V2.TUTAR,TAHSILATLAR_V2.EKLENME_TARIHI,TAHSILATLAR_V2.ACIKLAMA";
            //dataTahsilat.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM TAHSILATLAR_V2 INNER JOIN SATIS_FATURALARI_V2 ON TAHSILATLAR_V2.SATIS_FATURA_ID=SATIS_FATURALARI_V2.ID WHERE SATIS_FATURALARI_V2.CARI=" + cariID + " ORDER BY TAHSILATLAR_V2.ID DESC");

        }

        public void getSiparisTahsilat(string cariID)
        {
            string COLS = "SIPARIS_TAHSILATLAR_V2.ID,SIPARIS_TAHSILATLAR_V2.TARIH,SIPARIS_TAHSILATLAR_V2.TUTAR,SIPARIS_TAHSILATLAR_V2.EKLENME_TARIHI,SIPARIS_TAHSILATLAR_V2.ACIKLAMA";
            //dataSiparisTahsilat.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM SIPARIS_TAHSILATLAR_V2 INNER JOIN ALINAN_SIPARISLER_V2 ON SIPARIS_TAHSILATLAR_V2.SIPARIS_ID=ALINAN_SIPARISLER_V2.ID WHERE ALINAN_SIPARISLER_V2.CARI=" + cariID + " ORDER BY SIPARIS_TAHSILATLAR_V2.ID DESC");

        }

        public void getAlinanCekler(string cariID)
        {
            string COLS = "ID,EVRAK_NUMARASI,BELGE_NUMARASI,TARIH,BELGE_TARIHI,ARA_TOPLAM,MASRAF,TOPLAM,EKLENME_TARIHI";
            //dataAlinanCekler.DataSource = helper.getDataTable("SELECT " + COLS + " FROM CEK_GIRIS_BORDROSU_V2 WHERE CARI=" + cariID + "");
        }

        public void getVerilenCekler(string cariID)
        {
            string COLS = "ID,EVRAK_NUMARASI,BELGE_NUMARASI,TARIH,BELGE_TARIHI,ARA_TOPLAM,MASRAF,TOPLAM,EKLENME_TARIHI";
            //dataVerilenCekler.DataSource = helper.getDataTable("SELECT " + COLS + " FROM CEK_CIKIS_BORDROSU_V2 WHERE CARI=" + cariID + "");
        }

        public void getAlinanSenetler(string cariID)
        {
            string COLS = "ID,EVRAK_NUMARASI,BELGE_NUMARASI,TARIH,BELGE_TARIHI,ARA_TOPLAM,MASRAF,TOPLAM,EKLENME_TARIHI";
            //dataAlinanSenetler.DataSource = helper.getDataTable("SELECT " + COLS + " FROM SENET_GIRIS_BORDROSU_V2 WHERE CARI=" + cariID + "");
        }

        public void getVerilenSenetler(string cariID)
        {
            string COLS = "ID,EVRAK_NUMARASI,BELGE_NUMARASI,TARIH,BELGE_TARIHI,ARA_TOPLAM,MASRAF,TOPLAM,EKLENME_TARIHI";
            //dataVerilenSenetler.DataSource = helper.getDataTable("SELECT " + COLS + " FROM SENET_CIKIS_BORDROSU_V2 WHERE CARI=" + cariID + "");
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                getTumHareketler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                //Thread thread = new Thread(() => getTumHareketler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                //thread.Start();

                /*getSatisFaturalari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getAlisFaturalari(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getOdemeler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getSiparisTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getAlinanCekler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getVerilenCekler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getAlinanSenetler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                getVerilenSenetler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                */
            }
            catch
            {

            }
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataTahsilat_DoubleClick(object sender, EventArgs e)
        {
            FATURA.TAHSILAT_DUZENLE frm = new FATURA.TAHSILAT_DUZENLE();
            //frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //frm.ITEM_ID = int.Parse(dataTahsilat.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataOdeme_DoubleClick(object sender, EventArgs e)
        {
            FATURA.ODEME_DUZENLE frm = new FATURA.ODEME_DUZENLE();
            //frm.FATURA_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //frm.ITEM_ID = int.Parse(dataOdeme.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getOdemeler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void cARİBAKİYEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.CARI.RAPOR_CARI_BAKIYE frm = new RAPOR.CARI.RAPOR_CARI_BAKIYE();
            frm.CARI_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
        }

        private void dÜZENLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CARI.CARI_KART_DUZENLE frm = new CARI.CARI_KART_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            frm.ShowDialog();
            getDefault();
        }

        private void dataSiparisTahsilat_DoubleClick(object sender, EventArgs e)
        {
            SIPARIS.TAHSILAT_DUZENLE frm = new SIPARIS.TAHSILAT_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataSiparisTahsilat.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getSiparisTahsilat(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataAlinanCekler_DoubleClick(object sender, EventArgs e)
        {
            CEK_SENET.CEK_GIRIS_BORDROSU_DUZENLE frm = new CEK_SENET.CEK_GIRIS_BORDROSU_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataAlinanCekler.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getAlinanCekler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataVerilenCekler_DoubleClick(object sender, EventArgs e)
        {
            CEK_SENET.CEK_CIKIS_BORDROSU_DUZENLE frm = new CEK_SENET.CEK_CIKIS_BORDROSU_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataVerilenCekler.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getVerilenCekler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataAlinanSenetler_DoubleClick(object sender, EventArgs e)
        {
            CEK_SENET.SENET_GIRIS_BORDROSU_DUZENLE frm = new CEK_SENET.SENET_GIRIS_BORDROSU_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataAlinanSenetler.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getAlinanSenetler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataVerilenSenetler_DoubleClick(object sender, EventArgs e)
        {
            CEK_SENET.CEK_CIKIS_BORDROSU_DUZENLE frm = new CEK_SENET.CEK_CIKIS_BORDROSU_DUZENLE();
            //frm.ITEM_ID = int.Parse(dataVerilenSenetler.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getVerilenSenetler(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataSatisFaturalari_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataSatisFaturalari);
        }

        private void dataAlisFaturalari_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataAlisFaturalari);
        }

        private void dataTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataTahsilat);
        }

        private void dataOdeme_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataOdeme);
        }

        private void dataSiparisTahsilat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataSiparisTahsilat);
        }

        private void dataAlinanCekler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataAlinanCekler);
        }

        private void dataVerilenCekler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataVerilenCekler);
        }

        private void dataAlinanSenetler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataAlinanSenetler);
        }

        private void dataVerilenSenetler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //styleHelper.dataGridFormatNumber(dataVerilenSenetler);
        }

        public void getTumHareketler(string urunID)
        {
            this.Cursor = Cursors.WaitCursor;
            dataGridView2.Rows.Clear();



            DataTable dtSatisFaturalari = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_SATIS_FATURALARI("+urunID+")");
            foreach (DataRow dr in dtSatisFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Satış Faturası";
                drRows.Cells[1].Value =Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = Convert.ToDouble(dr["GENEL_TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "SATIS_FATURALARI";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtAlisFaturalari = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_ALIS_FATURALARI(" + urunID + ")");
            foreach (DataRow dr in dtAlisFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Alış Faturası";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["GENEL_TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "ALIS_FATURALARI";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtAlisIadeFaturalari = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_ALIS_IADE_FATURALARI(" + urunID + ")");
            foreach (DataRow dr in dtAlisIadeFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Alış İade Faturası";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = Convert.ToDouble(dr["GENEL_TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "ALIS_IADE_FATURALARI";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtSatisIadeFaturalari = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_SATIS_IADE_FATURALARI(" + urunID + ")");
            foreach (DataRow dr in dtSatisIadeFaturalari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Satış İade Faturası";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["GENEL_TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "SATIS_IADE_FATURALARI";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtAlinanSiparisler = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_ALINAN_SIPARISLER(" + urunID + ")");
            foreach (DataRow dr in dtAlinanSiparisler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Alınan Sipariş";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "ALINAN_SIPARISLER";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtVerilenSiparisler = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_VERILEN_SIPARISLER(" + urunID + ")");
            foreach (DataRow dr in dtVerilenSiparisler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Verilen Sipariş";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "VERILEN_SIPARISLER";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtStokGirisleri = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_STOK_GIRISLERI(" + urunID + ")");
            foreach (DataRow dr in dtStokGirisleri.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Stok Girişi";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "STOK_GIRISLERI";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = "";
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtStokCikislari = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_STOK_CIKISLARI(" + urunID + ")");
            foreach (DataRow dr in dtStokCikislari.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Stok Çıkışı";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "STOK_CIKISLARI";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = "";
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtTahsilatlar = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_TAHSILATLAR(" + urunID + ")");
            foreach (DataRow dr in dtTahsilatlar.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Tahsilat";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "TAHSILATLAR";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }



            DataTable dtOdemeler = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_ODEMELER(" + urunID + ")");
            foreach (DataRow dr in dtOdemeler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Ödeme";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "ODEMELER";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }



            DataTable dtAlinanCek = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_ALINAN_CEKLER(" + urunID + ")");
            foreach (DataRow dr in dtAlinanCek.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Alınan Çek";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["BELGE_TARIHI"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "ALINAN_CEKLER";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = "";
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtVerilenCek = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_VERILEN_CEKLER(" + urunID + ")");
            foreach (DataRow dr in dtVerilenCek.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Verilen Çek";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["BELGE_TARIHI"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[4].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "VERILEN_CEKLER";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = "";
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtVerilenSenet = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_VERILEN_SENETLER(" + urunID + ")");
            foreach (DataRow dr in dtVerilenSenet.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Verilen Senet";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["BELGE_TARIHI"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[4].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "VERILEN_SENETLER";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = "";
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtAlinanSenet = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_ALINAN_SENETLER(" + urunID + ")");
            foreach (DataRow dr in dtAlinanSenet.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Alınan Senet";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["BELGE_TARIHI"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["TOPLAM"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "ALINAN_SENETLER";
                drRows.Cells[7].Value = dr["BELGE_NUMARASI"].ToString();
                drRows.Cells[8].Value = "";
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtGelenHavale = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_GELEN_HAVALE(" + urunID + ")");
            foreach (DataRow dr in dtGelenHavale.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Gelen Havale";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "GELEN_HAVALE";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtGidenHavale = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_GONDERILEN_HAVALE(" + urunID + ")");
            foreach (DataRow dr in dtGidenHavale.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Gönderilen Havale";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "0.00";
                drRows.Cells[3].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "GONDERILEN_HAVALE";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            DataTable dtPosTahsil = helper.getDataTable("SELECT * FROM FUNC_GET_CARI_POS_TAHSIL(" + urunID + ")");
            foreach (DataRow dr in dtPosTahsil.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataGridView2);
                drRows.Cells[0].Value = "Pos Tahsil";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[3].Value = "0.00";
                drRows.Cells[4].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[5].Value = dr["ID"].ToString();
                drRows.Cells[6].Value = "POS_TAHSIL";
                drRows.Cells[7].Value = "";
                drRows.Cells[8].Value = dr["ACIKLAMA"].ToString();
                dataGridView2.Rows.Add(drRows);
            }

            styleHelper.dataGridFormatNumber(dataGridView2);



            dataGridView2.Sort(COL_EKLENME_TARIHI, ListSortDirection.Descending);


            double DrGiris = 0;
            double DrCikis = 0;
            double DrBakiye = 0;
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                double giris = double.Parse(dr.Cells[2].Value.ToString());
                double cikis = double.Parse(dr.Cells[3].Value.ToString());
                double bakiye = giris - cikis;
                DrGiris += giris;
                DrCikis += cikis;
                DrBakiye += bakiye;
            }
            DataGridViewRow drSumRows = new DataGridViewRow();
            drSumRows.DefaultCellStyle.BackColor = Color.NavajoWhite;
            drSumRows.CreateCells(dataGridView2);
            drSumRows.Cells[2].Value = DrGiris.ToString("N2"); ;
            drSumRows.Cells[3].Value = DrCikis.ToString("N2"); ;



            dataGridView2.Rows.Add(drSumRows);

            this.Cursor = Cursors.Default;
        }

        private void dataGridView2_DoubleClick_1(object sender, EventArgs e)
        {
            var hareket_tipi = dataGridView2.SelectedRows[0].Cells["COL_ITEM_TYPE"].Value.ToString();
            var hareket_id = dataGridView2.SelectedRows[0].Cells["COL_ITEM_ID"].Value.ToString();

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
            else if (hareket_tipi == "TAHSILATLAR")
            {
                FATURA.TAHSILAT_DUZENLE FRM2 = new FATURA.TAHSILAT_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ODEMELER")
            {
                FATURA.ODEME_DUZENLE FRM2 = new FATURA.ODEME_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "SIPARIS_TAHSILATLAR")
            {
                SIPARIS.TAHSILAT_DUZENLE FRM2 = new SIPARIS.TAHSILAT_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ODEMELER_IADE")
            {
                FATURA_IADE.IADE_ODEME_DUZENLE FRM2 = new FATURA_IADE.IADE_ODEME_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "TAHSILATLAR_IADE")
            {
                FATURA_IADE.IADE_TAHSILAT_DUZENLE FRM2 = new FATURA_IADE.IADE_TAHSILAT_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ALINAN_CEKLER")
            {
                CEK_SENET.CEK_GIRIS_BORDROSU_DUZENLE FRM2 = new CEK_SENET.CEK_GIRIS_BORDROSU_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "VERILEN_CEKLER")
            {
                CEK_SENET.CEK_CIKIS_BORDROSU_DUZENLE FRM2 = new CEK_SENET.CEK_CIKIS_BORDROSU_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "ALINAN_SENETLER")
            {
                CEK_SENET.SENET_GIRIS_BORDROSU_DUZENLE FRM2 = new CEK_SENET.SENET_GIRIS_BORDROSU_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            else if (hareket_tipi == "VERILEN_SENETLER")
            {
                CEK_SENET.SENET_CIKIS_BORDROSU_DUZENLE FRM2 = new CEK_SENET.SENET_CIKIS_BORDROSU_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            else if (hareket_tipi == "BANKA_GIRISLERI")
            {
                BANKA.GIRIS_DUZENLE FRM2 = new BANKA.GIRIS_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            else if (hareket_tipi == "GELEN_HAVALE")
            {
                BANKA.GELEN_HAVALE_DUZENLE FRM2 = new BANKA.GELEN_HAVALE_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            else if (hareket_tipi == "GONDERILEN_HAVALE")
            {
                BANKA.GONDERILEN_HAVALE_DUZENLE FRM2 = new BANKA.GONDERILEN_HAVALE_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }
            else if (hareket_tipi == "POS_TAHSIL")
            {
                BANKA.POS_TAHSIL_DUZENLE FRM2 = new BANKA.POS_TAHSIL_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            frm.ShowDialog();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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

        public void processCommand()
        {

            dataGridView1.SelectedRows[0].Cells["ALACAK"].Value = commonClass.getCariAlacak(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            dataGridView1.SelectedRows[0].Cells["BORC"].Value = commonClass.getCariBorc(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            dataGridView1.SelectedRows[0].Cells["BAKIYE"].Value = double.Parse(dataGridView1.SelectedRows[0].Cells["BORC"].Value.ToString()) - double.Parse(dataGridView1.SelectedRows[0].Cells["ALACAK"].Value.ToString());
            string abReport = "A";
            if (double.Parse(dataGridView1.SelectedRows[0].Cells["BORC"].Value.ToString()) > double.Parse(dataGridView1.SelectedRows[0].Cells["ALACAK"].Value.ToString()))
            {
                abReport = "B";
            }
            else if (double.Parse(dataGridView1.SelectedRows[0].Cells["BORC"].Value.ToString()) == double.Parse(dataGridView1.SelectedRows[0].Cells["ALACAK"].Value.ToString()))
            {
                abReport = "-";
            }
            dataGridView1.SelectedRows[0].Cells["A/B"].Value = abReport;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //processCommand();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            //dataGridView1.DataSource = dt;
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridReName(dataGridView1);
            styleHelper.dataGridFormatNumber(dataGridView1);

            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            double DrGiris = 0;
            double DrCikis = 0;
            double DrBakiye = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                double giris = double.Parse(dr.Cells["CARİ_ALACAĞI"].Value.ToString());
                double cikis = double.Parse(dr.Cells["CARİ_BORCU"].Value.ToString());
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

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styleHelper.dataGridFormatNumber(dataGridView2);


        }

        private void CARI_KARTLAR_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void yAZDIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YAZDIR.FORM frm = new YAZDIR.FORM();
            frm.reportData = reportSource;
            frm.ShowDialog();
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                searchProcess2();

            }
        }




    }
}
