﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.StoragesContracts;
using TypographyBusinessLogic.MailWorker;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using TypographyContracts.Enums;
using System;

namespace TypographyBusinessLogic.BusinessLogics {
    public class OrderLogic : IOrderLogic {
        private readonly IOrderStorage orderStorage;
        private readonly IClientStorage clientStorage;
        private readonly AbstractMailWorker mailWorker;

        public OrderLogic(IOrderStorage _orderStorage, IClientStorage _clientStorage, AbstractMailWorker _mailWorker) {
            orderStorage = _orderStorage;
            clientStorage = _clientStorage;
            mailWorker = _mailWorker;

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

            mailWorker.MailSendAsync(new MailSendInfoBindingModel {
                MailAddress = clientStorage.GetElement(new ClientBindingModel { Id = model.ClientId })?.Login,
                Subject = "Создан новый заказ",
                Text = $"Дата заказа: {DateTime.Now}, сумма заказа: {model.Sum}"
            });
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

            orderStorage.Update(new OrderBindingModel {
                Id = model.OrderId,
                Status = OrderStatus.Выполняется,
                PrintedId = element.PrintedId,
                ClientId = element.ClientId,
                ImplementerId = model.ImplementerId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate,
                DateImplement = DateTime.Now
            });

            mailWorker.MailSendAsync(new MailSendInfoBindingModel {
                MailAddress = clientStorage.GetElement(new ClientBindingModel { Id = element.ClientId })?.Login,
                Subject = $"Смена статуса заказа №{model.OrderId}",
                Text = $"Статус изменен на: {OrderStatus.Выполняется}"
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
                ImplementerId = element.ImplementerId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate
            });

            mailWorker.MailSendAsync(new MailSendInfoBindingModel {
                MailAddress = clientStorage.GetElement(new ClientBindingModel { Id = element.ClientId })?.Login,
                Subject = $"Смена статуса заказа №{model.OrderId}",
                Text = $"Статус изменен на: {OrderStatus.Готов}"
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
                ImplementerId = element.ImplementerId,
                Count = element.Count,
                Sum = element.Sum,
                DateCreate = element.DateCreate
            });

            mailWorker.MailSendAsync(new MailSendInfoBindingModel {
                MailAddress = clientStorage.GetElement(new ClientBindingModel { Id = element.ClientId })?.Login,
                Subject = $"Смена статуса заказа №{model.OrderId}",
                Text = $"Статус изменен на: {OrderStatus.Выдан}"
            });
        }
    }
}