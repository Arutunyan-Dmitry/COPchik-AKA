using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace KOP
{
    public partial class ImageExel : Component
    {
        //Не визуальный компонент для создания документа с изображениями.У компонента должен быть публичный метод, который должен принимать на вход имя файла (включая путь до файла), 
        //название документа(заголовок в документе) и массив изображений(т.е.более одного изображения), которые следует вставить в документ последовательно, в том же порядке, как они
        //приходят в метод.Должна быть проверка на заполненность входных данных значениями
        public ImageExel()
        {
            InitializeComponent();
        }

        public ImageExel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateExelImage(string filePath, string docTitle, string[] images)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            if (docTitle != null)
            {
                xlWorkSheet.Cells[1, 1] = docTitle;
            }
            else
            {
                MessageBox.Show("Не был передан заголовок!");
                return;
            }
            if (images != null) 
            {
                int topMargin = 30;
                foreach (var image in images)
                { 
                    xlWorkSheet.Shapes.AddPicture(image, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, topMargin, 640, 360);
                    topMargin += 400;
                }
            }
            else
            {
                MessageBox.Show("Не были переданы изображения!");
                return;
            }
            if (filePath != null)
            {
                xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            else
            {
                MessageBox.Show("Не был передан путь для изображения");
                return;
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            MessageBox.Show("Файл создан!");
        }
    }
}
