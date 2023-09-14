using InterviewTracker.BusinessLogic.Facades;
using InterviewTracker.BusinessLogic.Interfaces;
using InterviewTracker.DataObject;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAllCompanies()
        {
            try
            {
                var data = _companyInterviewFacade.GetAllCompanies();

                if (data == null || data.Count == 0)
                {
                    return NoContent();
                }

                return Ok(data);

            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting companies!");
            }
        }

        [HttpPost]
        public IActionResult SaveCompany(CompanyDto company)
        {
            try {
                var data = _companyInterviewFacade.SaveCompany(company);
                return Ok(data);
            } catch {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving company!");
            }
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
