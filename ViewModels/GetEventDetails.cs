﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAnalyticCore.ViewModels
{
    public class GetEventDetails
    {
        public DateTime Time { get; set; } 
        public int Game_Metric_Score_1{ get; set; } 
        public int Game_Metric_Score_2{ get; set; } 
        public int Count{ get; set; }
    }
}
