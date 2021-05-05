using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class AchievementListItem
    {
        public int AchievementID { get; set; }
        //public Game? GameTitle { get; set; }
        public int GameID { get; set; }
        [DisplayName("Character ID")]
        public int Char_Id { get; set; }
        [DisplayName("Character Name")]
        public string Char_Name { get; set; }
        public string Achievement { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
