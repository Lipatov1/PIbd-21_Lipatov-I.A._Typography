using TypographyContracts.Attributes;
using System;

namespace TypographyContracts.ViewModels {
    public class MessageInfoViewModel {
        public string MessageId { get; set; }

        [Column(title: "Отправитель", width: 100)]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 100)]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 100)]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Body { get; set; }
        [DisplayName("Ответ")]
        public string Reply { get; set; }
        [DisplayName("Прочитано")]
        public bool Read { get; set; }
    }
}