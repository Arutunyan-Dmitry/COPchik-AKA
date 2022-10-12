using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOP
{
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }


        public event EventHandler OutputDatehanged
        {
            add
            {
                myDateTimePicker.ValueChanged += value;
            }
            remove
            {
                myDateTimePicker.ValueChanged -= value;
            }
        }


        public DateTime? DateFrom { get; set; } = null;
        public DateTime? DateTo { get; set; } = null;

        public DateTime? Value
        {
            get
            {
                if (!DateFrom.HasValue || !DateTo.HasValue || myDateTimePicker.Value < DateFrom || myDateTimePicker.Value > DateTo)
                {
                    labelText.Text = "Данные не соответвуют диапозону, будет выбрана дата системы";
                    return DateTime.Now;

                }
                labelText.Text = null;
                return myDateTimePicker.Value;
            }
            set
            {
                if (!DateFrom.HasValue || !DateTo.HasValue || value < DateFrom || value > DateTo)
                {
                    labelText.Text = "Вы не ввелии данные!";
                    return;
                }
                myDateTimePicker.Value = value.Value;
            }
        }
    }
}
