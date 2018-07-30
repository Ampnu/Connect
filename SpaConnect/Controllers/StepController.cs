using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaConnect.Models;
using SpaConnect.ViewModels;

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

        public ActionResult Index(int id)
        {
            List<Step> stepID = _context.stepDB.ToList();

            foreach (var val in stepID)
            {
                if (id == val.operationID)
                {
                    return RedirectToAction("Details", "Step", new { id = id });
                }
            }
            return RedirectToAction("New", "Step", new { id = id });
        }

        public ActionResult Details(int id)
        {
            List<Step> step = _context.stepDB.Where(a => a.operationID == id).ToList();
            List<Operation> ulitiesID = _context.operationDB.Where(a => a.ID == id).ToList();

            NewAssetVM assetVM = new NewAssetVM
            {
                stepIDVM = step,
                utilIDVM = ulitiesID
            };

            return View(assetVM);
        }

        public ActionResult New(int id)
        {
            List<Operation> opsID = _context.operationDB.Where(m => m.ID == id).ToList(); //retriving list of assemblies for the DB

            var viewModel = new NewAssetVM
            {
                opsIDVM = opsID // storing the list in the new assemblies list
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NewAssetVM step)
        {
            _context.stepDB.Add(step.stepVM); //adding object to the database
            _context.SaveChanges();
            return RedirectToAction("Details", "Step", new { id = step.stepVM.operationID });
        }

        public ActionResult Result()
        {

            return View();
        }
    }
}