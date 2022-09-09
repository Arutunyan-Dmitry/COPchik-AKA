namespace ArutunyanControlLibrary
{
    /// <summary>
    /// Компонент ComboBox
    /// </summary>
    public partial class ArutunyanComboBox : UserControl
    {
        /// <summary>
        /// Событие изменения выбранного значения
        /// </summary>
        public event EventHandler SelectedItemChanged;
        /// <summary>
        /// Текущее значение
        /// </summary>
        public string CurrentValue { get; set; }
        public ArutunyanComboBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод заполнения ComboBox
        /// </summary>
        /// <param name="list"> Список эл-тов </param>
        public void SetValuesFromList(List<string> list)
        {
            Clear();
            foreach (string item in list)
                comboBox.Items.Add(item);
        }
        /// <summary>
        /// Метод очистки ComboBox
        /// </summary>
        public void Clear()
        {
            comboBox.Items.Clear();
        }
        /// <summary>
        /// Событие изменения выбранного значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem != null)
                CurrentValue = comboBox.SelectedItem.ToString();
            else
                CurrentValue = string.Empty;
            EventHandler handler = SelectedItemChanged;
            handler?.Invoke(this, e);
        }
    }
}
