using TypographyContracts.StoragesContracts;
using TypographyDatabaseImplement.Models;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TypographyDatabaseImplement.Implements {
    public class MessageInfoStorage : IMessageInfoStorage {
        public List<MessageInfoViewModel> GetFullList() {
            using var context = new TypographyDatabase();

            return context.MessageInfoes
            .Select(CreateModel)
            .ToList();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model) {
            if (model == null) {
                return null;
            }

            using var context = new TypographyDatabase();

            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue) {
                return context.MessageInfoes
                    .Skip((int)model.ToSkip)
                    .Take((int)model.ToTake)
                    .Select(CreateModel)
                    .ToList();
            }

            return context.MessageInfoes
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date) || (rec.MessageId == model.MessageId))
                .Skip(model.ToSkip ?? 0)
                .Take(model.ToTake ?? context.MessageInfoes.Count())
                .Select(CreateModel)
                .ToList();
        }

        public MessageInfoViewModel GetElement(MessageInfoBindingModel model) {
            if (model == null) {
                return null;
            }

            using var context = new TypographyDatabase();
            var message = context.MessageInfoes.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            return message != null ? CreateModel(message) : null;
        }

        public void Insert(MessageInfoBindingModel model) {
            using var context = new TypographyDatabase();
            MessageInfo element = context.MessageInfoes.FirstOrDefault(rec => rec.MessageId == model.MessageId);

            if (element != null) {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }

            context.MessageInfoes.Add(new MessageInfo {
                MessageId = model.MessageId,
                ClientId = model.ClientId != null ? model.ClientId : context.Clients.FirstOrDefault(rec => rec.Login == model.FromMailAddress)?.Id,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Reply = model.Reply,
                Read = model.Read
            });

            context.SaveChanges();
        }

        public void Update(MessageInfoBindingModel model) {
            using var context = new TypographyDatabase();
            var element = context.MessageInfoes.FirstOrDefault(rec => rec.MessageId == model.MessageId);

            if (element == null) {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
            context.SaveChanges();
        }

        private static MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo) {
            messageInfo.SenderName = model.FromMailAddress;
            messageInfo.DateDelivery = model.DateDelivery;
            messageInfo.MessageId = model.MessageId;
            messageInfo.ClientId = model.ClientId;
            messageInfo.Subject = model.Subject;
            messageInfo.Reply = model.Reply;
            messageInfo.Read = model.Read;
            messageInfo.Body = model.Body;
            return messageInfo;
        }

        private MessageInfoViewModel CreateModel(MessageInfo model) {
            return new MessageInfoViewModel {
                DateDelivery = model.DateDelivery,
                SenderName = model.SenderName,
                MessageId = model.MessageId,
                Subject = model.Subject,
                Reply = model.Reply,
                Body = model.Body,
                Read = model.Read
            };
        }
    }
}