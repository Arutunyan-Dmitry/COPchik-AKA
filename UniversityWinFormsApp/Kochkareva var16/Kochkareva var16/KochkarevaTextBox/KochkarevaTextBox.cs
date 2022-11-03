
namespace Kochkareva_var16.KochkarevaTextBox
{
    public partial class KochkarevaTextBox : UserControl
    {
        public KochkarevaTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выбранное значение
        /// </summary>
        public double? CurrentValue
        {
            set
            {
                if (!value.HasValue)
                {
                    textBox1.Text = null;
                    checkBox1.Checked = true;
                }
                else
                {
                    textBox1.Text = value.ToString();
                    checkBox1.Checked = false;
                }
            }
            get
            {
                if (checkBox1.Checked)
                {
                    return null;
                }
                else
                {
                    if (double.TryParse(textBox1.Text, out double doubleValue))
                        return doubleValue;
                    else
                    {
                        throw new Exception("Данные введены не корректно");
                    }
                }
            }
        }

        public event EventHandler ValueChanged;

        /// <summary>
        /// Событие, выдающие ошибку при нажатии не на числа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("Введите число", "Выбранный элемент", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Событие, вызываемое при смене значения textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(!checkBox1.Checked)
            {
                textBox1.Enabled = true;
            } 
            else
            {
                textBox1.Enabled = false;
            }
        }
    }
}
