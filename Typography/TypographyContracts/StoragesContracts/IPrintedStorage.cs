using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyContracts.StoragesContracts {
    public interface IPrintedStorage {
        List<PrintedViewModel> GetFullList();
        List<PrintedViewModel> GetFilteredList(PrintedBindingModel model);
        PrintedViewModel GetElement(PrintedBindingModel model);
        void Insert(PrintedBindingModel model);
        void Update(PrintedBindingModel model);
        void Delete(PrintedBindingModel model);
    }
}