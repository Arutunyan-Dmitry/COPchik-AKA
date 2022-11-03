using System.ComponentModel;

namespace UniversityContracts.ViewModels
{
    public class HandBookViewModel
    {
        public int Id { get; set; }
        [DisplayName("Позиция справочника")]
        public string Info { get; set; }
    }
}
