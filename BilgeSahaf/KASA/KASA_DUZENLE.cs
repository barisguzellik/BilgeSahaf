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
    public partial class KASA_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public KASA_DUZENLE()
        {
            InitializeComponent();
        }

        public int ITEM_ID = 0;
        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string[] col =
            {
                "KASA_ADI",
                "ACIKLAMA",
                "ACILIS_TARIHI"
            };
            string[] val =
            {
                txtKasaAdi.Text,
                txtAciklama.Text,
                dateFormat
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("KASALAR_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Kasa kaydedildi...", "Kasa");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Kasa");
            }
            

        }

        private void KASA_DUZENLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 * FROM KASALAR_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtAciklama.Text = dt.Rows[0]["ACIKLAMA"].ToString();
                txtKasaAdi.Text= dt.Rows[0]["KASA_ADI"].ToString();
                txtTarih.Text= dt.Rows[0]["ACILIS_TARIHI"].ToString();
            }
        }

        private void kASAYISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
