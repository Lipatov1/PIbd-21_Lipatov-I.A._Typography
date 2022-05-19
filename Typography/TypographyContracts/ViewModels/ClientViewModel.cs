using TypographyContracts.Attributes;

namespace TypographyContracts.ViewModels {
    public class ClientViewModel {
        public int Id { get; set; }
        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }
        [Column(title: "Логин", width: 100)]
        public string Login { get; set; }
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}