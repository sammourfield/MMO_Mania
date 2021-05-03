﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMO_Mania.Models
{
    public class LeaderboardModel
    {
        
        public int Char_Id { get; set; }
        public Game? GameTitle { get; set; }
        public string Char_Name { get; set; }
      
        public int Level { get; set; }
        public string Achievements { get; set; }
        [Key]
        public int Ranking { get; set; }
    }
}