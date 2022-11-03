using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class TableExel : Component
    {
        //Не визуальный компонент для создания документа с таблицей, у которой шапкой является первые два столбца и в них есть группировка.
        //У компонента должен быть публичный метод, который должен принимать на вход имя файла(включая путь до файла), название документа(заголовок в документе),
        //информацию по объединению ячеек(по строкам), высота строк(у каждой она может быть своя), заголовки для шапки и данные для таблицы.
        //Строки и столбцы таблицы считать с 0 позиции.
        //Ячейки в шапке, которые не объединяются по строкам должны быть объединены по столбцам
        //(т.е.ячейка первого столбца с ячейкой второго столбца, находящегося справа от ячейки первого столбца).
        //Данные должны передаваться в виде набора объектов какого-то класса.Таблица должна заполнятся по принципу:
        //каждый столбец – это запись класса из набора, ячейка столбца заполняется из свойства/поля объекта класса
        //(в настройках указывать для какой строки какое свойство/поле соответствует). Должна быть проверка на заполненность входных данных значениями.
        //Должна быть проверка, что объединенные ячейки не накладываются друг
        public TableExel()
        {
            InitializeComponent();
        }

        public TableExel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateTable<T>(string filePath, string docTitle, Dictionary<string, int[]> rowMergeInfo, int[] rowHight, string[] tableHeader, List<T> listData)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            /////////////////////////////////////////////////////////////////////////////////////////////////

            int columnCell = 1;
            int rowCell = 1;

            var propList = typeof(T).GetFields();
            var tmpList = new List<int>();

            //лист со всеми номерами строк, которые надо объединить вертикально
            foreach (var value in rowMergeInfo.Values)
            {
                tmpList.AddRange(value);
            }

            //объединяем две соседние ячейки по горизонтали, если они не в группе
            int rowGroup = rowCell;
            for (int i = 0; i < tableHeader.Length; i++)
            {
                if (!tmpList.Contains(rowGroup))
                {
                    xlWorkSheet.Range[xlWorkSheet.Cells[rowGroup, columnCell], xlWorkSheet.Cells[rowGroup, columnCell + 1]].Merge(misValue);
                    xlWorkSheet.Range[xlWorkSheet.Cells[rowGroup, columnCell], xlWorkSheet.Cells[rowGroup, columnCell + 1]].BorderAround(true);
                }
                rowGroup++;
            }

            //объединяем по группам, заполняем группы
            foreach (var item in rowMergeInfo)
            {
                xlWorkSheet.Range[xlWorkSheet.Cells[item.Value[0], columnCell], xlWorkSheet.Cells[item.Value[0] + item.Value.Length - 1, columnCell]].Merge(misValue);
                xlWorkSheet.Range[xlWorkSheet.Cells[item.Value[0], columnCell], xlWorkSheet.Cells[item.Value[0] + item.Value.Length - 1, columnCell]].Value = item.Key;
                xlWorkSheet.Range[xlWorkSheet.Cells[item.Value[0], columnCell], xlWorkSheet.Cells[item.Value[0] + item.Value.Length - 1, columnCell]].BorderAround(true);
            }

            //заполняем заголовки
            for (int i = 0; i < tableHeader.Length; i++)
            {
                if (!tmpList.Contains(i + 1))
                {
                    xlWorkSheet.Cells[i + 1, columnCell] = tableHeader[i];
                }
                else
                {
                    xlWorkSheet.Cells[i + 1, columnCell + 1] = tableHeader[i];
                    xlWorkSheet.Cells[i + 1, columnCell + 1].BorderAround(true);
                }
            }

            //выбираем высоту строк
            var headerRange = xlWorkSheet.Range[xlWorkSheet.Cells[rowCell, columnCell], xlWorkSheet.Cells[rowCell + tableHeader.Length - 1, columnCell + 1]];
            headerRange.Font.Bold = true;
            for (int i = 0; i < rowHight.Length; i++)
            {
                xlWorkSheet.Cells[i + rowCell, columnCell].RowHeight = rowHight[i];
                xlWorkSheet.Cells[i + rowCell, columnCell].BorderAround(true);
            }

            //заполняем столбцы таблицы данными
            int columnData = columnCell + 2;
            int rowData = rowCell;
            foreach (var item in listData)
            {
                foreach (var prop in propList)
                {
                    xlWorkSheet.Cells[rowData, columnData] = prop.GetValue(item).ToString();
                    xlWorkSheet.Cells[rowData, columnData].BorderAround(true);
                    rowData++;
                }
                columnData++;
                rowData = rowCell;
            }

            var tableRange = xlWorkSheet.Range[xlWorkSheet.Cells[rowCell, columnCell], xlWorkSheet.Cells[rowCell + propList.Length - 1, columnCell + listData.Count + 1]];
            tableRange.Columns.AutoFit();

            //////////////////////////////////////////////////////////////////////////////////////////
            if (filePath != null)
            {
                xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            else
            {
                MessageBox.Show("Не был передан путь");
                return;
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);

            MessageBox.Show("Файл создан!");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
