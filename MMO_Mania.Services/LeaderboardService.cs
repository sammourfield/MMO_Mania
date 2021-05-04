using MMO_Mania.Data;
using MMO_Mania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Services
{
   public  class LeaderboardService
    {
        private readonly Guid _userId;
        public IEnumerable<LeaderboardModel> RankCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new LeaderboardModel
                                {

                                    Ranking = e.Ranking,
                                    GameTitle = (Models.Game)e.GameTitle,
                                    Char_Id = e.Char_Id,
                                    Char_Name = e.Char_Name,
                                    Level = e.Level,
                                    Achievement = e.Achievement,
                                    
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
