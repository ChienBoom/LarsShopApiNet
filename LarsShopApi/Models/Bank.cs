using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LarsShopApi.Models
{
	[Table("bank")]
	public class Bank
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(50)]
		public string AccountName { get; set; }
		[Required]
		[StringLength(50)]
		public string Number { get; set; }
		[Required]
		public User User { get; set; }
	}
}
