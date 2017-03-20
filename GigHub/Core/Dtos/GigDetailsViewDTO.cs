using GigHub.Core.Models;

namespace GigHub.Dtos
{
    public class GigDetailsViewDTO
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}