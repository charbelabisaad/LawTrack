using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(ChargeTypeID))]
	[Index(nameof(CurrencyIDDefault))]
	[Index(nameof(CurrencyIDSecond))]
	public class CaseCharge : BaseEntity
	{
		[Key]
		public int ID { get; set; }

		public int CaseID { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }

		public int ChargeTypeID { get; set; }

		[ForeignKey("ChargeTypeID")]
		public virtual ChargeType ChargeType { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal AmountDefault { get; set; }

		[Required]
		public int CurrencyIDDefault { get; set; }

		[ForeignKey("CurrencyIDDefault")]
		public virtual Currency CurrencyDefault { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal AmountSecond { get; set; }

		[Required]
		public int CurrencyIDSecond { get; set; }

		[ForeignKey("CurrencyIDSecond")]
		public virtual Currency CurrencySecond { get; set; }

		public DateTime ChargeDate { get; set; }

		public string? Notes { get; set; }
	}
}
