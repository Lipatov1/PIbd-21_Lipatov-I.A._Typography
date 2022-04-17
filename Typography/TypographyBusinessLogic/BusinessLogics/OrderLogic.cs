using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.StoragesContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using TypographyContracts.Enums;
using System;

namespace TypographyBusinessLogic.BusinessLogics {
    public class OrderLogic : IOrderLogic {
        private readonly IOrderStorage orderStorage;
        private readonly IPrintedStorage printedStorage;
        private readonly IWarehouseStorage warehouseStorage;

        public OrderLogic(IOrderStorage _orderStorage, IPrintedStorage _printedStorage, IWarehouseStorage _warehouseStorage) {
            orderStorage = _orderStorage;
            printedStorage = _printedStorage;
            warehouseStorage = _warehouseStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model) {
            if (model == null) {
                return orderStorage.GetFullList();
            }

            if (model.Id.HasValue) {
                return new List<OrderViewModel> { orderStorage.GetElement(model) };
            }

            return orderStorage.GetFilteredList(model);
        }

        public void CreateOrder(CreateOrderBindingModel model) {
            OrderBindingModel order = new OrderBindingModel {
                PrintedId = model.PrintedId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = 0,
                DateCreate = DateTime.Now
            };
            orderStorage.Insert(order);
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model) {
            var element = orderStorage.GetElement(new OrderBindingModel {
                Id = model.OrderId
            });

            if (element == null) {
                throw new Exception("Элемент не найден");
            }

            if (!element.Status.Contains(OrderStatus.Принят.ToString())) {
                throw new Exception("Не в статусе \"Принят\"");
            }
            if (!warehouseStorage.CheckRemove(printedStorage.GetElement(new PrintedBindingModel { Id = element.PrintedId }).PrintedComponents, element.Count)) {
                throw new Exception("Недостаточно компонентов");
            }

            orderStorage.Update(new OrderBindingModel {
                Id = model.OrderId,
                Status = OrderStatus.Выполняется,
                PrintedId = element.PrintedId,
                ClientId = element.ClientId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate,
                DateImplement = DateTime.Now
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model) {
            var element = orderStorage.GetElement(new OrderBindingModel {
                Id = model.OrderId
            });

            if (element == null) { 
                throw new Exception("Элемент не найден");
            }

            if (!element.Status.Contains(OrderStatus.Выполняется.ToString())) {
                throw new Exception("Не в статусе \"Выполняется\"");
            }

            orderStorage.Update(new OrderBindingModel {
                Id = model.OrderId,
                Status = OrderStatus.Готов,
                DateImplement = element.DateImplement,
                PrintedId = element.PrintedId,
                ClientId = element.ClientId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate
            });
        }

        public void DeliveryOrder(ChangeStatusBindingModel model) {
            var element = orderStorage.GetElement(new OrderBindingModel {
                Id = model.OrderId
            });

            if (element == null) {
                throw new Exception("Элемент не найден");
            }

            if (!element.Status.Contains(OrderStatus.Готов.ToString())) {
                throw new Exception("Не в статусе \"Готов\"");
            }

            orderStorage.Update(new OrderBindingModel {
                Id = model.OrderId,
                Status = OrderStatus.Выдан,
                DateImplement = element.DateImplement,
                PrintedId = element.PrintedId,
                ClientId = element.ClientId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate
            });
        }
    }
}