﻿using System.ComponentModel.DataAnnotations;
using System;

namespace TypographyDatabaseImplement.Models {
    public class MessageInfo {
        [Key]
        public string MessageId { get; set; }
        public int? ClientId { get; set; }
        public string SenderName { get; set; }
        public DateTime DateDelivery { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Reply { get; set; }
        public bool Read { get; set; }
        public virtual Client Client { get; set; }
    }
}