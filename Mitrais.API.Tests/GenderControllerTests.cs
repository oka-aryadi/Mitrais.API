using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mitrais.API.Controllers;
using Mitrais.API.ViewModel;
using Mitrais.Data.Domain;
using Mitrais.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Mitrais.API.Tests
{
    public class GenderControllerTests
    {
        private Mock<IGenderService> _genderService;
        private GenderController _genderController;

        public GenderControllerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();

            _genderService = new Mock<IGenderService>();
            _genderController = new GenderController(_genderService.Object, mapper);
        }

        [Fact]
        public async Task Get_ShouldReturnsCorrectResult()
        {
            //Arrange
            var genders = new List<Gender>();
            genders.Add(new Gender
            {
                Id = Guid.NewGuid(),
                Name = "Male"
            });
            genders.Add(new Gender
            {
                Id = Guid.NewGuid(),
                Name = "Female"
            });

            _genderService.Setup(x => x.GetGendersAsync())
                .ReturnsAsync(genders);

            //Act
            var result = await _genderController.Get() as ObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.OK);
            Assert.IsType<List<GenderViewModel>>(result.Value);

        }
    }
}
