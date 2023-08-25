using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("user")]
	public class User
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
		[Required]
		[StringLength(50)]
		public string Sex { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DateOfBirth { get; set; }
		[Required]
		[StringLength(50)]
		[Index(IsUnique = true)]
		public string Email { get; set; }
		[Required]
		[StringLength(12)]
		[Index(IsUnique = true)]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(50)]
		public string role { get; set; }
		[Required]
		[StringLength(50)]
		public string Address { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
