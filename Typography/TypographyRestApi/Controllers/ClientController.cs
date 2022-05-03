using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TypographyRestApi.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly IClientLogic clietLogic;
        private readonly IMessageInfoLogic messageInfoLogic;

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
        public List<MessageInfoViewModel> GetMessages(int clientId) => messageInfoLogic.Read(new MessageInfoBindingModel { ClientId = clientId });
    }
}