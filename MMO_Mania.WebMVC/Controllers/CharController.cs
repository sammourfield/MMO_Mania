using Microsoft.AspNet.Identity;
using MMO_Mania.Data;
using MMO_Mania.Models;
using MMO_Mania.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMO_Mania.WebMVC.Controllers
{
    [Authorize]
    public class CharController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);
            var model = service.GetCharacters();
           

            return View(model);
        }
        //GET CHAR
        public ActionResult Create()
        {
            var games = new SelectList(_db.Games.ToList(), "GameID", "GameName");
            ViewBag.Games = games;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharCreate model)
        {
            Games games = _db.Games.Find(model.GameID);
            if (games == null)
            {
                return HttpNotFound("Game not found");
            }
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharService();

            if (service.CreateChar(model))
            {
                TempData["SaveResult"] = "Your Character has been Entered.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Character could not be entered.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCharService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        private CharService CreateCharService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharService(userId);
            return service;
        }
        public ActionResult Edit(int id)
        {
            var games = new SelectList(_db.Games.ToList(), "GameID", "GameName");
            ViewBag.Games = games;
            

            var service = CreateCharService();
            var detail = service.GetCharacterById(id);
            var model =
                new CharEdit
                {
                    Char_Id = detail.Char_Id,
                    GameID = detail.GameID,
                    GameName = detail.GameName,
                    Char_Name = detail.Char_Name,
                    Level = detail.Level,
                    Achievement = detail.Achievement
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Char_Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCharService();

            if (service.UpdateChar(model))
            {
                TempData["SaveResult"] = "Your Character was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Character could not be updated.");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateCharService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCharService();

            service.DeleteChar(id);

            TempData["SaveResult"] = "Your Character was deleted";
            return RedirectToAction("Index");
        }

    }
}