using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2.OfficePackage.HelperModels
{
    public class PdfInfo
    {
        public string Path { get; set; }
        public string Headline { get; set; }
        public List<string[,]> listTables { get; set; }
    }
}
