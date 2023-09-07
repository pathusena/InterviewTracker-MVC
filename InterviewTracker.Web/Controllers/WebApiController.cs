using InterviewTracker.BusinessLogic.Facades;
using InterviewTracker.DataObject;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult SaveCompany(CompanyDto company)
        {
            return Json(new { result = _companyInterviewFacade.SaveCompany(company) });
        }

        [HttpGet]
        public JsonResult GetInterviews(int companyId)
        {
            return Json(new { result = _companyInterviewFacade.GetInterviews(companyId) });
        }
    }
}
