using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR
{
    public partial class RAPOR_SORGU_CALISTIR : Form
    {
        public RAPOR_SORGU_CALISTIR()
        {
            InitializeComponent();
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string QUERY = "";
        private void RAPOR_SORGU_CALISTIR_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = QUERY;
        }

        private void sORGUYUÇALIŞTIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QUERY = richTextBox1.Text;
            this.Close();
        }
    }
}
