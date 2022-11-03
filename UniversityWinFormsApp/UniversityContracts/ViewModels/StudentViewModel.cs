using System.ComponentModel;

namespace UniversityContracts.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО")]
        public string Flm { get; set; }
        [DisplayName("Краткая характеристика")]
        public string ShortCharacteristic { get; set; }
        [DisplayName("Курс")]
        public string Grade { get; set; }
        [DisplayName("Стипендия")]
        public double? Scholatship { get; set; }
    }
}
