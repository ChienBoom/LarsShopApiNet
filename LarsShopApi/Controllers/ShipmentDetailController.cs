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
	public class ShipmentDetailController : ControllerBase
	{
		public DataContext _dataContext;
		public ShipmentDetailController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<ShipmentDetailController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.ShipmentDetail.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<ShipmentDetailController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.ShipmentDetail.FirstOrDefault(x => x.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<ShipmentDetailController>
		[HttpPost]
		public IActionResult Post([FromBody] ShipmentDetail value)
		{
			try
			{
				_dataContext.ShipmentDetail.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
			
		}

		// PUT api/<ShipmentDetailController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] ShipmentDetail value)
		{
			try
			{
				var shipmentDetail = _dataContext.ShipmentDetail.FirstOrDefault(o => o.Id == id);
				if (shipmentDetail != null)
				{
					_dataContext.Entry<ShipmentDetail>(shipmentDetail).CurrentValues.SetValues(value);
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

		// DELETE api/<ShipmentDetailController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var shipmentDetail = _dataContext.ShipmentDetail.FirstOrDefault(o => o.Id == id);
				if (shipmentDetail != null)
				{
					_dataContext.Remove(shipmentDetail);
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
