using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TypographyRestApi.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase {
        private readonly IOrderLogic _order;
        private readonly IPrintedLogic _printed;
        private readonly IMessageInfoLogic _message;

        public MainController(IOrderLogic order, IPrintedLogic printed, IMessageInfoLogic message) {
            _order = order;
            _printed = printed;
            _message = message;
        }

        [HttpGet]
        public List<PrintedViewModel> GetPrintedList() => _printed.Read(null)?.ToList();

        [HttpGet]
        public PrintedViewModel GetPrinted(int printedId) => _printed.Read(new PrintedBindingModel { Id = printedId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _message.Read(new MessageInfoBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}