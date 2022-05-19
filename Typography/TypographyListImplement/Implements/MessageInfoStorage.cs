using TypographyContracts.StoragesContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using TypographyListImplement.Models;
using System.Collections.Generic;
using System;

namespace TypographyListImplement.Implements {
    public class MessageInfoStorage : IMessageInfoStorage {
        private readonly DataListSingleton source;

        public MessageInfoStorage() {
            source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList() {
            var result = new List<MessageInfoViewModel>();

            foreach (var message in source.Messages) {
                result.Add(CreateModel(message));
            }

            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model) {
            if (model == null) {
                return null;
            }

            int toSkip = model.ToSkip ?? 0;
            int toTake = model.ToTake ?? source.Messages.Count;

            var result = new List<MessageInfoViewModel>();

            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue) {
                foreach (var msg in source.Messages) {
                    if (toSkip > 0) {
                        toSkip--;
                        continue;
                    }

                    if (toTake > 0) {
                        result.Add(CreateModel(msg));
                        toTake--;
                    }
                }

                return result;
            }

            foreach (var message in source.Messages) {
                if ((model.ClientId.HasValue && message.ClientId == model.ClientId) || (!model.ClientId.HasValue && message.DateDelivery.Date == model.DateDelivery.Date) || (message.MessageId == model.MessageId)) {
                    if (toSkip > 0) {
                        toSkip--;
                        continue;
                    }

                    if (toTake > 0) {
                        result.Add(CreateModel(message));
                        toTake--;
                    }
                }
            }

            return result;
        }
        
        public MessageInfoViewModel GetElement(MessageInfoBindingModel model) {
            if (model == null) {
                return null;
            }

            foreach (var message in source.Messages) {
                if (message.MessageId == model.MessageId) {
                    return CreateModel(message);
                }
            }

            return null;
        }

        public void Insert(MessageInfoBindingModel model) {
            source.Messages.Add(CreateModel(model, new MessageInfo()));
        }

        public void Update(MessageInfoBindingModel model) {
            MessageInfo tempMessageInfo = null;

            foreach (var message in source.Messages) {
                if (message.MessageId == model.MessageId) {
                    tempMessageInfo = message;
                    break;
                }
            }

            if (tempMessageInfo == null) {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tempMessageInfo);
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message) {
            string clientName = string.Empty;

            foreach (var client in source.Clients) {
                if (client.Id == model.ClientId) {
                    clientName = client.ClientFIO;
                    break;
                }
            }

            message.MessageId = model.MessageId;
            message.SenderName = clientName;
            message.Body = model.Body;
            message.ClientId = model.ClientId;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.Reply = model.Reply;
            message.Read = model.Read;
            return message;
        }
        private MessageInfoViewModel CreateModel(MessageInfo message) {
            return new MessageInfoViewModel {
                MessageId = message.MessageId,
                Body = message.Body,
                DateDelivery = message.DateDelivery,
                SenderName = message.SenderName,
                Subject = message.Subject,
                Reply = message.Reply,
                Read = message.Read
            };
        }
    }
}