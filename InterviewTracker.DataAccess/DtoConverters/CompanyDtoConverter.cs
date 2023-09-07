using InterviewTracker.DataAccess.Data;
using InterviewTracker.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTracker.DataAccess.DTO
{
    public static class CompanyDtoConverter
    {
        public static CompanyDto ToDto(Company company) {
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Country = company.Country,
                Description = company.Description,
                Phone = company.Phone,
                Remarks = company.Remarks,
                Date = company.Date
            };      
        }

        public static Company ToDomainqModal(CompanyDto companyDto)
        {
            return new Company
            {
                Id = companyDto.Id,
                Name = companyDto.Name,
                Country = companyDto.Country,
                Description = companyDto.Description,
                Phone = companyDto.Phone,
                Remarks = companyDto.Remarks,
                Date = companyDto.Date
            };
        }
    }
}
