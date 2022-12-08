using GameAnalyticCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAnalyticCore.Models;

namespace GameAnalyticCore.Services
{
   public interface IUserService 
    {
        
        List<GameUser> GetUsersList();

        GameUser GetUserDetailsById(Guid UserId);

        
        ResponseModel SaveUser(GameUser userModel);


        //ResponseModel DeleteUser(Guid UserId);

    }
}
