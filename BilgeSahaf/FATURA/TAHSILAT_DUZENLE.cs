using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
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
                "CARI",
                "ACIKLAMA",
                "KASA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtTutar.Text.Replace(",","."),
                txtCariID.Text,
                textBox2.Text,
                comboKasa.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("TAHSILATLAR_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Tahsilat kaydedildi...","Tahsilat");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Tahsilat");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            comboKasa.DataSource = helper.getDataTable("SELECT ID,KASA_ADI FROM KASALAR_V2 ORDER BY KASA_ADI");
            comboKasa.ValueMember = "ID";
            comboKasa.DisplayMember = "KASA_ADI";


            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM TAHSILATLAR_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtTarih.Text = dt.Rows[0]["TARIH"].ToString();
                txtTutar.Text = dt.Rows[0]["TUTAR"].ToString();
                txtCariID.Text = dt.Rows[0]["CARI"].ToString();
                textBox2.Text = dt.Rows[0]["ACIKLAMA"].ToString();
                comboKasa.SelectedValue = dt.Rows[0]["KASA"].ToString();
            }
        }

        private void tAHSİLATISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.setSqlCommand("DELETE FROM TAHSILATLAR_V2 WHERE ID=" + ITEM_ID + "");
            this.Close();
        }

        private void txtCariID_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCariID.Text = frm.lastSelectedUser.ToString();
        }
    }
}
