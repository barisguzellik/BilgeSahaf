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
    public partial class KULLANICI_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public KULLANICI_DUZENLE()
        {
            InitializeComponent();
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int ITEM_ID = 0;

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

            DataTable dt2 = helper.getDataTable("SELECT*FROM KULLANICILAR WHERE ID="+ITEM_ID+"");

            if (dt2.Rows.Count > 0)
            {
                txtAd.Text = dt2.Rows[0]["AD"].ToString();
                txtParo.Text= dt2.Rows[0]["PAROLA"].ToString();
                txtPosta.Text= dt2.Rows[0]["EPOSTA_ADRESI"].ToString();
                txtSoyad.Text= dt2.Rows[0]["SOYAD"].ToString();
                comboBox1.SelectedValue= dt2.Rows[0]["AKTIF"].ToString();
            }
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
                txtParo.Text,
                comboBox1.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("KULLANICILAR", cols, vals,"ID",ITEM_ID.ToString());
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Kullanıcı");
            }
        }
    }
}
