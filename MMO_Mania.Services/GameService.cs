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
    }
}
