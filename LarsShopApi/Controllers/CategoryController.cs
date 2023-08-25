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
    public class CategoryController : ControllerBase
    {
        public DataContext _dataContext;
        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
			try
			{
				return Ok(_dataContext.Category);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
			try
			{
				return Ok(_dataContext.Category.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category value)
        {
			try
			{
				_dataContext.Category.Add(value);
                _dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Category value)
        {
			try
			{
				var category = _dataContext.Category.FirstOrDefault(category => category.Id == id);
				if (category != null)
				{
					_dataContext.Entry(category).CurrentValues.SetValues(value);
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

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
			try
			{
				var category = _dataContext.Category.FirstOrDefault(category => category.Id == id);
				if (category != null)
				{
					_dataContext.Remove(category);
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
