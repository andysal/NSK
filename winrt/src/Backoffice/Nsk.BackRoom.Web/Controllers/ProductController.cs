using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nsk.BackRoom.Web.Models.Product;
using Nsk.BackRoom.Domain;
using Nsk.BackRoom.Domain.Commands;

namespace Nsk.BackRoom.Web.Controllers
{
    public class ProductController : Controller
    {
        public IServiceBus Bus { get; private set; }

        public ProductController(IServiceBus bus)
        {
            this.Bus = bus;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = new AddProductToCatalog(Guid.NewGuid(), model.ProductName, model.UnitPrice, model.QuantityPerUnit);
                    Bus.Send(command);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
