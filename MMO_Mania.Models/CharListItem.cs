
using MMO_Mania.Data;
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
    public class CharListItem
    {
        [DisplayName("Character ID")]
        public int Char_Id { get; set; }
        //public Game? GameTitle { get; set; }
        public string GameName { get; set; }

        [ForeignKey("Games")]
        public int GameID { get; set; }
        public virtual Games Games { get; set; }

        [DisplayName("Character Name")]
        public string Char_Name { get; set; }
        public int Level { get; set; }
        public string Achievement { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
