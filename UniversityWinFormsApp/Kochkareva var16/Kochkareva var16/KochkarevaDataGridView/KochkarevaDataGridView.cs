using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kochkareva_var16.KochkarevaDataGridView
{
    /// <summary>
    /// Визуальный компонент для вывода списка в виде таблицы (DataGridView).
    /// DataGridView настроен так, чтобы выбиралась только одна строка и строка целиком, а не ячейка, RowHeaders был скрыт. +
    /// Отдельный метод для конфигурации столбцов. +
    /// Через метод указывается сколько колонок + в DataGridView добавлять, их заголовки +, ширину +, признак видимости + и 
    /// имя свойства/поля объекта класса, + записи которого будут в таблице выводиться, значение из которого потребуется выводить в ячейке этой колонки. +
    /// Метод отчистки строк. +
    /// Публичное свойство для установки и получения индекса выбранной строки (set, get).  +
    /// Публичный параметризованный метод для получения объекта из выбранной строки (создать объект и через рефлексию заполнить свойства его). +
    /// </summary>

    public partial class KochkarevaDataGridView : UserControl
    {
        public KochkarevaDataGridView()
        {
            InitializeComponent();
        }
        public int IndexLine
        {
            get
            {
                if (dataGridView1.CurrentRow.Index < 0)
                {
                    throw new Exception("Данной строки не существует");
                }
                else
                {
                   return dataGridView1.CurrentRow.Index;
                }
            }
            set
            {
                if (value > dataGridView1.Rows.Count)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
                else 
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[value].Cells[0];
                }
            }
        }

        /// <summary>
        /// Метод настройки таблицы
        /// </summary>
        /// <param name="CountColumn"> Количество колонок </param>
        /// <param name="NameColumns"> Названия колонок </param>
        /// <param name="WidthColumns"> Ширина колонок </param>
        /// <param name="IsVisibleColumns"> Видимость колонок </param>
        /// <param name="NameObjects"> Названия свойств/полей объекта класса </param>
        public void AddSetting(List<SettingColumn> settingColumns)
        {
            dataGridView1.ColumnCount = settingColumns.Count;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < settingColumns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = settingColumns[i].NameColumn;
                dataGridView1.Columns[i].Width = settingColumns[i].WidthColumn;
                dataGridView1.Columns[i].Visible = settingColumns[i].IsVisibleColumn;
                dataGridView1.Columns[i].Name = settingColumns[i].NameObject;
            }
        }

        /// <summary>
        /// метод, со списком объектов какого-то класса в параметр, который идет заполнение DataGridView;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"> количество строк (объектов класса) в DataGridView </param>
        public void FillingDataGridView<T>(List<T> values)
        {
            int rowIndex = 0;
            dataGridView1.RowCount = values.Count;
            foreach (T value in values)
            {                
                for(int i = 0; i < dataGridView1.Columns.Count; i++)
                {   
                    var field = value?.GetType().GetProperties()?
                                               .FirstOrDefault(x => x.Name == dataGridView1.Columns[i].Name)?
                                               .GetValue(value);
                    dataGridView1.Rows[rowIndex].Cells[i].Value = field;
                }
                rowIndex++;
            }
        }

        /// <summary>
        /// Метод для получения объекта из выбранной строки
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого объекта</typeparam>
        /// <returns></returns>
        public T GetSelectedValue<T>()
        {
            T selectedValue = (T)FormatterServices.GetUninitializedObject(typeof(T)); //does not call ctor
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                var cellValue = dataGridView1.Rows[IndexLine].Cells[i].Value;

                var field = typeof(T).GetProperties()?.FirstOrDefault(x => x.Name == dataGridView1.Columns[i].Name);
                if (field != null)
                {
                    selectedValue?.GetType().GetProperties()?.FirstOrDefault(x => x.Name == dataGridView1.Columns[i].Name)?.
                        SetValue(selectedValue, Convert.ChangeType(cellValue, field.PropertyType));
                }
            }
            return selectedValue;
        }

        /// <summary>
        /// Метод отчистки строк
        /// </summary>
        public void ClearDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }        
    }
}
