using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.SIPARIS
{
    public partial class TAHSILAT_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public TAHSILAT_DUZENLE()
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
                "SIPARIS_ID",
                "ACIKLAMA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtTutar.Text.Replace(",","."),
                FATURA_ID.ToString(),
                textBox2.Text
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("SIPARIS_TAHSILATLAR_V2", col, val, "ID", ITEM_ID.ToString());
                //MessageBox.Show("Tahsilat kaydedildi...","Tahsilat");
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Tahsilat");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM SIPARIS_TAHSILATLAR_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtTarih.Text = dt.Rows[0]["TARIH"].ToString();
                txtTutar.Text = dt.Rows[0]["TUTAR"].ToString();
                FATURA_ID = int.Parse(dt.Rows[0]["SIPARIS_ID"].ToString());
                textBox2.Text= dt.Rows[0]["ACIKLAMA"].ToString();
            }
        }

        private void tAHSİLATISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.setSqlCommand("DELETE FROM SIPARIS_TAHSILATLAR_V2 WHERE ID=" + ITEM_ID + "");
            this.Close();
        }
    }
}
