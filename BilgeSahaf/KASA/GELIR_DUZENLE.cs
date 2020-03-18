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
    public partial class GELIR_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {

        public int ITEM_ID = 0;
        public GELIR_DUZENLE()
        {
            InitializeComponent();
        }

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
                "TARIH",
                "EKLENME_TARIHI",
                "ACIKLAMA",
                "TUTAR",
                "KASA"
            };
            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtAciklama.Text,
                txtTutar.Text.Replace(",","."),
                comboKasa.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("GELIRLER_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Gelir kaydedildi...", "Gelir");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Gelir");
            }
            

        }

        private void YENI_KASA_EKLE_Load(object sender, EventArgs e)
        {

            comboKasa.DataSource = helper.getDataTable("SELECT ID,KASA_ADI FROM KASALAR_V2 ORDER BY KASA_ADI");
            comboKasa.ValueMember = "ID";
            comboKasa.DisplayMember = "KASA_ADI";

            DataTable dt = helper.getDataTable("SELECT*FROM GELIRLER_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtAciklama.Text = dt.Rows[0]["ACIKLAMA"].ToString();
                txtTarih.Text = dt.Rows[0]["TARIH"].ToString();
                txtTutar.Text = dt.Rows[0]["TUTAR"].ToString();
                comboKasa.SelectedValue = dt.Rows[0]["KASA"].ToString();
            }
        }

        private void kAYDISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM GELIRLER_V2 WHERE ID=" + ITEM_ID + "");
                this.Close();
            }
        }
    }
}
