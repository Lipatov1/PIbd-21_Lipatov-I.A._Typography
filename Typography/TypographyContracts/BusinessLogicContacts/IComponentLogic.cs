using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyContracts.BusinessLogicContacts {
    interface IComponentLogic {
        List<ComponentViewModel> Read(ComponentBindingModel model);
        void CreateOrUpdate(ComponentBindingModel model);
        void Delete(ComponentBindingModel model);
    }
}