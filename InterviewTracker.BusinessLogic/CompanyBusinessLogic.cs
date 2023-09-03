using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.DataAccess.Interface;
using DO = InterviewTracker.DataObject;

namespace InterviewTracker.BusinessLogic
{
    public class CompanyBusinessLogic : ICompanyBusinessLogic
    {
        private readonly ICompanyDataAccess _companyDataAccess;

        public CompanyBusinessLogic(ICompanyDataAccess companyDataAccess) { 
            _companyDataAccess = companyDataAccess;
        }

        public List<DO::Company> GetAllCompanies() {
            try
            {
                return _companyDataAccess.GetCompanies();
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
                    return _companyDataAccess.SaveCompany(1, company);
                }
                else {
                    return _companyDataAccess.SaveCompany(0, company);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Unable to save company.");
            }
        }
    }
}