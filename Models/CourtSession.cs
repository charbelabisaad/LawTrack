using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(CourtID))]
	[Index(nameof(JudgeID))]	
	public class CourtSession : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		// 🔹 Case
		[Required]
		public int CaseID { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }

		// 🔹 Court
		[Required]
		public int CourtID { get; set; }

		[ForeignKey("CourtID")]
		public virtual Court Court { get; set; }

		// 🔹 Session Date
		[Required]
		public DateTime SessionDate { get; set; }

		// 🔹 Judge Name
	 
		public int? JudgeID { get; set; }

		[ForeignKey("JudgeID")]
		public virtual Judge Judge { get; set; }

		// 🔹 Result (important legal field)
		[Column(TypeName = "nvarchar(max)")]
		public string? Result { get; set; }

		// 🔹 Next Session Date
		public DateTime? NextSessionDate { get; set; }

		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }

	}
}
