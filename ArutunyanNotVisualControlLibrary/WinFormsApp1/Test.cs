using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Test
    {
        public int field0 { get; set; }
        public int field1 { get; set; }
        public string field2 { get; set; }
        public float field3 { get; set; }
        public int field4 { get; set; }
        public double field5 { get; set; }
        public int field6 { get; set; }

        public Test(int field0, int field1, string field2, float field3, int field4, double field5, int field6)
        {
            this.field0 = field0;
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
            this.field4 = field4;
            this.field5 = field5;
            this.field6 = field6;
        }
    }
}
