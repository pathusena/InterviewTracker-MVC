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

namespace InterviewTracker.DataAccess
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly InterviewTrackerDBContext _interviewTrackerDBContext;
        public InterviewRepository(InterviewTrackerDBContext interviewTrackerDBContext) {
            _interviewTrackerDBContext = interviewTrackerDBContext;
        }

        public List<InterviewDto> GetInterviews(int flag, int companyId) {
            List<InterviewDto> list = new List<InterviewDto>();

            List<SqlParameter> parms = new List<SqlParameter>{
                new SqlParameter { ParameterName = "@pInt_Flag", Value = flag},
                new SqlParameter { ParameterName = "@pInt_CompanyId", Value=companyId},
            };

            var _data = _interviewTrackerDBContext.Interviews.FromSqlRaw("EXEC USP_Interview_GetInterview @pInt_Flag, @pInt_CompanyId", parms.ToArray()).ToList();

            if (_data != null && _data.Count() > 0)
            {
                foreach (var item in _data)
                {
                    list.Add(InterviewDtoConverter.ToDto(item));
                }
            }

            return list;
        }
    }
}
