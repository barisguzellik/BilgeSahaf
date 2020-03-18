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
    public partial class GONDERILEN_HAVALE_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public GONDERILEN_HAVALE_DUZENLE()
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
                "BANKA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtTutar.Text.Replace(",","."),
                txtCariID.Text,
                textBox2.Text,
                comboBanka.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("GONDERILEN_HAVALE_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Ödeme kaydedildi...", "Ödeme");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Ödeme");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            comboBanka.DataSource = helper.getDataTable("SELECT ID,BANKA_ADI FROM BANKALAR_V2 ORDER BY BANKA_ADI");
            comboBanka.ValueMember = "ID";
            comboBanka.DisplayMember = "BANKA_ADI";

            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM GONDERILEN_HAVALE_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtTarih.Text = dt.Rows[0]["TARIH"].ToString();
                txtTutar.Text = dt.Rows[0]["TUTAR"].ToString();
                txtCariID.Text = dt.Rows[0]["CARI"].ToString();
                textBox2.Text = dt.Rows[0]["ACIKLAMA"].ToString();
                comboBanka.SelectedValue = dt.Rows[0]["BANKA"].ToString();
            }
        }

        private void tAHSİLATISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM GONDERILEN_HAVALE_V2 WHERE ID=" + ITEM_ID + "");
                this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCariID.Text = frm.lastSelectedUser.ToString();
        }

        private void txtCariID_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }
        }
    }
}
