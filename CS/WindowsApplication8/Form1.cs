using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace WindowsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] columnWidths; //keep user-defined column widths

        private void gridControl1_SizeChanged(object sender, EventArgs e)
        {
            RecalcWidths(gridView1, columnWidths);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridControl1.ForceInitialize();
            gridView1.OptionsView.ColumnAutoWidth = false;
            columnWidths = new int[gridView1.Columns.Count];
            ResetWidths(gridView1, columnWidths);
            gridView1.ColumnWidthChanged += new DevExpress.XtraGrid.Views.Base.ColumnEventHandler(gridView1_ColumnWidthChanged);
        }

        void gridView1_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            ResetWidths(sender as GridView, columnWidths);
        }

        private void ResetWidths(GridView view, int[] widths)
        {
            foreach (GridColumn col in view.Columns)
            {
                widths[col.AbsoluteIndex] = col.Width;
            }
            RecalcWidths(view, widths);
        }

        private void RecalcWidths(DevExpress.XtraGrid.Views.Grid.GridView view, int[] widths)
        {
            GridViewInfo info = view.GetViewInfo() as GridViewInfo;

            int room = info.ViewRects.ColumnPanelWidth;
            int sumWidth = 0;
            ArrayList cols = new ArrayList();
            foreach (GridColumn col in view.VisibleColumns)
            {
                sumWidth += widths[col.AbsoluteIndex];
                cols.Add(col);
            }
            if (sumWidth == 0) return;
            if (sumWidth > room) return; //prevent extreme column squeezing
            int remains = room;
            foreach (GridColumn col in cols)
            {
                col.Width = room * widths[col.AbsoluteIndex] / sumWidth;
                remains -= col.Width;
            }
            view.VisibleColumns[view.VisibleColumns.Count - 1].Width += remains;
        }
    }
}