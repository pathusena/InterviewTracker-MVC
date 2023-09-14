using InterviewTracker.BusinessLogic.Facades;
using InterviewTracker.BusinessLogic.Interfaces;
using InterviewTracker.DataObject;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.Web.Controllers
{
    public class WebApiController : Controller
    {
        private readonly ICompanyInterviewFacade _companyInterviewFacade;

        public WebApiController(ICompanyInterviewFacade companyInterviewFacade) {
            _companyInterviewFacade = companyInterviewFacade;
        }

        [HttpGet]
        public JsonResult GetAllCompanies()
        {
            JsonResult? result;
            try
            {
                var data = _companyInterviewFacade.GetAllCompanies();

                if (data == null)
                {
                    result = new JsonResult(new { success = true, result = NoContent() })
                    {
                        StatusCode = StatusCodes.Status204NoContent
                    };
                    return result;
                }

                result = new JsonResult(new { success = true, result = _companyInterviewFacade.GetAllCompanies() })
                {
                    StatusCode = StatusCodes.Status200OK
                };
                return result;

            } catch (Exception)
            {
                result = new JsonResult(new { success = false, error = "Something went wrong" })
                {
                    StatusCode = StatusCodes.Status503ServiceUnavailable
                };
                return result;
            }
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

        [HttpGet]
        public JsonResult DeleteCompany(int id)
        {
            return Json(new { result = _companyInterviewFacade.DeleteCompany(id) });
        }
    }
}
