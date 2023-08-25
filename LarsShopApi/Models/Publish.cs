using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("publish")]
	public class Publish
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string FullName { get; set; }
		[Required]
		[StringLength(100)]
		public string Address { get; set; }
		[Required]
		[StringLength(50)]
		[Index(IsUnique = true)]
		public string Email { get; set; }
		[Required]
		[StringLength(12)]
		[Index(IsUnique = true)]
		public string PhoneNumber { get; set; }
		public ICollection<Shipment> Shipments { get; set; }
	}
}
