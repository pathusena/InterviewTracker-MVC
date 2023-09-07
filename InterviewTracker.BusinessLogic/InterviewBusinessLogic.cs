using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.DataAccess;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.BusinessLogic
{
    public class InterviewBusinessLogic : IInterviewBusinessLogic
    {
        private readonly IInterviewRepository _interviewRepository;

        public InterviewBusinessLogic(IInterviewRepository interviewRepository) {
            _interviewRepository = interviewRepository;
        }

        public List<InterviewDto> GetInterviews(int companyId) {
            try
            {
                return _interviewRepository.GetInterviews(0, companyId);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to get interviews.");
            }
        }
    }
}
