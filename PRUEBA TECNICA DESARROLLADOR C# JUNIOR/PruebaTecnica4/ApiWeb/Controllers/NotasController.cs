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
    public class NotasController : ControllerBase
    {
        private readonly INotaService _notaService;
        public NotasController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost("AddNotum")]
        public async Task<IActionResult> AddNotum(Notum notum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _notaService.AddNotum(notum);

            if (response != null)
            {
                return new OkObjectResult(response);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("GetNotums")]
        public async Task<IActionResult> GetNotums()
        {
            var result = await _notaService.GetNotums();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetNotumById/{id}")]
        public async Task<IActionResult> GetNotumById(int id)
        {
            var result = await _notaService.GetNotumById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetNotumsByIds/{idAsignatura}/{idEstudiante}/{idPeriodo}")]
        public async Task<IActionResult> GetNotumsByIds(int idAsignatura, int idEstudiante, int idPeriodo)
        {
            var result = await _notaService.GetNotumsByIds(idAsignatura, idEstudiante, idPeriodo);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateNotum")]
        public async Task<IActionResult> UpdateNotum(Notum notum)
        {
            var result = await _notaService.UpdateNotum(notum);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteNotum/{id}")]
        public async Task<IActionResult> DeleteNotum(int id)
        {
            var result = await _notaService.DeleteNotum(id);
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
