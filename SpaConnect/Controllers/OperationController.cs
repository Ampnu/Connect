using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SpaConnect.Models;
using SpaConnect.ViewModels;

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

        public ActionResult Index(int id)
        {
            List<Operation> opsID = _context.operationDB.ToList();

            foreach (var val in opsID)
            {
                if (id == val.asmbID)
                {
                    return RedirectToAction("Details", "Operation", new { id = id });
                }  
            }
            return RedirectToAction("New", "Operation", new { id = id });
        }

        public ActionResult Details(int id)
        {
            List<Operation> ops = _context.operationDB.Where(a => a.asmbID == id).ToList();

            return View(ops);
        }

        public ActionResult New(int id)
        {
            List<Assy> asmbID = _context.assyDB.Where(m => m.ID == id).ToList(); //retriving list of assemblies for the DB

            var viewModel = new NewAssetVM
            {
                asmbIDVM = asmbID // storing the list in the new assemblies list
            };

            return View(viewModel);
        }

        public ActionResult Edit1(int id)
        {
            Operation opToEdit = _context.operationDB.SingleOrDefault(m => m.ID == id);
            List<Assy> asmbID = _context.assyDB.Where(m => m.ID == opToEdit.asmbID).ToList(); //retriving program for the DB

            var viewModel = new NewAssetVM
            {
                opVM = opToEdit,
                asmbIDVM = asmbID
            };

            return View(viewModel);
        }

        public ActionResult Edit2(int id)
        {
            Operation opToEdit = _context.operationDB.SingleOrDefault(m => m.ID == id);
            List<Assy> asmbID = _context.assyDB.Where(m => m.ID == opToEdit.asmbID).ToList(); //retriving program for the DB

            var viewModel = new NewAssetVM
            {
                opVM = opToEdit,
                asmbIDVM = asmbID
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NewAssetVM op)
        {
            _context.operationDB.Add(op.opVM); //adding object to the database
            _context.SaveChanges();
            return RedirectToAction("Details", "Operation", new { id = op.opVM.asmbID });
        }

        [HttpPost]
        public ActionResult Update(NewAssetVM op)
        {
            if (op.opVM.ID == 0)
            {
                _context.operationDB.Add(op.opVM); //adding object to the database
            }
            else
            {
                var opInDB = _context.operationDB.SingleOrDefault(m => m.ID == op.opVM.ID);
                opInDB.OPN = op.opVM.OPN;
                opInDB.opTitle = op.opVM.opTitle;
                opInDB.lessonPlan = op.opVM.lessonPlan;
                opInDB.tools = op.opVM.tools;
                opInDB.generalNotes = op.opVM.generalNotes;
            }
            _context.SaveChanges();

            return RedirectToAction("Details", "Operation", new { id = op.opVM.asmbID });
        }
    }
}