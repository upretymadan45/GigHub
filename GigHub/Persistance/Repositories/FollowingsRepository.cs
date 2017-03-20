using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHub.Core.Models;
using GigHub.Persistance;
using GigHub.Core.Repositories;

namespace GigHub.Persistance.Repositories
{
    public class FollowingsRepository : IFollowingsRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, Gig gig)
        {
            return _context.Followings.SingleOrDefault(a => a.FolloweeId == gig.ArtistId && a.FollowerId == userId);
        }

        public IEnumerable<Following> MyFollowings(string userId)
        {
            return 
                _context.Followings
                .Where(f => f.FollowerId == userId)
                .ToList();
        }

        public IEnumerable<ApplicationUser> ArtistFollowedByUser(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}