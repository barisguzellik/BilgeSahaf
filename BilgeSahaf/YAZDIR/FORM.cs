using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace BilgeSahaf.YAZDIR
{
    public partial class FORM : Form
    {
        public FORM()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        private void FORM_Load(object sender, EventArgs e)
        {
            

        }
        public DataTable reportData;
        private void button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = helper.getDataTable("SELECT * FROM CARI_KARTLAR_V2");
            DataTable dt = reportData;
            Report report = new Report();
            report.Load("cari-kartlar.frx");
            report.RegisterData(dt, "CARI_KARTLAR_V2");
            report.GetDataSource("CARI_KARTLAR_V2").Enabled=true;
            report.Show();
        }
    }
}
