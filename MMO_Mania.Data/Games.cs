using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Data
{
    public class Games
    {
        [Key]
        public int GameID { get; set; }
        
        public string GameName { get; set; }
        
        [Required]
        public string Desc { get; set; }


    }
 
}
