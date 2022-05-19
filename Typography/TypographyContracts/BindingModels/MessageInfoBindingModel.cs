using System;

namespace TypographyContracts.BindingModels {
    public class MessageInfoBindingModel {
        public int? ClientId { get; set; }
        public string MessageId { get; set; }
        public string FromMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Reply { get; set; }
        public bool Read { get; set; }
        public DateTime DateDelivery { get; set; }
        public int? ToSkip { get; set; }
        public int? ToTake { get; set; }
    }
}