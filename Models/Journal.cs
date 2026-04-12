using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(CurrencyIDDefault))]
	[Index(nameof(CurrencyIDSecond))] 
	public class Journal : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		 
		public int CaseID { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }
		 
		public DateTime Date { get; set; }
		 
		[StringLength(300)]
		public string Description { get; set; }
		 
		[Column(TypeName = "decimal(18,2)")]
		public decimal DebitDefault { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal CreditDefault { get; set; }

		[Required]
		public int CurrencyIDDefault { get; set; }

		[ForeignKey("CurrencyIDDefault")]
		public virtual Currency CurrencyDefault { get; set; }
		 
		[Column(TypeName = "decimal(18,2)")]
		public decimal DebitSecond { get; set; }
 
		[Column(TypeName = "decimal(18,2)")]
		public decimal CreditSecond { get; set; }

		[Required]
		public int CurrencyIDSecond { get; set; }

		[ForeignKey("CurrencyIDSecond")]
		public virtual Currency CurrencySecond { get; set; }

		// 🔹 Link to original record
		[StringLength(1, MinimumLength = 1)]
		public string ReferenceType { get; set; } // Charge / Payment

		public int? ReferenceID { get; set; }
	}
}
