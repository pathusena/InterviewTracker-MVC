﻿using System;
using System.Collections.Generic;

namespace InterviewTracker.DataAccess.Data
{
    public partial class Company
    {
        public Company()
        {
            Interviews = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Country { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Remarks { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
