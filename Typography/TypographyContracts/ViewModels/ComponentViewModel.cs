using TypographyContracts.Attributes;

namespace TypographyContracts.ViewModels {
    // Компонент, требуемый для изготовления печатной продукции
    public class ComponentViewModel {
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}