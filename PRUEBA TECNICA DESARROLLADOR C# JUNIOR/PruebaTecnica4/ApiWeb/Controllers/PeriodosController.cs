using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using Bussiness.Services;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodosController : ControllerBase
    {
        private readonly IPeriodoService _periodoService;
        public PeriodosController(IPeriodoService periodoService)
        {
            _periodoService = periodoService;
        }

        [HttpPost("AddPeriodo")]
        public async Task<IActionResult> AddPeriodo(Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _periodoService.AddPeriodo(periodo);

            if (response != null)
            {
                return new OkObjectResult(response);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("GetPeriodos")]
        public async Task<IActionResult> GetPeriodos()
        {
            var result = await _periodoService.GetPeriodos();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPeriodoById/{id}")]
        public async Task<IActionResult> GetPeriodoById(int id)
        {
            var result = await _periodoService.GetPeriodoById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdatePeriodo")]
        public async Task<IActionResult> UpdatePeriodo(Periodo periodo)
        {
            var result = await _periodoService.UpdatePeriodo(periodo);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeletePeriodo/{id}")]
        public async Task<IActionResult> DeletePeriodo(int id)
        {
            var result = await _periodoService.DeletePeriodo(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
