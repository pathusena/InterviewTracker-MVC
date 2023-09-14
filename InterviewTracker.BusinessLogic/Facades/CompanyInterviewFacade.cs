using InterviewTracker.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTracker.DataObject;
using InterviewTracker.DataAccess.Data;
using InterviewTracker.BusinessLogic.Interfaces;

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

        public List<CompanyDto> GetAllCompanies()
        {
            try
            {
                return _companyBusinessLogic.GetAllCompanies();
            } catch
            {
                throw;
            }
        }

        public CompanyDto SaveCompany(CompanyDto company)
        {
            try
            {
                return _companyBusinessLogic.SaveCompany(company);
            }
            catch
            {
                throw;
            }
        }

        public List<InterviewDto> GetInterviews(int companyId)
        {
            return _interviewBusinessLogic.GetInterviews(companyId);
        }

        public int DeleteCompany(int id)
        {
            return _companyBusinessLogic.DeleteCompany(id);
        }
    }
}
