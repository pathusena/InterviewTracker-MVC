
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
                new SqlParameter { ParameterName = "@pint_Id", Value = company.Id, Direction = ParameterDirection.InputOutput },
                new SqlParameter { ParameterName = "@pstr_Name", Value = company.Name },
                new SqlParameter { ParameterName = "@pdte_Date", Value = company.Date },
                new SqlParameter { ParameterName = "@pstr_Country", Value = company.Country },
                new SqlParameter { ParameterName = "@pstr_Phone", Value = (company.Phone == null ? DBNull.Value : company.Phone)},
                new SqlParameter { ParameterName = "@pstr_Description", Value = (company.Description == null ? DBNull.Value : company.Description)},
                new SqlParameter { ParameterName = "@pstr_Remarks", Value = (company.Remarks == null ? DBNull.Value : company.Remarks )}
            };

            _interviewTrackerDBContext.Database.ExecuteSqlRaw("EXECUTE USP_Company_SaveCompany @pint_Flag, @pint_Id OUTPUT, @pstr_Name, @pdte_Date, @pstr_Country, @pstr_Phone, @pstr_Description, @pstr_Remarks", parms.ToArray());
            company.Id = (int)parms[1].Value;
            return company;
        }

        public int DeleteCompany(int flag, int id)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@pint_Flag", Value = flag },
                new SqlParameter { ParameterName = "@pint_Id", Value = id },
            };

            _interviewTrackerDBContext.Database.ExecuteSqlRaw("EXECUTE USP_Company_DeleteCompany @pint_Flag, @pint_Id", parms.ToArray());
            return id;
        }
    }
}