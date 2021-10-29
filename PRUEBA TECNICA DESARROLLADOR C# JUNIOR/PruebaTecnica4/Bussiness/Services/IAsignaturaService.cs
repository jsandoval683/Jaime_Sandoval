using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Bussiness.Services
{
    public interface IAsignaturaService
    {
        Task<Asignatura> AddAsignatura(Asignatura asignatura);
        Task<List<Asignatura>> GetAsignaturas();
        Task<Asignatura> GetAsignaturaById(int id);
        Task<bool> UpdateAsignatura(Asignatura asignatura);
        Task<bool> DeleteAsignatura(int id);
    }
}
