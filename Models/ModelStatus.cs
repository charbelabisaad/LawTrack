using System.ComponentModel.DataAnnotations;

namespace LawTrack.Models
{
	public class ModelStatus
	{
		[Key]
		[Required]
		public int ID { get; set; }

		[Required]
		[StringLength(50)]
		public string ModelName { get; set; }

		[Required]
		[StringLength(50)]
		public string StatusIDs { get; set; }
 
	}
}
