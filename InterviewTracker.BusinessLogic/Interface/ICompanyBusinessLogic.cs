using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.BusinessLogic.Interface
{
    public interface ICompanyBusinessLogic
    {
        List<DO::Company> GetAllCompanies();
    }
}
