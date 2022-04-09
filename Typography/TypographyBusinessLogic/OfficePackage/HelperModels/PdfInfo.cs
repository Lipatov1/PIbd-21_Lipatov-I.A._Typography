using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System;

namespace TypographyBusinessLogic.OfficePackage.HelperModels {
    public class PdfInfo {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
        public List<ReportOrdersByDateViewModel> OrdersByDate { get; set; }
    }
}