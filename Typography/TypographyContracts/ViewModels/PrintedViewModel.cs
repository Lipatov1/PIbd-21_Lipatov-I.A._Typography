using TypographyContracts.Attributes;
using System.Collections.Generic;

namespace TypographyContracts.ViewModels {
    // Печатная продукция, изготавливаемая в магазине
    public class PrintedViewModel {
        public int Id { get; set; }

        [Column(title: "Название печатной продукции", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PrintedName { get; set; }

        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}