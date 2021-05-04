using MMO_Mania.Models;
using MMO_Mania.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Services
{
    public class AchievementService
    {
        private readonly Guid _userId;

        public AchievementService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAchieve(AchievementCreate model)
        {
            var entity =
                new Achievements()
                {
                    OwnerID = _userId,
                    GameTitle = (Data.Game)model.GameTitle,
                    Char_Name = model.Char_Name,
                    Achievement = model.Achievement,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Achievements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AchievementListItem> GetAchievements()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Achievements
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new AchievementListItem
                                {

                                    GameTitle = (Models.Game)e.GameTitle,
                                    AchievementID = e.AchievementID,
                                    Char_Name = e.Char_Name,
                                    Achievement = e.Achievement,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public AchievementDetail GetAchieveById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementID == id && e.OwnerID == _userId);
                return
                    new AchievementDetail
                    {
                        GameTitle = (Models.Game)entity.GameTitle,
                        AchievementID = entity.AchievementID,
                        Char_Name = entity.Char_Name,
                        Achievement = entity.Achievement,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateAchieve(AchievementEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementID == model.AchievementID && e.OwnerID == _userId);

                entity.Char_Name = model.Char_Name;
                entity.GameTitle = (Data.Game?)model.GameTitle;
                entity.Achievement = model.Achievement;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteAchieve(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementID == noteId && e.OwnerID == _userId);

                ctx.Achievements.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

    

