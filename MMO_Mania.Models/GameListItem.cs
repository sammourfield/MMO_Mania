using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class GameListItem
    {  

        [Key]
        public int GameId { get; set; }

        [Required]
        public string Desc { get; set; }

        public Game GameTitle { get; set; }


    }
   
}
    

