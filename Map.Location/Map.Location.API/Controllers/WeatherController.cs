using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Map.Location.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Map.Location.Data.Base;
using Map.Location.BI.Interfaces;
using Map.Location.Data.Dto;

namespace Map.Location.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class WeatherController : BaseController
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IMapper _mapper;
        private readonly IWeather _weather;

        public WeatherController(ILogger<WeatherController> logger, IMapper mapper, IWeather weather)
        {
            _logger = logger;
            _mapper = mapper;
            _weather = weather;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Coordinates coordinates)
        {
            return Ok(await _weather.Get(coordinates));
        }

        [HttpGet("to-string")]
        public async Task<IActionResult> ToString([FromQuery] Coordinates coordinates)
        {
            return Ok((await _weather.Get(coordinates)).ToString());
        }
    }
}
