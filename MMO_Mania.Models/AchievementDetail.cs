using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
     public class AchievementDetail
    {
        public int AchievementID { get; set; }
        //public Game? GameTitle { get; set; }
        public int Char_Id { get; set; }
        public int  GameID { get; set; }


        public string Char_Name { get; set; }
        
        public string Achievement { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
