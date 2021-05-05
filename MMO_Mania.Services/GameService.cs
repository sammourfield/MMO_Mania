using MMO_Mania.Data;
using MMO_Mania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Services
{

    public class GameService
        {
            private readonly int _gameID;

            public GameService(int GameID)
            {
                _gameID = GameID;
            }
          
            public IEnumerable<GameListItem> GetGames()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Games
                            .Where(e => e.GameID == _gameID)
                            .Select(
                                e =>
                                    new GameListItem
                                    {
                                        GameID = e.GameID,
                                        GameName = e.GameName,
                                        Desc = e.Desc,
                                    }
                            );

                    return query.ToArray();
                }
            }
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Games()
                {
                    GameID = _gameID,
                    GameName = model.GameName,
                    
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public GameDetail GetGameByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameID == id);
                return
                    new GameDetail
                    {
                        //GameTitle = (Models.Game)entity.GameTitle,
                        GameID = entity.GameID,
                        GameName = entity.GameName,
                        Desc = entity.Desc,
                        
                    };
            }
        }
    }
}
