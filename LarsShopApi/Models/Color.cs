using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("color")]
	public class Color
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[StringLength(50)]
		public string Description { get; set; }
		public ICollection<ProductDetail> ProductDetails { get; set; }
	}
}
