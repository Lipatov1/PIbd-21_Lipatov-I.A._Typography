using TypographyContracts.Enums;
using System;

namespace TypographyListImplement.Models {
    // Заказ
    public class Order {
        public int Id { get; set; }
        public int PrintedId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}