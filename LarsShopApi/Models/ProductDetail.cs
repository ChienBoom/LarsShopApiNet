using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("product_detail")]
	public class ProductDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int NumberOfStoke { get; set; }
		[Required]
		public Color Color { get; set; }
		[Required]
		public Size Size { get; set; }
		[Required]
		public Product Product { get; set; }
	}
}
