using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("product")]
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[Index(IsUnique = true)]
		public Guid Code { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		public int Star { get; set; }
		[Required]
		public int NumberOfSales { get; set; }
		[StringLength(100)]
		public string Description { get; set; }
		[Required]
		public ICollection<ProductDetail> ProductDetails { get; set; }
		public ICollection<Comment> Comments { get; set; }
		[Required]
		public Category Category { get; set; }
		[Required]
		public Shipment Shipment { get; set; }
		[Required]
		public string Picture { get; set; }
	}
}
