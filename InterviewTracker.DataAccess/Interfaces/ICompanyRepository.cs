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
        List<CompanyDto> GetCompanies();
        CompanyDto SaveCompany(int flag, CompanyDto company);
    }
}
