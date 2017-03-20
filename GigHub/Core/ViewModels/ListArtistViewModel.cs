using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.ViewModels
{
    public class ListArtistViewModel
    {
        public IEnumerable<ApplicationUser> FollowingArtist { get; set; }
    }
}