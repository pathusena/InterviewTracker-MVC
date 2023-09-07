using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InterviewTracker.DataObject.Common.Enumeration;

namespace InterviewTracker.DataObject
{
    public  class InterviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public InterviewStatus Status { get; set; }
        public string? Remark { get; set; }
    }
}
