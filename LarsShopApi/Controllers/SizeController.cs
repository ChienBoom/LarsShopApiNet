using LarsShopApi.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using LarsShopApi.Models;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LarsShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SizeController : ControllerBase
	{
		public DataContext _dataContext;
		public SizeController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<SizeController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.Size.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<SizeController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.Size.FirstOrDefault(x => x.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<SizeController>
		[HttpPost]
		public IActionResult Post([FromBody] Size value)
		{
			try
			{
				_dataContext.Size.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// PUT api/<SizeController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Size value)
		{
			try
			{
				var size = _dataContext.Size.FirstOrDefault(x =>x.Id == id);
				if (size != null)
				{
					_dataContext.Entry<Size>(size).CurrentValues.SetValues(value);
					_dataContext.SaveChanges() ;
					return Ok(value);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// DELETE api/<SizeController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var size = _dataContext.Size.FirstOrDefault(x => x.Id == id);
				if (size != null)
				{
					_dataContext.Remove(size);
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
