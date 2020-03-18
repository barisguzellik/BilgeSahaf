using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
{
    public partial class TAHSILAT_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public TAHSILAT_EKLE()
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
                "KASA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtTutar.Text.Replace(",","."),
                txtCariID.Text,
                textBox2.Text,
                comboKasa.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("TAHSILATLAR_V2", col, val);
                MessageBox.Show("Tahsilat Eklendi...","Tahsilat");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Tahsilat");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            txtTutar.Text = TUTAR;
            comboKasa.DataSource = helper.getDataTable("SELECT ID,KASA_ADI FROM KASALAR_V2 ORDER BY KASA_ADI");
            comboKasa.ValueMember = "ID";
            comboKasa.DisplayMember = "KASA_ADI";
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
