using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Controllers.Base;
using SimpleCRUD_MVC.Data.Models;

namespace SimpleCRUD_MVC.Controllers
{
    public class OrderItemController : BaseController
    {
        private readonly OrderItemService _orderItemService;
        private readonly ProductService _productService;
        private readonly IBaseService<Order> _orderService;

        public OrderItemController(OrderItemService orderItemService, ProductService productService, IBaseService<Order> orderService)
        {
            _orderItemService = orderItemService;
            _productService = productService;
            _orderService = orderService;
        }

        // GET: OrderItemController
        public ActionResult Index(int orderId)
        {
            List<OrderItemOutput> listOrder = _orderItemService.GetOrderItemByOrderId(orderId);
            ViewBag.OrderId = orderId;
            return View(listOrder);
        }

        // GET: OrderItemController/Details/5
        public ActionResult Details(int id)
        {
            OrderItemOutput output  = _orderItemService.GetById<OrderItemOutput>(x => x.Id == id, x => x.Product, x => x.Order);
            return View(output);
        }

        // GET: OrderItemController/Create
        public ActionResult Create(int orderId)
        {
            OrderOutput output = _orderService.GetById<OrderOutput>(x => x.Id == orderId, x => x.Client);
            ViewBag.OrderId = orderId;
            ViewBag.clientName = output.ClientFirstName + " " + output.ClientLastName;
            ViewBag.Products = _productService.GetAll<ProductInput>();
            return View(new OrderItemInput { OrderId = orderId});
        }

        // POST: OrderItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItemInput input, int orderId)
        {
            input.OrderId = orderId;

            if (!ModelState.IsValid)
            {
                return View(input);
            }
            try
            {
                _orderItemService.Add(input);
                Alert(AlertType.sucess, "Order Item added successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error adding Order Item");
                return View(input);
            }
        }

        // GET: OrderItemController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Products = _productService.GetAll<ProductInput>();
            OrderItemInput input = _orderItemService.GetById<OrderItemInput>(x => x.Id == id, x => x.Product);
            return View(input);
        }

        // POST: OrderItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderItemInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            try
            {
                _orderItemService.Update(input);
                Alert(AlertType.sucess, "Order item edited successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error when editing order item");
                return View(input);
            }
        }

        // GET: OrderItemController/Delete/5
        public ActionResult Delete(int id)
        {
            OrderItemOutput output = _orderItemService.GetById<OrderItemOutput>(x => x.Id == id, x => x.Product);
            return View(output);
        }

        // POST: OrderItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderItemOutput output)
        {
            try
            {
                _orderItemService.Delete(id);
                Alert(AlertType.sucess, "Order item deleted successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error deleting order item");
                return View(output);
            }
        }
    }
}
