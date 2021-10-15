using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Bussiness.Services
{
    public class TablaService : ITablaService
    {

        private readonly pruebaTecnicaCContext _context;

        public TablaService(pruebaTecnicaCContext context)
        {
            _context = context;
        }
        public async Task<List<Tabla>> GetTabla()
        {
            try
            {
                return await _context.Tablas.Take(10).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
