using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.GIRIS
{
    public partial class YENI_KULLANICI_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_KULLANICI_EKLE()
        {
            InitializeComponent();
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YENI_KULLANICI_EKLE_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE");
            dt.Columns.Add("TEXT");

            dt.Rows.Add();
            dt.Rows.Add();

            dt.Rows[0]["VALUE"] = "0";
            dt.Rows[0]["TEXT"] = "PASİF";

            dt.Rows[1]["VALUE"] = "1";
            dt.Rows[1]["TEXT"] = "AKTİF";


            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "VALUE";
            comboBox1.DisplayMember = "TEXT";
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] cols =
            {
                "AD",
                "SOYAD",
                "EPOSTA_ADRESI",
                "PAROLA",
                "AKTIF"
            };

            string[] vals =
            {
                txtAd.Text,
                txtSoyad.Text,
                txtPosta.Text,
                txtParola.Text,
                comboBox1.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("KULLANICILAR", cols, vals);
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Kullanıcı");
            }
        }
    }
}
