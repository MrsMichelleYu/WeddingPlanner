using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User thisUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.Email == thisUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                thisUser.Password = Hasher.HashPassword(thisUser, thisUser.Password);
                dbContext.Users.Add(thisUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", thisUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogPassword);
                if (result == 0)// result is a failure
                {
                    ModelState.AddModelError("LogPassword", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                ModelState.AddModelError("LogEmail", "You must be logged in first");
                return View("Index");
            }
            List<Wedding> AllWeddings = dbContext.Weddings
                .Include(w => w.Creator)
                .Include(wedding => wedding.Guests)
                .ToList();
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            foreach (var wedding in AllWeddings)
            {
                if (wedding.Date < DateTime.Now)
                {
                    dbContext.Weddings.Remove(wedding);
                    dbContext.SaveChanges();
                }
            }
            return View(AllWeddings);
        }

        [HttpGet("new")] //displays form to enter a new wedding
        public IActionResult New()
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = thisUserId;
            return View();
        }

        [HttpPost("add")] //add a new wedding
        public IActionResult Add(Wedding newWedding)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            // int someUserId = (int)thisUserId; //convert nullable int to a non-nullable int 
            if (ModelState.IsValid)
            {
                newWedding.UserId = thisUserId;
                dbContext.Weddings.Add(newWedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            ViewBag.UserId = thisUserId;
            return View("New");
        }

        [HttpGet("rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            int someUserId = (int)thisUserId;
            JoinedWedding newGuest = new JoinedWedding()
            {
                WeddingId = weddingId,
                UserId = someUserId,
            };
            dbContext.JoinedWeddings.Add(newGuest);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("unrsvp/{weddingId}")]
        public IActionResult UnRSVP(int weddingId)
        {
            JoinedWedding retrievedGuest = dbContext.JoinedWeddings.SingleOrDefault(guest => guest.WeddingId == weddingId);
            dbContext.JoinedWeddings.Remove(retrievedGuest);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{weddingId}")]
        public IActionResult Delete(int weddingId)
        {
            Wedding retrievedWedding = dbContext.Weddings.SingleOrDefault(wedding => wedding.WeddingId == weddingId);
            dbContext.Weddings.Remove(retrievedWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("{weddingId}")]
        public IActionResult Show(int weddingId)
        {
            Wedding thisWedding = dbContext.Weddings
                .Include(w => w.Guests)
                .ThenInclude(g => g.GuestInfo)
                .SingleOrDefault(wedding => wedding.WeddingId == weddingId);
            return View("Show", thisWedding);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
