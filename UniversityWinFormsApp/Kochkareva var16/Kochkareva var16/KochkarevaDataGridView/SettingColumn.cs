using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kochkareva_var16.KochkarevaDataGridView
{
    public class SettingColumn
    {
        public string NameColumn;
        public int WidthColumn = 15;
        public bool IsVisibleColumn = false;
        public string NameObject;
        public SettingColumn(string NameColumn, int WidthColumn, bool IsVisibleColumn, string NameObject)
        {
            this.NameColumn = NameColumn;
            this.WidthColumn = WidthColumn;
            this.IsVisibleColumn = IsVisibleColumn;
            this.NameObject = NameObject;
        }
    }
}
