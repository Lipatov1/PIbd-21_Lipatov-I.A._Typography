﻿using System.ComponentModel;

namespace TypographyContracts.ViewModels {
    // Компонент, требуемый для изготовления изделия
    public class ComponentViewModel {
        public int Id { get; set; }

        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}