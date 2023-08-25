using LarsShopApi.Context;
using LarsShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LarsShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		public DataContext _dataContext;
		public ProductController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<ProductController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.Product.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<ProductController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.Product.FirstOrDefault(x => x.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<ProductController>
		[HttpPost]
		public IActionResult Post([FromBody] Product value)
		{
			try
			{
				_dataContext.Product.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// PUT api/<ProductController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Product value)
		{
			try
			{
				var product = _dataContext.Product.FirstOrDefault(x => x.Id == id);
				if(product != null)
				{
					_dataContext.Entry<Product>(product).CurrentValues.SetValues(value);
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

		// DELETE api/<ProductController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var product = _dataContext.Product.FirstOrDefault(x => x.Id == id);
				if (product != null)
				{
					_dataContext.Remove(product);
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
