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
    public partial class CIKIS_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public CIKIS_DUZENLE()
        {
            InitializeComponent();
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        public int ITEM_ID = 0;
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
                "BANKA"
            };
            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtAciklama.Text,
                txtTutar.Text.Replace(",","."),
                comboBanka.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("BANKA_CIKISLAR_V2", col, val,"ID",ITEM_ID.ToString());
                MessageBox.Show("Çıkış kaydedildi...", "Çıkış");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Çıkış");
            }
            

        }

        private void YENI_KASA_EKLE_Load(object sender, EventArgs e)
        {
            comboBanka.DataSource = helper.getDataTable("SELECT ID,BANKA_ADI FROM BANKALAR_V2 ORDER BY BANKA_ADI");
            comboBanka.ValueMember = "ID";
            comboBanka.DisplayMember = "BANKA_ADI";

            DataTable dt = helper.getDataTable("SELECT*FROM BANKA_CIKISLAR_V2 WHERE ID="+ITEM_ID+"");
            if (dt.Rows.Count > 0)
            {
                txtAciklama.Text = dt.Rows[0]["ACIKLAMA"].ToString();
                txtTarih.Text= dt.Rows[0]["TARIH"].ToString();
                txtTutar.Text= dt.Rows[0]["TUTAR"].ToString();
                comboBanka.SelectedValue= dt.Rows[0]["BANKA"].ToString();
            }
        }

        private void kAYDISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM BANKA_CIKISLAR_V2 WHERE ID=" + ITEM_ID + "");
                this.Close();

            }
        }
    }
}
