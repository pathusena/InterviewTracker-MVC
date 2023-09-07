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
        List<CompanyDto> GetAllCompanies();

        CompanyDto SaveCompany(CompanyDto company);
    }
}
