using GameAnalyticCore.Models;
using GameAnalyticCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAnalyticCore.Services
{
    interface IGameAnalytics
    {
        Task<ResponseModel> PostEvent(Events events);
        Events GetEventDetailsByUserId(Guid UserId);
        Task<List<GetEventDetails>> GetEvent(string EventType, DateTime fromDate, DateTime toDate, Guid UserId);
    }
}
