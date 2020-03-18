using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf
{
    class DefaultStyles
    {
        public void dataGridStyle(DataGridView dtgrid)
        {
            dtgrid.BackgroundColor = Color.White;
            //dtgrid.Dock = DockStyle.Fill;
            //dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgrid.ReadOnly = true;
            dtgrid.RowHeadersVisible = false;
            dtgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgrid.AllowUserToResizeRows = false;
        }

        public void dataGridStyle2(KryptonDataGridView dtgrid)
        {
            dtgrid.BackgroundColor = Color.White;
            
            //dtgrid.Dock = DockStyle.Fill;
            //dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgrid.ReadOnly = true;
            dtgrid.RowHeadersVisible = false;
            dtgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgrid.AllowUserToResizeRows = false;
        }

        public void dataGridFormatNumber(DataGridView dtgrid)
        {
            foreach (DataGridViewColumn column in dtgrid.Columns)
            {
                if (column.ValueType == typeof(decimal) || column.ValueType == typeof(double))
                {
                    column.DefaultCellStyle.Format = "n2";
                }
            }
        }

        public void dataGridReName(DataGridView dtgrid)
        {
            foreach (DataGridViewColumn column in dtgrid.Columns)
            {
                column.HeaderText = column.Name.Replace("_", " ");
            }
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        public void dataGridColWidth(DataGridView dtGrid,string TARGET_GRID)
        {
            DataTable dtCols = helper.getDataTable("SELECT*FROM SETTING_COL_WIDTH WHERE TARGET_GRID='"+TARGET_GRID+"'");
            foreach (DataRow drCol in dtCols.Rows)
            {
                foreach (DataGridViewColumn col in dtGrid.Columns)
                {
                    if (drCol["COL"].ToString() == col.Name)
                    {
                        col.Width = int.Parse(drCol["WIDTH"].ToString());
                    }
                }
            }
        }

        public void saveDataGridColWidth(string TARGET_GRID,string COL,int WIDTH)
        {
            
            DataTable dt = helper.getDataTable("SELECT*FROM SETTING_COL_WIDTH WHERE COL='" + COL + "' AND TARGET_GRID='" + TARGET_GRID + "'");

            string[] cols = { "TARGET_GRID", "COL", "WIDTH" };
            string[] vals = { TARGET_GRID, COL, WIDTH.ToString() };

            if (dt.Rows.Count == 0) {
                helper.setSqlCommandForInsertWithParameters("SETTING_COL_WIDTH", cols, vals);
            }
            else
            {
                helper.setSqlCommandForUpdateWithParameters("SETTING_COL_WIDTH", cols, vals, "ID", dt.Rows[0][0].ToString());
            }
        }

        public void testFunc(object sender, DataGridViewColumnEventArgs e)
        {

            try
            {
                saveDataGridColWidth(e.Column.DataGridView.Tag.ToString(),e.Column.Name, e.Column.Width);
            }
            catch { }
        }

       
    }
}
