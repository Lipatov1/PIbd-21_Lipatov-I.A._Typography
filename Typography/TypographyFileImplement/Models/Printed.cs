using System.Collections.Generic;

namespace TypographyFileImplement.Models {
    // Печатная продукция, изготавливаемая в магазине
    public class Printed {        
        public int Id { get; set; }
        public string PrintedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> PrintedComponents { get; set; }
    }
}
