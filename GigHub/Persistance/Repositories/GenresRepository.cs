using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Models;
using GigHub.Persistance;
using GigHub.Core.Repositories;

namespace GigHub.Persistance.Repositories
{
    public class GenresRepository : IGenresRepository
    {
        private ApplicationDbContext _context;
        public GenresRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}