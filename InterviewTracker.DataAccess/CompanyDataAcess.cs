
using InterviewTracker.DataAccess.Data;
using InterviewTracker.DataAccess.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.DataAccess
{
    public class CompanyDataAcess : ICompanyDataAccess
    {
        private readonly InterviewTrackerDBContext _interviewTrackerDBContext;

        public CompanyDataAcess(InterviewTrackerDBContext interviewTrackerDBContext) { 
           _interviewTrackerDBContext = interviewTrackerDBContext;
        }

        public List<DO::Company> GetCompanies()
        {
            List<DO::Company> list = new List<DO.Company>();

            var flag = new SqlParameter("pint_Flag", SqlDbType.Int).Value = 0;
            var id = new SqlParameter("pint_Id", SqlDbType.Int).Value = -1;

            var _data = _interviewTrackerDBContext.Companies.FromSqlRaw($"EXECUTE USP_Company_GetCompany {flag}, {id}").ToList();

            if (_data != null && _data.Count() > 0) {
                foreach (var item in _data)
                {
                    list.Add(new DO.Company() { 
                        Id = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        Description = item.Description,
                        Phone = item.Phone,
                        Remarks = item.Remarks,
                        Date = item.Date
                    });
                }
            }

            return list;
        }
    }
}