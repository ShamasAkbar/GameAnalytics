using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAnalyticCore.Models;
using GameAnalyticCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameAnalyticCore.Services
{
    public class UserService : IUserService
    {
        private  CoreDbContext _context;
        public UserService(CoreDbContext context)
        {
            _context = context;
        }

        public List<GameUser> GetUsersList()
        {
            List<GameUser> empList;
            try
            {
                empList = _context.GameUsers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }
        public GameUser GetUserDetailsById(Guid UserId)
        {
            GameUser emp;
            try
            {
                emp = _context.Find<GameUser>(UserId);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }
        public ResponseModel SaveUser(GameUser gameUser)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                GameUser _temp = GetUserDetailsById(gameUser.UserId);
                if (_temp != null)
                {
                    _temp.FullName = gameUser.FullName;
                    _temp.Email = gameUser.Email;
                    
                    _context.Update<GameUser>(_temp);
                    model.Messsage = "User Update Successfully";
                }
                else
                {
                    _context.Add<GameUser>(gameUser);
                    model.Messsage = "User Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteEmployee(Guid UserId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                GameUser _temp = GetUserDetailsById(UserId);
                if (_temp != null)
                {
                    _context.Remove<GameUser>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }



    }
}
