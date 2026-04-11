using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	public class Priority
	{ 
		[Key]
		[StringLength(1, MinimumLength = 1)]
		public string ID { get; set; }

		[Required]
		[StringLength(50)]
		public string Description { get; set; }

		[Required]
		[StringLength(7, MinimumLength = 7)]
		public string Color { get; set; }
		 
	}
}
