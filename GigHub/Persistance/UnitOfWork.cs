using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Persistance.Repositories;

namespace GigHub.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }
        public IFollowingsRepository Followings { get; private set; }
        public IGenresRepository Genres { get; private set; }

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            Gigs = new GigRepository(_context);
            Attendances = new AttendanceRepository(_context);
            Followings = new FollowingsRepository(_context);
            Genres = new GenresRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}