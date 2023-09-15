using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.Test.MockData
{
    public class CompanyMockData
    {
        private static CompanyDto _Company = new CompanyDto { 
            Id = -1,
            Name = "Paragon Software (Pvt) Ltd",
            Country = "Sri Lanka",
            Date = DateTime.Now,
            Description = "Description",
            Phone = "0774817474",
            Remarks = "Remarks Test"
        };

        public static CompanyDto Company
        {
            get {
                return _Company;
            }
            set {
                _Company = value;
            }
        }

        public static List<CompanyDto> GetCompanies() { 
            return new List<CompanyDto>() { 
                new CompanyDto{ 
                    Id = 1,
                    Name = "Paragon Software (Pvt) Ltd",
                    Date = DateTime.Now,
                    Country = "Sri Lanka",
                    Description = "Description",
                    Phone = "0774817474",
                    Remarks = "Test Remark"
                },
                new CompanyDto{
                    Id = 2,
                    Name = "Virtusa (Pvt) Ltd",
                    Date = DateTime.Now,
                    Country = "Sri Lanka",
                    Description = "Description",
                    Phone = "0774817474",
                    Remarks = "Test Remark"
                },
                new CompanyDto{
                    Id = 3,
                    Name = "IFS",
                    Date = DateTime.Now,
                    Country = "Sri Lanka",
                    Description = "Description",
                    Phone = "0774817474",
                    Remarks = "Test Remark"
                },
            }; 
        }

        public static List<CompanyDto> EmptyCompanies()
        {
            return new List<CompanyDto>();
        }
    }
}
