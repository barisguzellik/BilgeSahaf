using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.DIGER
{
    public partial class STOK_SAYIM_FISI_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public STOK_SAYIM_FISI_DUZENLE()
        {
            InitializeComponent();
        }



        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();


        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (val.ToString() != string.Empty)
                    {
                        DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM STOK_KARTI_V2 WHERE ID=" + val.ToString() + "");
                        if (dt.Rows.Count > 0)
                        {
                            var stokAdi = dt.Rows[0]["STOK_ADI"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();

                            var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                        }
                    }
                }
                catch
                {

                }

            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void getDepo()
        {
            txtDepo.DataSource = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2");
            txtDepo.DisplayMember = "DEPO_ADI";
            txtDepo.ValueMember = "ID";
        }

        DefaultStyles style = new DefaultStyles();
        CommonClass commonClass = new CommonClass();

        public int ITEM_ID = 0;

        private void YENI_SATIS_FATURASI_Load(object sender, EventArgs e)
        {
            getDepo();

            DataTable dt = helper.getDataTable("SELECT*FROM STOK_SAYIM_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    txtTarih.Text = row["TARIH"].ToString();
                    txtBelgeNo.Text = row["BELGE_NUMARASI"].ToString();
                    txtAciklama.Text = row["ACIKLAMA"].ToString();

                    try
                    {
                        txtDepo.SelectedValue = row["DEPO"].ToString();
                    }
                    catch { }

                    DataTable dtProduct = helper.getDataTable("SELECT*FROM STOK_SAYIM_URUNLER WHERE FIS_ID=" + ITEM_ID + "");
                    int rowsCount = 1;
                    dataGridView1.Rows.Clear();
                    foreach (DataRow rowChild in dtProduct.Rows)
                    {
                        DataGridViewRow insertRow = new DataGridViewRow();
                        insertRow.CreateCells(dataGridView1);
                        insertRow.Cells[0].Value = rowChild["URUN_ID"].ToString();
                        insertRow.Cells[3].Value = rowChild["SAYILAN"].ToString();
                        dataGridView1.Rows.Add(insertRow);
                        rowsCount++;
                    }
                    firstProductLoad = true;
                }

            }
        }
        public void calculateTotals()
        {

        }
        bool firstProductLoad = false;
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                var val = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                if (val.ToString() != string.Empty)
                {
                    DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM STOK_KARTI_V2 WHERE ID=" + val.ToString() + "");
                    if (dt.Rows.Count > 0)
                    {
                        var stokAdi = dt.Rows[0]["STOK_ADI"].ToString();
                        dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();

                        var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();
                        dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                        if (firstProductLoad)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["SAYILAN"].Value = 0;
                        }
                    }
                }
            }
            catch
            {

            }
            calculateTotals();
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;
            string[] col =
            {
                "TARIH",
                "EKLENME_TARIHI",
                "BELGE_NUMARASI",
                "DEPO",
                "ACIKLAMA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtBelgeNo.Text,
                txtDepo.SelectedValue.ToString(),
                txtAciklama.Text
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("STOK_SAYIM_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM STOK_SAYIM_V2 ORDER BY ID DESC", "ID");

                string[] colFis =
             {
                "TARIH",
                "EKLENME_TARIHI",
                "CARI",
                "CARI_UNVANI",
                "BELGE_NUMARASI",
                "DEPO"
            };

                string[] valFis =
                {
                dateFormat,
                DateTime.Now.ToString(),
                "488",
                "STOK SAYIM",
                txtBelgeNo.Text,
                txtDepo.SelectedValue.ToString()
            };

                helper.setSqlCommandForInsertWithParameters("STOK_GIRISLERI_V2", colFis, valFis);
                string lastIDGiris = helper.getTableColumnData("SELECT TOP 1 ID FROM STOK_GIRISLERI_V2 ORDER BY ID DESC", "ID");

                helper.setSqlCommandForInsertWithParameters("STOK_CIKISLARI_V2", colFis, valFis);
                string lastIDCikis = helper.getTableColumnData("SELECT TOP 1 ID FROM STOK_CIKISLARI_V2 ORDER BY ID DESC", "ID");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string[] childCol ={
                            "FIS_ID",
                            "URUN_ID",
                            "SAYILAN"
                        };
                        string[] childVal ={
                            lastID,
                            row.Cells["URUN_ID"].Value.ToString(),
                            row.Cells["SAYILAN"].Value.ToString()
                        };
                        helper.setSqlCommandForInsertWithParameters("STOK_SAYIM_URUNLER", childCol, childVal);

                        if (int.Parse(row.Cells["EKLENECEK"].Value.ToString()) > 0)
                        {
                            string[] childColFisGiris ={
                            "STOK_GIRIS_ID",
                            "URUN_ID",
                            "MIKTAR"
                            };
                            string[] childValFisGiris ={
                            lastIDGiris,
                            row.Cells["URUN_ID"].Value.ToString(),
                            row.Cells["EKLENECEK"].Value.ToString()
                            };
                            helper.setSqlCommandForInsertWithParameters("STOK_GIRIS_URUNLER", childColFisGiris, childValFisGiris);
                        }

                        if (int.Parse(row.Cells["CIKARILACAK"].Value.ToString()) > 0)
                        {
                            string[] childColFisCikis ={
                            "STOK_CIKIS_ID",
                            "URUN_ID",
                            "MIKTAR"
                            };
                            string[] childValFisCikis ={
                            lastIDCikis,
                            row.Cells["URUN_ID"].Value.ToString(),
                            row.Cells["CIKARILACAK"].Value.ToString()
                            };
                            helper.setSqlCommandForInsertWithParameters("STOK_CIKIS_URUNLER", childColFisCikis, childValFisCikis);
                        }

                    }
                }



                MessageBox.Show("Fiş kaydedildi...", "Fiş");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Fiş");
            }

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateTotals();
        }
    }
}
