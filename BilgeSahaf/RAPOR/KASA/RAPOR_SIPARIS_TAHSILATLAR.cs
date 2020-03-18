using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR.KASA
{
    public partial class RAPOR_SIPARIS_TAHSILATLAR : Form
    {
        public RAPOR_SIPARIS_TAHSILATLAR()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();
        private void RAPOR_STOK_KARTLARI_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);
            dataGridView1.DataSource = helper.getDataTable("SELECT ALINAN_SIPARISLER_V2.AD,SIPARIS_TAHSILATLAR_V2.TARIH,SIPARIS_TAHSILATLAR_V2.EKLENME_TARIHI,SIPARIS_TAHSILATLAR_V2.TUTAR,SIPARIS_TAHSILATLAR_V2.ACIKLAMA FROM ALINAN_SIPARISLER_V2 INNER JOIN SIPARIS_TAHSILATLAR_V2 ON ALINAN_SIPARISLER_V2.ID=SIPARIS_TAHSILATLAR_V2.SIPARIS_ID ORDER BY SIPARIS_TAHSILATLAR_V2.ID DESC");
            toolStripStatusLabel1.Text ="Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
        }

        private void sORGUÇALIŞTIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.RAPOR_SORGU_CALISTIR frm = new RAPOR.RAPOR_SORGU_CALISTIR();
            frm.ShowDialog();
            if(frm.QUERY!=null && frm.QUERY!=string.Empty && frm.QUERY != "")
            {
                try
                {
                    dataGridView1.DataSource = helper.getDataTable(frm.QUERY);
                    toolStripStatusLabel1.Text = "Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
                }
                catch(Exception x)
                {
                    MessageBox.Show(x.Message,"RAPOR");
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styles.dataGridFormatNumber(dataGridView1);
        }
    }
}
