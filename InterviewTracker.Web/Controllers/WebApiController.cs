using InterviewTracker.BusinessLogic.Facades;
using InterviewTracker.BusinessLogic.Interfaces;
using InterviewTracker.DataAccess.Data;
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
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var data = await _companyInterviewFacade.GetAllCompanies();

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
        public async Task<IActionResult> SaveCompany(CompanyDto company)
        {
            try {
                var data = await _companyInterviewFacade.SaveCompany(company);
                return Ok(data);
            } catch {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving company!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInterviews(int companyId)
        {
            try {
                var data = await _companyInterviewFacade.GetInterviews(companyId);

                if (data == null || data.Count == 0) { 
                    return NoContent();
                }

                return Ok(data);
            } catch {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting interviews!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var data = await _companyInterviewFacade.DeleteCompany(id);
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting company!");
            }
        }
    }
}
