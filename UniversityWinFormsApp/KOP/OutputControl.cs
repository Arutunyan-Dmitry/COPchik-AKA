using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;
using System.Runtime.Serialization;

namespace KOP
{
    public partial class OutputControl : UserControl
    {
        public List<string> config;

        private event EventHandler _event;
        public event KeyEventHandler KeysDown;
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

        public void CreateTree<T>(List<T> list) where T : class //через параметризованный метод, у которого в передаваемых параметрах идет список объектов какого-то класса
        {
            if (config == null)
            {
                throw new NullReferenceException("Список конфигураций не заполнен");
            }
            if (list == null)
            {
                throw new NullReferenceException("Список объектов не найден");
            }
            if (list.Count != 0)
            {
                var elementType = list[0].GetType();

                foreach (var node in list)
                {
                    var currentLevelNodes = myTreeView.Nodes;
                    int currentLevel = 1;
                    foreach (var nodeName in config)
                    {
                        var fieldInfo = elementType.GetProperties()?
                            .FirstOrDefault(x => x.Name == nodeName);
                        if (fieldInfo != null)
                        {
                            string fieldValue = "";
                            if (fieldInfo.GetValue(node) != null)
                                fieldValue = fieldInfo.GetValue(node).ToString();
                            else
                                fieldValue = "Нет";
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
        }

        public void ConfigTree(List<string> config) //Выбираем элементы для конфигурации дерева
        {
            if (config != null)
            {
                this.config = config;
            }
        }

        public T? GetSelectedNode<T>() where T : class //Публичный метод для получения выбранной записи 
        {
            if (myTreeView.SelectedNode != null)
            {
                if (myTreeView.SelectedNode.Nodes.Count == 0)
                {
                    List<string> values = new List<string>();
                    while (myTreeView.SelectedNode.Parent != null)
                    {
                        values.Add(myTreeView.SelectedNode.Text);
                        myTreeView.SelectedNode = myTreeView.SelectedNode.Parent;
                    }
                    values.Add(myTreeView.SelectedNode.Text);
                    config = config.Reverse<string>().ToList();

                    T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
                    for (int i = 0; i < config.Count; i++)
                    {
                        var field = obj.GetType().GetProperties()?
                            .FirstOrDefault(x => x.Name == config[i]);
                        if (!field.PropertyType.Name.Contains("Nullable"))
                        {
                            field?.SetValue(obj, Convert.ChangeType(values[i], field.PropertyType));
                        }
                        else
                        {
                            if (!values[i].Equals("Нет"))
                                field?.SetValue(obj, Convert.ToDouble(values[i]));
                        }

                    }
                    return obj;
                }
                else
                {
                    throw new Exception("Нельзя выбирать родительскую ветвь");
                }
            }
            else
            {
                throw new Exception("Элемент не выбран");
            }
        }
        public void Clear()
        {
            myTreeView.Nodes.Clear();
        }
        private void myTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventHandler handler = KeysDown;
            handler?.Invoke(this, e);
        }
    }
}