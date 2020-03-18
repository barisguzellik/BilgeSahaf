using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.DIGER
{
    public partial class STOK_SAYIM : Form
    {
        public STOK_SAYIM()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        DefaultStyles style = new DefaultStyles();
        CommonClass commonClass = new CommonClass();

        private void STOK_SAYIM_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "StokSayimGrid1";

            style.dataGridStyle(dataGridView1);

            
            getDefault();
        }
        public void getDefault()
        {
            string COLS = "ID,TARIH,BELGE_NUMARASI,ACIKLAMA,EKLENME_TARIHI";
            dataGridView1.DataSource = helper.getDataTable("SELECT " + COLS + " FROM STOK_SAYIM_V2 ORDER BY ID DESC");
        }

        private void stokSayımFişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DIGER.YENI_STOK_SAYIM_FISI frm = new DIGER.YENI_STOK_SAYIM_FISI();
            frm.ShowDialog();
            getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DIGER.STOK_SAYIM_FISI_DUZENLE frm = new DIGER.STOK_SAYIM_FISI_DUZENLE();
                frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                frm.ShowDialog();
            }
            catch { }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            style.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(style.testFunc);

        }
    }
}
