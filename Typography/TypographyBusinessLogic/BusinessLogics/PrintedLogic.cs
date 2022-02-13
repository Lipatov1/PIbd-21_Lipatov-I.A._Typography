using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.StoragesContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System;

namespace TypographyBusinessLogic.BusinessLogics {
    public class PrintedLogic : IPrintedLogic {
        private readonly IPrintedStorage printedStorage;

        public PrintedLogic(IPrintedStorage _printedStorage) {
            printedStorage = _printedStorage;
        }

        public List<PrintedViewModel> Read(PrintedBindingModel model) {
            if (model == null) {
                return printedStorage.GetFullList();
            }

            if (model.Id.HasValue) {
                return new List<PrintedViewModel> { printedStorage.GetElement(model) };
            }

            return printedStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PrintedBindingModel model) {
            var element = printedStorage.GetElement(new PrintedBindingModel { 
                PrintedName = model.PrintedName
            });

            if (element != null && element.Id != model.Id) {
                throw new Exception("Уже есть печатная продуция с таким названием");
            }

            if (model.Id.HasValue) {
                printedStorage.Update(model);
            }
            else {
                printedStorage.Insert(model);
            }
        }

        public void Delete(PrintedBindingModel model) {
            var element = printedStorage.GetElement(new PrintedBindingModel {
                Id = model.Id
            });

            if (element == null) {
                throw new Exception("Элемент не найден");
            }
                
            printedStorage.Delete(model);
        }
    }
}