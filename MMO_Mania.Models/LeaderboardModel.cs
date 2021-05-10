using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class LeaderboardModel
    {
        
        
        public int Char_Id { get; set; }
        public int GameID { get; set; }
        [DisplayName("Character Name")]
        public string Char_Name { get; set; }
      
        public int Level { get; set; }
        public string Achievement { get; set; }
        [Key]
        [DisplayName("MMO Mania Rank")]
        public int Ranking { get; set; }
    }
}
