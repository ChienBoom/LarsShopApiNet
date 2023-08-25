using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("shipper")]
	public class Shipper
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string FullName { get; set; }
		[Required]
		public string Sex { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DateOfBirth { get; set; }
		[Required]
		[MaxLength(12)]
		[Index(IsUnique = true)]
		public string PhoneNumber { get; set; }
		[Required]
		[MaxLength(50)]
		[Index(IsUnique = true)]
		public string Email { get; set; }
		[Required]
		[MaxLength(100)]
		public string Address { get; set; }
		public OrderDetail OrderDetail { get; set; }
	}
}
