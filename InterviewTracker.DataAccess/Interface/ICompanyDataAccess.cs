using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.DataAccess.Interface
{
    public interface ICompanyDataAccess
    {
        List<DO::Company> GetCompanies();
    }
}
