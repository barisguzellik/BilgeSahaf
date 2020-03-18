using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR.STOK
{
    public partial class RAPOR_STOK_KARTLARI : Form
    {
        public RAPOR_STOK_KARTLARI()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();

        DataTable dt = new DataTable();
        private void RAPOR_STOK_KARTLARI_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);

            backgroundWorker1.RunWorkerAsync();
        }

        private void sORGUÇALIŞTIRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            backgroundWorker2.RunWorkerAsync();
        }

        public void processCommand()
        {
            dt = helper.getDataTable("SELECT*FROM STOK_KARTI_V2");

            int min = 0;
            int max = dt.Rows.Count;

            foreach(DataRow dr in dt.Rows)
            {
                min++;

                backgroundWorker1.ReportProgress((min * 100) / max);
            }
            
        }
        public void queryCommand()
        {
            RAPOR.RAPOR_SORGU_CALISTIR frm = new RAPOR.RAPOR_SORGU_CALISTIR();
            frm.QUERY = "SELECT*FROM STOK_KARTI_V2;";
            frm.ShowDialog();
            
            if (frm.QUERY != null && frm.QUERY != string.Empty && frm.QUERY != "")
            {
                try
                {
                    dt = helper.getDataTable(frm.QUERY);

                    int min = 0;
                    int max = dt.Rows.Count;

                    foreach (DataRow dr in dt.Rows)
                    {
                        min++;

                        backgroundWorker2.ReportProgress((min * 100) / max);
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "RAPOR");
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            processCommand();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            dataGridView1.DataSource = dt;
            toolStripStatusLabel1.Text = "Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            dataGridView1.DataSource = dt;
            toolStripStatusLabel1.Text = "Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            queryCommand();
        }
    }
}
