using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("shipment")]
	public class Shipment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[Index(IsUnique = true)]
		public Guid code { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime CreatedDate { get; set;}
		[Required]
		public Publish Publish { get; set; }
		public long ShipmentDetailId { get; set; }
		[Required]
		public ShipmentDetail ShipmentDetail { get; set; }
	}
}
