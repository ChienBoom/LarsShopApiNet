using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("comment")]
	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[MaxLength(255)]
		public string Content { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime CreatedDate { get; set; }
		[Required]
		public Product Product { get; set; }
		[Required]
		public User User { get; set; }
	}
}
