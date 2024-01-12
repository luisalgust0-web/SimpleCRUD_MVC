using Microsoft.AspNetCore.Mvc;
using SimpleCRUD_MVC.Business.Models;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Controllers.Base;
using SimpleCRUD_MVC.Data.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SimpleCRUD_MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBaseService<Client> _service;

        public HomeController(IBaseService<Client> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            List<ClientOutput> Clients = _service.GetAll<ClientOutput>();
            return View(Clients);
        }
    }
}