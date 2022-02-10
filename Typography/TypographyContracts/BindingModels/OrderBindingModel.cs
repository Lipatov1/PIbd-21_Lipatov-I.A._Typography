using TypographyContracts.Enums;
using System;

namespace TypographyContracts.BindingModels {
    // Заказ
    class OrderBindingModel {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}