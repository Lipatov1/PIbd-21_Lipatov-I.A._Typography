using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyContracts.BusinessLogicsContracts {
    public interface IProductLogic {
        List<PrintedViewModel> Read(PrintedBindingModel model);
        void CreateOrUpdate(PrintedBindingModel model);
        void Delete(PrintedBindingModel model);
    }
}