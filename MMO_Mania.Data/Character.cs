using MMO_Mania.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Data
{
    public class Character
    {
        [Key]
        public int Char_Id { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        
        
        public Game? GameTitle { get; set; }
        public string Char_Name { get; set; }
        [Required]

        public int Level { get; set; }
        public string Achievement { get; set; }
        [Required]
        [ForeignKey("Achievements")]
        public int AchievementID { get; set; }
        public virtual Achievements Achievements { get; set; }

        public int Ranking { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
    public enum Game
    {
        WorldOfWarcraft = 1,
        RuneScape,
        ElderScrolls
    }
}
