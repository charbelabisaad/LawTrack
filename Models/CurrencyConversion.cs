using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	[Index("CurrencyIDFrom")]
	[Index("CurrencyIDTo")]
	public class CurrencyConversion
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		public int CurrencyIDFrom { get; set; }

		[ForeignKey("CurrencyIDFrom")]
		public Currency CurrencyFrom { get; set; }

		[Required]
		public int CurrencyIDTo { get; set; }

		[ForeignKey("CurrencyIDTo")]
		public Currency CurrencyTo { get; set; }

		[Required]
		[StringLength(1,MinimumLength = 1)]
		public string Operation {  get; set; }

		[Required]
		[Column(TypeName ="decimal(18,2)")]
		public decimal Rate { get; set; }

	}
}
