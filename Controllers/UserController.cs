using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Impl;
using FileData;
using LoginExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private IList<User> Users = new List<User>();
        private DBContext _dbContext = new DBContext();
        private SqliteService _service;
        
        public UserController()
        {
            _service = new SqliteService(_dbContext);
        }
        
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User suser)
        {
            try
            {
                User user = await _service.addUser(suser);

                return Created("https://localhost:5004/User", user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetUsers()
        {
            Users = await _service.getUsers();
            try
            {
                IList<User> users = Users;
                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


    }
}