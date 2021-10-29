using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileData;
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

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            _adults = _fileContext.Adults;
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
            _adults = _fileContext.Adults;
            try
            {
                _adults.Add(adult);
                _fileContext.SaveChanges();
                return Created("https://localhost:5004/Person", adult);
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
            _adults = _fileContext.Adults;
            try
            {
                for (int i = 0; i < _adults.Count; i++)
                {
                    if (_adults[i].Id == id)
                    {
                        _adults.Remove(_adults[i]);
                    }
                }
                _fileContext.SaveChanges();
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