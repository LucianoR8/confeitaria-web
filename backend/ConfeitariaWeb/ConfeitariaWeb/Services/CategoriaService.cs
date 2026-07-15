using ConfeitariaWeb.Data;
using ConfeitariaWeb.Services.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Repositories.Interface;

namespace ConfeitariaWeb.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        
    }
}