using System.ComponentModel.DataAnnotations;

namespace LawTrack.Models
{
	public class PaymentMethod
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3 )] 
		public string Code {  get; set; } 

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(200)]
		public string? Description { get; set; }

	}
}
