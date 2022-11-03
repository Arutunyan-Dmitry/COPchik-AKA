using System.Runtime.Serialization;
using System.Text;

namespace ArutunyanControlLibrary
{
    /// <summary>
    /// Компонент ListBox
    /// </summary>
    public partial class ArutunyanListBox : UserControl
    {
        private string StartSym = "";
        private string EndSym = "";
        private List<(string, string, List<string>)> Pattern = new List<(string, string, List<string>)>();

        public int currentIndex
        {
            get { if (listBox.SelectedIndex == -1) return -1; return listBox.SelectedIndex;  }
            set { if (value > listBox.Items.Count) listBox.SelectedIndex = -1; else listBox.SelectedIndex = value; }
        }

        public ArutunyanListBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для задания макетной строки listbox
        /// </summary>
        /// <param name="startSym"> Символ начала наименования поля </param>
        /// <param name="endSym"> Символ конца наименования поля </param>
        /// <param name="pattern"> Макетная строка </param>
        /// <exception cref="Exception"></exception>
        public void setPattern(string startSym, string endSym, string pattern)
        {
            if (!startSym.Equals("") && !endSym.Equals("") && !pattern.Equals(""))
            {
                Pattern.Clear();
                StartSym = startSym;
                EndSym = endSym;
                string tmpName = "";
                string tmpField = "";
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i] != StartSym[0])
                    {
                        tmpName += pattern[i];
                    } else
                    {
                        for (int j = i+=1; j < pattern.Length; j++)
                        {
                            if (pattern[j] != EndSym[0])
                            {
                                tmpField += pattern[j];
                            } else
                            {
                                i = j;
                                Pattern.Add((tmpName, tmpField, new List<string>()));
                                tmpName = "";
                                tmpField = "";
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Укажите все необходимые параметры");
            }
        }

        /// <summary>
        /// Метод заполнения listbox
        /// </summary>
        /// <typeparam name="T"> Тип передаваемого объекта </typeparam>
        /// <param name="items"> Список передаваемых объектов </param>
        /// <exception cref="Exception"></exception>
        public void fillList<T>(List<T> items)
        {
            StringBuilder tmp = new StringBuilder();
            foreach (var item in items)
            {
                tmp = new StringBuilder();
                for (int i =0; i < Pattern.Count; i++)
                {
                    if (item?.GetType().GetProperties()?.FirstOrDefault(x => x.Name == Pattern[i].Item2) == null)
                    {
                        throw new Exception("Макет несоответствует полям класса");
                    }
                    var value = item?.GetType().GetProperties()?
                                               .FirstOrDefault(x => x.Name == Pattern[i].Item2)?
                                               .GetValue(item);
                    tmp.Append($"{Pattern[i].Item1} {value}");
                    Pattern[i].Item3.Add(value?.ToString());
                }
                listBox.Items.Add(tmp);
            }
        }

        /// <summary>
        /// Метод получения выбранного объекта (возвращает объект выбранной строки)
        /// </summary>
        /// <typeparam name="T"> Тип возвращаемого объекта </typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T getSelectedObj<T>()
        {
            T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
            if (listBox.Text != "")        
            {
                foreach (var value in Pattern)
                {
                    var field = obj.GetType().GetProperties()?
                        .FirstOrDefault(x => x.Name == value.Item2);
                    field?.SetValue(obj, Convert.ChangeType(value.Item3[currentIndex], field.PropertyType));
                }
                return obj;
            }
            else
            {
                throw new Exception("Строка не выбрана");
            }
        }
    }
}
