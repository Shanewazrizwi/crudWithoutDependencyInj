using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WithoutDependencyCrud.Models;

namespace WithoutDependencyCrud.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationContext context;

        public ProductsController(ApplicationContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var products = context.products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
            // return View();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var pro = context.products.SingleOrDefault(e => e.Id == id);
            if(pro != null)
            {
                context.products.Remove(pro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Update(int id)
        {
            var pro = context.products.SingleOrDefault(e => e.Id == id);
            if (pro != null)
            {

                return View(pro);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(Product pro)
        {
            context.products.Update(pro);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
