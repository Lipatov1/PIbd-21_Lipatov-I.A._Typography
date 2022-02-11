using System.ComponentModel;
using System;

namespace TypographyContracts.ViewModels {
    // Заказ
    public class OrderViewModel {
        public int Id { get; set; }
        public int PrintedId { get; set; }

        [DisplayName("Печатная продукция")]
        public string PrintedName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}