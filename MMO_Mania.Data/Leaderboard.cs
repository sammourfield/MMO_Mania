using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Data
{
    public class Leaderboard
    {
        [Key]
        public int Rank { get; set; }
        [ForeignKey("Char_Id")]
        public int Char_Id { get; set; }
        public string Char_Name { get; set; }
        public int Level { get; set; }
        public string Achievements { get; set; }
    }
    
}
