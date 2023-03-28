﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviaReport.Models
{
    public class UserCRA
    {
        public int Id { get; set; }
     
        public int UserId { get; set; }
        public User User { get; set; }
        public int CRAId { get; set; }
        public CRA CRA { get; set; }
       

    }
}
