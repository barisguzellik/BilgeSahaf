using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.CARI
{
    public partial class CARI_KART_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public int ITEM_ID = 0;
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        public CARI_KART_DUZENLE()
        {
            InitializeComponent();
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CARI_KART_DUZENLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM CARI_KARTLAR_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    txtAdres.Text = row["ADRES"].ToString();
                    txtCariKodu.Text = row["CARI_KODU"].ToString();
                    txtCariTuru.Text = row["CARI_TURU"].ToString();
                    txtCariUnvani.Text = row["UNVANI"].ToString();
                    txtCepTelefon.Text = row["CEP_TELEFON"].ToString();
                    txtGrupKodu.Text = row["GRUP_KODU"].ToString();
                    txtIl.Text = row["IL"].ToString();
                    txtIlce.Text = row["ILCE"].ToString();
                    txtTelefon.Text = row["TELEFON"].ToString();
                    txtVergiDairesi.Text = row["VERGI_DAIRESI"].ToString();
                    txtVergiNumarasi.Text = row["VERGI_NUMARASI"].ToString();
                    txtYetkiliKisi.Text = row["YETKILI_KISI"].ToString();
                    txtOzelKod1.Text = row["OZEL_KODLAR_1"].ToString();
                    txtOzelKod2.Text = row["OZEL_KODLAR_2"].ToString();
                    txtOzelKod3.Text = row["OZEL_KODLAR_3"].ToString();
                    txtOzelKod4.Text = row["OZEL_KODLAR_4"].ToString();
                    txtOzelKod5.Text = row["OZEL_KODLAR_5"].ToString();
                    txtFaturaAdresi.Text = row["FATURA_ADRESI"].ToString();

                }
            }
        }

        private void kARTISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM CARI_KARTLAR_V2 WHERE ID=" + ITEM_ID + "");
                this.Close();
            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] col = {
                "CARI_KODU",
                "UNVANI",
                "CARI_TURU",
                "ADRES",
                "IL",
                "ILCE",
                "TELEFON",
                "CEP_TELEFON",
                "YETKILI_KISI",
                "VERGI_DAIRESI",
                "VERGI_NUMARASI",
                "GRUP_KODU",
                "OZEL_KODLAR_1",
                "OZEL_KODLAR_2",
                "OZEL_KODLAR_3",
                "OZEL_KODLAR_4",
                "OZEL_KODLAR_5",
                "FATURA_ADRESI"
            };
            string[] val = {
                txtCariKodu.Text,
                txtCariUnvani.Text,
                txtCariTuru.Text,
                txtAdres.Text,
                txtIl.Text,
                txtIlce.Text,
                txtTelefon.Text,
                txtCepTelefon.Text,
                txtYetkiliKisi.Text,
                txtVergiDairesi.Text,
                txtVergiNumarasi.Text,
                txtGrupKodu.Text,
                txtOzelKod1.Text,
                txtOzelKod2.Text,
                txtOzelKod3.Text,
                txtOzelKod4.Text,
                txtOzelKod5.Text,
                txtFaturaAdresi.Text

            };
            try
            {
                helper.setSqlCommandForUpdateWithParameters("CARI_KARTLAR_V2", col, val, "ID", ITEM_ID.ToString());
                MessageBox.Show("Cari kaydedildi...", "Cari");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Cari");
            }
        }
    }
}
