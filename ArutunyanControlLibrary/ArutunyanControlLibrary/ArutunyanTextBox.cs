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
        public string Value { get; set; }

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
            Value = textBox.Text;
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Событие для проверки введённого текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox.Text, Template) &&
                textBox.Text != String.Empty)
            {
                throw new Exception("Поле должно быть заполнено в соответствии с шаблоном!");
            }
        }
    }
}
