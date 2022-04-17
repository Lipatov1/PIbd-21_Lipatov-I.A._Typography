using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyContracts.BusinessLogicsContracts {
    public interface IImplementerLogic {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}