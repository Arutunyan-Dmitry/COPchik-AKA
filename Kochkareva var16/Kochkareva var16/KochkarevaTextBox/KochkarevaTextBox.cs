using Kochkareva_var16.KochkarevaListBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
        public int? CurrentValue
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
                    if (int.TryParse(textBox1.Text, out int intValue))
                        return intValue;
                    else
                    {
                        throw new Exception("Данные введены не корректные");
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
    }
}
