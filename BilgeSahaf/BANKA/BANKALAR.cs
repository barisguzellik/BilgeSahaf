using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.BANKA
{
    public partial class BANKALAR : Form
    {
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles styleHelper = new DefaultStyles();

        public BANKALAR()
        {
            InitializeComponent();
        }
        public string COLS = "ID,BANKA_ADI,SUBESI,ACILIS_TARIHI,HESAP_NUMARASI";
        private void KASALAR_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "BankaGrid1";
            dataTumHareketler.Tag = "BankaGrid2";

            styleHelper.dataGridStyle(dataGridView1);
            styleHelper.dataGridStyle(dataTumHareketler);

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
            dataGridView1.DataSource = helper.getDataTable("SELECT*FROM VIEW_BANKALAR");
        }

        private void yENİKASAEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BANKA.YENI_BANKA_EKLE frm = new YENI_BANKA_EKLE();
            frm.ShowDialog();
            getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            BANKA.BANKA_DUZENLE frm = new BANKA_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            //getDefault();
        }
        

       

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTarih_ValueChanged(object sender, EventArgs e)
        {
            getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
        }

        
       

        private void yENİGİDEREKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BANKA.YENI_GIRIS_EKLE frm = new BANKA.YENI_GIRIS_EKLE();
            frm.ShowDialog();
            getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void yENİGELİREKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BANKA.YENI_CIKIS_EKLE frm = new BANKA.YENI_CIKIS_EKLE();
            frm.ShowDialog();
            getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            }
            catch { }
        }

       

        public void getTumHareketler(int id)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            DateTime dtTime2 = Convert.ToDateTime(txtTarih2.Text);
            string dateFormat2 = dtTime2.Year + "-" + dtTime2.Month + "-" + dtTime2.Day;

            dataTumHareketler.Rows.Clear();

            DataTable dtGelirler = helper.getDataTable("SELECT * FROM BANKA_GIRISLER_V2 WHERE BANKA="+id+" AND BANKA_GIRISLER_V2.TARIH BETWEEN '" + dateFormat + "' AND '"+dateFormat2+"'");
            foreach (DataRow dr in dtGelirler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Gelir";
                drRows.Cells[1].Value =Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "BANKA";
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[5].Value = "0.00";
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "GELIRLER";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtGiderler = helper.getDataTable("SELECT * FROM BANKA_CIKISLAR_V2 WHERE BANKA=" + id + " AND BANKA_CIKISLAR_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtGiderler.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Gider";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = "BANKA";
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = "0.00";
                drRows.Cells[5].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "GIDERLER";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtGelenHavale = helper.getDataTable("SELECT * FROM GELEN_HAVALE_V2 INNER JOIN CARI_KARTLAR_V2 ON GELEN_HAVALE_V2.CARI=CARI_KARTLAR_V2.ID WHERE BANKA=" + id + " AND GELEN_HAVALE_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtGelenHavale.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Gelen Havale";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["UNVANI"].ToString();
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[5].Value = "0.00";
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "GELEN_HAVALE";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtGidenHavale = helper.getDataTable("SELECT * FROM GONDERILEN_HAVALE_V2 INNER JOIN CARI_KARTLAR_V2 ON GONDERILEN_HAVALE_V2.CARI=CARI_KARTLAR_V2.ID WHERE BANKA=" + id + " AND GONDERILEN_HAVALE_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtGidenHavale.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Gönderilen Havale";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["UNVANI"].ToString();
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = "0.00";
                drRows.Cells[5].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "GONDERILEN_HAVALE";
                dataTumHareketler.Rows.Add(drRows);
            }

            DataTable dtPosTahsil = helper.getDataTable("SELECT * FROM POS_TAHSIL_V2 INNER JOIN CARI_KARTLAR_V2 ON POS_TAHSIL_V2.CARI=CARI_KARTLAR_V2.ID WHERE BANKA=" + id + " AND POS_TAHSIL_V2.TARIH BETWEEN '" + dateFormat + "' AND '" + dateFormat2 + "'");
            foreach (DataRow dr in dtPosTahsil.Rows)
            {
                DataGridViewRow drRows = new DataGridViewRow();
                drRows.CreateCells(dataTumHareketler);
                drRows.Cells[0].Value = "Pos Tahsil";
                drRows.Cells[1].Value = Convert.ToDateTime(dr["TARIH"].ToString());
                drRows.Cells[2].Value = dr["UNVANI"].ToString();
                drRows.Cells[3].Value = dr["ACIKLAMA"].ToString();
                drRows.Cells[4].Value = Convert.ToDouble(dr["TUTAR"].ToString()).ToString("N2");
                drRows.Cells[5].Value = "0.00";
                drRows.Cells[6].Value = Convert.ToDateTime(dr["EKLENME_TARIHI"].ToString());
                drRows.Cells[7].Value = dr["ID"].ToString();
                drRows.Cells[8].Value = "POS_TAHSIL";
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

        private void dataTumHareketler_DoubleClick(object sender, EventArgs e)
        {
            var hareket_tipi = dataTumHareketler.SelectedRows[0].Cells["HAREKET_TIPI"].Value.ToString();
            var hareket_id = dataTumHareketler.SelectedRows[0].Cells["HAREKET_ID"].Value.ToString();

            Form frm = new Form();
           

            if (hareket_tipi == "GELIRLER")
            {
                BANKA.GIRIS_DUZENLE FRM2 = new BANKA.GIRIS_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            if (hareket_tipi == "GIDERLER")
            {
                BANKA.CIKIS_DUZENLE FRM2 = new BANKA.CIKIS_DUZENLE();
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

            if (hareket_tipi == "POS_TAHSIL")
            {
                BANKA.POS_TAHSIL_DUZENLE FRM2 = new BANKA.POS_TAHSIL_DUZENLE();
                FRM2.ITEM_ID = int.Parse(hareket_id);
                frm = FRM2;
            }

            frm.ShowDialog();
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

        private void txtTarih2_ValueChanged(object sender, EventArgs e)
        {
            getTumHareketler(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
        }
    }
}
