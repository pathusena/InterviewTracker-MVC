using System;
using System.Collections.Generic;

namespace InterviewTracker.DataAccess.Data
{
    public partial class Interview
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public byte Status { get; set; }
        public string? Remark { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
