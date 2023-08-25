using LarsShopApi.Context;
using LarsShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LarsShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        public DataContext _dataContext;
        public BankController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<BankController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dataContext.Bank.ToList());
			}
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // GET api/<BankController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
			try
			{
				return Ok(_dataContext.Bank.FirstOrDefault(b => b.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
        }

        // POST api/<BankController>
        [HttpPost]
        public IActionResult Post([FromBody] Bank value)
        {
			try
			{
				_dataContext.Bank.Add(value);
                _dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Bank value)
        {
			try
			{
				var bank = _dataContext.Bank.FirstOrDefault(b => b.Id == id);
				if (bank != null)
				{
					_dataContext.Entry(bank).CurrentValues.SetValues(value);
					_dataContext.SaveChanges();
					return Ok(value);
				}
				else return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
        }

        // DELETE api/<BankController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
			try
			{
				var bank = _dataContext.Bank.FirstOrDefault(b => b.Id == id);
                if (bank != null)
                {
                    _dataContext.Remove(bank);
                    _dataContext.SaveChanges();
                    return Ok();
                }
                else return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
        }
    }
}
