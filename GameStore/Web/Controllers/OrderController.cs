using BLL.Interfaces;
using BLL.Models;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateOrderDetails(string json)
        {
            OrderViewModel order = new()
            {
                DetailsData = json,
                TotalPrice = GetTotalPrice(json)
            };

            return View("Create", order);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var order = new OrderModel()
                {
                    UserId = viewModel.UserId,
                    Payment = viewModel.Payment,
                    Comment = viewModel.Comments,
                    TotalPrice = viewModel.TotalPrice
                };
                order = await _orderService.CreateOrderAsync(order);

                var list = GetList(viewModel.DetailsData);
                var orderDetails = new List<OrderDetail>();
                foreach (CartItem item in list)
                {
                    orderDetails.Add(await _orderService.CreateOrderDetailAsync(item.id, item.count, item.price, order.Id));
                    await _orderService.SellGame(item.id, item.count);
                }

                return View("Success");
            }
            
            return View("Create", viewModel);
        }


        private decimal GetTotalPrice(string json)
            => GetList(json).Sum(i => i.price * i.count);

        private IEnumerable<CartItem>? GetList(string? json) 
            => JsonConvert.DeserializeObject<IEnumerable<CartItem>>(json);
    }
}
