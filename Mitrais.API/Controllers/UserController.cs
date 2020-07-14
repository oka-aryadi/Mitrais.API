using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mitrais.API.ViewModel;
using Mitrais.Data.Request;
using Mitrais.Interface;

namespace Mitrais.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostUser postUser)
        {
            var user = await _userService.GetUserAsync(new UserFilter() { Email = postUser.Email });

            if (user != null)
            {
                return BadRequest("Email should be unique");
            }

            user = await _userService.GetUserAsync(new UserFilter() { MobileNumber = postUser.MobileNumber });

            if (user != null)
            {
                return BadRequest("Mobile number should be unique");
            }

            var result = await _userService.PostUserAsync(postUser);
            var response = _mapper.Map<UserViewModel>(result);
            return CreatedAtAction("Post", response);
        }
    }
}
