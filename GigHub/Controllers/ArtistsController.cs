using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Persistance;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class ArtistsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ArtistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public ActionResult FollowingArtist()
        {
            var userId = User.Identity.GetUserId();

            var listArtistViewModel = new ListArtistViewModel
            {
                FollowingArtist = _unitOfWork.Followings.ArtistFollowedByUser(userId)
            };

            return View(listArtistViewModel);
        }
    }
}