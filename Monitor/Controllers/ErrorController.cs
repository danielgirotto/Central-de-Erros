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
    public class ErrorController : ControllerBase
    {
        private readonly IErrorService _service;
        private readonly IMapper _mapper;

        public ErrorController(IErrorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{environmentId}/{description?}/{level?}/{origin?}")]
        public ActionResult<IEnumerable<ErrorDTO>> GetAll(string description, string level, string origin, int environmentId)
        {
            if (description != null)
                return Ok(_service.FindByEnvironmentIdAndDescription(environmentId, description)
                    .Select(x => _mapper.Map<ErrorDTO>(x))
                    .ToList());

            if (level != null)
                return Ok(_service.FindByEnvironmentIdAndLevelName(environmentId, level)
                    .Select(x => _mapper.Map<ErrorDTO>(x))
                    .ToList());

            if (origin != null)
                return Ok(_service.FindByEnvironmentIdAndOrigin(environmentId, origin)
                    .Select(x => _mapper.Map<ErrorDTO>(x))
                    .ToList());

            return Ok(_service.FindByEnvironmentId(environmentId)
                .Select(x => _mapper.Map<ErrorDTO>(x))
                .ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<ErrorDTO> Get(int id)
        {
            return Ok(_mapper.Map<ErrorDTO>(_service.FindById(id)));
        }

        [HttpPost]
        public ActionResult<ErrorDTO> Post([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<ErrorDTO>(_service.Save(_mapper.Map<Error>(value))));
        }
    }
}
