using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Models;
using System.Data.Entity;
using GigHub.ViewModels;
using GigHub.Core.Repositories;
using GigHub.Persistance;

namespace GigHub.Persistance.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;
        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gig> GigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public IEnumerable<Gig> MyUpcomingGigs(string userId)
        {
            return _context.Gigs
                .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
        }

        public IEnumerable<Gig> UpcomingGigs()
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
        }

        public Gig GetGig(int id)
        {
            return _context.Gigs
                .Include(g=>g.Artist)
                .Include(g=>g.Genre)
                .SingleOrDefault(g => g.Id == id);
        }

        public Gig GetGigWithAttendance(GigFormViewModel viewModel)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == viewModel.Id);
        }

        public Gig GigsWithArtistAndGenre(int id)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == id);
        }

        public Gig GetGigWithAttendee(int id)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id);
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}