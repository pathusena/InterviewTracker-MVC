using InterviewTracker.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.Web.Controllers
{
    public class WebApiController : Controller
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;

        public WebApiController(ICompanyBusinessLogic companyBusinessLogic) {
            _companyBusinessLogic = companyBusinessLogic;
        }

        [HttpGet]
        public JsonResult GetAllCompanies()
        {
            return Json(new { result = _companyBusinessLogic.GetAllCompanies() });
        }
    }
}
