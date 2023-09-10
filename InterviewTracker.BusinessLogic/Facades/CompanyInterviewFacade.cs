using InterviewTracker.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTracker.DataObject;
using InterviewTracker.DataAccess.Data;

namespace InterviewTracker.BusinessLogic.Facades
{
    public class CompanyInterviewFacade
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
            return _companyBusinessLogic.GetAllCompanies();
        }

        public CompanyDto SaveCompany(CompanyDto company)
        {
            return _companyBusinessLogic.SaveCompany(company);
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
