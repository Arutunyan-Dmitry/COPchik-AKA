using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace KOP
{
    public partial class SelectedControl : UserControl
    {
        //Список с выбором
        //Список заполняется через метод, передающий список строк

        public SelectedControl()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedIndexChanged
        {
            add
            {
                myCheckedListBox.SelectedIndexChanged += value;
            }
            remove
            {
                myCheckedListBox.SelectedIndexChanged -= value;
            }
        }

        public string SelectedItem //свойство для получения и установки выбранного значения
        {
            get
            {
                if (myCheckedListBox.SelectedItem == null)
                {
                    return string.Empty;
                }

                return myCheckedListBox.SelectedItem.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && myCheckedListBox.Items.Contains(value))
                {
                    myCheckedListBox.SetItemChecked(myCheckedListBox.Items.IndexOf(value), true);
                }
            }
        }


        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e) 
        {
            if (e.NewValue == CheckState.Checked && myCheckedListBox.CheckedItems.Count > 0)
            {
                myCheckedListBox.ItemCheck += new ItemCheckEventHandler(CheckedListBox_ItemCheck);
            }
        }


        public void FillCheckedListBox(List<String> strings) //заполнение списком строк
        {
            foreach (string item in strings)
            {
                myCheckedListBox.Items.Add(item);
            }
        }

        public void ClearCheckedListBox() //чистка
        {
            myCheckedListBox.Items.Clear();
        }
    }
}