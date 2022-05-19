using TypographyContracts.StoragesContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using TypographyFileImplement.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TypographyFileImplement.Implements {
    public class MessageInfoStorage : IMessageInfoStorage {
        private readonly FileDataListSingleton source;

        public MessageInfoStorage() {
            source = FileDataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList() {
            return source.Messages.Select(CreateModel).ToList();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model) {
            if (model == null) {
                return null;
            }

            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue) {
                return source.Messages
                    .Skip((int)model.ToSkip)
                    .Take((int)model.ToTake)
                    .Select(CreateModel)
                    .ToList();
            }

            return source.Messages
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date) || (rec.MessageId == model.MessageId))
                .Skip(model.ToSkip ?? 0)
                .Take(model.ToTake ?? source.Messages.Count())
                .Select(CreateModel)
                .ToList();
        }

        public MessageInfoViewModel GetElement(MessageInfoBindingModel model) {
            if (model == null) {
                return null;
            }

            var message = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            return message != null ? CreateModel(message) : null;
        }

        public void Insert(MessageInfoBindingModel model) {
            MessageInfo element = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);

            if (element != null) {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }

            source.Messages.Add(new MessageInfo {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                Reply = model.Reply,
                Read = model.Read
            });
        }

        public void Update(MessageInfoBindingModel model) {
            var element = source.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId);

            if (element == null) {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, element);
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