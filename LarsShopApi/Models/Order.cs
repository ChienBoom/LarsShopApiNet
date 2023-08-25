using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("order")]
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[Index(IsUnique = true)]
		public Guid Code { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime CreatedDate { get; set;}
		public long OrderDetailId { get; set; }
		[Required]
		public OrderDetail OrderDetail { get; set; }
		[Required]
		public User User { get; set; }
	}
}
