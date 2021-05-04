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
            private readonly Guid _gameID;

            public GameService(Guid GameID)
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

                                        GameTitle = (Models.Game)e.GameTitle,
                                        Desc = e.Desc,
                                    }
                            );

                    return query.ToArray();
                }
            }
        }
}
