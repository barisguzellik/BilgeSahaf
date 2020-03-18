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
    public partial class RAPOR_STOK_ENVANTER : Form
    {
        public int STOK_ID = 0;

        public RAPOR_STOK_ENVANTER()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();

        DataTable dt = new DataTable();

        public void processCommand()
        {
            if (STOK_ID == 0)
            {
                dt = helper.getDataTable("SELECT * FROM VIEW_STOK_KARTLARI");
            }
            else
            {
                dt = helper.getDataTable("SELECT * FROM STOK_KARTI_V2 WHERE ID=" + STOK_ID + "");
            }
            dataGridView1.DataSource = dt;

            /*dt.Columns.Add("GIREN", typeof(int));
            dt.Columns.Add("CIKAN", typeof(int));
            dt.Columns.Add("KALAN", typeof(int));

            int min = 0;
            int max = dt.Rows.Count;

            foreach (DataRow dr in dt.Rows)
            {
                min++;

                dr["GIREN"] = commonClass.getCalculateGiris(int.Parse(dr["ID"].ToString()));
                dr["CIKAN"] = commonClass.getCalculateCikis(int.Parse(dr["ID"].ToString()));
                dr["KALAN"] = int.Parse(dr["GIREN"].ToString()) - int.Parse(dr["CIKAN"].ToString());

                backgroundWorker1.ReportProgress((min * 100) / max);
            }*/
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
                    dt.Columns.Add("GIREN", typeof(int));
                    dt.Columns.Add("CIKAN", typeof(int));
                    dt.Columns.Add("KALAN", typeof(int));

                    int min = 0;
                    int max = dt.Rows.Count;

                    foreach (DataRow dr in dt.Rows)
                    {
                        min++;

                        dr["GIREN"] = commonClass.getCalculateGiris(int.Parse(dr["ID"].ToString()));
                        dr["CIKAN"] = commonClass.getCalculateCikis(int.Parse(dr["ID"].ToString()));
                        dr["KALAN"] = int.Parse(dr["GIREN"].ToString()) - int.Parse(dr["CIKAN"].ToString());

                        backgroundWorker2.ReportProgress((min * 100) / max);
                    }
                   
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "RAPOR");
                }
            }
        }

        private void RAPOR_STOK_ENVANTER_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);

            //backgroundWorker1.RunWorkerAsync();
            processCommand();

        }

        private void sORGUÇALIŞTIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            queryCommand();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            dataGridView1.DataSource = dt;
            toolStripStatusLabel1.Text = "Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styles.dataGridFormatNumber(dataGridView1);
        }
    }
}
