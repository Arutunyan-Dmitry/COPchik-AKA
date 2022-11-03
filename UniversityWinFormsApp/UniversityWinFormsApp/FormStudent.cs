using System.Windows.Forms;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;

namespace UniversityWinFormsApp
{
    public partial class FormStudent : Form
    {
        public int Id { set { id = value; } }
        private readonly IStudentLogic _studentLogic;
        private readonly IHandBookLogic _handBookLogic;
        private int? id;
        public FormStudent(IStudentLogic studentLogic, IHandBookLogic handBookLogic)
        {
            InitializeComponent();
            _studentLogic = studentLogic;
            _handBookLogic = handBookLogic;
        }
        private void FormStudent_Load(object sender, EventArgs e)
        {
            var handbook = _handBookLogic.Read(null);
            List<string> handBookValues = new List<string>();
            foreach (var item in handbook)
            {
                handBookValues.Add(item.Info);
            }
            arutunyanComboBox.SetValuesFromList(handBookValues);

            if (id.HasValue)
            {
                try
                {
                    var view = _studentLogic.Read(new StudentBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFlm.Text = view.Flm;
                        textBoxShortCharacteristic.Text = view.ShortCharacteristic;
                        arutunyanComboBox.CurrentValue = view.Grade;                  
                        kochkarevaTextBox.CurrentValue = view.Scholatship;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFlm.Text) || string.IsNullOrEmpty(textBoxShortCharacteristic.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _studentLogic.CreateOrUpdate(new StudentBindingModel
                {
                    Id = id,
                    Flm = textBoxFlm.Text,
                    ShortCharacteristic = textBoxShortCharacteristic.Text,
                    Grade = arutunyanComboBox.CurrentValue,
                    Scholatship = kochkarevaTextBox.CurrentValue
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
