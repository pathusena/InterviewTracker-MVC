using InterviewTracker.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using DO = InterviewTracker.DataObject;

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

        [HttpPost]
        public JsonResult SaveCompany(DO::Company company)
        {
            return Json(new { result = _companyBusinessLogic.SaveCompany(company) });
        }
    }
}
