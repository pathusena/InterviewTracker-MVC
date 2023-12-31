﻿namespace InterviewTracker.DataObject
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Country { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Remarks { get; set; }
        public DateTime Date { get; set; }
    }
}
