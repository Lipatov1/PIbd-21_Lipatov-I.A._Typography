using TypographyContracts.ViewModels;
using System.Collections.Generic;

namespace TypographyBusinessLogic.OfficePackage.HelperModels {
    public class WordInfo {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PrintedViewModel> Printeds { get; set; }
    }
}