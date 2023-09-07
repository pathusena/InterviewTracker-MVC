using InterviewTracker.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.BusinessLogic
{
    public class CompanyInterviewFacade
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        //private readonly IInterviewBusinessLogic _interviewBusinessLogic

        public CompanyInterviewFacade(ICompanyBusinessLogic companyBusinessLogic) {
            _companyBusinessLogic = companyBusinessLogic;
            //_interviewBusinessLogic = interviewBusinessLogic;
        }

        public List<DO::Company> GetAllCompanies()
        {
            return _companyBusinessLogic.GetAllCompanies();
        }

        public DO::Company SaveCompany(DO::Company company)
        {
            return _companyBusinessLogic.SaveCompany(company);
        }
    }
}
