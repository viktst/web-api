using WebAPI.Controllers;
using Domain.Entities;
using Domain.Models.Requests;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NUnit.Framework.Assert;

namespace AspektViktor.Tests.Controllers
{
    [TestFixture]
    public class CompanyControllerTests
    {
        private Mock<ICompanyService> _mockCompanyService;
        private Mock<ILogger<CompanyController>> _mockLogger;
        private CompanyController _controller;

        [SetUp]
        public void Setup() =>
            (_mockCompanyService, _mockLogger, _controller) = (
                new Mock<ICompanyService>(),
                new Mock<ILogger<CompanyController>>(),
                new CompanyController(new Mock<ICompanyService>().Object, new Mock<ILogger<CompanyController>>().Object)
            );

        [Test]
        public async Task CreateCompanyAsync_ValidInput_IsNotNull() =>
            That(await _controller.CreateCompanyAsync(new CompanyDTO { Name = "Apple" }), Is.Not.Null);

        [Test]
        public async Task GetCompanies_ReturnsCompanies_WhenCompaniesExist()
        {
            var companies = new List<CompanyEntity> { new(), new() };
            _mockCompanyService.Setup(x => x.GetCompaniesAsync()).ReturnsAsync(companies);

            var result = await _controller.GetCompanies() as OkObjectResult;

            That(result, Is.Not.Null);
            That(result!.Value, Is.EqualTo(companies));
        }

        [Test]
        public async Task UpdateCompanyAsync_ValidInput_ReturnsUpdatedCompany()
        {
            int id = 1;
            var request = new CompanyDTO();
            var updatedCompany = new CompanyEntity();

            _mockCompanyService.Setup(x => x.UpdateCompanyAsync(id, request)).ReturnsAsync(updatedCompany);

            var result = await _controller.UpdateCompanyAsync(id, request) as OkObjectResult;

            That(result, Is.Not.Null);
            That(result!.Value, Is.EqualTo(updatedCompany));
        }

        [Test]
        public async Task DeleteCompanyAsync_ValidId_ReturnsNoContent()
        {
            _mockCompanyService.Setup(x => x.DeleteCompanyAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            That(await _controller.DeleteCompanyAsync(1), Is.InstanceOf<NoContentResult>());
        }
    }
}
