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
	public class OrderController : ControllerBase
	{
		public DataContext _dataContext;
		public OrderController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<OrderController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.Order);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET api/<OrderController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.Order.FirstOrDefault(o => o.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST api/<OrderController>
		[HttpPost]
		public IActionResult Post([FromBody] Order value)
		{
			try
			{
				_dataContext.Order.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT api/<OrderController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Order value)
		{
			try
			{
				var order = _dataContext.Order.FirstOrDefault(o => (o.Id == id));
				if (order != null)
				{
					_dataContext.Entry<Order>(order).CurrentValues.SetValues(value);
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

		// DELETE api/<OrderController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var order = _dataContext.Order.FirstOrDefault(o => (o.Id == id));
				if (order != null)
				{
					_dataContext.Remove(order);
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
