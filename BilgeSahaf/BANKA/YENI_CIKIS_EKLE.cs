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
    public partial class YENI_CIKIS_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_CIKIS_EKLE()
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
                helper.setSqlCommandForInsertWithParameters("BANKA_CIKISLAR_V2", col, val);
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
        }
    }
}
