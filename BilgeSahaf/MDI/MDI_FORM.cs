using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.MDI
{
    public partial class MDI_FORM : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        CommonClass commonClass = new CommonClass();

        public MDI_FORM()
        {
            InitializeComponent();
        }


        private void MDI_FORM_Load(object sender, EventArgs e)
        {
            //TEST.TEST frmTest = new TEST.TEST();
            //frmTest.ShowDialog();

            SATIS.HIZLI_SATIS frm = new SATIS.HIZLI_SATIS();

            //openTabPanes(frm, "HIZLI_SATIS");

            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
            _isNetworkOnline = NetworkInterface.GetIsNetworkAvailable();

            if (_isNetworkOnline)
            {
                connectionFalse.Visible = false;
                connectionTrue.Visible = true;
            }
            else
            {
                connectionFalse.Visible = true;
                connectionTrue.Visible = false;
            }
        }
        bool _isNetworkOnline;
        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            _isNetworkOnline = e.IsAvailable;

            if (_isNetworkOnline)
            {
                connectionFalse.Visible = false;
                connectionTrue.Visible = true;
            }
            else
            {
                connectionFalse.Visible = true;
                connectionTrue.Visible = false;
            }
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            STOK.STOK_KARTLARI frm = new STOK.STOK_KARTLARI();

            commonClass.openFormOnMdi(frm, this);
        }

        private void çIKIŞYAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yENİSTOKKARTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            STOK.YENI_STOK_KARTI frm = new STOK.YENI_STOK_KARTI();
            commonClass.openFormOnMdi(frm, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            STOK.STOK_KARTLARI frm = new STOK.STOK_KARTLARI();

            //openTabPanes(frm, "STOK_KARTLARI");

            openTabPanesTwo(frm, "STOK_KARTLARI");

            //commonClass.openFormOnMdi(frm, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CARI.CARI_KARTLAR frm = new CARI.CARI_KARTLAR();
            openTabPanesTwo(frm, "CARI_KARTLAR");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SIPARIS.ALINAN_SIPARISLER frm = new SIPARIS.ALINAN_SIPARISLER();
            openTabPanes(frm, "ALINAN_SIPARISLER");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SIPARIS.VERILEN_SIPARISLER frm = new SIPARIS.VERILEN_SIPARISLER();
            openTabPanes(frm, "VERILEN_SIPARISLER");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CARI.CARI_KARTLAR frm = new CARI.CARI_KARTLAR();
            commonClass.openFormOnMdi(frm, this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SIPARIS.ALINAN_SIPARISLER frm = new SIPARIS.ALINAN_SIPARISLER();
            commonClass.openFormOnMdi(frm, this);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SIPARIS.VERILEN_SIPARISLER frm = new SIPARIS.VERILEN_SIPARISLER();
            commonClass.openFormOnMdi(frm, this);
        }

        private void sİPARİŞLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vERİLENSİPARİŞLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cARİKARTLARToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FATURA.SATIS_FATURALARI frm = new FATURA.SATIS_FATURALARI();
            openTabPanes(frm, "SATIS_FATURALARI");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FATURA.ALIS_FATURALARI frm = new FATURA.ALIS_FATURALARI();
            openTabPanes(frm, "ALIS_FATURALARI");
        }

        private void aLIŞFATURALARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sATIŞFATURALARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FATURA.ALIS_FATURALARI frm = new FATURA.ALIS_FATURALARI();
            commonClass.openFormOnMdi(frm, this);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FATURA.SATIS_FATURALARI frm = new FATURA.SATIS_FATURALARI();
            commonClass.openFormOnMdi(frm, this);
        }

        private void kASAToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            KASA.KASALAR frm = new KASA.KASALAR();
            openTabPanes(frm, "KASALAR");
        }

        private void sTOKGİRİŞLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOKÇIKIŞLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SATIS.HIZLI_SATIS frm = new SATIS.HIZLI_SATIS();
            commonClass.openFormOnMdi(frm, this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SATIS.HIZLI_SATIS frm = new SATIS.HIZLI_SATIS();
            openTabPanesTwo(frm, "HIZLI_SATIS");


        }

        private void hIZLISATIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOKKARTLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void openTabPanes(Form frm, string name)
        {
            frm.TopLevel = false;
            //TabPage tp = new TabPage();
            KryptonPage tp = new KryptonPage();
            tp.Width = tabControl1.Width;
            tp.Height = tabControl1.Height-20;
            tp.Text = frm.Text;
            tp.Name = name;

            tabControl1.Pages.Add(tp);
            frm.Parent = tp;
            commonClass.openInTabs(frm);
            tabControl1.SelectedPage = tp;

            /*if (commonClass.checkOpened(frm))
            {
                try
                {
                    // tabControl1.SelectTab(name);
                }
                catch
                {
                    frm.TopLevel = false;
                    KryptonPage tp = new KryptonPage();
                    tp.Width = tabControl1.Width;
                    tp.Height = tabControl1.Height;
                    tp.Text = frm.Text;
                    tp.Name = name;
                    //tabControl1.TabPages.Add(tp);
                    tabControl1.Pages.Add(tp);
                    frm.Parent = tp;
                    commonClass.openInTabs(frm);
                    tabControl1.SelectedPage = tp;
                }

            }
            else
            {
                
            }*/
        }

        public void openTabPanesTwo(Form frm, string name)
        {

            frm.TopLevel = false;
            KryptonPage tp = new KryptonPage();
            tp.Width = tabControl1.Width;
            tp.Height = tabControl1.Height-20;
            tp.Text = frm.Text;
            tp.Name = name;
            tabControl1.Pages.Add(tp);
            frm.Parent = tp;
            commonClass.openInTabs(frm);
            tabControl1.SelectedPage = tp;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = tabControl1.SelectedPage.Name;
            
            //commonClass.closeForm(name);


            tabControl1.Pages.RemoveAt(tabControl1.SelectedIndex);

        }

        private void tümSekmeleriKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commonClass.closeAllForm();
            tabControl1.Pages.Clear();
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }

        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }

        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }

        private void bANKAToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            BANKA.BANKALAR frm = new BANKA.BANKALAR();

            openTabPanes(frm, "BANKALAR");
        }

        private void tÜMSTOKKARTLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOKENVANTERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOKMALİYETToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOKKARDURUMUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tAHMİNİENVANTERKAZANÇToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOKGİRİŞLERİToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sTOKÇIKIŞLARIToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cARİKARTLARToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cARİBAKİYEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sATIŞFATURALARIToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aLIŞFATURALARIToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void kDVRAPORUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tAHSİLATLARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void öDEMELERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gİRİŞLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çIKIŞLARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kASARAPORUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bANKARAPORUToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gİRİŞLERToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void çIKIŞLARToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void hIZLIMENÜYÜGİZLEGÖSTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }*/
        }

        private void kULLANICIDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void kULLANICILARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hAKKINDAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dEPOLARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sİPARİŞTAHSİLATLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aLINANÇEKLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vERİLENÇEKLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aLINANSENETLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vERİLENSENETLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aLIŞİADEFATURALARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sATIŞİADEFATURALARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yAYINEVLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            SIPARIS.YENI_ALINAN_SIPARIS frm = new SIPARIS.YENI_ALINAN_SIPARIS();
            openTabPanes(frm, "YENI_ALINAN_SIPARIS");
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            FATURA.YENI_ALIS_FATURASI frm = new FATURA.YENI_ALIS_FATURASI();
            openTabPanes(frm, "YENI_ALIS_FATURASI");
        }

        private void sTOKSAYIMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton6_Click(object sender, EventArgs e)
        {
            STOK.STOK_KARTLARI frm = new STOK.STOK_KARTLARI();

            openTabPanesTwo(frm, "STOK_KARTLARI");
        }

        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            FATURA.STOK_GIRISLERI frm = new FATURA.STOK_GIRISLERI();
            openTabPanes(frm, "STOK_GIRISLERI");
        }

        private void kryptonRibbonGroupButton5_Click(object sender, EventArgs e)
        {
            CARI.CARI_KARTLAR frm = new CARI.CARI_KARTLAR();
            openTabPanesTwo(frm, "CARI_KARTLAR");
        }

        private void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {
            FATURA.STOK_CIKISLARI frm = new FATURA.STOK_CIKISLARI();
            openTabPanes(frm, "STOK_CIKISLARI");
        }

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            SATIS.HIZLI_SATIS frm = new SATIS.HIZLI_SATIS();
            openTabPanes(frm, "HIZLI_SATIS");
        }

        private void kryptonRibbonGroupButton24_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_KARTLARI frm = new RAPOR.STOK.RAPOR_STOK_KARTLARI();
            openTabPanes(frm, "RAPOR_STOK_KARTLARI");
        }

        private void kryptonRibbonGroupButton25_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_ENVANTER frm = new RAPOR.STOK.RAPOR_STOK_ENVANTER();
            openTabPanes(frm, "RAPOR_STOK_ENVANTER");
        }

        private void kryptonRibbonGroupButton26_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_MALIYET frm = new RAPOR.STOK.RAPOR_STOK_MALIYET();
            openTabPanes(frm, "RAPOR_STOK_MALIYET");
        }

        private void kryptonRibbonGroupButton27_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_KAR_DURUMU frm = new RAPOR.STOK.RAPOR_STOK_KAR_DURUMU();
            openTabPanes(frm, "RAPOR_STOK_KAR_DURUMU");
        }

        private void kryptonRibbonGroupButton28_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_TAHMINI_ENVANTER_KAZANC frm = new RAPOR.STOK.RAPOR_TAHMINI_ENVANTER_KAZANC();
            openTabPanes(frm, "RAPOR_TAHMINI_ENVANTER_KAZANC");
        }

        private void kryptonRibbonGroupButton29_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_GIRISLERI frm = new RAPOR.STOK.RAPOR_STOK_GIRISLERI();
            openTabPanes(frm, "RAPOR_STOK_GIRISLERI");
        }

        private void kryptonRibbonGroupButton30_Click(object sender, EventArgs e)
        {
            RAPOR.STOK.RAPOR_STOK_CIKISLARI frm = new RAPOR.STOK.RAPOR_STOK_CIKISLARI();
            openTabPanes(frm, "RAPOR_STOK_CIKISLARI");
        }

        private void kryptonRibbonGroupButton31_Click(object sender, EventArgs e)
        {
            RAPOR.CARI.RAPOR_CARI_KARTLAR frm = new RAPOR.CARI.RAPOR_CARI_KARTLAR();
            openTabPanes(frm, "RAPOR_CARI_KARTLAR");
        }

        private void kryptonRibbonGroupButton32_Click(object sender, EventArgs e)
        {
            RAPOR.CARI.RAPOR_CARI_BAKIYE frm = new RAPOR.CARI.RAPOR_CARI_BAKIYE();
            openTabPanes(frm, "RAPOR_CARI_BAKIYE");
        }

        private void kryptonRibbonGroupButton33_Click(object sender, EventArgs e)
        {
            RAPOR.FATURA.RAPOR_SATIS_FATURALARI frm = new RAPOR.FATURA.RAPOR_SATIS_FATURALARI();
            openTabPanes(frm, "RAPOR_SATIS_FATURALARI");
        }

        private void kryptonRibbonGroupButton34_Click(object sender, EventArgs e)
        {
            RAPOR.FATURA.RAPOR_ALIS_FATURALARI frm = new RAPOR.FATURA.RAPOR_ALIS_FATURALARI();
            openTabPanes(frm, "RAPOR_ALIS_FATURALARI");
        }

        private void kryptonRibbonGroupButton35_Click(object sender, EventArgs e)
        {
            RAPOR.FATURA.RAPOR_KDV_RAPORU frm = new RAPOR.FATURA.RAPOR_KDV_RAPORU();
            openTabPanes(frm, "RAPOR_KDV_RAPORU");
        }

        private void kryptonRibbonGroupButton36_Click(object sender, EventArgs e)
        {
            RAPOR.KASA.RAPOR_KASA_RAPORU frm = new RAPOR.KASA.RAPOR_KASA_RAPORU();
            openTabPanes(frm, "RAPOR_KASA_RAPORU");
        }

        private void kryptonRibbonGroupButton37_Click(object sender, EventArgs e)
        {
            RAPOR.KASA.RAPOR_TAHSILATLAR frm = new RAPOR.KASA.RAPOR_TAHSILATLAR();
            openTabPanes(frm, "RAPOR_TAHSILATLAR");
        }

        private void kryptonRibbonGroupButton38_Click(object sender, EventArgs e)
        {
            RAPOR.KASA.RAPOR_SIPARIS_TAHSILATLAR frm = new RAPOR.KASA.RAPOR_SIPARIS_TAHSILATLAR();
            openTabPanes(frm, "RAPOR_SIPARIS_TAHSILATLAR");
        }

        private void kryptonRibbonGroupButton39_Click(object sender, EventArgs e)
        {
            RAPOR.KASA.RAPOR_ODEMELER frm = new RAPOR.KASA.RAPOR_ODEMELER();
            openTabPanes(frm, "RAPOR_ODEMELER");
        }

        private void kryptonRibbonGroupButton40_Click(object sender, EventArgs e)
        {
            RAPOR.KASA.RAPOR_GIRISLER frm = new RAPOR.KASA.RAPOR_GIRISLER();
            openTabPanes(frm, "RAPOR_KASA_GIRISLER");
        }

        private void kryptonRibbonGroupButton41_Click(object sender, EventArgs e)
        {
            RAPOR.KASA.RAPOR_CIKISLAR frm = new RAPOR.KASA.RAPOR_CIKISLAR();
            openTabPanes(frm, "RAPOR_KASA_CIKISLAR");
        }

        private void kryptonRibbonGroupButton42_Click(object sender, EventArgs e)
        {
            RAPOR.BANKA.RAPOR_BANKA_RAPORU frm = new RAPOR.BANKA.RAPOR_BANKA_RAPORU();
            openTabPanes(frm, "RAPOR_BANKA_RAPORU");
        }

        private void kryptonRibbonGroupButton43_Click(object sender, EventArgs e)
        {
            RAPOR.BANKA.RAPOR_GIRISLER frm = new RAPOR.BANKA.RAPOR_GIRISLER();
            openTabPanes(frm, "RAPOR_BANKA_GIRISLER");
        }

        private void kryptonRibbonGroupButton44_Click(object sender, EventArgs e)
        {
            RAPOR.BANKA.RAPOR_CIKISLAR frm = new RAPOR.BANKA.RAPOR_CIKISLAR();
            openTabPanes(frm, "RAPOR_BANKA_CIKISLAR");
        }

        private void kryptonRibbonGroupButton4_Click(object sender, EventArgs e)
        {
            SIPARIS.ALINAN_SIPARISLER frm = new SIPARIS.ALINAN_SIPARISLER();
            openTabPanes(frm, "ALINAN_SIPARISLER");
        }

        private void kryptonRibbonGroupButton7_Click(object sender, EventArgs e)
        {
            SIPARIS.VERILEN_SIPARISLER frm = new SIPARIS.VERILEN_SIPARISLER();
            openTabPanes(frm, "VERILEN_SIPARISLER");
        }

        private void kryptonRibbonGroupButton9_Click(object sender, EventArgs e)
        {
            FATURA.ALIS_FATURALARI frm = new FATURA.ALIS_FATURALARI();
            openTabPanes(frm, "ALIS_FATURALARI");
        }

        private void kryptonRibbonGroupButton8_Click(object sender, EventArgs e)
        {
            FATURA.SATIS_FATURALARI frm = new FATURA.SATIS_FATURALARI();
            openTabPanes(frm, "SATIS_FATURALARI");
        }

        private void kryptonRibbonGroupButton11_Click(object sender, EventArgs e)
        {
            FATURA_IADE.ALIS_IADE_FATURALARI frm = new FATURA_IADE.ALIS_IADE_FATURALARI();
            openTabPanes(frm, "ALIS_IADE_FATURALARI");
        }

        private void kryptonRibbonGroupButton10_Click(object sender, EventArgs e)
        {
            FATURA_IADE.SATIS_IADE_FATURALARI frm = new FATURA_IADE.SATIS_IADE_FATURALARI();
            openTabPanes(frm, "SATIS_IADE_FATURALARI");
        }

        private void kryptonRibbonGroupButton12_Click(object sender, EventArgs e)
        {
            KASA.KASALAR frm = new KASA.KASALAR();
            openTabPanes(frm, "KASALAR");
        }

        private void kryptonRibbonGroupButton13_Click(object sender, EventArgs e)
        {
            BANKA.BANKALAR frm = new BANKA.BANKALAR();

            openTabPanes(frm, "BANKALAR");
        }

        private void kryptonRibbonGroupButton14_Click(object sender, EventArgs e)
        {
            CEK_SENET.ALINAN_CEKLER frm = new CEK_SENET.ALINAN_CEKLER();
            openTabPanes(frm, "ALINAN_CEKLER");
        }

        private void kryptonRibbonGroupButton15_Click(object sender, EventArgs e)
        {
            CEK_SENET.VERILEN_CEKLER frm = new CEK_SENET.VERILEN_CEKLER();
            openTabPanes(frm, "VERILEN_CEKLER");
        }

        private void kryptonRibbonGroupButton16_Click(object sender, EventArgs e)
        {
            CEK_SENET.ALINAN_SENETLER frm = new CEK_SENET.ALINAN_SENETLER();
            openTabPanes(frm, "ALINAN_SENETLER");
        }

        private void kryptonRibbonGroupButton17_Click(object sender, EventArgs e)
        {
            CEK_SENET.VERILEN_SENETLER frm = new CEK_SENET.VERILEN_SENETLER();
            openTabPanes(frm, "VERILEN_SENETLER");
        }

        private void kryptonRibbonGroupButton18_Click(object sender, EventArgs e)
        {
            DEPO.DEPO_KARTLARI frm = new DEPO.DEPO_KARTLARI();
            openTabPanes(frm, "DEPO_KARTLARI");
        }

        private void kryptonRibbonGroupButton19_Click(object sender, EventArgs e)
        {
            INDIRIMLER.INDIRIMLER_YAYINEVLERI frm = new INDIRIMLER.INDIRIMLER_YAYINEVLERI();
            openTabPanes(frm, "YAYINEVLERI");
        }

        private void kryptonRibbonGroupButton20_Click(object sender, EventArgs e)
        {
            DIGER.STOK_SAYIM frm = new DIGER.STOK_SAYIM();
            openTabPanes(frm, "STOK_SAYIM");
        }

        private void kryptonRibbonGroupButton23_Click(object sender, EventArgs e)
        {
            AYARLAR.HAKKINDA frm = new AYARLAR.HAKKINDA();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupButton21_Click(object sender, EventArgs e)
        {
            GIRIS.KULLANICILAR frm = new GIRIS.KULLANICILAR();
            openTabPanes(frm, "KULLANICILAR");
        }

        private void kryptonRibbonGroupButton22_Click(object sender, EventArgs e)
        {
            GIRIS.GIRIS frm = new GIRIS.GIRIS();
            frm.Show();
            this.Close();
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(tabControl1.Height.ToString());
            
                
        }

        private void kryptonRibbon1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            SIPARIS.YENI_ALINAN_SIPARIS frm = new SIPARIS.YENI_ALINAN_SIPARIS();
            openTabPanes(frm, "YENI_ALINAN_SIPARIS");
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            FATURA.YENI_ALIS_FATURASI frm = new FATURA.YENI_ALIS_FATURASI();
            openTabPanes(frm, "YENI_ALIS_FATURASI");
            
        }

        private void kryptonRibbonGroupButton45_Click(object sender, EventArgs e)
        {
            FATURA.TAHSILAT_EKLE frm = new FATURA.TAHSILAT_EKLE();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupButton46_Click(object sender, EventArgs e)
        {
            FATURA.ODEME_EKLE frm = new FATURA.ODEME_EKLE();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupButton47_Click(object sender, EventArgs e)
        {
            BANKA.GELEN_HAVALE_EKLE frm = new BANKA.GELEN_HAVALE_EKLE();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupButton48_Click(object sender, EventArgs e)
        {
            BANKA.GONDERILEN_HAVALE_EKLE frm = new BANKA.GONDERILEN_HAVALE_EKLE();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupButton49_Click(object sender, EventArgs e)
        {
            BANKA.POS_TAHSIL_EKLE frm = new BANKA.POS_TAHSIL_EKLE();
            frm.ShowDialog();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            FATURA.TAHSILAT_EKLE frm = new FATURA.TAHSILAT_EKLE();
            frm.ShowDialog();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            FATURA.ODEME_EKLE frm = new FATURA.ODEME_EKLE();
            frm.ShowDialog();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            BANKA.POS_TAHSIL_EKLE frm = new BANKA.POS_TAHSIL_EKLE();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupButton38_Click_1(object sender, EventArgs e)
        {
            RAPOR.BANKA.RAPOR_POS_TAHSIL frm = new RAPOR.BANKA.RAPOR_POS_TAHSIL();
            openTabPanes(frm, "RAPOR_POS_TAHSIL");
        }

        private void kryptonRibbonGroupButton50_Click(object sender, EventArgs e)
        {
            RAPOR.BANKA.RAPOR_GELEN_HAVALE frm = new RAPOR.BANKA.RAPOR_GELEN_HAVALE();
            openTabPanes(frm, "RAPOR_GELEN_HAVALE");
        }

        private void kryptonRibbonGroupButton51_Click(object sender, EventArgs e)
        {
            RAPOR.BANKA.RAPOR_GONDERILEN_HAVALE frm = new RAPOR.BANKA.RAPOR_GONDERILEN_HAVALE();
            openTabPanes(frm, "RAPOR_GONDERILEN_HAVALE");
        }
    }
}
