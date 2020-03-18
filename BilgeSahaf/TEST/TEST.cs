using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.TEST
{
    
    public partial class TEST : Form
    {
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        public TEST()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM _AKTAR_BARKOD");
            foreach(DataRow dr in dt.Rows)
            {
                string id = helper.getTableColumnData("SELECT ID FROM STOK_KARTI_V2 WHERE STOK_KODU='" + dr["STOK_KODU"] + "'","ID");
                string[] col = { "STOK_ID", "BARKOD" };
                string[] val = { id, dr["BARKOD"].ToString() };
                helper.setSqlCommandForInsertWithParameters("STOK_BARKODLARI", col, val);
            }
            MessageBox.Show("OK");
        }
    }
}
