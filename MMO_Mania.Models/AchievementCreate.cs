using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class AchievementCreate
    {
        [Required]
        public Game? GameTitle { get; set; }
        [Required]

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(16, ErrorMessage = "There are too many characters in this field.")]
        public string Char_Name { get; set; }
        
        [MaxLength(2000)]
        public string Achievement { get; set; }
    }

 
}
    