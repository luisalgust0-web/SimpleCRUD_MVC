using Microsoft.AspNetCore.Mvc;
using SimpleCRUD_MVC.Business.Models;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Data.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SimpleCRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeneralService<Client> _service;

        public HomeController(IGeneralService<Client> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            List<ClientOutput> Clients = _service.GetAll<ClientOutput>();
            return View(Clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientInput input)
        {
            try{
                _service.Add(input);
                return View(input);
            }
            catch(Exception ex)
            {
                return View(input);
            }
        }

        public IActionResult Edit(int id)
        {
            ClientOutput output = _service.GetById<ClientOutput>(id);
            return View(output);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ClientOutput output = _service.GetById<ClientOutput>(id);
                _service.Update(id);
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                ClientOutput output = _service.GetById<ClientOutput>(id);
                return View(output);
            }
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}