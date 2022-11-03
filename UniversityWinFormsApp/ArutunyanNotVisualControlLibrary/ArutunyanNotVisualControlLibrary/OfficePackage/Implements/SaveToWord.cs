using ArutunyanNotVisualControlLibrary.OfficePackage.HelperEnums;
using ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ArutunyanNotVisualControlLibrary.OfficePackage.Implements
{
    public class SaveToWord : AbstractSaveToWord
    {
        private WordprocessingDocument _wordDocument;
        private MainDocumentPart _mainDocumentPart;
        private Body _docBody;
        private Table _table;
        /// <summary>
        /// Получение типа выравнивания
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            return type switch
            {
                WordJustificationType.Both => JustificationValues.Both,
                WordJustificationType.Center => JustificationValues.Center,
                _ => JustificationValues.Left,
            };
        }
        /// <summary>
        /// Настройки страницы
        /// </summary>
        /// <returns></returns>
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }
        /// <summary>
        /// Задание форматирования для абзаца
        /// </summary>
        /// <param name="paragraphProperties"></param>
        /// <returns></returns>
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperties)
        {
            if (paragraphProperties != null)
            {
                var properties = new ParagraphProperties();
                properties.AppendChild(new Justification()
                {
                    Val = GetJustificationValues(paragraphProperties.JustificationType)
                });
                properties.AppendChild(new SpacingBetweenLines
                {
                    LineRule = LineSpacingRuleValues.Auto
                });
                properties.AppendChild(new Indentation());
                var paragraphMarkRunProperties = new ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperties.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize
                    {
                        Val = paragraphProperties.Size
                    });
                }
                properties.AppendChild(paragraphMarkRunProperties);
                return properties;
            }
            return null;
        }
        protected override void CreateWord(string info)
        {
            _wordDocument = WordprocessingDocument.Create(info, WordprocessingDocumentType.Document);
            _mainDocumentPart = _wordDocument.AddMainDocumentPart();
            _mainDocumentPart.Document = new Document();
            _docBody = _mainDocumentPart.Document.AppendChild(new Body());
        }
        protected override void CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                var docParagraph = new Paragraph();

                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    var docRun = new Run();
                    var properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space = SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                _docBody.AppendChild(docParagraph);
            }
        }
        protected override void CreateTable(int[] width, List<(int, int, string)> joined,
            List<(string, string)> columns)
        {
            _table = new Table();
            TableProperties tblProp = new TableProperties(
                new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 14
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 14
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 14
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 14
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    }
                )
            );
            _table.AppendChild(tblProp);
            TableRow tableRowHeaderOne = new TableRow();
            for (int i = 0; i < width.Length; i++)
            {
                TableCell cellHeader = new TableCell();
                bool flag = true;
                foreach (var join in joined)
                {
                    if (i == join.Item1)
                    {
                        cellHeader.Append(new TableCellProperties(new HorizontalMerge() { Val = MergedCellValues.Restart }));
                        cellHeader.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width[i].ToString() }));
                        cellHeader.Append(new Paragraph(new ParagraphProperties(new 
                            Justification() { Val = JustificationValues.Center }), 
                            new Run(new RunProperties(new Bold()), 
                            new Text(join.Item3))));
                        flag = false;
                    } else if (i > join.Item1 && i <= join.Item2)
                    {
                        cellHeader.Append(new TableCellProperties(new HorizontalMerge() { Val = MergedCellValues.Continue }));
                        cellHeader.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width[i].ToString() }));
                        flag = false;
                    }
                }
                if (flag)
                {
                    cellHeader.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Restart }));
                    cellHeader.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width[i].ToString() }));
                    cellHeader.Append(new Paragraph(new ParagraphProperties(new Justification()
                    { Val = JustificationValues.Center }),
                            new Run(new RunProperties(new Bold()),
                            new Text(columns[i].Item1))));
                }
                tableRowHeaderOne.Append(cellHeader);             
            }
            TableRow tableRowHeaderTwo = new TableRow();
            for (int i = 0; i < width.Length; i++)
            {
                TableCell cellHeader = new TableCell();
                cellHeader.Append(new TableCellProperties(new VerticalMerge() { Val = MergedCellValues.Continue }));
                cellHeader.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width[i].ToString() }));
                cellHeader.Append(new Paragraph(new ParagraphProperties(new Justification()
                { Val = JustificationValues.Center }),
                    new Run(new RunProperties(new Bold()),
                    new Text(columns[i].Item1))));
                tableRowHeaderTwo.Append(cellHeader);
            }
            _table.Append(tableRowHeaderOne);
            _table.Append(tableRowHeaderTwo);
            _docBody.AppendChild(_table);
        }

        protected override void CreateRow(int widthIndx, int[] width, List<string> tableRowInfo)
        {
            TableRow tableRow = new TableRow();
            foreach (string celltext in tableRowInfo)
            {
                TableCell tableCell = new TableCell();
                tableRow.Append(new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = width[widthIndx].ToString() }));
                tableRow.Append(new Paragraph(new Run(new Text(celltext))));
                tableRow.Append(tableCell);
            }
            _table.Append(tableRow);
        }
        protected override void CreateLinearDiagram(LegendPositions lp, List<(string, int[])> data)
        {
            ChartPart chartPart = _mainDocumentPart.AddNewPart<ChartPart>("rId110");
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.Append(new EditingLanguage() { Val = new StringValue("en-US") });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());

            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            uint i = 0;

            LineChart lineChart = plotArea.AppendChild(new LineChart());

            foreach (var item in data)
            {
                LineChartSeries lineChartSeries = lineChart.AppendChild(new LineChartSeries(
                    new DocumentFormat.OpenXml.Drawing.Charts.Index() { Val = new UInt32Value(i) },
                    new Order() { Val = new UInt32Value(i) },
                    new SeriesText(new NumericValue() { Text = item.Item1 })));

                    StringLiteral strLit = lineChartSeries.AppendChild(new CategoryAxisData()).AppendChild(new StringLiteral());
                    strLit.Append(new PointCount() { Val = Convert.ToUInt32(item.Item2.Length) });
                    for (int pt = 0; pt < item.Item2.Length; pt++)
                    {
                        strLit.AppendChild(new StringPoint() { Index = Convert.ToUInt32(pt) }).Append(new NumericValue(pt.ToString()));
                    }

                    NumberLiteral numLit = lineChartSeries.AppendChild(new Values()).AppendChild(new NumberLiteral());
                    numLit.Append(new FormatCode("General"));
                    numLit.Append(new PointCount() { Val = Convert.ToUInt32(item.Item2.Length) });
                    for (int pt = 0; pt < item.Item2.Length; pt++)
                    {
                        numLit.AppendChild(new NumericPoint() { Index = Convert.ToUInt32(pt) }).Append
                        (new NumericValue(item.Item2[pt].ToString()));
                    }
                i++;
            }

            lineChart.Append(new AxisId() { Val = new UInt32Value(48650112u) });
            lineChart.Append(new AxisId() { Val = new UInt32Value(48672768u) });

            // Add the Category Axis (Ось).
            CategoryAxis catAx = plotArea.AppendChild(new CategoryAxis(new AxisId()
            { Val = new UInt32Value(48650112u) }, new Scaling(new DocumentFormat.OpenXml.Drawing.Charts.Orientation()
            {
                Val = new EnumValue<OrientationValues>(OrientationValues.MinMax)
            }),
                new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                new CrossingAxis() { Val = new UInt32Value(48672768U) },
                new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                new AutoLabeled() { Val = new BooleanValue(true) },
                new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) },
                new LabelOffset() { Val = new UInt16Value((ushort)100) }));

            // Add the Value Axis.
            ValueAxis valAx = plotArea.AppendChild(new ValueAxis(new AxisId() { Val = new UInt32Value(48672768u) },
                new Scaling(new DocumentFormat.OpenXml.Drawing.Charts.Orientation()
                {
                    Val = new EnumValue<OrientationValues>(OrientationValues.MinMax)
                }),
                new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                new MajorGridlines(),
                new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                {
                    FormatCode = new StringValue("General"),
                    SourceLinked = new BooleanValue(true)
                }, new TickLabelPosition()
                {
                    Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo)
                }, new CrossingAxis() { Val = new UInt32Value(48650112U) },
                new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }));

            // Add the chart Legend.
            Legend legend = chart.AppendChild(new Legend(new LegendPosition() { Val = new EnumValue<LegendPositionValues>((LegendPositionValues)lp) },
                new Layout()));

            GeneratePartContent(_mainDocumentPart);
            _wordDocument.Save();
            _wordDocument.Close();
        }
        public static void GeneratePartContent(MainDocumentPart _mainDocumentPart)
        {
            Paragraph paragraph = new Paragraph() {};

            // Create a new run that has an inline drawing object
            Run run = new Run();
            Drawing drawing = new Drawing();

            Inline inline = new Inline();
            inline.Append(new Extent() { Cx = 5274310L, Cy = 3076575L });
            DocProperties docPros = new DocProperties() { Id = (UInt32Value)1U, Name = "Chart 1" };
            inline.Append(docPros);

            DocumentFormat.OpenXml.Drawing.Graphic g = new DocumentFormat.OpenXml.Drawing.Graphic();
            DocumentFormat.OpenXml.Drawing.GraphicData graphicData = new DocumentFormat.OpenXml.Drawing.GraphicData() { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" };
            ChartReference chartReference = new ChartReference() { Id = "rId110" };
            graphicData.Append(chartReference);
            g.Append(graphicData);
            inline.Append(g);
            drawing.Append(inline);
            run.Append(drawing);
            paragraph.Append(run);

            _mainDocumentPart.Document.Body.Append(paragraph);
        }
        protected override void SaveWord()
        {
            _docBody.AppendChild(CreateSectionProperties());
            _wordDocument.Save();
            _wordDocument.Close();
        }
    }
}
