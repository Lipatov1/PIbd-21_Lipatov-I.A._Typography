using TypographyContracts.Attributes;
using System.Collections.Generic;
using System;

namespace TypographyContracts.ViewModels {
    public class WarehouseViewModel {
        public int Id { get; set; }

        [Column(title: "Название склада", width: 150)]
        public string WarehouseName { get; set; }

        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string WarehouseManagerFullName { get; set; }

        [Column(title: "Дата создания", width: 120, format: "dd/MM/yyyy")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}