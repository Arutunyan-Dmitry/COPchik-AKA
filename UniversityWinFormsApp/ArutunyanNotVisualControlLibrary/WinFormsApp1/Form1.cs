using ArutunyanNotVisualControlLibrary.OfficePackage.HelperEnums;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bigTextDocx1.CreateWordDoc("D:\\����.doc", "����", new string[] { "���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ����",
                                                                             "���� ���� ������ ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ����  ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ����",
                                                                             "���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� �� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ���� ����",
                                                                            });
                MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                doubleStringTableDocx1.CreateWordDocx("D:\\����1.docx", "����", new List<(int, int, string)>
            {
                (0, 2, "Text1"),
                (4, 5, "Text2")
            }, new int[] { 3400, 2300, 2000, 3700, 3200, 1500 }, new List<(string, string)> {
                ("Col1", "field0"),
                ("Col2", "field3"),
                ("Col3", "field4"),
                ("Col4", "field1"),
                ("Col5", "field5"),
                ("Col6", "field2"),
            }, new List<Object> { new Test(1, 2, "skdkd", 3, 4, 2.5, 6),
               new Test(1, 2, "skdkd", 3, 4, 2.5, 6),
               new Test(1, 2, "skdkd", 3, 4, 2.5, 6),
               new Test(1, 2, "skdkd", 3, 4, 2.5, 6),
               new Test(1, 2, "skdkd", 3, 4, 2.5, 6),
               new Test(1, 2, "skdkd", 3, 4, 2.5, 6),});
                MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                linearDiagramDocx1.CreateWordDocx("D:\\����2.docx", "���������", LegendPositions.Right, new List<(string, int[])>
            {
                ("First", new int[] { 5, 10, 3}),
                ("Second", new int[] { 15, 2, 7}),
                ("Third", new int[] { 4, 25}),
                ("Fourth", new int[] { 6, 12, 14})
            });
                MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}