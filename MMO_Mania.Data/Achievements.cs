using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Data
{
    public class Achievements
    {
        [Required]
        public Guid OwnerID { get; set; }
        public Game? GameTitle { get; set; }
        [Key]
        public int AchievementID { get; set; }
        [Required]
        public string Char_Name { get; set; }
        [Required]
        public string Achievement { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
