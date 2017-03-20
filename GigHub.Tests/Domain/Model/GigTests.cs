using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Core.Models;
using FluentAssertions;
using System.Linq;

namespace GigHub.Tests.Domain.Model
{
    [TestClass]
    public class GigTests
    {
        [TestMethod]
        public void Cancel_WhenCalled_ShouldSetIsCancelledToTrue()
        {
            var gig = new Gig();

            gig.Cancel();

            gig.IsCanceled.Should().BeTrue();

        }

        [TestMethod]
        public void Cancel_WhenCalled_EachAttendeeHasNotification()
        {
            var gig = new Gig();
            gig.Attendances.Add(new Attendance { Attendee = new ApplicationUser { Name ="name" } });

            gig.Cancel();

            var attendees = gig.Attendances.Select(a => a.Attendee).ToList();
            attendees[0].UserNotifications.Count.Should().Be(1);
        }
    }
}
