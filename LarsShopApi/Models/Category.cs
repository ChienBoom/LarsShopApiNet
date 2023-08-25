using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("category")]
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string FullName { get; set; }
		[Required]
		[Index(IsUnique = true)]
		public Guid Code { get; set; }
		[StringLength(100)]
		public string Description { get; set; }
		public ICollection<Product> Products { get; set; }
		[Required]
		public string Picture { get; set; }
	}
}
