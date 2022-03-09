﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TypographyDatabaseImplement.Models {
    // Компонент, требуемый для изготовления изделия
    public class Component {
        public int Id { get; set; }

        [Required]
        public string ComponentName { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<PrintedComponent> ProductComponents { get; set; }
    }
}