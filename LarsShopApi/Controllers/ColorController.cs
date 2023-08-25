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
    public class ColorController : ControllerBase
    {
        public DataContext _dataContext;
        public ColorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<ColorController>
        [HttpGet]
        public IActionResult Get()
        {
			try
			{
				return Ok(_dataContext.Color);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
			try
			{
				return Ok(_dataContext.Color.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // POST api/<ColorController>
        [HttpPost]
        public IActionResult Post([FromBody] Color value)
        {
			try
			{
				_dataContext.Color.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Color value)
        {
			try
			{
				var color = _dataContext.Color.FirstOrDefault(c => c.Id == id);
				if (color != null)
				{
					_dataContext.Entry(color).CurrentValues.SetValues(value);
					_dataContext.SaveChanges();
					return Ok(value);
				}
				else return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
			try
			{
				var color = _dataContext.Color.FirstOrDefault(c => c.Id == id);
				if (color != null)
				{
					_dataContext.Remove(color);
					_dataContext.SaveChanges();
					return Ok();
				}
				else return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
        }
    }
}
