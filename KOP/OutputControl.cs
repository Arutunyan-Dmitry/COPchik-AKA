using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;

namespace KOP
{
    public partial class OutputControl : UserControl
    {
        public List<string> config;

        private event EventHandler _event;

        public OutputControl()
        {
            InitializeComponent();
            myTreeView.AfterSelect += (sender, e) => _event?.Invoke(sender, e);
        }

        public event EventHandler OutputDatehanged
        {
            add
            {
                _event += value;
            }
            remove
            {
                _event -= value;
            }
        }


        public int SelectedIndex  //Публичное свойство для установки и получения индекса выбранной ветки(set, get). 
        {
            get
            {
                if (myTreeView.SelectedNode != null)
                {
                    return myTreeView.SelectedNode.Index;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (value > -1 && value < myTreeView.Nodes.Count)
                {
                    myTreeView.SelectedNode = myTreeView.Nodes[value];
                    return;
                }
            }
        }

        public void CreateTree<T>(List<T> list) where T : class, new() //через параметризованный метод, у которого в передаваемых параметрах идет список объектов какого-то класса
        {
            if (config == null)
            {
                throw new NullReferenceException("Config for tree is empty");
            }
            if (list == null)
            {
                throw new NullReferenceException("Filds of object is empty");
            }
            var elementType = list[0].GetType();

            foreach (var node in list)
            {
                var currentLevelNodes = myTreeView.Nodes;
                int currentLevel = 1;
                foreach (var nodeName in config)
                {
                    var fieldInfo = elementType.GetField(nodeName);
                    if (fieldInfo != null)
                    {
                        var fieldValue = fieldInfo.GetValue(node).ToString();
                        if (!currentLevelNodes.ContainsKey(fieldValue))
                        {
                            if (currentLevel == config.Count)
                            {
                                currentLevelNodes.Add(fieldValue);
                            }
                            else
                            {
                                currentLevelNodes.Add(fieldValue, fieldValue);
                            }
                        }
                        if (currentLevel != config.Count)
                        {
                            currentLevelNodes = currentLevelNodes.Find(fieldValue, false)[0].Nodes;
                        }
                    }
                    currentLevel++;
                }
            }
        }

        public void ConfigTree(List<string> config) //Выбираем элементы для конфигурации дерева
        {
            if (config != null)
            {
                this.config = config;
            }
        }

        public T? GetSelectedNode<T>() where T : class, new() //Публичный метод для получения выбранной записи 
        {
            if (myTreeView.SelectedNode != null)
            {
                T itemT = Activator.CreateInstance<T>();
                foreach (string item in config.Reverse<string>())
                {
                    string value = myTreeView.SelectedNode.Text;
                    var field = itemT.GetType().GetField(item);

                    var fieldInfo = field;
                    var type = field?.FieldType;
                    fieldInfo.SetValue(itemT, Convert.ChangeType(value, type));

                    if (myTreeView.SelectedNode.Parent != null)
                    {
                        myTreeView.SelectedNode = myTreeView.SelectedNode.Parent;
                    }
                }
                return itemT;

            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали");
                return default;
            }

        }
        public void Clear()
        {
            myTreeView.Nodes.Clear();
        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            myTreeViewLabelShow.Text = "Вы выбрали элемент!";
        }
    }
}