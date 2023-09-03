using Microsoft.AspNetCore.Mvc;
using InterviewTracker.BusinessLogic;
using DO = InterviewTracker.DataObject;
using InterviewTracker.BusinessLogic.Interface;

namespace InterviewTracker.Web.Controllers
{
    public class CompanyController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
