using InterviewTracker.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.Web.Controllers
{
    public class WebApiController : Controller
    {
        private readonly CompanyInterviewFacade _companyInterviewFacade;

        public WebApiController(CompanyInterviewFacade companyInterviewFacade) {
            _companyInterviewFacade = companyInterviewFacade;
        }

        [HttpGet]
        public JsonResult GetAllCompanies()
        {
            return Json(new { result = _companyInterviewFacade.GetAllCompanies() });
        }

        [HttpPost]
        public JsonResult SaveCompany(DO::Company company)
        {
            return Json(new { result = _companyInterviewFacade.SaveCompany(company) });
        }
    }
}
