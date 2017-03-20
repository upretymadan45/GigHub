using System.Linq;
using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class GigListingViewModel
    {
        public ILookup<int, Attendance> Attendances;
        public ILookup<string, Following> Followings;

        public bool IsAuthenticated { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}