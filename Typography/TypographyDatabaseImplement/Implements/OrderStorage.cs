using TypographyContracts.StoragesContracts;
using TypographyDatabaseImplement.Models;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TypographyDatabaseImplement.Implements {
    public class OrderStorage : IOrderStorage {
        public List<OrderViewModel> GetFullList() {
            using (var context = new TypographyDatabase()) {
                return context.Orders
                    .Include(rec => rec.Printed)
                    .Include(rec => rec.Client)
                    .Select(rec => new OrderViewModel {
                        Id = rec.Id,
                        PrintedId = rec.PrintedId,
                        PrintedName = rec.Printed.PrintedName,
                        ClientId = rec.ClientId,
                        ClientFIO = rec.Client.ClientFIO,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status.ToString(),
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model) {
            if (model == null) {
                return null;
            }

            using (var context = new TypographyDatabase()) {
                return context.Orders
                    .Include(rec => rec.Printed)
                    .Include(rec => rec.Client)
                    .Where(rec => rec.PrintedId == model.PrintedId || (rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo && model.DateFrom.HasValue && model.DateTo.HasValue) || model.ClientId.HasValue && rec.ClientId == model.ClientId)
                    .Select(rec => new OrderViewModel {
                        Id = rec.Id,
                        PrintedId = rec.PrintedId,
                        PrintedName = rec.Printed.PrintedName,
                        ClientId = rec.ClientId,
                        ClientFIO = rec.Client.ClientFIO,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status.ToString(),
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model) {
            if (model == null) {
                return null;
            }

            using (var context = new TypographyDatabase()) {
                Order order = context.Orders
                    .Include(rec => rec.Printed)
                    .Include(rec => rec.Client)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel {
                    Id = order.Id,
                    PrintedId = order.PrintedId,
                    PrintedName = order.Printed.PrintedName,
                    ClientId = order.ClientId,
                    ClientFIO = order.Client.ClientFIO,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status.ToString(),
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model) {
            using (var context = new TypographyDatabase()) {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model) {
            using (var context = new TypographyDatabase()) {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null) {
                    throw new Exception("Элемент не найден");
                }

                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model) {
            using (var context = new TypographyDatabase()) {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null) {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order) {
            order.PrintedId = model.PrintedId;
            order.Sum = model.Sum;
            order.Count = model.Count;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ClientId = model.ClientId.Value;
            return order;
        }
    }
}