using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;

namespace UniversityBusinessLogic.BusinessLogic
{
    public class HandBookLogic : IHandBookLogic
    {
        private readonly IHandBookStorage _handBookStorage;
        public HandBookLogic(IHandBookStorage handBookStorage)
        {
            _handBookStorage = handBookStorage;
        }
        public List<HandBookViewModel> Read(HandBookBindingModel model)
        {
            if (model == null)
            {
                return _handBookStorage.GetFullList();
            }
            else
            {
                return new List<HandBookViewModel> { _handBookStorage.GetElement(model) };
            }
        }
        public void CreateOrUpdate(HandBookBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _handBookStorage.Update(model);
            }
            else
            {
                _handBookStorage.Insert(model);
            }
        }
        public void Delete(HandBookBindingModel model)
        {
            var element = _handBookStorage.GetElement(new HandBookBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Позиция справочника не найдена");
            }
            _handBookStorage.Delete(model);
        }
    }
}
