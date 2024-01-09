using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;
using SimpleCRUD_MVC.Business.Services;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Data.Models;

namespace SimpleCRUD_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductOutput> outputList = _service.GetAll<ProductOutput>(x => x.ProductImage);
            return View(outputList);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductOutput productOutput = _service.GetById<ProductOutput>(id);
            return View(productOutput);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            else
            {
                try
                {
                    _service.Add(input);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(input);
                }
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductInput input = _service.GetById<ProductInput>(id);
            return View(input);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductInput input)
        {
            if (!ModelState.IsValid) 
            {
                return View(input);
            }
            else
            {
                try
                {
                    _service.Update(input);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(input);
                }
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductOutput output = _service.GetById<ProductOutput>(id);
            return View(output);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductOutput output)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(output);
            }
        }
    }
}
