using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.DataAccess.Interface;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.BusinessLogic
{
    public class CompanyBusinessLogic : ICompanyBusinessLogic
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyBusinessLogic(ICompanyRepository companyRepository) { 
            _companyRepository = companyRepository;
        }

        public List<DO::Company> GetAllCompanies() {
            try
            {
                return _companyRepository.GetCompanies();
            }
            catch (Exception e)
            {
                throw new Exception("Unable to get companies.");
            }
        }

        public DO::Company SaveCompany(DO::Company company)
        {
            try
            {
                if (company.Id > 0)
                {
                    return _companyRepository.SaveCompany(1, company);
                }
                else {
                    return _companyRepository.SaveCompany(0, company);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Unable to save company.");
            }
        }
    }
}