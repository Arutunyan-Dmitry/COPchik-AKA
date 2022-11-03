using ArutunyanNotVisualControlLibrary.OfficePackage.Implements;
using ArutunyanNotVisualControlLibrary.OfficePackage;
using System.ComponentModel;
using ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels;

namespace ArutunyanNotVisualControlLibrary
{
    public partial class DoubleStringTableDocx : Component
    {
        private readonly AbstractSaveToWord _saveToWord = new SaveToWord();
        public DoubleStringTableDocx()
        {
            InitializeComponent();
        }

        public DoubleStringTableDocx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// Создание документа с таблицей
        /// </summary>
        /// <param name="path">Путь к файлу для сохранения</param>
        /// <param name="header">Заголовок таблицы</param>
        /// <param name="joined">Объединение ячеек (с какой, по какую, каким текстом объединить)</param>
        /// <param name="width">Ширина каждого столбца (px)</param>
        /// <param name="columns">Соответсвие колонка - поле объекта (текст колонки, название поля)</param>
        /// <param name="data">Список объектов данных</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public void CreateWordDocx(string path, string header, List<(int, int, string)> joined,
            int[] width, List<(string, string)> columns, List<Object> data)
        {
            if (!path.Equals("") && !header.Equals("") && joined != null && joined?.Count > 0 &&
                width != null && width?.Length > 0 && columns != null && columns?.Count > 0 && 
                data != null && data?.Count > 0)
            {
                if (!path.Substring(path.Length - 5).Contains(".doc") ||
                    !path.Contains(":\\") || !path.Contains("\\"))
                {
                    throw new ArgumentException("Путь должен быть указан верно и содержать" +
                        "в себе название файла. Пример: C:\\user\\MyDocument.docx");
                }
                if(width.Length != columns.Count)
                {
                    throw new ArgumentException("Не всем колонкам соответствует ширина");
                }
                for (int i = 0; i < joined.Count; i++)
                {
                    int tmp = joined[i].Item1;
                    for (int j = 0; j < joined.Count; j++)
                    {
                        if (tmp >= joined[j].Item1 && tmp <= joined[j].Item2 && i != j)
                            throw new Exception("Объединение ячеек не должно накладываться" +
                                "друг на друга");
                    }
                }
                _saveToWord.CreateTableDoc(new WordTableInfo
                {
                    Path = path,
                    Header = header,
                    Joined = joined,
                    Width = width,
                    Columns = columns,
                    Data = data,
                });
            }
            else
            {
                throw new ArgumentException("Ни один из аргументов не должны быть пустым");
            }
        }
    }
}
