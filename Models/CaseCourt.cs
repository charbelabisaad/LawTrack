using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(CourtID))]
	public class CaseCourt : BaseEntity
	{
		[Key]
		public int ID { get; set; }
		 
		[Required]
		public int CaseID { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }
		 
		[Required]
		public int CourtID { get; set; }

		[ForeignKey("CourtID")]
		public virtual Court Court { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		// 🔹 Current court
		public bool IsCurrent { get; set; } = true;

		// 🔹 Notes (optional)
		public string? Notes { get; set; }
	}
}
