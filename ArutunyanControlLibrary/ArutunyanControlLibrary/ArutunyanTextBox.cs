using System.Text.RegularExpressions;

namespace ArutunyanControlLibrary
{
    /// <summary>
    /// Компонент TextBox
    /// </summary>
    public partial class ArutunyanTextBox : UserControl
    {
        /// <summary>
        /// Событие изменения текста
        /// </summary>
        public event EventHandler ValueChanged;
        /// <summary>
        /// Шаблон для проверки заполнения поля
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Значение поля TextBox
        /// </summary>
        public string Value { 
            get { if (textBox.Text != "" && !Regex.IsMatch(textBox.Text, Template)) return string.Empty; return textBox.Text;  } 
            set { if (value != "" && !Regex.IsMatch(value, Template)) textBox.Text = string.Empty; else textBox.Text = value; } 
        }

        public ArutunyanTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод создания плейсхолдера с шаблоном-примером
        /// </summary>
        /// <param name="examp"> Шаблон-пример </param>
        public void SetExample(string examp)
        {
            toolTip.SetToolTip(textBox, examp);
        }

        /// <summary>
        /// Событие изменения текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }
    }
}
