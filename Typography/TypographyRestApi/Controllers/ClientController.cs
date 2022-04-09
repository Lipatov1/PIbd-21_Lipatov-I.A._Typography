﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TypographyRestApi.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly IClientLogic _logic;

        public ClientController(IClientLogic logic) {
            _logic = logic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) {
            var list = _logic.Read(new ClientBindingModel {
                Login = login,
                Password = password
            });

            return (list != null && list.Count > 0) ? list[0] : null;
        }

        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
}