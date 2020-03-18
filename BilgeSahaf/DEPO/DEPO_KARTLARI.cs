using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.DEPO
{
    public partial class DEPO_KARTLARI : Form
    {
        public DEPO_KARTLARI()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles style = new DefaultStyles();

        private void DEPO_KARTLARI_Load(object sender, EventArgs e)
        {
            dataGridView1.Tag = "DepoGrid1";

            style.dataGridStyle(dataGridView1);

            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(style.testFunc);

            getDefault();
        }

        string COLS = "ID,DEPO_ADI,ACIKLAMA";
        public void getDefault()
        {
            dataGridView1.DataSource = helper.getDataTable("SELECT "+COLS+" FROM DEPO_KARTLARI_V2");
        }

        private void yENİDEPOKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DEPO.YENI_DEPO_KARTI frm = new YENI_DEPO_KARTI();
            frm.ShowDialog();
            getDefault();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DEPO.DEPO_KARTI_DUZENLE frm = new DEPO_KARTI_DUZENLE();
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
