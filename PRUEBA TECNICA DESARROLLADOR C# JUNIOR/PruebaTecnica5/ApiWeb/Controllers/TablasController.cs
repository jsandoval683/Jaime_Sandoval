using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Services;
using DataAccess.Models;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablasController : ControllerBase
    {
        private readonly ITablaService _tablaService;
        public TablasController(ITablaService tablaService)
        {
            _tablaService = tablaService;
        }

        [HttpGet("GetTablas")]
        public async Task<IActionResult> GetTablas()
        {
            var result = await _tablaService.GetTabla();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
