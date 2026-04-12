using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	public class Currency
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(10)]
		string Code { get; set; }

		[Required]
		[StringLength(50)]
		string Name { get; set; }

		[Required]
		[StringLength(5)]
		string Symbol { get; set; }
		 
	}
}
