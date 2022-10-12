using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kochkareva_var16.KochkarevaDataGridView
{
    public class TestDate
    {
        //тестовое поле 1
        public string MyStringColumn1 { get; set; }
        //тестовое поле 2
        public int MyIntColumn { get; set; }
        //тестовое поле 3
        public string MyStringColumn2 { get; set; }
        //тестовое поле 4
        public string MyStringColumn3 { get; set; }
        public TestDate(string MyStringColumn1, int MyIntColumn, string MyStringColumn2, string MyStringColumn3)
        {
            this.MyStringColumn1 = MyStringColumn1;
            this.MyIntColumn = MyIntColumn;
            this.MyStringColumn2 = MyStringColumn2;
            this.MyStringColumn3 = MyStringColumn3;
        }
    }
}
