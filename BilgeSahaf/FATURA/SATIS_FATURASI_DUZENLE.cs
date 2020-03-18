using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
{
    public partial class SATIS_FATURASI_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public SATIS_FATURASI_DUZENLE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCariID.Text = frm.lastSelectedUser.ToString();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void txtCariID_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }
        }

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
                            var fiyat_1 = dt.Rows[0]["FIYAT_1"].ToString();

                            dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                            dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value = fiyat_1;
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = "0,00";
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";

                            dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = "";

                            var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                            var kdv = 0;
                            dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value = kdv;
                            var kdv_toplam = (double.Parse(fiyat_1) * kdv) / 100;

                            var toplam = double.Parse(fiyat_1) + kdv_toplam;
                            dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;
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
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                try
                {
                    var adet = dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value.ToString();
                    var fiyat = dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value.ToString();
                    var kdv = dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value.ToString();
                    var iskonto = dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value.ToString();
                    var iskonto_oran = dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value.ToString();
                    double iskontolu_fiyat = 0;

                    if (iskonto_oran == "0")
                    {
                        iskontolu_fiyat = double.Parse(fiyat) - double.Parse(iskonto);
                    }
                    else
                    {
                        double iskontolubirim = (double.Parse(fiyat) * double.Parse(iskonto_oran)) / 100;
                        iskontolu_fiyat = double.Parse(fiyat) - iskontolubirim;
                        dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = iskontolubirim.ToString();
                    }

                    double tutar = (iskontolu_fiyat) * double.Parse(adet);
                    var kdv_toplam = (tutar * double.Parse(kdv)) / 100;
                    double toplam = ((iskontolu_fiyat) * double.Parse(adet)) + kdv_toplam;
                    dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;

                    calculateTotals();
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

        public bool firstProductLoad = false;

        public void getDepo()
        {
            txtDepo.DataSource = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2");
            txtDepo.DisplayMember = "DEPO_ADI";
            txtDepo.ValueMember = "ID";
        }

        private void YENI_SATIS_FATURASI_Load(object sender, EventArgs e)
        {
            getDepo();
            DataTable dt = helper.getDataTable("SELECT*FROM SATIS_FATURALARI_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    txtCariID.Text = row["CARI"].ToString();
                    txtTarih.Text = row["TARIH"].ToString();
                    txtGenelToplam.Text = row["GENEL_TOPLAM"].ToString();
                    txtIskonto.Text = row["ISKONTO_TOPLAM"].ToString();
                    txtKdv.Text = row["KDV_TOPLAM"].ToString();
                    txtToplam.Text = row["TOPLAM"].ToString();
                    txtUnvani.Text = row["CARI_UNVANI"].ToString();
                    txtBelgeNo.Text = row["BELGE_NUMARASI"].ToString();
                    txtFaturaNo.Text = row["FATURA_NUMARASI"].ToString();
                    txtSatisElemani.Text = row["SATIS_ELEMANI"].ToString();

                    txtBelgeNotu.Text = row["ACIKLAMA"].ToString();
                    try
                    {
                        txtDepo.SelectedValue = row["DEPO"].ToString();
                    }
                    catch { }

                    Thread thread = new Thread(new ThreadStart(threadProcess));
                    thread.Start();

                }
            }
        }

        public void threadProcess()
        {
            DataTable dtProduct = helper.getDataTable("SELECT*FROM FUNC_GET_SATIS_FATURA_DETAY(" + ITEM_ID + ")");
            int rowsCount = 1;


            this.Invoke((MethodInvoker)delegate
            {
                dataGridView1.Rows.Clear();
            });

            foreach (DataRow rowChild in dtProduct.Rows)
            {
                DataGridViewRow insertRow = new DataGridViewRow();
                insertRow.CreateCells(dataGridView1);
                insertRow.Cells[0].Value = rowChild["URUN_ID"].ToString();
                insertRow.Cells[1].Value = rowChild["BARKOD_1"].ToString();
                insertRow.Cells[2].Value = rowChild["STOK_ADI"].ToString();
                insertRow.Cells[3].Value = rowChild["ACIKLAMA"].ToString();
                insertRow.Cells[4].Value = rowChild["MIKTAR"].ToString();
                insertRow.Cells[5].Value = rowChild["BIRIM_FIYAT"].ToString();
                insertRow.Cells[6].Value = rowChild["ISKONTO_ORAN"].ToString();
                insertRow.Cells[7].Value = rowChild["ISKONTO"].ToString();
                insertRow.Cells[8].Value = rowChild["KDV_ORANI"].ToString();
                insertRow.Cells[9].Value = rowChild["TOPLAM"].ToString();

                rowsCount++;

                this.Invoke((MethodInvoker)delegate
                {
                    dataGridView1.Rows.Add(insertRow);
                });
            }
            firstProductLoad = true;
        }

        public void calculateTotals()
        {
            if (firstProductLoad)
            {
                double varToplam = 0;
                double varGenelToplam = 0;
                double varIskonto = 0;
                double kdvToplam = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ADET"].Value != null && row.Cells["BIRIM_FIYAT"].Value != null)
                    {
                        var birimFiyat = double.Parse(row.Cells["BIRIM_FIYAT"].Value.ToString());
                        var adet = double.Parse(row.Cells["ADET"].Value.ToString());
                        var iskonto = double.Parse(row.Cells["ISKONTO"].Value.ToString());
                        double insertToplam = (birimFiyat) * adet;
                        varToplam += insertToplam;
                    }
                    if (row.Cells["ISKONTO"].Value != null)
                    {
                        double kalem_adet = double.Parse(row.Cells["ADET"].Value.ToString());
                        double kalem_iskonto = double.Parse(row.Cells["ISKONTO"].Value.ToString());
                        var ekle_iskonto = kalem_adet * kalem_iskonto;
                        varIskonto += ekle_iskonto;
                    }
                    if (row.Cells["TOPLAM"].Value != null)
                    {
                        varGenelToplam += double.Parse(row.Cells["TOPLAM"].Value.ToString());
                    }
                    if (row.Cells["KDV"].Value != null)
                    {
                        var kdv = double.Parse(row.Cells["KDV"].Value.ToString());
                        var birimFiyat = double.Parse(row.Cells["BIRIM_FIYAT"].Value.ToString());
                        var iskonto = double.Parse(row.Cells["ISKONTO"].Value.ToString());
                        var adet = double.Parse(row.Cells["ADET"].Value.ToString());
                        double ekle_kdv = (((birimFiyat - iskonto) * adet) * kdv) / 100;
                        kdvToplam += ekle_kdv;
                    }
                }
                txtToplam.Text = varToplam.ToString("N");
                txtGenelToplam.Text = varGenelToplam.ToString("N");
                txtIskonto.Text = varIskonto.ToString("N");

                txtKdv.Text = kdvToplam.ToString("N");
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (firstProductLoad)
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
                            var fiyat_1 = dt.Rows[0]["FIYAT_1"].ToString();

                            var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                            dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();
                            if (firstProductLoad)
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                                dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = "";
                                dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value = fiyat_1;
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = "0,00";

                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";

                                var kdv = 0;
                                dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value = kdv;
                                var kdv_toplam = (double.Parse(fiyat_1) * kdv) / 100;

                                var toplam = double.Parse(fiyat_1) + kdv_toplam;
                                dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;
                            }

                        }
                    }
                }
                catch
                {

                }
                calculateTotals();
            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;
            string[] col =
            {
                "TARIH",
                "EKLENME_TARIHI",
                "CARI",
                "CARI_UNVANI",
                "TOPLAM",
                "ISKONTO_TOPLAM",
                "KDV_TOPLAM",
                "GENEL_TOPLAM",
                "BELGE_NUMARASI",
                "FATURA_NUMARASI",
                "SATIS_ELEMANI",
                "DEPO",
                "ACIKLAMA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtCariID.Text,
                txtUnvani.Text,
                txtToplam.Text.Replace(".","").Replace(",","."),
                txtIskonto.Text.Replace(".","").Replace(",","."),
                txtKdv.Text.Replace(".","").Replace(",","."),
                txtGenelToplam.Text.Replace(".","").Replace(",","."),
                txtBelgeNo.Text,
                txtFaturaNo.Text,
                txtSatisElemani.Text,
                txtDepo.SelectedValue.ToString(),
                txtBelgeNotu.Text
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("SATIS_FATURALARI_V2", col, val, "ID", ITEM_ID.ToString());

                helper.setSqlCommand("DELETE FROM SATIS_FATURA_URUNLER WHERE SATIS_FATURA_ID=" + ITEM_ID + "");
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string[] childCol ={
                            "SATIS_FATURA_ID",
                            "URUN_ID",
                            "MIKTAR",
                            "BIRIM_FIYAT",
                            "KDV_ORANI",
                            "TOPLAM",
                            "ISKONTO",
                            "ISKONTO_ORAN",
                            "ACIKLAMA"
                        };
                        string[] childVal ={
                            ITEM_ID.ToString(),
                            row.Cells["URUN_ID"].Value.ToString(),
                            row.Cells["ADET"].Value.ToString(),
                            row.Cells["BIRIM_FIYAT"].Value.ToString().Replace(",","."),
                            row.Cells["KDV"].Value.ToString(),
                            row.Cells["TOPLAM"].Value.ToString().Replace(",","."),
                            row.Cells["ISKONTO"].Value.ToString().Replace(",","."),
                            row.Cells["ISKONTO_ORAN"].Value.ToString().Replace(",","."),
                            row.Cells["ACIKLAMA"].Value.ToString()
                        };
                        helper.setSqlCommandForInsertWithParameters("SATIS_FATURA_URUNLER", childCol, childVal);

                    }
                }


                //MessageBox.Show("Fatura kaydedildi...", "Fatura");
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Fatura");
            }

        }

        public int ITEM_ID = 0;
        private void fATURAYISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM SATIS_FATURALARI_V2 WHERE ID=" + ITEM_ID + "");
                helper.setSqlCommand("DELETE FROM SATIS_FATURA_URUNLER WHERE SATIS_FATURA_ID=" + ITEM_ID + "");

                this.Close();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateTotals();
        }
    }
}
