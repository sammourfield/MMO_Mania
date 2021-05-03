using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class AchievementEdit
    {
        public int AchievementID { get; set; }
        public Game? GameTitle { get; set; }
        public string Char_Name { get; set; }
        public string Achievement { get; set; }
    }
}
