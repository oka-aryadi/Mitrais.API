using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mitrais.API.Controllers;
using Mitrais.API.ViewModel;
using Mitrais.Data.Domain;
using Mitrais.Data.Request;
using Mitrais.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mitrais.API.Tests
{
    public class UserControllerTests
    {
        private Mock<IUserService> _userService;
        private UserController _userController;

        public UserControllerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();

            _userService = new Mock<IUserService>();
            _userController = new UserController(_userService.Object, mapper);
        }

        [Fact]
        public async Task Post_WhenEmailAddressExistsShouldReturnBadRequest()
        {
            //Arrange
            var postUser = new PostUser();
            var user = new User();

            _userService.Setup(x => x.GetUserAsync(It.IsAny<UserFilter>()))
                .ReturnsAsync(user);

            //Act
            var result = await _userController.Post(postUser) as ObjectResult;

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.Equal("Email should be unique", result.Value);
        }

        [Fact]
        public async Task Post_WhenMobileNumberExistsShouldReturnBadRequest()
        {
            //Arrange
            var postUser = new PostUser();
            User user = null;

            _userService.SetupSequence(x => x.GetUserAsync(It.IsAny<UserFilter>()))
                .ReturnsAsync(user)
                .ReturnsAsync(new User());

            //Act
            var result = await _userController.Post(postUser) as ObjectResult;

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.Equal("Mobile number should be unique", result.Value);
        }

        [Fact]
        public async Task Post_WhenValidationPassShouldReturnsCorrectResult()
        {
            //Arrange
            var postUser = new PostUser();
            User user = null;
            var insertedUser = new User();

            _userService.SetupSequence(x => x.GetUserAsync(It.IsAny<UserFilter>()))
                .ReturnsAsync(user)
                .ReturnsAsync(user);

            _userService.Setup(x => x.PostUserAsync(postUser))
                .ReturnsAsync(insertedUser);

            //Act
            var result = await _userController.Post(postUser) as ObjectResult;

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(result.StatusCode, (int)HttpStatusCode.Created);
            Assert.IsType<UserViewModel>(result.Value);
        }
    }
}
