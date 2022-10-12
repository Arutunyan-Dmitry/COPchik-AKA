using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kochkareva_var16.KochkarevaListBox
{

    /// Список значений.
    /// Список заполняется через метод, передающий список строк
    public partial class KochkarevaListBox : UserControl
    {
        /// <summary>
        /// Выбранное значение предусмотреть возможность возврата значения null
        /// </summary>
        public string CurrentValue
        {
            set
            {
                if (listBox.SelectedIndex == -1)
                {
                    listBox.SelectedItem = string.Empty;
                }
                else
                {
                    listBox.SelectedItem = value;
                }
            }
            get 
            { 
                if(listBox.SelectedIndex == -1)
                {
                    return string.Empty;
                }
                else
                {
                    return listBox.SelectedItem.ToString();
                }
            }
        }

        public event EventHandler ValueChanged;

        public KochkarevaListBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для заполнения списка
        /// </summary>
        public void FillingList(List<string> list)
        {
            foreach (string items in list)
            {
                listBox.Items.Add(items);
            }
        }

        /// <summary>
        ///  Метод для очистки списка
        /// </summary>
        public void ClearList()
        {
            listBox.Items.Clear();
        }

        /// <summary>
        /// Событие, вызываемое при смене значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }
    }
}
