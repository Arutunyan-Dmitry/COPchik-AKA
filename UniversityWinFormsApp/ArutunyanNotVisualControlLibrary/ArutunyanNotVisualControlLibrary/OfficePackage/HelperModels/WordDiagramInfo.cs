using ArutunyanNotVisualControlLibrary.OfficePackage.HelperEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels
{
    public class WordDiagramInfo
    {
        public string Path { get; set; }
        public string Header { get; set; }
        public LegendPositions LegendPosition { get; set; }
        public List<(string, int[])> Data { get; set; }
    }
}
