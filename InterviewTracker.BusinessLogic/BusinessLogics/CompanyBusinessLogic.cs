using InterviewTracker.BusinessLogic.Interface;
using InterviewTracker.BusinessLogic.Interfaces;
using InterviewTracker.DataAccess.Data;
using InterviewTracker.DataAccess.Interface;
using InterviewTracker.DataObject;

namespace InterviewTracker.BusinessLogic
{
    public class CompanyBusinessLogic : ICompanyBusinessLogic
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoggerBusinessLogic _loggerBusinessLogic;

        public CompanyBusinessLogic(ICompanyRepository companyRepository, ILoggerBusinessLogic loggerBusinessLogic) { 
            _companyRepository = companyRepository;
            _loggerBusinessLogic = loggerBusinessLogic;
        }

        public List<CompanyDto> GetAllCompanies() {
            try
            {
                return _companyRepository.GetCompanies();
            }
            catch (Exception e)
            {
                _loggerBusinessLogic.LogError(e.Message);
                throw new Exception("Unable to get companies.");
            }
        }

        public CompanyDto SaveCompany(CompanyDto company)
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
                _loggerBusinessLogic.LogError(e.Message);
                throw new Exception("Unable to save company.");
            }
        }

        public int DeleteCompany(int id)
        {
            try
            {
                return _companyRepository.DeleteCompany(0, id);

            }
            catch (Exception e)
            {
                _loggerBusinessLogic.LogError(e.Message);
                throw new Exception("Unable to delete company.");
            }
        }
    }
}