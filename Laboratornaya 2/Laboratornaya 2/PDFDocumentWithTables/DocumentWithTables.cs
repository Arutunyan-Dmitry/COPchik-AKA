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

namespace Laboratornaya_2.PDFDocumentWithTables
{
    public partial class DocumentWithTables : Component
    {
        private AbstractSaveToPdf _saveToPdf;
        public DocumentWithTables()
        {
            InitializeComponent();
        }

        public DocumentWithTables(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// метод для проверки вводимых данных
        /// </summary> 
        /// <param name="Path">имя файла (включая путь до файла)</param>
        /// <param name="Headline">название документа (заголовок в документе)</param>
        /// <param name="listTables">набор таблиц (каждая представляет собой двумерный массив строк, где каждая строка – ячейка таблицы документа)</param>
        /// <returns></returns>
        public bool CheckData(string Path, string Headline, List<string[,]> listTables)
        {
            if (string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(Headline))
            {
                return false;
            }
            if (listTables.Count != 0)
            {
                foreach (var elem in listTables)
                {
                    if (elem.GetLength(0) != 0 && elem.GetLength(1) != 0)
                    {
                        for (int i = 0; i < elem.GetLength(0); i++)
                        {
                            for (int j = 0; j < elem.GetLength(1); j++)
                            {
                                if (string.IsNullOrEmpty(elem[i, j]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// метод для создания таблиц
        /// </summary>
        /// <param name="Path">имя файла (включая путь до файла)</param>
        /// <param name="Headline">название документа (заголовок в документе)</param>
        /// <param name="listTables">набор таблиц (каждая представляет собой двумерный массив строк, где каждая строка – ячейка таблицы документа)</param>
        public void CreatePDF(string Path, string Headline, List<string[,]> listTables)
        {
            if (!CheckData(Path, Headline, listTables))
            {
                MessageBox.Show("Данные введены не правильно ", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            _saveToPdf = new SaveToPdf();
            _saveToPdf.CreateDocWithTables(new PdfInfo
            {
                Path = Path,
                Headline = Headline,
                listTables = listTables
            });
        }
    }
}
