using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR.BANKA
{
    public partial class RAPOR_BANKA_RAPORU : Form
    {
        public RAPOR_BANKA_RAPORU()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();
        private void RAPOR_KASA_RAPORU_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);

            processCommand();
        }
        public void processCommand()
        {
            DateTime dtTime1 = Convert.ToDateTime(date1.Text);
            DateTime dtTime2 = Convert.ToDateTime(date2.Text);

            string dateFormat1 = dtTime1.Year + "-" + dtTime1.Month + "-" + dtTime1.Day;
            string dateFormat2 = dtTime2.Year + "-" + dtTime2.Month + "-" + dtTime2.Day;

            DataTable dt = helper.getDataTable("SELECT*FROM BANKALAR_V2");
            dt.Columns.Add("GIRISLER", typeof(double));
            dt.Columns.Add("CIKISLAR", typeof(double));
            dt.Columns.Add("BAKIYE", typeof(double));

            foreach(DataRow dr in dt.Rows)
            {
                dt.Rows[0]["GIRISLER"] = commonClass.getCalculateBankaGiris(int.Parse(dr["ID"].ToString()),dateFormat1, dateFormat2);
                dt.Rows[0]["CIKISLAR"] = commonClass.getCalculateBankaCikis(int.Parse(dr["ID"].ToString()), dateFormat1, dateFormat2);
                dt.Rows[0]["BAKIYE"] = double.Parse(dt.Rows[0]["GIRISLER"].ToString()) - double.Parse(dt.Rows[0]["CIKISLAR"].ToString());
            }

            dataGridView1.DataSource = dt;

        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            processCommand();
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            processCommand();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styles.dataGridFormatNumber(dataGridView1);
        }
    }
}
