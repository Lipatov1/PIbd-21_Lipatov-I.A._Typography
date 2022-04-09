using TypographyBusinessLogic.OfficePackage.HelperModels;
using TypographyContracts.BusinessLogicsContracts;
using TypographyBusinessLogic.OfficePackage;
using TypographyContracts.StoragesContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TypographyBusinessLogic.BusinessLogics {
    public class ReportLogic : IReportLogic {
        private readonly IComponentStorage _componentStorage;
        private readonly IPrintedStorage  _printedStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IPrintedStorage printedStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf) {
            _printedStorage = printedStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportPrintedComponentViewModel> GetPrintedComponent() {
            var components = _componentStorage.GetFullList();
            var printeds = _printedStorage.GetFullList();
            var list = new List<ReportPrintedComponentViewModel>();

            foreach (var printed in printeds) {
                var record = new ReportPrintedComponentViewModel {
                    PrintedName = printed.PrintedName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var component in printed.PrintedComponents) {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }

                list.Add(record);
            }
            return list;
        }

        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model) {
            return _orderStorage.GetFilteredList(new OrderBindingModel  {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel {
                DateCreate = x.DateCreate,
                PrintedName = x.PrintedName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        // Сохранение компонент в файл-Word
        public void SavePrintedsToWordFile(ReportBindingModel model) {
            _saveToWord.CreateDoc(new WordInfo {
                FileName = model.FileName,
                Title = "Список продцукции",
                Printeds = _printedStorage.GetFullList()
            });
        }

        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SavePrintedComponentToExcelFile(ReportBindingModel model) {
            _saveToExcel.CreateReport(new ExcelInfo {
                FileName = model.FileName,
                Title = "Список компонент",
                PrintedComponents = GetPrintedComponent()
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model) {
            _saveToPdf.CreateDoc(new PdfInfo {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}