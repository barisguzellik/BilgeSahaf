using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA_IADE
{
    public partial class IADE_TAHSILAT_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public IADE_TAHSILAT_DUZENLE()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int FATURA_ID = 0;
        public string TUTAR = "0.00";
        public int ITEM_ID = 0;

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string[] col =
            {
                "TARIH",
                "EKLENME_TARIHI",
                "TUTAR",
                "ALIS_FATURA_ID"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtTutar.Text.Replace(",","."),
                FATURA_ID.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("IADE_TAHSILATLAR_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Tahsilat kaydedildi...","Tahsilat");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Tahsilat");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM IADE_TAHSILATLAR_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtTarih.Text = dt.Rows[0]["TARIH"].ToString();
                txtTutar.Text = dt.Rows[0]["TUTAR"].ToString();
                FATURA_ID = int.Parse(dt.Rows[0]["ALIS_FATURA_ID"].ToString());
            }
        }

        private void tAHSİLATISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.setSqlCommand("DELETE FROM IADE_TAHSILATLAR_V2 WHERE ID=" + ITEM_ID + "");
            this.Close();
        }
    }
}
