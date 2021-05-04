using MMO_Mania.Data;
using MMO_Mania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Services
{
    public class CharService
    {
        private readonly Guid _userId;

        public CharService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateChar(CharCreate model)
        {
            var entity =
                new Character()
                {
                    OwnerID = _userId,
                    GameTitle = (Data.Game)model.GameTitle,
                    Char_Name = model.Char_Name,
                    Level = model.Level,
                    Achievement = model.Achievement,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new CharListItem
                                {

                                    GameTitle = (Models.Game)e.GameTitle,
                                    Char_Id = e.Char_Id,
                                    Char_Name = e.Char_Name,
                                    Level = e.Level,
                                    Achievement = e.Achievement,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.Char_Id == id && e.OwnerID == _userId);
                return
                    new CharacterDetail
                    {
                        GameTitle = (Models.Game)entity.GameTitle,
                        Char_Id = entity.Char_Id,
                        Char_Name = entity.Char_Name,
                        Level = entity.Level,
                        Achievement = entity.Achievement,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateChar(CharEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.Char_Id == model.Char_Id && e.OwnerID == _userId);

                entity.Char_Name = model.Char_Name;
                entity.GameTitle = (Data.Game?)model.GameTitle;
                entity.Level = model.Level;
                entity.Achievement = model.Achievement;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteChar(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.Char_Id == noteId && e.OwnerID == _userId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
