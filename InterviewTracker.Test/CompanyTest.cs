using InterviewTracker.BusinessLogic.Interfaces;
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
        public void GetAllCompanies_ShouldReturn200Status()
        {
            //Arrange
            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            companyInterviewFacade.Setup(x => x.GetAllCompanies()).Returns(CompanyMockData.GetCompanies());
            var sut = new WebApiController(companyInterviewFacade.Object); // sut means system under test

            //Act
            var result = sut.GetAllCompanies();

            //Assert
            var objectResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
        }

        public void GetAllCompanies_ShouldReturn204Sttus() {

            var companyInterviewFacade = new Mock<ICompanyInterviewFacade>();
            //companyInterviewFacade.Setup(x => x.GetAllCompanies()).Returns(CompanyMockData);
        }
    }
}