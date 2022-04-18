using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyBusinessLogic.OfficePackage.HelperModels   {
    public class ExcelInfo {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPrintedComponentViewModel> PrintedComponents { get; set; }
        public List<ReportWarehouseComponentViewModel> WarehouseComponents { get; set; }
    }
}