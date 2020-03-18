using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR.FATURA
{
    public partial class RAPOR_KDV_RAPORU : Form
    {
        public RAPOR_KDV_RAPORU()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();
        public void generateMonth()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VALUE");
            dt.Columns.Add("TEXT");

            dt.Rows.Add("01", "OCAK");
            dt.Rows.Add("02", "ŞUBAT");
            dt.Rows.Add("03", "MART");
            dt.Rows.Add("04", "NİSAN");
            dt.Rows.Add("05", "MAYIS");
            dt.Rows.Add("06", "HAZİRAN");
            dt.Rows.Add("07", "TEMMUZ");
            dt.Rows.Add("08", "AĞUSTOS");
            dt.Rows.Add("09", "EYLÜL");
            dt.Rows.Add("10", "EKİM");
            dt.Rows.Add("11", "KASIM");
            dt.Rows.Add("12", "ARALIK");

            
        }
        private void RAPOR_KDV_RAPORU_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);
            getResult();
            
        }
        public void getResult()
        {
            DateTime dtTime = Convert.ToDateTime(dateTimePicker1.Text);

            string dateFormat1 = dtTime.Year + "-" + dtTime.Month + "-01";
            string dateFormat2 = dtTime.Year + "-" + dtTime.Month + "-" + DateTime.DaysInMonth(dtTime.Year, dtTime.Month);


            DataTable dt = new DataTable();
            dt.Columns.Add("SATIS_FATURALARI_KDV", typeof(double));
            dt.Columns.Add("ALIS_FATURALARI_KDV", typeof(double));
            dt.Columns.Add("ODENECEK_KDV", typeof(double));


            dataGridView1.DataSource = dt;
            dt.Rows.Add();

            dataGridView1.Rows[0].Cells[0].Value = commonClass.getSatisFaturalariTotal(dateFormat1, dateFormat2);
            dataGridView1.Rows[0].Cells[1].Value = commonClass.getAlisFaturalariTotal(dateFormat1, dateFormat2);
            dataGridView1.Rows[0].Cells[2].Value = double.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString()) - double.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString());


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getResult();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styles.dataGridFormatNumber(dataGridView1);
        }
    }
}
