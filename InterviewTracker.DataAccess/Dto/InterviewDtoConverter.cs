using InterviewTracker.DataAccess.Data;
using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InterviewTracker.DataObject.Common.Enumeration;

namespace InterviewTracker.DataAccess.Dto
{
    public class InterviewDtoConverter
    {
        public static InterviewDto ToDto(Interview interview)
        {
            return new InterviewDto
            {
                Id = interview.Id,
                Name = interview.Name,
                Status = (InterviewStatus)interview.Status,
                CompanyId = interview.CompanyId,
                Remark = interview.Remark,
                Date = interview.Date
            };
        }

        public static Interview ToDomainqModal(InterviewDto interviewDto)
        {
            return new Interview
            {
                Id = interviewDto.Id,
                Name = interviewDto.Name,
                Status = Convert.ToByte(interviewDto.Status),
                CompanyId = interviewDto.CompanyId,
                Remark = interviewDto.Remark,
                Date = interviewDto.Date
            };
        }
    }
}
