using System.Collections.Generic;
using System.ComponentModel;

namespace TypographyContracts.ViewModels {
    // Изделие, изготавливаемое в магазине
    public class PrintedViewModel {
        public int Id { get; set; }

        [DisplayName("Название изделия")]
        public string PrintedName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}