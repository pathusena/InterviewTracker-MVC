using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTracker.DataObject;

namespace InterviewTracker.DataAccess.Interface
{
    public interface ICompanyRepository
    {
        Task<List<CompanyDto>> GetCompanies();
        Task<CompanyDto> SaveCompany(int flag, CompanyDto company);
        Task<int> DeleteCompany(int flag, int id);
    }
}
