using ArutunyanNotVisualControlLibrary.OfficePackage.HelperEnums;
using ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels;

namespace ArutunyanNotVisualControlLibrary.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateBigTextDoc(WordBigTextInfo info)
        {
            CreateWord(info.Path);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Header, new
                WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var item in info.Text)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { ("     " + item, new
                    WordTextProperties { Size = "18", Bold = false, }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "18",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord();
        }
        public void CreateTableDoc(WordTableInfo info)
        {
            CreateWord(info.Path);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> {
                (info.Header, new WordTextProperties { Bold = true, Size = "24", })},
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            CreateTable(info.Width, info.Joined, info.Columns);
            List<string> values = new List<string>();
            for (int i = 0; i < info.Data.Count; i++)
            {            
                foreach(var pattern in info.Columns)
                {
                    if (info.Data[i]?.GetType().GetProperties()?.FirstOrDefault(x => x.Name == pattern.Item2) == null)
                    {
                        throw new Exception("Макет несоответствует полям класса");
                    }
                    var value = info.Data[i]?.GetType().GetProperties()?
                                               .FirstOrDefault(x => x.Name == pattern.Item2)?
                                               .GetValue(info.Data[i]);
                    values.Add(value.ToString());
                }
                CreateRow(i, info.Width, values);
                values.Clear();
            }
            SaveWord();
        }

        public void CreateLinearDiagramDocx(WordDiagramInfo info)
        {
            CreateWord(info.Path);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> {
                (info.Header, new WordTextProperties { Bold = true, Size = "24", })},
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            CreateLinearDiagram(info.LegendPosition, info.Data);
        }
        /// <summary>
        /// Создание doc-файла
        /// </summary>
        /// <param name="path"></param>
        protected abstract void CreateWord(string path);
        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);
        /// <summary>
        /// Создание заголовка таблицы с текстом
        /// </summary>
        /// <param name="width"></param>
        /// <param name="joined"></param>
        /// <param name="columns"></param>
        protected abstract void CreateTable(int[] width, List<(int, int, string)> joined,
            List<(string, string)> columns);
        /// <summary>
        /// Создание строки таблицы с текстом
        /// </summary>
        /// <param name="widthIndex"></param>
        /// <param name="width"></param>
        /// <param name="tableRow"></param>
        protected abstract void CreateRow(int widthIndex, int[] width, List<string> tableRow);
        /// <summary>
        /// Создание диаграммы
        /// </summary>
        /// <param name="lp"></param>
        /// <param name="data"></param>
        protected abstract void CreateLinearDiagram(LegendPositions lp, List<(string, int[])> data);
        /// <summary>
        /// Сохранение файла
        /// </summary>
        protected abstract void SaveWord();
    }
}
