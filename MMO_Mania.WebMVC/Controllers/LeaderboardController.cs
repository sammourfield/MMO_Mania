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
        // GET: Leaderboard
       
        public ActionResult Ranking()
        {
            
            List<Character> characters = new List<Character>();

            var result = characters.OrderByDescending(c => c.Level)
                .Select((c, index) => new LeaderboardModel
                {
                    Char_Id = c.Char_Id,
                    
                    Char_Name = c.Char_Name,
                    Level = c.Level,
                    //Ranking = index < 5 ? "1" : index < 10 ? "2" : index < 15 ? "3" : "4" //based on the index to set ranking
                }); ;
            return View(result);
        }
    }
}