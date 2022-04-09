using System.ComponentModel;

namespace TypographyContracts.ViewModels {
    public class ClientViewModel {
        public int Id { get; set; }
        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}