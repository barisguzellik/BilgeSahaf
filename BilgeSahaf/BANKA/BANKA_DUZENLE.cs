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
    public partial class BANKA_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public int ITEM_ID = 0;
        public BANKA_DUZENLE()
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
                "BANKA_ADI",
                "SUBESI",
                "ACILIS_TARIHI",
                "HESAP_NUMARASI",
                "IBAN_NUMARASI"
            };
            string[] val =
            {
               txtBankaAdi.Text,
               txtSubesi.Text,
               dateFormat,
               txtHesapNo.Text,
               txtIbanNo.Text
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("BANKALAR_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Banka kaydedildi...", "Kasa");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Banka");
            }


        }

        private void YENI_KASA_EKLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM BANKALAR_V2 WHERE ID="+ITEM_ID+"");
            if (dt.Rows.Count > 0)
            {
                txtBankaAdi.Text = dt.Rows[0]["BANKA_ADI"].ToString();
                txtHesapNo.Text= dt.Rows[0]["HESAP_NUMARASI"].ToString();
                txtIbanNo.Text= dt.Rows[0]["IBAN_NUMARASI"].ToString();
                txtSubesi.Text= dt.Rows[0]["SUBESI"].ToString();
                txtTarih.Text= dt.Rows[0]["ACILIS_TARIHI"].ToString();
            }
        }

        private void bANKAYISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM BANKALAR_V2 WHERE ID=" + ITEM_ID + "");
                helper.setSqlCommand("DELETE FROM BANKA_GIRISLER_V2 WHERE BANKA=" + ITEM_ID + "");
                helper.setSqlCommand("DELETE FROM BANKA_CIKISLAR_V2 WHERE BANKA=" + ITEM_ID + "");
                this.Close();

            }
        }
    }
}
