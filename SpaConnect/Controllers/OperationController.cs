using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SpaConnect.Models;

namespace SpaConnect.Controllers
{
    public class OperationController : Controller
    {
        private RouterDBContext _context;

        public OperationController()
        {
            _context = new RouterDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var ops = _context.operationDB.Where(a => a.asmbID == id).ToList();

            return View(ops);
        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Operation op)
        {
            _context.operationDB.Add(op); //adding object to the database
            _context.SaveChanges();

            return RedirectToAction("Result", "Operation");
        }

        public ActionResult Result()
        {

            return View();
        }
    }
}