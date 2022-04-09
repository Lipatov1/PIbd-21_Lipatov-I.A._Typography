namespace TypographyContracts.BindingModels {
    // Данные от клиента, для создания заказа
    public class CreateOrderBindingModel {
        public int PrintedId { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}