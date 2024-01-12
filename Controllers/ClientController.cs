using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD_MVC.Business.Models;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Controllers.Base;
using SimpleCRUD_MVC.Data.Models;

namespace SimpleCRUD_MVC.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IBaseService<Client> _generalService;
        
        public ClientController(IBaseService<Client> generalService)
        {
            _generalService = generalService;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            List<ClientOutput> clientOutputs = _generalService.GetAll<ClientOutput>();
            return View(clientOutputs);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            ClientOutput clientOutput = _generalService.GetById<ClientOutput>(id);
            return View(clientOutput);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            else
            {
                try
                {
                    _generalService.Add(input);
                    Alert(AlertType.sucess, "Client added successfully");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Alert(AlertType.error, "Error adding client");
                    return View(input);
                }
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            ClientInput clientInput= _generalService.GetById<ClientInput>(id);
            return View(clientInput);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            else
            {
                try
                {
                    _generalService.Update(input);
                    Alert(AlertType.sucess, "Client edited successfully");
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    Alert(AlertType.error, "Error when editing client");
                    return View(input);
                }
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            ClientOutput output = _generalService.GetById<ClientOutput>(id);
            return View(output);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClientOutput output)
        {
            try
            {
                _generalService.Delete(id);
                Alert(AlertType.sucess, "Client deleted successfully");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Alert(AlertType.error, "Error deleting client");
                return View(output);
            }
        }
    }
}
