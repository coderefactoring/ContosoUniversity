using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ContosoUniversity.Interfaces;
using ContosoUniversity.ViewModels;


namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork _uow;
        IMapper _mapper;

        public HomeController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var enrollmentData = _uow.EnrollmentRepository.GetEnrollments();

            var data = _mapper.Map<IEnumerable<EnrollmentDateGroup>>(enrollmentData);

            return View(data);
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