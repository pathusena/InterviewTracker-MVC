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
        Task<List<CompanyDto>> GetAllCompanies();
        Task<CompanyDto> SaveCompany(CompanyDto company);
        Task<List<InterviewDto>> GetInterviews(int companyId);
        Task<int> DeleteCompany(int id);
    }
}
