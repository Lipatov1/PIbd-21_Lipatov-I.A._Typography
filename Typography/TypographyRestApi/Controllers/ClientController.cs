using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TypographyRestApi.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly IClientLogic clietLogic;
        private readonly IMessageInfoLogic messageInfoLogic;
        private readonly int messagesOnPage = 2;

        public ClientController(IClientLogic clietLogic, IMessageInfoLogic messageInfoLogic) {
            this.clietLogic = clietLogic;
            this.messageInfoLogic = messageInfoLogic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) {
            var list = clietLogic.Read(new ClientBindingModel {
                Login = login,
                Password = password
            });

            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(ClientBindingModel model) => clietLogic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => clietLogic.CreateOrUpdate(model);

        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetMessages(int clientId, int page) {
            var list = messageInfoLogic.Read(new MessageInfoBindingModel {
                ClientId = clientId,
                ToSkip = (page - 1) * messagesOnPage,
                ToTake = messagesOnPage + 1 }).ToList();

            var hasNext = !(list.Count() <= messagesOnPage);

            return (list.Take(messagesOnPage).ToList(), hasNext);
        }
    }
}