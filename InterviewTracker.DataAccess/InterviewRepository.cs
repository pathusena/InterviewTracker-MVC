using InterviewTracker.DataAccess.Data;
using InterviewTracker.DataAccess.Dto;
using InterviewTracker.DataAccess.DTO;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataObject;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InterviewTracker.DataAccess
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly InterviewTrackerDBContext _interviewTrackerDBContext;
        public InterviewRepository(InterviewTrackerDBContext interviewTrackerDBContext) {
            _interviewTrackerDBContext = interviewTrackerDBContext;
        }

        public async Task<List<InterviewDto>> GetInterviews(int flag, int companyId) {
            List<InterviewDto> list = new List<InterviewDto>();

            List<SqlParameter> parms = new List<SqlParameter>{
                new SqlParameter { ParameterName = "@pInt_Flag", Value = flag},
                new SqlParameter { ParameterName = "@pInt_CompanyId", Value=companyId},
            };

            var _data = await _interviewTrackerDBContext.Interviews.FromSqlRaw("EXEC USP_Interview_GetInterview @pInt_Flag, @pInt_CompanyId", parms.ToArray()).ToListAsync();

            if (_data != null && _data.Count() > 0)
            {
                foreach (var item in _data)
                {
                    list.Add(InterviewDtoConverter.ToDto(item));
                }
            }

            return list;
        }

        public async Task<InterviewDto> SaveInterview(int flag, InterviewDto interview)
        {

            List<SqlParameter> parms = new List<SqlParameter>{
                new SqlParameter { ParameterName = "@pint_Flag", Value = flag},
                new SqlParameter { ParameterName = "@pint_CompanyId", Value=interview.CompanyId},
                new SqlParameter { ParameterName = "@pint_Id", Value=interview.Id, Direction = ParameterDirection.InputOutput },
                new SqlParameter { ParameterName = "@pstr_Name", Value=interview.Name},
                new SqlParameter { ParameterName = "@pdte_Date", Value=interview.Date},
                new SqlParameter { ParameterName = "@pint_Status", Value=interview.Status},
                new SqlParameter { ParameterName = "@pstr_Remark", Value = (interview.Remark == null ? DBNull.Value : interview.Remark )},
            };

            await _interviewTrackerDBContext.Database.ExecuteSqlRawAsync("EXEC USP_Interview_SaveInterview @pint_Flag, @pint_CompanyId, @pint_Id OUTPUT, @pstr_Name, @pdte_Date, @pint_Status, @pstr_Remark", parms.ToArray());

            interview.Id = (int)parms[2].Value;

            return interview;
        }

        public async Task<int> DeleteInterview(int flag, int id)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@pint_Flag", Value = flag },
                new SqlParameter { ParameterName = "@pint_Id", Value = id },
            };

            await _interviewTrackerDBContext.Database.ExecuteSqlRawAsync("EXECUTE USP_Interview_DeleteInterview @pint_Flag, @pint_Id", parms.ToArray());
            return id;
        }
    }
}
