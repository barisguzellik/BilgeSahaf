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
    public partial class YENI_BANKA_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_BANKA_EKLE()
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
                helper.setSqlCommandForInsertWithParameters("BANKALAR_V2", col, val);
                MessageBox.Show("Banka kaydedildi...", "Kasa");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Banka");
            }


        }

        private void YENI_KASA_EKLE_Load(object sender, EventArgs e)
        {

        }
    }
}
