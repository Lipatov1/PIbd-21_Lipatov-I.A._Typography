using System.Collections.Generic;

namespace TypographyContracts.BindingModels {
    // Печатная продукция, изготавливаемая в магазине
    public class PrintedBindingModel {
        public int? Id { get; set; }
        public string PrintedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}