﻿using System.Collections.Generic;
using System;

namespace TypographyContracts.ViewModels {
    public class ReportWarehouseComponentViewModel {
        public string WarehouseName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}