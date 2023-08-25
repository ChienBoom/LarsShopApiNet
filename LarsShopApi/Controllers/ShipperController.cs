using LarsShopApi.Context;
using LarsShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LarsShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipperController : ControllerBase
	{
		public DataContext _dataContext;
		public ShipperController(DataContext dataContext) 
		{
			_dataContext = dataContext;
		}
		// GET: api/<ShipperController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.Shipper.ToList());
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
		}

		// GET api/<ShipperController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.Shipper.FirstOrDefault(s => s.Id == id));
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
		}

		// POST api/<ShipperController>
		[HttpPost]
		public IActionResult Post([FromBody] Shipper value)
		{
			try
			{
				_dataContext.Shipper.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
			
		}

		// PUT api/<ShipperController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Shipper value)
		{
			try
			{
				var shipper = _dataContext.Shipper.FirstOrDefault(s => s.Id == id);
				if (shipper != null)
				{
					_dataContext.Entry<Shipper>(shipper).CurrentValues.SetValues(value);
					_dataContext.SaveChanges(true);
					return Ok(value);
				}
				return NotFound();
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
			
		}

		// DELETE api/<ShipperController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var shipper = _dataContext.Shipper.FirstOrDefault(s => s.Id == id);
				if (shipper != null)
				{
					_dataContext.Remove(shipper);
					_dataContext.SaveChanges(true);
					return Ok();
				}
				return NotFound();
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
			
		}
	}
}
