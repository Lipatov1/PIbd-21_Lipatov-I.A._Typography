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

        public MainController(IOrderLogic order, IPrintedLogic printed) {
            _order = order;
            _printed = printed;
        }

        [HttpGet]
        public List<PrintedViewModel> GetPrintedList() => _printed.Read(null)?.ToList();

        [HttpGet]
        public PrintedViewModel GetPrinted(int printedId) => _printed.Read(new PrintedBindingModel { Id = printedId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}