using Laboratornaya_2.OfficePackage;
using Laboratornaya_2.OfficePackage.HelperModels;
using Laboratornaya_2.OfficePackage.Implements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2.PDFDocumentWithTable
{
    public partial class DocumentWithCustomTable : Component
    {
        private AbstractSaveToPdf _saveToPdf;

        public DocumentWithCustomTable()
        {
            InitializeComponent();
        }

        public DocumentWithCustomTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// метод для проверки данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path">имя файла (включая путь до файла)</param>
        /// <param name="Headline">название документа (заголовок в документе)</param>
        /// <param name="WidthColumn">информация по ширине каждого столбца</param>
        /// <param name="HeightRow">информация по высоте каждой строки</param>
        /// <param name="HeadersField">заголовки для шапки по столбцам</param>
        /// <param name="HeadersRows">заголовки для шапки по строкам</param>
        /// <param name="DateTable">данные для таблицы</param>
        /// <returns></returns>
        public bool CheckData<T>(string Path, string Headline, int[] WidthColumn, int[] HeightRow, List<Tuple<string, string>> HeadersField,
            List<string> HeadersRows, List<T> DateTable)
        {
            if (string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(Headline) || WidthColumn.Length == 0 || HeightRow.Length == 0)
            {
                return false;
            }
            if (HeadersField.Count == 0)
            {
                return false;
            }
            if (HeadersRows.Count != 0)
            {
                foreach (var elem in HeadersRows)
                {
                    if (string.IsNullOrEmpty(elem))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            if (DateTable.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// метод для создания документа с таблицей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path">имя файла (включая путь до файла)</param>
        /// <param name="Headline">название документа (заголовок в документе)</param>
        /// <param name="WidthColumn">информация по ширине каждого столбца</param>
        /// <param name="HeightRow">информация по высоте каждой строки</param>
        /// <param name="HeadersField">заголовки для шапки по столбцам</param>
        /// <param name="HeadersRows">заголовки для шапки по строкам</param>
        /// <param name="DateTable">данные для таблицы</param>
        public void CreatePDF<T>(string Path, string Headline, int[] WidthColumn, int[] HeightRow, List<Tuple<string, string>> HeadersField, 
            List<string> HeadersRows, List<T> DateTable)
        {
            if (!CheckData(Path, Headline, WidthColumn, HeightRow, HeadersField, HeadersRows, DateTable))
            {
                MessageBox.Show("Данные введены не правильно ", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            _saveToPdf = new SaveToPdf();
            _saveToPdf.CreateDocWithCustomTable(new PdfInfoCustomTable<T>
            {
                Path = Path,
                Headline = Headline,
                WidthColumn = WidthColumn,
                HeightRow = HeightRow,
                HeadersField = HeadersField,
                HeadersRows = HeadersRows,
                DateTable = DateTable
            });
        }
    }
}
