using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyContracts.BusinessLogicsContracts {
    public interface IReportLogic {
        // Получение списка компонентов с указанием, в каких изделиях используются
        List<ReportPrintedComponentViewModel> GetPrintedComponent();

        // Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        // Сохранение компонентов в файл-Word
        void SaveComponentsToWordFile(ReportBindingModel model);

        // Сохранение компонентов с указаеним печатной продукции в файл-Excel
        void SavePrintedComponentToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}