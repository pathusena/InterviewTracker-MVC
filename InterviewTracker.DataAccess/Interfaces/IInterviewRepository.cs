using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.DataAccess.Interface
{
    public interface IInterviewRepository
    {
        Task<List<InterviewDto>> GetInterviews(int flag, int companyId);
    }
}
