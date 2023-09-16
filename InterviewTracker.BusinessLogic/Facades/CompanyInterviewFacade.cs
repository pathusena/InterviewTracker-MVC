using InterviewTracker.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTracker.DataObject;
using InterviewTracker.DataAccess.Data;
using InterviewTracker.BusinessLogic.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.Design;

namespace InterviewTracker.BusinessLogic.Facades
{
    public class CompanyInterviewFacade : ICompanyInterviewFacade
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        private readonly IInterviewBusinessLogic _interviewBusinessLogic;

        public CompanyInterviewFacade(ICompanyBusinessLogic companyBusinessLogic, IInterviewBusinessLogic interviewBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
            _interviewBusinessLogic = interviewBusinessLogic;
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            try
            {
                return await _companyBusinessLogic.GetAllCompanies();
            } catch
            {
                throw;
            }
        }

        public async Task<CompanyDto> SaveCompany(CompanyDto company)
        {
            try
            {
                return await _companyBusinessLogic.SaveCompany(company);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InterviewDto>> GetInterviews(int companyId)
        {
            try
            {
                return await _interviewBusinessLogic.GetInterviews(companyId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteCompany(int id)
        {
            try
            {
                return await _companyBusinessLogic.DeleteCompany(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<InterviewDto> SaveInterview(InterviewDto interview)
        {
            try
            {
                return await _interviewBusinessLogic.SaveInterview(interview);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteInterview(int id)
        {
            try
            {
                return await _interviewBusinessLogic.DeleteInterview(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
