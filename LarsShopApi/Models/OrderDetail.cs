using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("order_detail")]
	public class OrderDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		public decimal TotalPrice { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		public string Pay { get; set; }
		[MaxLength(100)]
		public string Description { get; set; }
		[Required]
		public Product Product { get; set; }
		[Required]
		public Order Order { get; set; }
		public long ShipperId { get; set; }
		[Required]
		public Shipper Shipper { get; set; }
	}
}
