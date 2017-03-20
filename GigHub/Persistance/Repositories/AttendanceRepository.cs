using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Models;
using GigHub.Persistance;
using GigHub.Core.Repositories;

namespace GigHub.Persistance.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                           .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                           .ToList();
        }

        public Attendance GetAttendance(int id, string userId)
        {
            return _context.Attendances.SingleOrDefault(a => a.AttendeeId == userId && a.GigId == id);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}