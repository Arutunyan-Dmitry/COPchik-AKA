using ArutunyanNotVisualControlLibrary.OfficePackage;
using ArutunyanNotVisualControlLibrary.OfficePackage.HelperEnums;
using ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels;
using ArutunyanNotVisualControlLibrary.OfficePackage.Implements;
using System.ComponentModel;

namespace ArutunyanNotVisualControlLibrary
{
    public partial class LinearDiagramDocx : Component
    {
        AbstractSaveToWord _saveToWord = new SaveToWord();
        public LinearDiagramDocx()
        {
            InitializeComponent();
        }

        public LinearDiagramDocx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// Создание документа с линейной диаграммой
        /// </summary>
        /// <param name="path">Путь к файлу для сохранения</param>
        /// <param name="header">Заголовок диаграммы</param>
        /// <param name="lp">Позиция легенды</param>
        /// <param name="data">Данные диаграммы (название серии, массив значений (точек) серии)</param>
        /// <exception cref="ArgumentException"></exception>
        public void CreateWordDocx(string path, string header, LegendPositions lp, List<(string, int[])> data)
        {
            if (!path.Equals("") && !header.Equals("") && data != null && data?.Count > 0)
            {
                if (!path.Substring(path.Length - 5).Contains(".doc") ||
                    !path.Contains(":\\") || !path.Contains("\\"))
                {
                    throw new ArgumentException("Путь должен быть указан верно и содержать" +
                        "в себе название файла. Пример: C:\\user\\MyDocument.docx");
                }
                _saveToWord.CreateLinearDiagramDocx(new WordDiagramInfo
                {
                    Path = path,
                    Header = header,
                    LegendPosition = lp,
                    Data = data
                });
            }
            else
            {
                throw new ArgumentException("Ни один из аргументов не должны быть пустым");
            }
        }
    }
}
