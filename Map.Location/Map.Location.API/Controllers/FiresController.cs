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
    public class FiresController : BaseController
    {
        private readonly ILogger<FiresController> _logger;
        private readonly IMapper _mapper;
        private readonly IGeolocation _geolocation;
        private readonly IFires _fires;

        public FiresController(ILogger<FiresController> logger, IMapper mapper, IGeolocation geolocation, IFires fires)
        {
            _logger = logger;
            _mapper = mapper;
            _geolocation = geolocation;
            _fires = fires;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Coordinates coordinates)
        {
            return Ok(await _geolocation.GetObjectsNearby(coordinates));
        }

        [HttpPost("add-fire")]
        public async Task<IActionResult> AddFire([FromBody] Fire fire)
        {
            await _fires.AddFire(fire);

            return Ok();
        }
    }
}
