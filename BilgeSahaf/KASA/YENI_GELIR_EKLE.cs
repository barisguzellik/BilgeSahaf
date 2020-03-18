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
    public partial class YENI_GELIR_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_GELIR_EKLE()
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
                helper.setSqlCommandForInsertWithParameters("GELIRLER_V2", col, val);
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
        }
    }
}
