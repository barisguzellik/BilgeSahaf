using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.SATIS
{
    public partial class HIZLI_SATIS : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public HIZLI_SATIS()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public void getDepo()
        {
            txtDepo.DataSource = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2");
            txtDepo.DisplayMember = "DEPO_ADI";
            txtDepo.ValueMember = "ID";
        }
        void btn_Click(object sender, EventArgs e)
        {
            KryptonButton btn = sender as KryptonButton;
            DataGridViewRow dtRow = new DataGridViewRow();
            dtRow.CreateCells(dataGridView1);
            dtRow.Cells[0].Value = btn.Name;
            dataGridView1.Rows.Add(dtRow);
        }
        DefaultStyles styleHelper = new DefaultStyles();
        private void HIZLI_SATIS_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtStokSec;

            dataGridView1.Tag = "HizliSatisGrid1";
            styleHelper.dataGridColWidth(dataGridView1, dataGridView1.Tag.ToString());
            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(styleHelper.testFunc);

            getDepo();

            txtCariID.Text = "378";

            int buttonCount = 20;
            int fillButton = 0;
            int addButton = 0;
            DataTable dtPromoStok = helper.getDataTable("SELECT ID,STOK_ADI FROM STOK_KARTI_V2 WHERE OZEL_KOD_5='HIZLI_SATIS'");
            foreach (DataRow dr in dtPromoStok.Rows)
            {
                KryptonButton btn = new KryptonButton();
                btn.PaletteMode = PaletteMode.Office2010Blue;
                btn.Text = dr["STOK_ADI"].ToString();
                btn.Name = dr["ID"].ToString();
                int width = flowLayoutPanel1.Width - 35;
                btn.Width = width / 3;

                btn.Height = 50;
                btn.Click += new EventHandler(btn_Click);
                flowLayoutPanel1.Controls.Add(btn);
                fillButton++;
            }

            if (fillButton < 20)
            {
                DataTable dtPromoStokNew = helper.getDataTable("SELECT TOP 20 ID,STOK_ADI FROM STOK_KARTI_V2 ORDER BY ID DESC");
                foreach (DataRow dr in dtPromoStokNew.Rows)
                {
                    if (addButton < buttonCount - fillButton)
                    {
                        KryptonButton btn = new KryptonButton();
                        btn.PaletteMode = PaletteMode.Office2010Blue;
                        btn.Text = dr["STOK_ADI"].ToString();
                        btn.Name = dr["ID"].ToString();
                        int width = flowLayoutPanel1.Width - 35;
                        btn.Width = width / 3;

                        btn.Height = 50;
                        btn.Click += new EventHandler(btn_Click);
                        flowLayoutPanel1.Controls.Add(btn);
                        addButton++;
                    }

                }
            }



            /*DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE CARI_KODU=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }*/

            comboBanka.DataSource = helper.getDataTable("SELECT ID,BANKA_ADI FROM BANKALAR_V2 ORDER BY BANKA_ADI");
            comboBanka.ValueMember = "ID";
            comboBanka.DisplayMember = "BANKA_ADI";

            comboBanka2.DataSource = helper.getDataTable("SELECT ID,BANKA_ADI FROM BANKALAR_V2 ORDER BY BANKA_ADI");
            comboBanka2.ValueMember = "ID";
            comboBanka2.DisplayMember = "BANKA_ADI";

            comboKasa.DataSource = helper.getDataTable("SELECT ID,KASA_ADI FROM KASALAR_V2 ORDER BY KASA_ADI");
            comboKasa.ValueMember = "ID";
            comboKasa.DisplayMember = "KASA_ADI";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCariID.Text = frm.lastSelectedUser.ToString();
        }

        private void txtCariID_TextChanged_1(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
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

                            var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();

                            dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = "";
                            dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                            dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value = fiyat_1;
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = "0,00";
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";

                            dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                            dataGridView1.Rows[e.RowIndex].Cells["SON_ALIS"].Value = commonClass.getSonAlisFiyati(int.Parse(val.ToString()));

                            var kdv = 0;
                            dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value = kdv;
                            var kdv_toplam = (double.Parse(fiyat_1) * kdv) / 100;

                            var toplam = double.Parse(fiyat_1) + kdv_toplam;
                            dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;

                            var yayinevi = dt.Rows[0]["YAYINEVI"].ToString().Trim();

                            DataTable isIskonto = helper.getDataTable("SELECT TOP 1 ISKONTO_ORANI FROM YAYINEVI_ISKONTO WHERE YAYINEVI='" + yayinevi + "' ORDER BY ID DESC");
                            if (isIskonto.Rows.Count > 0)
                            {
                                var iskonto_orani = isIskonto.Rows[0][0].ToString();
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = iskonto_orani;
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";
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

        public void calculateTotals()
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
                    double ekle_kdv = ((birimFiyat - iskonto) * kdv) / 100;
                    kdvToplam += ekle_kdv;
                }
            }
            txtToplam.Text = varToplam.ToString("N");
            txtGenelToplam.Text = varGenelToplam.ToString("N");
            lblGENELTOPLAM.Text = varGenelToplam.ToString("N");
            txtIskonto.Text = varIskonto.ToString("N");

            txtKdv.Text = kdvToplam.ToString("N");
        }

        private void dataGridView1_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
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

                        dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();
                        dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = "";
                        dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                        dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value = fiyat_1;
                        dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = "0,00";
                        dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;


                        dataGridView1.Rows[e.RowIndex].Cells["SON_ALIS"].Value = commonClass.getSonAlisFiyati(int.Parse(val.ToString()));

                        var kdv = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value = kdv;
                        var kdv_toplam = (double.Parse(fiyat_1) * kdv) / 100;

                        var toplam = double.Parse(fiyat_1) + kdv_toplam;
                        dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;

                        var yayinevi = dt.Rows[0]["YAYINEVI"].ToString().Trim();

                        DataTable isIskonto = helper.getDataTable("SELECT TOP 1 ISKONTO_ORANI FROM YAYINEVI_ISKONTO WHERE YAYINEVI='" + yayinevi + "' ORDER BY ID DESC");
                        if (isIskonto.Rows.Count > 0)
                        {
                            var iskonto_orani = isIskonto.Rows[0][0].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = iskonto_orani;
                        }
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";
                        }
                    }
                }
            }
            catch
            {

            }
            calculateTotals();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
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
                "DEPO"
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
                txtDepo.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("SATIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM SATIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

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
                            lastID,
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

                string[] col2 =
                        {
                            "TARIH",
                            "EKLENME_TARIHI",
                            "TUTAR",
                            "CARI",
                            "ACIKLAMA",
                            "KASA"
                        };

                string[] val2 =
                {
                            dateFormat,
                            DateTime.Now.ToString(),
                            txtGenelToplam.Text.Replace(".","").Replace(",","."),
                            txtCariID.Text,
                            txtBelgeNo.Text + " NOLU SATIŞ FATURASI NAKİT ÖDEME",
                            comboKasa.SelectedValue.ToString()
                        };


                helper.setSqlCommandForInsertWithParameters("TAHSILATLAR_V2", col2, val2);

                resetForm();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Satış");
            }
        }

        CommonClass commonClass = new CommonClass();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        public void resetForm()
        {
            dataGridView1.Rows.Clear();
            txtParcaliTahsil.Text = "0,00";
        }

        private void txtStokSec_TextChanged(object sender, EventArgs e)
        {



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            pnlKrediKarti.Visible = true;
            pnlParcali.Visible = false;
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            pnlParcali.Visible = true;
            pnlKrediKarti.Visible = false;
        }

        private void dataGridView1_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateTotals();
        }
        bool viewSonAlis = false;
        private void sonAlışıGörGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewSonAlis)
            {
                dataGridView1.Columns["SON_ALIS"].Visible = false;
                viewSonAlis = false;
            }
            else
            {
                dataGridView1.Columns["SON_ALIS"].Visible = true;
                viewSonAlis = true;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            SIPARIS.STOK_SEC frm = new SIPARIS.STOK_SEC();
            frm.ShowDialog();
            //dataGridView1.SelectedCells[0].Value = frm.lastSelectedProduct.ToString();

            DataGridViewRow dtRow = new DataGridViewRow();
            dtRow.CreateCells(dataGridView1);
            dtRow.Cells[0].Value = frm.lastSelectedProduct.ToString();
            dataGridView1.Rows.Add(dtRow);
        }

        private void button7_Click(object sender, EventArgs e)
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
                "DEPO"
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
                txtDepo.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("SATIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM SATIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

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
                            lastID,
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



                string[] col3 =
                {
                    "TARIH",
                    "EKLENME_TARIHI",
                    "ACIKLAMA",
                    "TUTAR",
                    "BANKA",
                    "CARI"
                };
                string[] val3 =
                {
                    dateFormat,
                    DateTime.Now.ToString(),
                    txtBelgeNo.Text + " NOLU FATURA KREDİ KARTLI SATIŞ",
                    txtGenelToplam.Text.Replace(".","").Replace(",","."),
                    comboBanka.SelectedValue.ToString(),
                    txtCariID.Text
                };

                helper.setSqlCommandForInsertWithParameters("POS_TAHSIL_V2", col3, val3);
                pnlKrediKarti.Visible = false;
                resetForm();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Satış");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
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
                "DEPO"
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
                txtDepo.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("SATIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM SATIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

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
                            lastID,
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

                resetForm();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Satış");
            }
        }

        private void NAKİTBTN_Click(object sender, EventArgs e)
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
                "DEPO"
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
                txtDepo.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("SATIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM SATIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

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
                            lastID,
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

                string[] col2 =
                        {
                            "TARIH",
                            "EKLENME_TARIHI",
                            "TUTAR",
                            "CARI",
                            "ACIKLAMA",
                            "KASA"
                        };

                string[] val2 =
                {
                            dateFormat,
                            DateTime.Now.ToString(),
                            txtParcaliTahsil.Text.Replace(",","."),
                            txtCariID.Text,
                            txtBelgeNo.Text + " NOLU FATURA PARÇALI TAHSİL",
                            comboKasa.SelectedValue.ToString()
                        };


                helper.setSqlCommandForInsertWithParameters("TAHSILATLAR_V2", col2, val2);
                pnlParcali.Visible = false;
                resetForm();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Satış");
            }
        }

        private void button8_Click(object sender, EventArgs e)
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
                "DEPO"
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
                txtDepo.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("SATIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM SATIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

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
                            lastID,
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


                string[] col3 =
                {
                    "TARIH",
                    "EKLENME_TARIHI",
                    "ACIKLAMA",
                    "TUTAR",
                    "BANKA",
                    "CARI"
                };
                string[] val3 =
                {
                    dateFormat,
                    DateTime.Now.ToString(),
                    txtBelgeNo.Text + " NOLU FATURA PARÇALI KREDİ KARTLI TAHSİL",
                    txtGenelToplam.Text.Replace(".","").Replace(",","."),
                    comboBanka.SelectedValue.ToString(),
                    txtCariID.Text
                };

                helper.setSqlCommandForInsertWithParameters("POS_TAHSIL_V2", col3, val3);

                pnlParcali.Visible = false;
                resetForm();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Satış");
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Delete))
                {
                    //int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    //dataGridView1.Rows[rowIndex].Selected = true;

                }
            }
            catch { }
        }

        private void txtStokSec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtStokSec.Text.Length > 2)
                {

                    DataTable dt = helper.getDataTable("SELECT TOP 1 ID FROM STOK_KARTI_V2 WHERE STOK_KODU='" + txtStokSec.Text + "' OR BARKOD_1='" + txtStokSec.Text + "' OR BARKOD_2='" + txtStokSec.Text + "' OR BARKOD_3='" + txtStokSec.Text + "' ");

                    if (dt.Rows.Count == 1)
                    {
                        DataGridViewRow dtRow = new DataGridViewRow();
                        dtRow.CreateCells(dataGridView1);
                        dtRow.Cells[0].Value = dt.Rows[0]["ID"].ToString();
                        dataGridView1.Rows.Add(dtRow);
                        txtStokSec.Text = "";
                    }
                    else if (dt.Rows.Count == 0)
                    {
                        DataTable dtBarkod = helper.getDataTable("SELECT TOP 1 STOK_KARTI_V2.ID FROM STOK_KARTI_V2 INNER JOIN STOK_BARKODLARI ON STOK_KARTI_V2.ID=STOK_BARKODLARI.STOK_ID WHERE STOK_BARKODLARI.BARKOD='" + txtStokSec.Text + "'");
                        if (dtBarkod.Rows.Count == 1)
                        {
                            DataGridViewRow dtRow = new DataGridViewRow();
                            dtRow.CreateCells(dataGridView1);
                            dtRow.Cells[0].Value = dtBarkod.Rows[0]["ID"].ToString();
                            dataGridView1.Rows.Add(dtRow);
                            txtStokSec.Text = "";
                        }
                    }
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    int iRow = dataGridView1.CurrentCell.RowIndex;

                    if (iColumn == dataGridView1.Columns.Count - 2)
                    {
                        dataGridView1.CurrentCell = dataGridView1[1, iRow + 1];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
                    }

                    if (iRow == dataGridView1.RowCount)
                    {
                        dataGridView1.Rows.Add();
                    }
                        
                }
            }
            catch { }

            if (e.KeyData == (Keys.Control | Keys.V))
            {
                int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                int iRow = dataGridView1.CurrentCell.RowIndex;
                if(!dataGridView1.Rows[iRow].Cells[iColumn].ReadOnly)
                {
                   
                    dataGridView1.Rows[iRow].Cells[iColumn].Value = Clipboard.GetText();
                    dataGridView1.Rows.Add();
                }
                
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[0];
            }
            else
            {
                if (e.ColumnIndex != 1)
                {
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{right}");
                }
                
            }
        }
    }
}
