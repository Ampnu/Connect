using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaConnect.Models;

namespace SpaConnect.Controllers
{
    public class StepController : Controller
    {
        private RouterDBContext _context;

        public StepController()
        {
            _context = new RouterDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var step = _context.stepDB.Where(a => a.operationID == id).ToList();

            return View(step);
        }
    }
}