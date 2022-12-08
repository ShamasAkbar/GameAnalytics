using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameAnalyticCore.Services;
using GameAnalyticCore.Models;

namespace GameAnalyticCore.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IGameAnalytics _gameAnalytics;
        private readonly IMailService mailService;
        public UserController(IUserService service)
        {
            _userService = service;
        }
        public UserController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                var employees = _userService.GetUsersList();
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetUserById")]
        public IActionResult GetUserById(Guid UserId)
        {
            try
            {
                var user = _userService.GetUserDetailsById(UserId);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("PostData")]
        public async Task<IActionResult> PostData([FromBody] Events events)
        {
            try
            {
                var Events =await _gameAnalytics.PostEvent(events);
                if (Events == null) return NotFound();
                return Ok(Events);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("GetData")]
        public async Task<IActionResult>GetData(string EventType, DateTime fromData, DateTime toDate , Guid UserId)
        {
            try
            {
                var Events = await _gameAnalytics.GetEvent(EventType,fromData,  toDate, UserId);
                if (Events == null) return NotFound();
                return Ok(Events);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
