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
	public class UserController : ControllerBase
	{
		public DataContext _dataContext;
		public UserController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<UserController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.User.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.User.FirstOrDefault(u => u.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<UserController>
		[HttpPost]
		public IActionResult Post([FromBody] User value)
		{
			try
			{
				_dataContext.User.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] User value)
		{
			try
			{
				var user = _dataContext.User.FirstOrDefault(u => u.Id == id);
				if (user != null)
				{
					_dataContext.Entry<User>(user).CurrentValues.SetValues(value);
					_dataContext.SaveChanges();
					return Ok(value);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var user = _dataContext.User.FirstOrDefault(u => u.Id == id);
				if (user != null)
				{
					_dataContext.Remove(user);
					_dataContext.SaveChanges();
					return Ok();
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
		}
	}
}
