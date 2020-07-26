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
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _service;
        private readonly IMapper _mapper;

        public LevelController(ILevelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LevelDTO>> GetAll()
        {
            var levels = _service.SelectAll()
                .Select(x => _mapper.Map<LevelDTO>(x))
                .ToList();

            return Ok(levels);
        }

        [HttpPost]
        public ActionResult<LevelDTO> Post([FromBody] LevelDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<LevelDTO>(_service.Save(_mapper.Map<Level>(value))));
        }
    }
}
