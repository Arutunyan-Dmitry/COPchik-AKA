using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.BusinessLogicContracts
{
    public interface IHandBookLogic
    {
        List<HandBookViewModel> Read(HandBookBindingModel model);
        void CreateOrUpdate(HandBookBindingModel model);
        void Delete(HandBookBindingModel model);
    }
}
