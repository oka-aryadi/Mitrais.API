using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mitrais.API.ViewModel;
using Mitrais.Interface;

namespace Mitrais.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private IGenderService _genderService;
        private IMapper _mapper;

        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _genderService.GetGendersAsync();
            var response = _mapper.Map<IEnumerable<GenderViewModel>>(result);
            return Ok(response);
        }
    }
}
