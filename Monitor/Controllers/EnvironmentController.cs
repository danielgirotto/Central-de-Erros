using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monitor.DTOs;
using Monitor.Models;
using Monitor.Services;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _service;
        private readonly IMapper _mapper;

        public EnvironmentController(IEnvironmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentDTO>> GetAll()
        {
            var environments = _service.SelectAll()
                .Select(x => _mapper.Map<EnvironmentDTO>(x))
                .ToList();

            return Ok(environments);
        }

        [HttpPost]
        public ActionResult<EnvironmentDTO> Post([FromBody] EnvironmentDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<EnvironmentDTO>(_service.Save(_mapper.Map<Environment>(value))));
        }
    }
}
