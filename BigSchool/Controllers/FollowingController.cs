using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class FollowingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDTOs followingDTOs)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FollowerId == followingDTOs.FolloweeId))
                return BadRequest("Following already exists!");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}