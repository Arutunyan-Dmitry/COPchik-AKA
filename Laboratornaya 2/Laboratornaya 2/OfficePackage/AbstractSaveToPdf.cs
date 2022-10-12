using Laboratornaya_2.OfficePackage.HelperEnums;
using Laboratornaya_2.OfficePackage.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        List<string> rowText = new List<string>();
        string[,] arrayRows;

        /// <summary>
        /// метод для работы с документом с таблицами
        /// </summary>
        /// <param name="info"></param>
        public void CreateDocWithTables(PdfInfo info)
        {
            CreatePdf(info);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Headline,
                Style = "NormalTitle"
            });
            foreach (var elem in info.listTables)
            {
                CreateParagraph(new PdfParagraph
                {
                    Text = "",
                    Style = "NormalTitle"
                });
                CreateTable(new List<string> { "3cm", "3cm", "3cm", "3cm", "3cm" });
                arrayRows = elem;
                for (int i = 0; i < arrayRows.GetLength(0); i++)  //строки
                {
                    rowText.Clear();
                    for (int j = 0; j < arrayRows.GetLength(1); j++)  //столбцы
                    {
                        rowText.Add(arrayRows[i, j]);
                    }
                    CreateRow(new PdfRowParameters
                    {
                        Texts = rowText,
                        Style = "Normal",
                        ParagraphAlignment = PdfParagraphAlignmentType.Left
                    });
                }
                rowText.Clear();
            }
            SavePdf(info);
        }

        /// <summary>
        /// метод для работы с документом с таблицей, у которой шапка – первая строка и первый столбец.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info"></param>
        public void CreateDocWithCustomTable<T>(PdfInfoCustomTable<T> info)
        {
            PdfInfo pdInfo = new PdfInfo { Path = info.Path };
            CreatePdf(pdInfo);
            CreateParagraph(new PdfParagraph
            {
                Text = info.Headline,
                Style = "NormalTitle"
            });

            List<string> WidthColumn = new List<string>();
            foreach (var elem in info.WidthColumn)
            {
                WidthColumn.Add(elem.ToString());
            }
            CreateTable(WidthColumn);
            int[] rowsHeight = info.HeightRow;
            for (int i = 0; i < info.DateTable.Count + 1; i++)
            {
                rowText.Clear();
                if (i == 0)
                {
                    foreach (var NameHeaders in info.HeadersField)
                    {
                        rowText.Add(NameHeaders.Item1);
                    }
                    CreateRow(new PdfRowParameters
                    {
                        Texts = rowText,
                        Style = "NormalTitle",
                        ParagraphAlignment = PdfParagraphAlignmentType.Center,
                        RowHeight = info.HeightRow[i]
                    });
                }
                else
                {
                    rowText.Add(info.HeadersRows[i - 1]);
                    for (int j = 0; j < info.HeadersField.Count; j++)
                    {
                        var field = info.DateTable[i - 1]?.GetType().GetProperties()?
                            .FirstOrDefault(x => x.Name == info.HeadersField[j].Item2)?.GetValue(info.DateTable[i - 1]);
                        if (field != null)
                        {
                            rowText.Add(field.ToString());
                        }
                    }
                    CreateRow(new PdfRowParameters
                    {
                        Texts = rowText,
                        Style = "Normal",
                        ParagraphAlignment = PdfParagraphAlignmentType.Left,
                        RowHeight = info.HeightRow[i]
                    });
                }
            }
            PdfInfo pdfInfo = new PdfInfo()
            {
                Path = info.Path
            };
            SavePdf(pdfInfo);
        }
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreatePdf(PdfInfo info);
        /// <summary>
        /// Создание параграфа с текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateParagraph(PdfParagraph paragraph);
        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateTable(List<string> columns);
        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        protected abstract void CreateRow(PdfRowParameters rowParameters);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void SavePdf(PdfInfo info);
    }
}
