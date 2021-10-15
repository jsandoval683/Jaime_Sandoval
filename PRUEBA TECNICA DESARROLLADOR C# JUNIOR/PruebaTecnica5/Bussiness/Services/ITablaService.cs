using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Bussiness.Services
{
    public interface ITablaService
    {
        Task<List<Tabla>> GetTabla();
    }
}
