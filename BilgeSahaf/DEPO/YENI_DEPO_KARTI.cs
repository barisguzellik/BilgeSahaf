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
    public partial class YENI_DEPO_KARTI : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_DEPO_KARTI()
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

                helper.setSqlCommandForInsertWithParameters("DEPO_KARTLARI_V2", COL, VAL);
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message,"DEPO");
            }
        }

        private void YENI_DEPO_KARTI_Load(object sender, EventArgs e)
        {

        }
    }
}
