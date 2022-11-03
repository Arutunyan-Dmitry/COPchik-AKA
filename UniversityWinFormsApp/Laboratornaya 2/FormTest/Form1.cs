using Laboratornaya_2.PDFDocumentWithHistogram;
using Laboratornaya_2.PDFDocumentWithTable;
using Laboratornaya_2.PDFDocumentWithTables;
using System;

namespace FormTest
{
    public partial class Form1 : Form
    {
        DocumentWithTables dwt;
        DocumentWithCustomTable dwct;
        DocumentWithHistogram dwhist;
        public Form1()
        {
            InitializeComponent();
        }
        List<string[,]> listArrays = new List<string[,]>();
        string[,] myArray = { { "hello", "world", "hey" }, { "i", "haven't", "idea" }, { "����", "�����", "�" },
                                {"�", "������", "����� � ������� ���� ��������� ���������� �� ������" }};


        string[,] myArray2 = { { "������", "����", "��������" }, { "������ ������������ ", "�������� ", "�������� " }, { "������� ", "������� ", "��������� ��������" },
                                {"�", "������", "����� � ������� ���� ��������� ���������� �� ������ 2 " }};


        List<TestDate> testData = new List<TestDate>()
            {
                new TestDate( "Double Knot", 2020, "Mixtape", "Gone Days"),
                 new TestDate( "Wolfgang", 2021, "Thunderous", "Scars"),
                  new TestDate( "Stop", 2022, "Slump", "Any")
            };
        int[] Width = { 100, 50, 120, 70, 70 };
        int[] Height = { 40, 20, 50, 90 };
        List<string> HeadersColumns = new List<string> { "id �����", " �������� �����", "��������� ��� �������", "��� ����� �������� �����", "� ��� ��������" };
        List<string> HeadersRows = new List<string> { "1", "2", "��� ��� ��������� 3" };

        List<(string, double[])> DataHistogram = new List<(string, double[])>
        {
            ("Mixtape", new double[] {10, 15, 20, 25}), ("Thunderous", new double[] {4, 8, 12}),
            ("Wolfgang", new double[] {4, 71, 25,3,9}), ("Double Knot", new double[] {56})
        };
        private void button1_Click(object sender, EventArgs e)
        {
            listArrays.Add(myArray);
            listArrays.Add(myArray2);
            dwt = new DocumentWithTables();
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    dwt.CreatePDF(dialog.FileName, "Someting Good", listArrays);
                    MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Tuple<string, string>> HeadersField = new List<Tuple<string, string>>();
            HeadersField.Add(Tuple.Create("id �����", ""));
            HeadersField.Add(Tuple.Create("�������� �����", "MyStringColumn1"));
            HeadersField.Add(Tuple.Create("��� ����� �������� �����", "MyStringColumn2"));
            HeadersField.Add(Tuple.Create("��������� ��� �������", "MyIntColumn"));
            HeadersField.Add(Tuple.Create("� ��� ��������", "MyStringColumn3"));
            dwct = new DocumentWithCustomTable();
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    dwct.CreatePDF<TestDate>(dialog.FileName, "Someting Good", Width, Height, HeadersField, HeadersRows, testData);
                    MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dwhist = new DocumentWithHistogram();
            string HeaderHistogram = "��������� �����������";
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dwhist.CreatePdfHistogram(dialog.FileName, "Something Good", HeaderHistogram, DataHistogram, LegendPosition.LeftArea);
                    //dwt.CreatePDF(dialog.FileName, "Someting Good", listArrays);
                    MessageBox.Show("���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}