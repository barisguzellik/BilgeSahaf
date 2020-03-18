using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR.CARI
{
    public partial class RAPOR_CARI_BAKIYE : Form
    {
        public RAPOR_CARI_BAKIYE()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();

        public int CARI_ID = 0;

        DataTable dt = new DataTable();

        private void RAPOR_STOK_ENVANTER_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);

            processCommand();

            //backgroundWorker1.RunWorkerAsync();

        }

        public void processCommand()
        {
            if (CARI_ID == 0)
            {
                dt = helper.getDataTable("SELECT * FROM VIEW_CARI_KARTLAR");

                dataGridView1.DataSource = dt;
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();

                dt = helper.getDataTable("SELECT * FROM CARI_KARTLAR_V2 WHERE ID=" + CARI_ID + "");

                dt.Columns.Add("ALACAK", typeof(double));
                dt.Columns.Add("BORC", typeof(double));
                dt.Columns.Add("BAKIYE", typeof(double));
                dt.Columns.Add("A/B", typeof(string));

                int min = 0;
                int max = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
                    min++;


                    dr["ALACAK"] = commonClass.getCariAlacak(int.Parse(dr[0].ToString()));
                    dr["BORC"] = commonClass.getCariBorc(int.Parse(dr[0].ToString()));
                    dr["BAKIYE"] = double.Parse(dr["BORC"].ToString()) - double.Parse(dr["ALACAK"].ToString());
                    string abReport = "A";
                    if (double.Parse(dr["BORC"].ToString()) > double.Parse(dr["ALACAK"].ToString()))
                    {
                        abReport = "B";
                    }
                    else if (double.Parse(dr["BORC"].ToString()) == double.Parse(dr["ALACAK"].ToString()))
                    {
                        abReport = "-";
                    }
                    dr["A/B"] = abReport;

                    backgroundWorker1.ReportProgress((min * 100) / max);
                }

            }

            


        }

        public void queryCommand()
        {
            RAPOR.RAPOR_SORGU_CALISTIR frm = new RAPOR.RAPOR_SORGU_CALISTIR();
            frm.QUERY = "SELECT*FROM CARI_KARTLAR_V2;";
            frm.ShowDialog();
            if (frm.QUERY != null && frm.QUERY != string.Empty && frm.QUERY != "")
            {



                try
                {
                    dt = helper.getDataTable(frm.QUERY);
                    dt.Columns.Add("ALACAK", typeof(double));
                    dt.Columns.Add("BORC", typeof(double));
                    dt.Columns.Add("BAKIYE", typeof(double));
                    dt.Columns.Add("A/B", typeof(string));

                    int min = 0;
                    int max = dt.Rows.Count;

                    foreach (DataRow dr in dt.Rows)
                    {
                        min++;

                        dr["ALACAK"] = commonClass.getCariAlacak(int.Parse(dr[0].ToString()));
                        dr["BORC"] = commonClass.getCariBorc(int.Parse(dr[0].ToString()));
                        dr["BAKIYE"] = double.Parse(dr["BORC"].ToString()) - double.Parse(dr["ALACAK"].ToString());
                        string abReport = "A";
                        if (double.Parse(dr["BORC"].ToString()) > double.Parse(dr["ALACAK"].ToString()))
                        {
                            abReport = "B";
                        }
                        else if (double.Parse(dr["BORC"].ToString()) == double.Parse(dr["ALACAK"].ToString()))
                        {
                            abReport = "-";
                        }
                        dr["A/B"] = abReport;
                        backgroundWorker2.ReportProgress((min * 100) / max);
                    }

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "RAPOR");
                }
            }
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
