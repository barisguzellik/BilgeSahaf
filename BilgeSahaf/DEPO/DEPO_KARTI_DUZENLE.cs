using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.DEPO
{
    public partial class DEPO_KARTI_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public int ITEM_ID = 0;
        public DEPO_KARTI_DUZENLE()
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
            string[] COL =
            {
                "DEPO_ADI",
                "ACIKLAMA"
            };

            string[] VAL =
            {
                txtDepoAdi.Text,
                txtAciklama.Text
            };

            try
            {

                helper.setSqlCommandForUpdateWithParameters("DEPO_KARTLARI_V2", COL, VAL,"ID",ITEM_ID.ToString());
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message,"DEPO");
            }
        }

        private void DEPO_KARTI_DUZENLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2 WHERE ID="+ITEM_ID+"");
            if (dt.Rows.Count > 0)
            {
                txtDepoAdi.Text = dt.Rows[0]["DEPO_ADI"].ToString();
                txtAciklama.Text = dt.Rows[0]["ACIKLAMA"].ToString();
            }
        }
    }
}
