using MMO_Mania.Models;
using MMO_Mania.Data;
using MMO_Mania.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace MMO_Mania.WebMVC.Controllers
{
    public class LeaderboardController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Leaderboard

        public ActionResult Ranking()
        {
            var chars = _db.Set<Character>().ToList();
            List<LeaderboardModel> charactersWithRank = new List<LeaderboardModel>();



            var result = chars.OrderByDescending(c => c.Level)
                .Select((c, index) => new LeaderboardModel
                {
                    Char_Id = c.Char_Id,
                    
                    Char_Name = c.Char_Name,
                    Level = c.Level
                });
            var rank = 1;
            foreach(var res in result)
            {
                res.Ranking = rank;
                charactersWithRank.Add(res);
                rank++;
            }
           
            return View(charactersWithRank);
        }
    }
}