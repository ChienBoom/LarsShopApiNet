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
	public class ProductDetailController : ControllerBase
	{
		public DataContext _dataContext;
		public ProductDetailController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		// GET: api/<ProductDetailController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(_dataContext.ProductDetail.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// GET api/<ProductDetailController>/5
		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			try
			{
				return Ok(_dataContext.ProductDetail.FirstOrDefault(X => X.Id == id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// POST api/<ProductDetailController>
		[HttpPost]
		public IActionResult Post([FromBody] ProductDetail value)
		{
			try
			{
				_dataContext.ProductDetail.Add(value);
				_dataContext.SaveChanges();
				return Ok(value);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message.ToString());
			}
		}

		// PUT api/<ProductDetailController>/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] ProductDetail value)
		{
			try
			{
				var productDetail = _dataContext.ProductDetail.FirstOrDefault(x => x.Id == id);
				if (productDetail != null)
				{
					_dataContext.Entry<ProductDetail>(productDetail).CurrentValues.SetValues(value);
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

		// DELETE api/<ProductDetailController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				var productDetail = _dataContext.ProductDetail.FirstOrDefault(x => x.Id == id);
				if (productDetail != null)
				{
					_dataContext.Remove(productDetail);
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
