using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaConnect.ViewModels;

namespace SpaConnect.Models
{
    public class CMOController : Controller
    {
        private RouterDBContext _context;

        public CMOController()
        {
            _context = new RouterDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: CMO
        public ActionResult Index()
        {
            List<Step> step = _context.stepDB.Where(a => a.editStatus == true).ToList();
            List<ReleaseCCBVM> CCB = new List<ReleaseCCBVM>();

            foreach(var val in step)
            {
                ReleaseCCBVM releaseRouter = new ReleaseCCBVM();
                releaseRouter.stepCCBID = val.ID;
                Operation opToRelease = _context.operationDB.Where(m => m.ID == val.operationID).Single();
                releaseRouter.OPNCCB = opToRelease.OPN;
                releaseRouter.opTitleCCB = opToRelease.opTitle;
                CCB.Add(releaseRouter);
            } 
            return View(CCB);
        }

        public ActionResult Release(int id)
        {
            Step step = _context.stepDB.Single(m => m.ID == id);
            step.editStatus = false;
            _context.SaveChanges();

            return View();
        }
    }
}