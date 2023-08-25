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
	public class ShipmentController : ControllerBase
	{
		public DataContext _dataContext;
		public ShipmentController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<ShipmentController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.Shipment.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<ShipmentController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.Shipment.FirstOrDefault(o => o.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<ShipmentController>
		[HttpPost]
		public IActionResult Post([FromBody] Shipment value)
		{
			try
			{
				_dataContext.Shipment.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
		}

		// PUT api/<ShipmentController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Shipment value)
		{
			try
			{
				var shipment = _dataContext.Shipment.FirstOrDefault(o => o.Id == id);
				if (shipment != null)
				{
					_dataContext.Entry<Shipment>(shipment).CurrentValues.SetValues(value);
					_dataContext.SaveChanges(true);
					return Ok(value);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
		}

		// DELETE api/<ShipmentController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var shipment = _dataContext.Shipment.FirstOrDefault(o => o.Id == id);
				if (shipment != null)
				{
					_dataContext.Remove(shipment);
					_dataContext.SaveChanges(true);
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
