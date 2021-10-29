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
    public class AsignaturasController : ControllerBase
    {
        private readonly IAsignaturaService _asignaturaService;

        public AsignaturasController(IAsignaturaService asignaturaService)
        {
            _asignaturaService = asignaturaService;
        }

        [HttpPost("AddAsignatura")]
        public async Task<IActionResult> AddAsignatura(Asignatura asignatura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _asignaturaService.AddAsignatura(asignatura);

            if (response != null)
            {
                return new OkObjectResult(response);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("GetAsignaturas")]
        public async Task<IActionResult> GetAsignaturas()
        {
            var result = await _asignaturaService.GetAsignaturas();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAsignaturaById/{id}")]
        public async Task<IActionResult> GetAsignaturaById(int id)
        {
            var result = await _asignaturaService.GetAsignaturaById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateAsignatura")]
        public async Task<IActionResult> UpdateAsignatura(Asignatura asignatura)
        {
            var result = await _asignaturaService.UpdateAsignatura(asignatura);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteAsignatura/{id}")]
        public async Task<IActionResult> DeleteAsignatura(int id)
        {
            var result = await _asignaturaService.DeleteAsignatura(id);
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
