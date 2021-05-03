using Microsoft.AspNet.Identity;
using MMO_Mania.Models;
using MMO_Mania.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMO_Mania.WebMVC.Controllers

        [Authorize]
        public class AchievementController : Controller
        {

            public ActionResult Index()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new AchievementService(userId);
                var model = service.GetAchievements();

                return View(model);
            }
            //GET CHAR
            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(AchievementCreate model)
            {
                if (!ModelState.IsValid) return View(model);

                var service = CreateAchieveService();

                if (service.CreateAchieve(model))
                {
                    TempData["SaveResult"] = "Your Achievement has been Entered.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Achievement could not be entered.");

                return View(model);
            }
            public ActionResult Details(int id)
            {
                var svc = CreateAchieveService();
                var model = svc.GetAchieveById(id);

                return View(model);
            }

            private AchievementService CreateAchieveService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new AchievementService(userId);
                return service;
            }
            public ActionResult Edit(int id)
            {
                var service = CreateAchieveService();
                var detail = service.GetAchieveById(id);
                var model =
                    new AchievementEdit
                    {
                        AchievementID = detail.AchievementID,
                        GameTitle = detail.GameTitle,
                        Char_Name = detail.Char_Name,
                        Achievement = detail.Achievement
                    };
                return View(model);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, AchievementEdit model)
            {
                if (!ModelState.IsValid) return View(model);

                if (model.AchievementID != id)
                {
                    ModelState.AddModelError("", "Id Mismatch");
                    return View(model);
                }
                var service = CreateAchieveService();

                if (service.UpdateAchieve(model))
                {
                    TempData["SaveResult"] = "Your Achievement was updated.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Your Achievement could not be updated.");
                return View();
            }
            public ActionResult Delete(int id)
            {
                var svc = CreateAchieveService();
                var model = svc.GetAchieveById(id);

                return View(model);
            }

            [HttpPost]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeletePost(int id)
            {
                var service = CreateAchieveService();

                service.DeleteAchieve(id);

                TempData["SaveResult"] = "Your Achievement was deleted";
                return RedirectToAction("Index");
            }
        }
}