using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.StorageContracts
{
    public interface IHandBookStorage
    {
        List<HandBookViewModel> GetFullList();
        HandBookViewModel GetElement(HandBookBindingModel model);
        void Insert(HandBookBindingModel model);
        void Update(HandBookBindingModel model);
        void Delete(HandBookBindingModel model);
    }
}
