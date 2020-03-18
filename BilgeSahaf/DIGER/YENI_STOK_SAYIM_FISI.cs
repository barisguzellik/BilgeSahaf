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
    public partial class YENI_STOK_SAYIM_FISI : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_STOK_SAYIM_FISI()
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

                            int giren = commonClass.getCalculateGiris(int.Parse(val.ToString()));
                            int cikan = commonClass.getCalculateCikis(int.Parse(val.ToString()));

                            int mevcut = giren - cikan;
                            dataGridView1.Rows[e.RowIndex].Cells["MEVCUT"].Value = mevcut;

                            dataGridView1.Rows[e.RowIndex].Cells["SAYILAN"].Value = 0;

                            if (mevcut > 0)
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = 0;
                                dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = mevcut;
                            }
                            else if (mevcut < 0)
                            {
                                var fark = 0 - mevcut;
                                dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = fark;
                                dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = 0;
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = 0;
                                dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = 0;
                            }

                        }
                    }
                }
                catch
                {

                }


            }

            if (e.ColumnIndex == 1)
            {
                try
                {
                    var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (val.ToString() != string.Empty)
                    {

                        DataTable dt = helper.getDataTable("SELECT TOP 1 ID FROM STOK_KARTI_V2 WHERE BARKOD_1='" + val + "' OR BARKOD_2='" + val + "' OR BARKOD_3='" + val + "' ");

                        if (dt.Rows.Count == 1)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["URUN_ID"].Value = dt.Rows[0]["ID"].ToString();
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            DataTable dtBarkod = helper.getDataTable("SELECT TOP 1 STOK_KARTI_V2.ID FROM STOK_KARTI_V2 INNER JOIN STOK_BARKODLARI ON STOK_KARTI_V2.ID=STOK_BARKODLARI.STOK_ID WHERE STOK_BARKODLARI.BARKOD='" + val + "'");
                            if (dtBarkod.Rows.Count == 1)
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["URUN_ID"].Value = dtBarkod.Rows[0]["ID"].ToString();
                            }
                        }

                    }
                }
                catch
                {

                }
            }

            if (e.ColumnIndex == 4)
            {
                try
                {
                    var mevcut = dataGridView1.Rows[e.RowIndex].Cells["MEVCUT"].Value.ToString();
                    var sayilan = dataGridView1.Rows[e.RowIndex].Cells["SAYILAN"].Value.ToString();

                    if (int.Parse(sayilan) > int.Parse(mevcut))
                    {
                        var fark = int.Parse(sayilan) - int.Parse(mevcut);
                        dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = fark;
                        dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = 0;
                    }
                    else if (int.Parse(sayilan) < int.Parse(mevcut))
                    {
                        var fark = int.Parse(mevcut) - int.Parse(sayilan);
                        dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = fark;
                        dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = 0;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = 0;
                    }
                }
                catch
                {

                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SIPARIS.STOK_SEC frm = new SIPARIS.STOK_SEC();
                frm.ShowDialog();
                //dataGridView1.SelectedCells[0].Value = frm.lastSelectedProduct.ToString();

                DataGridViewRow dtRow = new DataGridViewRow();
                dtRow.CreateCells(dataGridView1);
                dtRow.Cells[0].Value = frm.lastSelectedProduct.ToString();
                dataGridView1.Rows.Add(dtRow);
            }
        }

        public void getDepo()
        {
            txtDepo.DataSource = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2");
            txtDepo.DisplayMember = "DEPO_ADI";
            txtDepo.ValueMember = "ID";
        }

        DefaultStyles style = new DefaultStyles();
        CommonClass commonClass = new CommonClass();

        private void YENI_SATIS_FATURASI_Load(object sender, EventArgs e)
        {
            getDepo();

        }

        public void calculateTotals()
        {

        }

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

                        int giren = commonClass.getCalculateGiris(int.Parse(val.ToString()));
                        int cikan = commonClass.getCalculateCikis(int.Parse(val.ToString()));

                        int mevcut = giren - cikan;
                        dataGridView1.Rows[e.RowIndex].Cells["MEVCUT"].Value = mevcut;

                        dataGridView1.Rows[e.RowIndex].Cells["SAYILAN"].Value = 0;

                        if (mevcut > 0)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = 0;
                            dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = mevcut;
                        }
                        else if (mevcut < 0)
                        {
                            var fark = 0 - mevcut;
                            dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = fark;
                            dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = 0;
                        }
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["EKLENECEK"].Value = 0;
                            dataGridView1.Rows[e.RowIndex].Cells["CIKARILACAK"].Value = 0;
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

                        if(int.Parse(row.Cells["EKLENECEK"].Value.ToString())>0)
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
                            helper.setSqlCommandForInsertWithParameters("STOK_GIRIS_URUNLER", childColFisGiris,childValFisGiris);
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
