using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.STOK
{
    public partial class STOK_KARTI_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public int ITEM_ID = 0;
        public STOK_KARTI_DUZENLE()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        private void STOK_KARTI_DUZENLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM STOK_KARTI_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    txtBarkod1.Text = row["BARKOD_1"].ToString();
                    txtBarkod2.Text = row["BARKOD_2"].ToString();
                    txtBarkod3.Text = row["BARKOD_3"].ToString();
                    txtBirimi.Text= row["BIRIM"].ToString();
                    txtFiyat1.Text= row["FIYAT_1"].ToString();
                    txtFiyat2.Text= row["FIYAT_2"].ToString();
                    txtFiyat3.Text= row["FIYAT_3"].ToString();
                    txtFiyat4.Text= row["FIYAT_4"].ToString();
                    txtFiyat5.Text= row["FIYAT_5"].ToString();
                    txtGrubu.Text= row["GRUBU"].ToString();
                    txtOzelKod1.Text= row["OZEL_KOD_1"].ToString();
                    txtOzelKod2.Text= row["OZEL_KOD_2"].ToString();
                    txtOzelKod3.Text= row["OZEL_KOD_3"].ToString();
                    txtOzelKod4.Text= row["OZEL_KOD_4"].ToString();
                    txtOzelKod5.Text= row["OZEL_KOD_5"].ToString();
                    txtStokAdi.Text= row["STOK_ADI"].ToString();
                    txtStokKodu.Text= row["STOK_KODU"].ToString();
                    txtYayinEvi.Text= row["YAYINEVI"].ToString();
                    txtYazar.Text= row["YAZAR"].ToString();
                    txtMinStok.Text = row["MINIMUM_STOK"].ToString();
                    txtMakStok.Text = row["MAKSIMUM_STOK"].ToString();
                    txtDoviz.Text = row["DOVIZ"].ToString();


                    DataTable dtProduct = helper.getDataTable("SELECT*FROM STOK_BARKODLARI WHERE STOK_ID=" + ITEM_ID + "");
                    dataBarkod.Rows.Clear();
                    foreach (DataRow rowChild in dtProduct.Rows)
                    {
                        DataGridViewRow insertRow = new DataGridViewRow();
                        insertRow.CreateCells(dataBarkod);
                        insertRow.Cells[0].Value = rowChild["BARKOD"].ToString();
                        dataBarkod.Rows.Add(insertRow);
                    }

                }
            }
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kARTISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM STOK_KARTI_V2 WHERE ID=" + ITEM_ID + "");
                helper.setSqlCommand("DELETE FROM STOK_BARKODLARI WHERE STOK_ID=" + ITEM_ID + "");
                this.Close();

            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] col = {
                "STOK_KODU",
                "STOK_ADI",
                "YAZAR",
                "YAYINEVI",
                "GRUBU",
                "OZEL_KOD_1",
                "OZEL_KOD_2",
                "OZEL_KOD_3",
                "OZEL_KOD_4",
                "OZEL_KOD_5",
                "BIRIM",
                "BARKOD_1",
                "BARKOD_2",
                "BARKOD_3",
                "FIYAT_1",
                "FIYAT_2",
                "FIYAT_3",
                "FIYAT_4",
                "FIYAT_5",
                "MINIMUM_STOK",
                "MAKSIMUM_STOK",
                "DOVIZ"
            };
            string[] val = {
                txtStokKodu.Text,
                txtStokAdi.Text,
                txtYazar.Text,
                txtYayinEvi.Text,
                txtGrubu.Text,
                txtOzelKod1.Text,
                txtOzelKod2.Text,
                txtOzelKod3.Text,
                txtOzelKod4.Text,
                txtOzelKod5.Text,
                txtBirimi.Text,
                txtBarkod1.Text,
                txtBarkod2.Text,
                txtBarkod3.Text,
                txtFiyat1.Text.Replace(",","."),
                txtFiyat2.Text.Replace(",","."),
                txtFiyat3.Text.Replace(",","."),
                txtFiyat4.Text.Replace(",","."),
                txtFiyat5.Text.Replace(",","."),
                txtMinStok.Text,
                txtMakStok.Text,
                txtDoviz.Text
            };
            try
            {
                helper.setSqlCommandForUpdateWithParameters("STOK_KARTI_V2", col, val,"ID",ITEM_ID.ToString());

                helper.setSqlCommand("DELETE FROM STOK_BARKODLARI WHERE STOK_ID=" + ITEM_ID + "");
                foreach (DataGridViewRow row in dataBarkod.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string[] childCol = { "STOK_ID", "BARKOD" };
                        string[] childVal = {
                            ITEM_ID.ToString(),
                            row.Cells[0].Value.ToString(),
                        };
                        helper.setSqlCommandForInsertWithParameters("STOK_BARKODLARI", childCol, childVal);
                    }
                }

                MessageBox.Show("Stok kaydedildi...", "Stok");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Stok");
            }

        }
    }
}
