using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Bussiness.Services
{
    public interface IEstudianteService
    {
        Task<Estudiante> AddEstudiante(Estudiante estudiante);
        Task<List<Estudiante>> GetEstudiantes();
        Task<Estudiante> GetEstudianteById(int id);
        Task<bool> UpdateEstudiante(Estudiante estudiante);
        Task<bool> DeleteEstudiante(int id);
    }
}
