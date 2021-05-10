using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class CharEdit
    {
        public int Char_Id { get; set; }
        //public Game? GameTitle { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        [DisplayName("Character Name")]
        public string Char_Name { get; set; }
        public int Level { get; set; }
        public string Achievement { get; set; }
    }
}
