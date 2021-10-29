using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Bussiness.Services
{
    public interface IPeriodoService
    {
        Task<Periodo> AddPeriodo(Periodo periodo);
        Task<List<Periodo>> GetPeriodos();
        Task<Periodo> GetPeriodoById(int id);
        Task<bool> UpdatePeriodo(Periodo periodo);
        Task<bool> DeletePeriodo(int id);
    }
}
