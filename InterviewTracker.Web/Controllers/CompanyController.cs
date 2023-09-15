using Microsoft.AspNetCore.Mvc;
using InterviewTracker.BusinessLogic;
using DO = InterviewTracker.DataObject;
using InterviewTracker.BusinessLogic.Interface;
using Microsoft.AspNetCore.Authorization;

namespace InterviewTracker.Web.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
