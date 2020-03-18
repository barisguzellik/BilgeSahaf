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
    public partial class YENI_KASA_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_KASA_EKLE()
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
                helper.setSqlCommandForInsertWithParameters("KASALAR_V2", col, val);
                MessageBox.Show("Kasa kaydedildi...", "Kasa");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Kasa");
            }
            

        }

        private void YENI_KASA_EKLE_Load(object sender, EventArgs e)
        {

        }
    }
}
