using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.CEK_SENET
{
    public partial class ALINAN_SENETLER : Form
    {
        public ALINAN_SENETLER()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles style = new DefaultStyles();
        CommonClass commonClass = new CommonClass();

        private void yENİALINANÇEKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CEK_SENET.SENET_GIRIS_BORDROSU frm = new SENET_GIRIS_BORDROSU();
            frm.ShowDialog();
            getDefault();
        }

        private void ALINAN_CEKLER_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "AlSenetGrid1";
            dataGridView2.Tag = "AlSenetGrid2";

            style.dataGridStyle(dataGridView1);
            style.dataGridStyle(dataGridView2);
            
            getDefault();

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(style.testFunc);
            dataGridView2.ColumnWidthChanged += new DataGridViewColumnEventHandler(style.testFunc);

        }
        string COLS = "SENET_GIRIS_BORDROSU_V2.ID,CARI_KARTLAR_V2.UNVANI,SENET_GIRIS_BORDROSU_V2.TARIH,SENET_GIRIS_BORDROSU_V2.BELGE_TARIHI,SENET_GIRIS_BORDROSU_V2.BELGE_NUMARASI,SENET_GIRIS_BORDROSU_V2.EVRAK_NUMARASI,SENET_GIRIS_BORDROSU_V2.ARA_TOPLAM,SENET_GIRIS_BORDROSU_V2.MASRAF,SENET_GIRIS_BORDROSU_V2.TOPLAM,SENET_GIRIS_BORDROSU_V2.EKLENME_TARIHI";
        public void getDefault()
        {

            dataGridView1.DataSource = helper.getDataTable("SELECT "+COLS+ " FROM CARI_KARTLAR_V2 INNER JOIN SENET_GIRIS_BORDROSU_V2 ON CARI_KARTLAR_V2.ID=SENET_GIRIS_BORDROSU_V2.CARI ORDER BY SENET_GIRIS_BORDROSU_V2.ID DESC");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            getDetails();
        }

        public void getDetails()
        {
            try
            {
                string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string col = "CINSI,REFERANS,VADE,MEBLAG,ACIKLAMA";
                dataGridView2.DataSource = helper.getDataTable("SELECT " + col + " FROM SENET_GIRIS_BORDROSU_DETAYLAR WHERE SENET_GIRIS_ID=" + ID + "");

                
            }
            catch { }
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CEK_SENET.SENET_GIRIS_BORDROSU_DUZENLE frm = new CEK_SENET.SENET_GIRIS_BORDROSU_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getDefault();
        }

        private void yENİToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            style.dataGridFormatNumber(dataGridView2);

            style.dataGridColWidth(dataGridView2, dataGridView2.Tag.ToString());
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            //double val = double.Parse(dataGridView2.Rows[e.RowIndex].Cells["MEBLAG"].Value.ToString());
            //dataGridView2.Rows[e.RowIndex].Cells["MEBLAG"].Value = val.ToString("n");

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            style.dataGridFormatNumber(dataGridView1);

            style.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());
        }
        public void searchProcess()
        {
            string query = "1=1 ";
            string[] likeColumns =
            {
                "CARI_KARTLAR_V2.UNVANI",
                "SENET_GIRIS_BORDROSU_V2.EVRAK_NUMARASI",
                "SENET_GIRIS_BORDROSU_V2.BELGE_NUMARASI",
                "SENET_GIRIS_BORDROSU_V2.TARIH",
                "SENET_GIRIS_BORDROSU_V2.BELGE_TARIHI",
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


            dataGridView1.DataSource = helper.getDataTable("SELECT TOP 50 " + COLS + " FROM CARI_KARTLAR_V2 INNER JOIN SENET_GIRIS_BORDROSU_V2 ON CARI_KARTLAR_V2.ID=SENET_GIRIS_BORDROSU_V2.CARI WHERE " + query);
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchProcess();
        }
    }
}
