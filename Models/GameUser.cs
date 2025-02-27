﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameAnalyticCore.Models
{
    
    public class GameUser
    {
       [Key]
        public Guid UserId
        {
            get;
            set;
        }
        public string FullName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}
