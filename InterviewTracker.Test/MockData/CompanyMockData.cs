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
