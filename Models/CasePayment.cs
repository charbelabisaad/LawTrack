using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(ChargeID))]
	[Index(nameof(CurrencyIDDefault))]
	[Index(nameof(CurrencyIDSecond))]
	[Index(nameof(PaymentMethodID))]
	public class CasePayment : BaseEntity
	{
		[Key]
		public int ID { get; set; }

		// 🔹 Case
		[Required]
		public int CaseID { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }

		// 🔹 Related Charge (optional but recommended)
		public int? ChargeID { get; set; }

		[ForeignKey("ChargeID")]
		public virtual CaseCharge Charge { get; set; }

		// 🔹 Amount Paid
		[Required]
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

		// 🔹 Payment Date
		[Required]
		public DateTime PaymentDate { get; set; }

		// 🔹 Payment Method
		[Required]
		public int PaymentMethodID { get; set; }

		[ForeignKey("PaymentMethodID")]
		public virtual PaymentMethod PaymentMethod { get; set; }

		[StringLength(100)]
		public string? PaymentMethodNumber { get; set; }  
		 
		public DateTime? PaymentMethodDate { get; set; }    
		 
		// 🔹 Reference (receipt, bank ref, etc.)
		[StringLength(100)]
		public string? ReferenceNumber { get; set; }

		// 🔹 Notes
		public string? Notes { get; set; }
	}
}
