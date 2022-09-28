
namespace ArutunyanNotVisualControlLibrary.OfficePackage.HelperModels
{
    public class WordTableInfo
    {
        public string Path { get; set; }
        public string Header { get; set; }
        public List<(int, int, string)> Joined { get; set; }
        public int[] Width { get; set; }
        public List<(string, string)> Columns { get; set; }
        public List<Object> Data { get; set; }
    }
}
