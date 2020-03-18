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
    public partial class GONDERILEN_HAVALE_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public GONDERILEN_HAVALE_EKLE()
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
                helper.setSqlCommandForInsertWithParameters("GONDERILEN_HAVALE_V2", col, val);
                MessageBox.Show("Ödeme Eklendi...", "Ödeme");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Ödeme");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            txtTutar.Text = TUTAR;

            comboBanka.DataSource = helper.getDataTable("SELECT ID,BANKA_ADI FROM BANKALAR_V2 ORDER BY BANKA_ADI");
            comboBanka.ValueMember = "ID";
            comboBanka.DisplayMember = "BANKA_ADI";
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
