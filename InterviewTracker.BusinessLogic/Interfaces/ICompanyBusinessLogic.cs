using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLogic.Interface
{
    public interface ICompanyBusinessLogic
    {
        Task<List<CompanyDto>> GetAllCompanies();

        Task<CompanyDto> SaveCompany(CompanyDto company);

        Task<int> DeleteCompany(int id);
    }
}
