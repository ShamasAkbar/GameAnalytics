using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GameAnalyticCore.Models;
using GameAnalyticCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameAnalyticCore.Services
{
    public class GameAnalytics : IGameAnalytics
    {
        private readonly CoreDbContext _context;
        public GameAnalytics(CoreDbContext context)
        {
            _context = context;
        }

        public Events GetEventDetailsByUserId(Guid UserId)
        {
            Events events;
            try
            {
                events = _context.Find<Events>(UserId);
            }
            catch (Exception)
            {
                throw;
            }
            return events;
        }
        public async Task<ResponseModel>  PostEvent(Events eve)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                if (eve == null)
                    return model;
                
                    Events events = new Events();                
                    events.EventID = eve.EventID;
                    events.EventName = eve?.EventName;
                    events.Time = System.DateTime.Now;
                    events.Event_Day = DateTime.Now.Day;
                    events.Event_Month = DateTime.Now.Month;
                    events.Event_Week = GetWeekNumber().ToString();
                    events.Event_Year = DateTime.Now.Year;
                    events.UserId = eve.UserId;
                    events.Game_Metric_Score_1 = eve.Game_Metric_Score_1;
                    events.Game_Metric_Score_2 = eve.Game_Metric_Score_2;

                    _context.Add<Events>(events);
                    _context.SaveChanges();
                    
                    model.Messsage = "Record Inserted Successfully";
                    model.IsSuccess = true;
            }
            catch(Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
        public int GetWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        public async Task<List<GetEventDetails>>  GetEvent(string EventType, DateTime fromDate, DateTime toDate, Guid UserId)
        {
            
            List<GetEventDetails> details = new List<GetEventDetails>();
            try
            {
                var events = _context.Events.Where(o => o.UserId == UserId && o.EventName == EventType && o.Time >= fromDate && o.Time <= toDate).ToList();
                               
                int i = 1;
                foreach (var item in events)
                {
                    
                  GetEventDetails obj = new GetEventDetails()
                  {
                    Time = item.Time,
                    Game_Metric_Score_1 = item.Game_Metric_Score_1,
                    Game_Metric_Score_2 = item.Game_Metric_Score_2,
                    Count = i,

                   };
                    i++;

                    details.Add(obj);
                }
            }
            catch(Exception ex)
            {
                
            }
            return details ;
            

        }
        
    }
}
