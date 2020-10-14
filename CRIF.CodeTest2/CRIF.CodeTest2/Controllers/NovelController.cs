using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRIF.CodeTest2.API.Services;
using CRIF.CodeTest2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRIF.CodeTest2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NovelController : ControllerBase
    {


        private readonly ILogger<NovelController> _logger;
        private readonly INovelService _novelService;

        public NovelController(ILogger<NovelController> logger, INovelService novelService)
        {
            _logger = logger;
            _novelService = novelService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var result = _novelService.GetById(Guid.Parse(id));

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]Novel novel)
        {
                 await _novelService.Save(novel);
            return Ok();
        }
    }
}
