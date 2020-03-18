using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.GIRIS
{
    public partial class KULLANICILAR : Form
    {
        public KULLANICILAR()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles style = new DefaultStyles();

        private void KULLANICILAR_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "KullaniciGrid1";


            style.dataGridStyle(dataGridView1);
            getDefault();

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(style.testFunc);
        }

        public void getDefault()
        {
            string COLS = "ID,AD,SOYAD,EPOSTA_ADRESI,AKTIF";
            dataGridView1.DataSource = helper.getDataTable("SELECT "+COLS+" FROM KULLANICILAR");

        }

        private void kULLANICIEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YENI_KULLANICI_EKLE frm = new YENI_KULLANICI_EKLE();
            frm.ShowDialog();
            getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            KULLANICI_DUZENLE frm = new KULLANICI_DUZENLE();
            frm.ITEM_ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            frm.ShowDialog();
            getDefault();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            style.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());
        }
    }
}
