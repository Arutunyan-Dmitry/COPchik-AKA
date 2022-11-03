using KOP.Helpers;
using Unity;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;
using UniversityContracts.ViewModels;

namespace UniversityWinFormsApp
{
    public partial class FormMain : Form
    {
        public readonly IStudentLogic _studentLogic;
        public readonly IHandBookLogic _handBookLogic;
        public FormMain(IStudentLogic studentLogic, IHandBookLogic handBookLogic)
        {
            InitializeComponent();
            _studentLogic = studentLogic;
            _handBookLogic = handBookLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            var list = _studentLogic.Read(null);
            outputControl.Clear();
            outputControl.ConfigTree(new List<string>()
            {
                "Grade",
                "Scholatship",
                "Id",
                "Flm"
            });
            outputControl.CreateTree(list);
        }
        //-------------------------- Компоненты меню ---------------------------
        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormHandBook>();
            form.ShowDialog();
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent();
        }
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateStudent();
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }
        private void текстовыйДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDocx();
        }
        private void таблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePdf();
        }
        private void диаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateExcel();
        }
        //-------------------------- Компоненты меню ---------------------------

        //---------------------- Отработка нажатия клавиш ----------------------
        private void outputControl_KeysDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                AddStudent();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.U)
                UpdateStudent();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D)
                DeleteStudent();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                CreateDocx();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
                CreatePdf();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
                CreateExcel();
        }
        //---------------------- Отработка нажатия клавиш ----------------------

        //--------------------------- Функ. методы -----------------------------
        public void AddStudent()
        {
            var form = Program.Container.Resolve<FormStudent>();
            form.ShowDialog();
            LoadData();
        }
        public void UpdateStudent()
        {
            try
            {
                var student = outputControl.GetSelectedNode<StudentViewModel>();
                var form = Program.Container.Resolve<FormStudent>();
                form.Id = student.Id;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
        public void DeleteStudent()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var student = outputControl.GetSelectedNode<StudentViewModel>();
                    _studentLogic.Delete(new StudentBindingModel()
                    {
                        Id = student.Id
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadData();
        }
        public void CreateDocx()
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var list = _studentLogic.Read(new StudentBindingModel()
                    {
                        Scholatship = 0.1
                    });
                    string[] arr = new string[list.Count];
                    for (int i = 0; i < list.Count; i++)
                    {
                        arr[i] = list[i].Flm + " " + list[i].ShortCharacteristic;
                    }
                    bigTextDocx.CreateWordDoc(dialog.FileName, "Студенты", arr);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void CreatePdf()
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var list = _studentLogic.Read(null);
                    var rows = new List<string>();
                    foreach (var item in list)
                    {
                        rows.Add(item.Id.ToString());
                    }

                    int[] rowsH = new int[rows.Count + 1];
                    for (int i = 0; i < rowsH.Length; i++)
                    {
                        rowsH[i] = 1;
                    }

                    var headers = new List<Tuple<string, string>>();
                    headers.Add(new Tuple<string, string>("", ""));
                    headers.Add(new Tuple<string, string>("ФИО", "Flm"));
                    headers.Add(new Tuple<string, string>("Курс", "Grade"));
                    headers.Add(new Tuple<string, string>("Стипендия", "Scholatship"));

                    documentWithCustomTable.CreatePDF(dialog.FileName, "Студенты", new int[5]
                    {
                        50, 200, 80, 80, 0
                    }, rowsH, headers, rows, list);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void CreateExcel()
        {
            using var dialog = new SaveFileDialog { Filter = "xls|*.xls" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var handBookList = _handBookLogic.Read(null);
                    var diagramData = new Dictionary<string, int>();
                    foreach (var item in handBookList)
                    {
                        var studlist = _studentLogic.Read(new StudentBindingModel()
                        {
                            Grade = item.Info
                        });
                        diagramData.Add(item.Info, studlist.Count);
                    }
                    diagramExel.CreateExelDiagram(dialog.FileName, "Студенты", "Получают стипендию", LegendPlace.Bottom, diagramData);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------- Функ. методы -----------------------------
    }
}
