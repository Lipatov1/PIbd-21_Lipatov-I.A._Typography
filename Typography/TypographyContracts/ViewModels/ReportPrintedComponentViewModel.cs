using System.Collections.Generic;
using System;

namespace TypographyContracts.ViewModels {
    public class ReportPrintedComponentViewModel {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Printeds { get; set; }
    }
}