using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("shipment_detail")]
	public class ShipmentDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		public decimal TotalPrice { get; set; }
		[MaxLength(100)]
		public string Description { get; set; }
		[Required]
		public Shipment Shipment { get; set; }
	}
}
