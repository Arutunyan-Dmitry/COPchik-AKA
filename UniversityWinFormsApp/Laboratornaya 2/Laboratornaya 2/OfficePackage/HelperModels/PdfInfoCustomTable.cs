using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2.OfficePackage.HelperModels
{
    public class PdfInfoCustomTable<T>
    {
        public string Path { get; set; }
        public string Headline { get; set; }
        public int[] WidthColumn { get; set; }
        public int[] HeightRow { get; set; }
        public List<Tuple<string, string>> HeadersField { get; set; }
        public List<string> HeadersRows { get; set; }
        public List<T> DateTable { get; set; }
    }
}
