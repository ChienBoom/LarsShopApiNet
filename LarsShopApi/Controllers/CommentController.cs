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
    public class CommentController : ControllerBase
    {
        public DataContext _dataContext;
        public CommentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get()
        {
			try
			{
				return Ok(_dataContext.Comment);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
			try
			{
				return Ok(_dataContext.Comment.FirstOrDefault(c => c.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] Comment value)
        {
			try
			{
				_dataContext.Comment.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Comment value)
        {
			try
			{
				var comment = _dataContext.Comment.FirstOrDefault(c => c.Id == id);
				if (comment != null)
				{
					_dataContext.Entry(comment).CurrentValues.SetValues(value);
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

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
			try
			{
				var comment = _dataContext.Comment.FirstOrDefault(c => c.Id == id);
				if (comment != null)
				{
					_dataContext.Remove(comment);
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
