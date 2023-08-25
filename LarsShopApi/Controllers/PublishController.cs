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
	public class PublishController : ControllerBase
	{
		public DataContext _dataContext;
		public PublishController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<PublishController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.Publish.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<PublishController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.Publish.FirstOrDefault(x => x.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST api/<PublishController>
		[HttpPost]
		public IActionResult Post([FromBody] Publish value)
		{
			try
			{
				_dataContext.Publish.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		// PUT api/<PublishController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Publish value)
		{
			try
			{
				var publish = _dataContext.Publish.FirstOrDefault(o => o.Id == id);
				if (publish != null)
				{
					_dataContext.Entry<Publish>(publish).CurrentValues.SetValues(value);
					_dataContext.SaveChanges(true);
					return Ok(value);
				}
				else return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		// DELETE api/<PublishController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var publish = _dataContext.Publish.FirstOrDefault(o => o.Id == id);
				if (publish != null)
				{
					_dataContext.Remove(publish);
					_dataContext.SaveChanges(true);
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
