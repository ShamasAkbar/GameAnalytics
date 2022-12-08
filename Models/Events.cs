using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameAnalyticCore.Models
{
    
    public class Events
    {
       
            [Key]
            public int EventID{ get; set; }
            public string EventName{ get; set; }
            public int Event_Day{ get; set; }
            public string Event_Week{ get; set; }
            public int Event_Month{ get; set; }
            public int Event_Year { get; set; }

            public DateTime Time { get; set; }
            public int Game_Metric_Score_1 { get; set; }
            public int Game_Metric_Score_2 { get; set; }
            
            public Guid UserId { get; set; }
            [ForeignKey("UserId")]
            
            public virtual GameUser GameUsers { get; set; }

    }
}
