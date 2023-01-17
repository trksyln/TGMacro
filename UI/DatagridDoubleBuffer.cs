using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TGMacro.UI
{
    public class DatagridDoubleBuffer : DataGridView
    {
        public DatagridDoubleBuffer()
        {
            DoubleBuffered= true;
        }
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
