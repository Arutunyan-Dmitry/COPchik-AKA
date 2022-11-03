using KOP.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace KOP
{

    public partial class DiagramExel : Component
    {
        //Не визуальный компонент для создания документа с круговой диаграммой.
        //У компонента должен быть публичный метод, который должен принимать на вход имя файла(включая путь до файла),
        //название документа(заголовок в документе), заголовок для диаграммы, указание расположения легенды для диаграммы (создать для этого перечисление),
        //набор данных для диаграммы (название серии и данные для графика).
        //Должна быть проверка на заполненность входных данных значениями
        public DiagramExel()
        {
            InitializeComponent();
        }

        public DiagramExel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateExelDiagram(string filePath, string docTitle, string diagramTitle, LegendPlace legendPlace, Dictionary<string, int> dictionary)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            
            int row = 1;
            int column = 1;
            foreach(var item in dictionary)
            {
                xlWorkSheet.Cells[row, column] = item.Key;
                xlWorkSheet.Cells[row, column+1] = item.Value;
                row++;
            }

            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myDiagram = xlCharts.Add(100, 20, 300, 300);
            Excel.Chart diagramPage = myDiagram.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "B" + (row - 1).ToString());


            diagramPage.SetSourceData(chartRange, misValue);
            diagramPage.ChartType = Excel.XlChartType.xlPie;
            diagramPage.HasTitle = true;
            diagramPage.ChartTitle.Text = diagramTitle;

            switch (legendPlace)
            {
                case LegendPlace.Left:
                    diagramPage.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
                    break;
                case LegendPlace.Right:
                    diagramPage.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight;
                    break;
                case LegendPlace.Bottom:
                    diagramPage.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                    break;
                case LegendPlace.Top:
                    diagramPage.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                    break;
            }

            if (filePath != null)
            {
                xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            else
            {
                throw new Exception("Не был передан путь для файла");
            }

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
        }

    }
}
