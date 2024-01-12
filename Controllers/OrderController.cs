using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Controllers.Base;
using SimpleCRUD_MVC.Data.Models;

namespace SimpleCRUD_MVC.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IBaseService<Order> _service;
        private readonly IBaseService<Client> _clientService;

        public OrderController(IBaseService<Order> service, IBaseService<Client> clientService)
        {
            _service = service;
            _clientService = clientService;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            List<OrderOutput> listOrders = _service.GetAll<OrderOutput>(x => x.Client);
            return View(listOrders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            OrderOutput output = _service.GetById<OrderOutput>(x => x.Id == id, x => x.Client);
            return View(output);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.clientList = _clientService.GetAll<ClientOutput>();
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            try
            {
                _service.Add(input);
                Alert(AlertType.sucess, "Order added successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error adding order");
                return View(input);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            OrderInput input = _service.GetById<OrderInput>(id);
            ViewBag.clientList = _clientService.GetAll<ClientOutput>();
            return View(input);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderInput input)
        {
            try
            {
                _service.Update(input);
                Alert(AlertType.sucess, "Order edited successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error when editing order");
                return View(input);
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            OrderOutput output = _service.GetById<OrderOutput>(x => x.Id == id, x => x.Client);
            return View(output);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderOutput output)
        {
            try
            {
                _service.Delete(id);
                Alert(AlertType.sucess, "Order deleted successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error deleting order");
                return View(output);
            }
        }
    }
}
