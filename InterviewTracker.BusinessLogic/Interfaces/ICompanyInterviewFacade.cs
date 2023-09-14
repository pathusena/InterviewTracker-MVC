using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLogic.Interfaces
{
    public interface ICompanyInterviewFacade
    {
        List<CompanyDto> GetAllCompanies();
        CompanyDto SaveCompany(CompanyDto company);
        List<InterviewDto> GetInterviews(int companyId);
        int DeleteCompany(int id);
    }
}
