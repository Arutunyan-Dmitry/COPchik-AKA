using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using Color = MigraDoc.DocumentObjectModel.Color;

namespace Laboratornaya_2.PDFDocumentWithHistogram
{
    public partial class DocumentWithHistogram : Component
    {
        public DocumentWithHistogram()
        {
            InitializeComponent();
        }

        public DocumentWithHistogram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Метод для проверки вводимых данных
        /// </summary>
        /// <param name="Path"> путь к файлу и название </param>
        /// <param name="Headline"> заголовок в документе </param>
        /// <param name="HeaderHistogram"> заголовок диаграммы </param>
        /// <param name="DataHistogram"> данные диаграммы </param>
        /// <returns></returns>
        public bool CheckData(string Path, string Headline, string HeaderHistogram, List<(string, double[])> DataHistogram)
        {
            if (string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(Headline) || string.IsNullOrEmpty(HeaderHistogram))
            {
                return false;
            }
            if (DataHistogram.Count != 0)
            {
                foreach (var elem in DataHistogram)
                {
                    if (string.IsNullOrEmpty(elem.Item1) || elem.Item2.Length == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// метод для создания документа с гистограммой
        /// </summary>
        /// <param name="Path">путь к файлу и название</param>
        /// <param name="Headline">заголовок в документе</param>
        /// <param name="HeaderHistogram">заголовок диаграммы</param>
        /// <param name="DataHistogram">данные диаграммы</param>
        /// <param name="legendPosition">расположение легенды для диаграммы</param>
        public void CreatePdfHistogram(string Path, string Headline, string HeaderHistogram, List<(string, double[])> DataHistogram,
           LegendPosition legendPosition)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (!CheckData(Path, Headline, HeaderHistogram, DataHistogram))
            {
                MessageBox.Show("Данные введены не правильно ", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            Document document = new Document();
            Section section = document.AddSection();
            Paragraph paragraph = document.LastSection.AddParagraph(Headline);
            paragraph.Style = "NormalTitle";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Color = Color.FromArgb(0, 0, 0, 0);
            document.LastSection.AddParagraph(HeaderHistogram);
            paragraph.AddBookmark("Charts");
            Chart chart = new Chart();
            chart.Left = 0;
            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);
            Series series = new Series();
            foreach (var item in DataHistogram)
            {
                series = chart.SeriesCollection.AddSeries();
                series.Name = item.Item1;
                series.ChartType = ChartType.Column2D;
                series.Add(item.Item2); // данные для столбцов
                series.HasDataLabel = true;
            }
            Legend legend;
            if (legendPosition == LegendPosition.BottomArea)
            {
                legend = chart.BottomArea.AddLegend();

            }
            if (legendPosition == LegendPosition.TopArea)
            {
                legend = chart.TopArea.AddLegend();
            }
            if (legendPosition == LegendPosition.LeftArea)
            {
                legend = chart.LeftArea.AddLegend();
            }
            if (legendPosition == LegendPosition.RightArea)
            {
                legend = chart.RightArea.AddLegend();
            }
            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N");  // ось Х

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.XAxis.Title.Caption = "X-Axis";

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Color = Colors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;

            document.LastSection.Add(chart);

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path);
        }
    }
}
