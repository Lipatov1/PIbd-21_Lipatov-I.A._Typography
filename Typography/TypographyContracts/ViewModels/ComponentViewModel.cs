using System.ComponentModel;

namespace TypographyContracts.ViewModels {
    // Компонент, требуемый для изготовления печатной продукции
    public class ComponentViewModel {
        public int Id { get; set; }

        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}