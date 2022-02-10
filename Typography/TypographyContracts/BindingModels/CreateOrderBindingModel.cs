namespace TypographyContracts.BindingModels {
    // Данные от клиента, для создания заказа
    class CreateOrderBindingModel {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}