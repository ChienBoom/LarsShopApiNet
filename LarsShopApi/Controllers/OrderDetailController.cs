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
	public class OrderDetailController : ControllerBase
	{
		public DataContext _dataContext;
		public OrderDetailController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<OrderDetailController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.OrderDetail.ToList());
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
		}

		// GET api/<OrderDetailController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{

				return Ok(_dataContext.OrderDetail.FirstOrDefault(x => x.Id == id));
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
		}

		// POST api/<OrderDetailController>
		[HttpPost]
		public IActionResult Post([FromBody] OrderDetail value)
		{
			try
			{
				_dataContext.OrderDetail.Add(value);
				_dataContext.SaveChanges();
				return Ok();
			}
			catch(System.Exception ex)
			{
				return BadRequest(ex.Message.ToString());
				throw;
			}
		}

		// PUT api/<OrderDetailController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] OrderDetail value)
		{
			try
			{
				var orderDetail = _dataContext.OrderDetail.FirstOrDefault(o  => o.Id == id);
				if(orderDetail != null)
				{
					_dataContext.Entry<OrderDetail>(orderDetail).CurrentValues.SetValues(value);
					_dataContext.SaveChanges();
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

		// DELETE api/<OrderDetailController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var orderDetail = _dataContext.OrderDetail.FirstOrDefault(o => o.Id == id);
				if (orderDetail != null)
				{
					_dataContext.Remove(orderDetail);
					_dataContext.SaveChanges();
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
