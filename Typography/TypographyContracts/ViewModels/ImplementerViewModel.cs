using TypographyContracts.Attributes;

namespace TypographyContracts.ViewModels {
    public class ImplementerViewModel {
        public int Id { get; set; }

        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FIO { get; set; }

        [Column(title: "Время работы исполнителя", width: 150)]
        public int WorkingTime { get; set; }

        [Column(title: "Время отдыха исполнителя", width: 150)]
        public int PauseTime { get; set; }
    }
}