﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class CharListItem
    {
        public int Char_Id { get; set; }
        //public Game? GameTitle { get; set; }
        public string GameName { get; set; }
        public int GameID { get; set; }
        public string Char_Name { get; set; }
        public int Level { get; set; }
        public string Achievement { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
