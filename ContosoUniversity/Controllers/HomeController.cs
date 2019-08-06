using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Interfaces;
using ContosoUniversity.ViewModels;


namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork _uow;
        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var domainData = _uow.EnrollmentRepository.GetLatestEnrollments(10);

            var data = from enrollment in domainData
                       select new EnrollmentDateGroup
                       {
                           EnrollmentDate = enrollment.EnrollmentDate,
                           StudentCount = enrollment.StudentCount
                       };

            return View(data.ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }
    }
}