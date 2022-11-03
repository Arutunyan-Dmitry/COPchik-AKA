using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;

namespace UniversityWinFormsApp
{
    public partial class FormHandBook : Form
    {
        private readonly IHandBookLogic _logic;
        public FormHandBook(IHandBookLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormHandBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {          
            try
            {
                dataGridView.Rows.Clear();
                var list = _logic.Read(null);
                if (list != null)
                {
                    foreach(var item in list)
                    {
                        dataGridView.Rows.Add(item.Id, item.Info);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                dataGridView.Rows.Add();
                dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[1];
                dataGridView.BeginEdit(true);
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView.CurrentRow.Index != dataGridView.Rows.Count - 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Удалить эту(ти) запись(и)?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        {
                            try
                            {
                                _logic.Delete(new HandBookBindingModel()
                                {
                                    Id = (int)row.Cells[0].Value
                                });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }           
                    LoadData();
                } 
                else
                {
                    MessageBox.Show("Нельзя удалить начальную строку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.Value != null)
            {
                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    _logic.CreateOrUpdate(new HandBookBindingModel()
                    {
                        Id = (int)dataGridView.CurrentRow.Cells[0].Value,
                        Info = (string)dataGridView.CurrentCell.Value
                    });
                    MessageBox.Show("Изменено", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _logic.CreateOrUpdate(new HandBookBindingModel()
                    {
                        Info = (string)dataGridView.CurrentCell.Value
                    });
                    MessageBox.Show("Сохранено", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Нельзя сохранять пустые строки в справочник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
        }
    }
}
