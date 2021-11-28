using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Impl;
using FileData;
using LoginExample.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PersonController:ControllerBase
    {
        private FileContext _fileContext = new FileContext();
        private IList<Adult> _adults = new List<Adult>();
        private IList<User> Users = new List<User>();
        private DBContext _dbContext = new DBContext();
        private SqliteService _service;

        public PersonController()
        {
            _service = new SqliteService(_dbContext);
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetUsers()
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
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            _adults = await _service.GetAdults();
            try
            {
                IList<Adult> adults = _adults;
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adult added = await _service.addAdult(adult);

                return Created("https://localhost:5004/Person", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> RemoveAdult([FromRoute] int id)
        {
            _adults = await _service.GetAdults();
            try
            {
                for (int i = 0; i < _adults.Count; i++)
                {
                    if (_adults[i].Id == id)
                    {
                        _service.RemoveAdult(i);
                    }
                }
                _dbContext.SaveChanges();
                Console.WriteLine("did");
                return Accepted($"https://localhost:5004/Person/{id}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


    }



}