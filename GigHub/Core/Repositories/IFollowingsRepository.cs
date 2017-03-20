using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IFollowingsRepository
    {
        Following GetFollowing(string userId, Gig gig);
        IEnumerable<Following> MyFollowings(string userId);
        IEnumerable<ApplicationUser> ArtistFollowedByUser(string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}