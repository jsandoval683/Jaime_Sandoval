using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Bussiness.Services
{
    public interface INotaService
    {
        Task<Notum> AddNotum(Notum notum);
        Task<List<Notum>> GetNotums();
        Task<Notum> GetNotumById(int id);
        Task<List<Notum>> GetNotumsByIds(int idEstudiante, int idAsignatura, int idPeriodo);
        Task<bool> UpdateNotum(Notum notum);
        Task<bool> DeleteNotum(int id);
    }
}
