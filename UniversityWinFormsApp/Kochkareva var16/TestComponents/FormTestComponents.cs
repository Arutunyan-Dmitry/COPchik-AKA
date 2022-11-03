using Kochkareva_var16.KochkarevaDataGridView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestComponents
{
    public partial class FormTestComponents : Form
    {
        List<string> values = new List<string>() { "MANIAC",
                                                        "VENOM",
                                                        "Chramer",
                                                        "Miroh",
                                                        "Back door"};
        public string NameColumn = "AllIn LegendaryWar Noesy Oddinary";
        public string WidthColumn = "80 150 80 150";
        public string IsVisibleColumn = "true true true true";
        public string NameObject = "MyStringColumn1 MyIntColumn MyStringColumn2 MyStringColumn3";
        TestDate td = new TestDate("qwerty", 15, "qwerty", "qwerty"); 
        
        public FormTestComponents()
        {
            InitializeComponent();
            kochkarevaListBox1.FillingList(values);
           // kochkarevaDataGridView1.AddSetting(4, NameColumn, WidthColumn, IsVisibleColumn, NameObject);
            //SettingColumn(string NameColumn, int WidthColumn, bool IsVisibleColumn, string NameObject)
            List<SettingColumn> columns = new List<SettingColumn>();
            columns.Add(new SettingColumn("AllIn", 80,true, "MyStringColumn1"));
            columns.Add(new SettingColumn("LegendaryWar", 150, true, "MyIntColumn"));
            columns.Add(new SettingColumn("Noesy", 80, true, "MyStringColumn2"));
            columns.Add(new SettingColumn("Oddinary", 150, true, "MyStringColumn3"));
            kochkarevaDataGridView1.AddSetting(columns);

            List<TestDate> testDates = new List<TestDate>()
            {
                new TestDate("Double Knot", 2020, "Mixtape", "Gone Days"),
                 new TestDate("Wolfgang", 2021, "Thunderous", "Scars"),
                  new TestDate("Stop", 2022, "Slump", "Any")
            };
            kochkarevaDataGridView1.FillingDataGridView<TestDate>(testDates);
        }

        private void kochkarevaListBox1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("элемент: " + kochkarevaListBox1.CurrentValue, "Выбранный элемент", MessageBoxButtons.OK);

          //  td = kochkarevaDataGridView1.GetSelectedValue<TestDate>();
        }

        private void kochkarevaTextBox1_ValueChanged(object sender, EventArgs e)
        {

            MessageBox.Show("элемент: " + kochkarevaTextBox1.CurrentValue, "Выбранный элемент", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kochkarevaDataGridView1.IndexLine = 2;

            var testTD = kochkarevaDataGridView1.GetSelectedValue<TestDate>();

            MessageBox.Show("элемент: " + testTD.MyStringColumn1.ToString() +" " + testTD.MyIntColumn.ToString()
                + " " + testTD.MyStringColumn2.ToString() + " " + testTD.MyStringColumn3.ToString(), "Выбранный элемент", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("элемент: " + kochkarevaDataGridView1.IndexLine.ToString(), "Выбранный элемент", MessageBoxButtons.OK);
        }
    }
}
