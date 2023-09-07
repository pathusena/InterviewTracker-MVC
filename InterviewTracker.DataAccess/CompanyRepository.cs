
using InterviewTracker.DataAccess.Data;
using InterviewTracker.DataAccess.DTO;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataObject;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InterviewTracker.DataAccess
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly InterviewTrackerDBContext _interviewTrackerDBContext;

        public CompanyRepository(InterviewTrackerDBContext interviewTrackerDBContext) { 
           _interviewTrackerDBContext = interviewTrackerDBContext;
        }

        public List<CompanyDto> GetCompanies()
        {
            List<CompanyDto> list = new List<CompanyDto>();

            var flag = new SqlParameter("pint_Flag", SqlDbType.Int).Value = 0;
            var id = new SqlParameter("pint_Id", SqlDbType.Int).Value = -1;

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@pint_Flag", Value = 0 },
                new SqlParameter { ParameterName = "@pint_Id", Value = -1 },
            };

            var _data = _interviewTrackerDBContext.Companies.FromSqlRaw("EXECUTE USP_Company_GetCompany @pint_Flag, @pint_Id", parms.ToArray()).ToList();

            if (_data != null && _data.Count() > 0) {
                foreach (var item in _data)
                {
                    list.Add(CompanyDtoConverter.ToDto(item));
                }
            }

            return list;
        }

        public CompanyDto SaveCompany(int flag, CompanyDto company)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {   
                new SqlParameter { ParameterName = "@pint_Flag", Value = flag },
                new SqlParameter { ParameterName = "@pint_Id", Value = company.Id },
                new SqlParameter { ParameterName = "@pstr_Name", Value = company.Name },
                new SqlParameter { ParameterName = "@pdte_Date", Value = company.Date },
                new SqlParameter { ParameterName = "@pstr_Country", Value = company.Country },
                new SqlParameter { ParameterName = "@pstr_Phone", Value = company.Phone },
                new SqlParameter { ParameterName = "@pstr_Description", Value = company.Description },
                new SqlParameter { ParameterName = "@pstr_Remarks", Value = company.Remarks }
            };

            _interviewTrackerDBContext.Database.ExecuteSqlRaw("EXECUTE USP_Company_SaveCompany @pint_Flag, @pint_Id, @pstr_Name, @pdte_Date, @pstr_Country, @pstr_Phone, @pstr_Description, @pstr_Remarks", parms.ToArray());

            return company;
        }
    }
}