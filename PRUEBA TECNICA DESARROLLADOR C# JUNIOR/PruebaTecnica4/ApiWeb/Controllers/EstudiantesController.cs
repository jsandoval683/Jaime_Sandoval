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
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;
        public EstudiantesController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpPost("AddEstudiante")]
        public async Task<IActionResult> AddEstudiante(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _estudianteService.AddEstudiante(estudiante);

            if (response != null)
            {
                return new OkObjectResult(response);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("GetEstudiantes")]
        public async Task<IActionResult> GetEstudiantes()
        {
            var result = await _estudianteService.GetEstudiantes();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetEstudianteById/{id}")]
        public async Task<IActionResult> GetEstudianteById(int id)
        {
            var result = await _estudianteService.GetEstudianteById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateEstudiante")]
        public async Task<IActionResult> UpdateEstudiante(Estudiante estudiante)
        {
            var result = await _estudianteService.UpdateEstudiante(estudiante);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteEstudiante/{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var result = await _estudianteService.DeleteEstudiante(id);
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
