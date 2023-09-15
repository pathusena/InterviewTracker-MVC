using InterviewTracker.BusinessLogic.Interfaces;
using InterviewTracker.DataObject;
using InterviewTracker.Test.MockData;
using InterviewTracker.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InterviewTracker.Test
{
    public class CompanyTest
    {
        [Fact]
        public void GetAllCompanies_ShouldReturn200StatusWithData()
        {
            //Arrange
            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            companyInterviewFacade.Setup(x => x.GetAllCompanies()).Returns(CompanyMockData.GetCompanies());
            var sut = new WebApiController(companyInterviewFacade.Object); // sut means system under test

            //Act
            var result = sut.GetAllCompanies();

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            List<CompanyDto>? companyList = objectResult.Value as List<CompanyDto>;
            Assert.NotNull(companyList);
            Assert.NotEmpty(companyList);
        }

        [Fact]
        public void GetAllCompanies_ShouldReturn204Status() {

            //Arrange
            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            companyInterviewFacade.Setup(x => x.GetAllCompanies()).Returns(CompanyMockData.EmptyCompanies());
            var sut = new WebApiController(companyInterviewFacade.Object);

            //Act
            var result = sut.GetAllCompanies();

            //Assert
            var objectResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, objectResult.StatusCode);

        }

        [Fact]
        public void GetAllCompanies_ShouldReturn500Status() { 
            //Arrange
            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            companyInterviewFacade.Setup(x => x.GetAllCompanies()).Throws(new Exception("Internal Server Error"));
            var sut = new WebApiController(companyInterviewFacade.Object);

            //Act
            var result = sut.GetAllCompanies();

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);    
        }

        [Fact]
        public void SaveCompany_ShouldReturn200StatusWithSavedCompany() { 
            //Arrange
            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            companyInterviewFacade.Setup(x => x.SaveCompany(CompanyMockData.Company)).Returns(CompanyMockData.Company);
            var sut = new WebApiController(companyInterviewFacade.Object);

            //Act
            var result = sut.SaveCompany(CompanyMockData.Company);

            //Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(objectResult.Value);
            Assert.IsType<CompanyDto>(objectResult.Value);
        }

        [Fact]
        public void SaveCompany_ShouldReturn500Status()
        {
            //Arrange
            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            companyInterviewFacade.Setup(x => x.SaveCompany(CompanyMockData.Company)).Throws(new Exception("Internal Server Error"));
            var sut = new WebApiController(companyInterviewFacade.Object);

            //Act
            var result = sut.SaveCompany(CompanyMockData.Company);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
    }
}