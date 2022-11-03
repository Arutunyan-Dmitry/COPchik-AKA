using ArutunyanNotVisualControlLibrary.OfficePackage;
using ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels;
using ArutunyanNotVisualControlLibrary.OfficePackage.Implements;
using System.ComponentModel;

namespace ArutunyanNotVisualControlLibrary
{
    public partial class BigTextDocx : Component
    {
        private readonly AbstractSaveToWord _saveToWord = new SaveToWord();
        public BigTextDocx()
        {
            InitializeComponent();
        }

        public BigTextDocx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        /// <summary>
        /// Создание документа с большим текстом
        /// </summary>
        /// <param name="path">Путь к файлу для сохранения</param>
        /// <param name="header">Заголовок текста</param>
        /// <param name="text">Текст</param>
        /// <exception cref="ArgumentException"></exception>
        public void CreateWordDoc(string path, string header, string[] text)
        {
            if (!path.Equals("") && !header.Equals("") && text != null && text?.Length > 0)
            {
                if(!path.Substring(path.Length - 5).Contains(".doc") ||
                    !path.Contains(":\\") || !path.Contains("\\"))
                {
                    throw new ArgumentException("Путь должен быть указан верно и содержать" +
                        "в себе название файла. Пример: C:\\user\\MyDocument.docx");
                }
                _saveToWord.CreateBigTextDoc(new WordBigTextInfo
                {
                    Path = path,
                    Header = header,
                    Text = text
                });
            } else
            {
                throw new ArgumentException("Ни один из аргументов не должны быть пустым");
            }
        }
    }
}
