using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(ClientID))]
	[Index(nameof(TypeID))]
	[Index(nameof(StatusID))]
	[Index(nameof(AssignedUserID))]
	[Index(nameof(CourtID))]
	public class Case
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(50)]
		public string CaseNumber { get; set; }

		[Required]
		[StringLength(300)]
		public string Title { get; set; }

		[Column(TypeName = "nvarchar(max)")]
		public string? Description { get; set; }

		// 🔹 Client
		[Required]
		public int ClientID { get; set; }

		[ForeignKey("ClientID")]
		public virtual Client Client { get; set; }

		// 🔹 Case Type
		[Required]
		public int TypeID { get; set; }

		[ForeignKey("TypeID")]
		public virtual CaseType CaseType { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string CaseStatusID { get; set; }

		[ForeignKey("CaseStatusID")]
		public virtual CaseStatus CaseStatus { get; set; }

		// 🔹 Assigned Lawyer/User
		public int? AssignedUserID { get; set; }

		[ForeignKey("AssignedUserID")]
		public virtual User AssignedUser { get; set; }

		// 🔹 Dates
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		// 🔹 Priority
		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string PriorityID { get; set; }

		[ForeignKey("PriorityID")]
		public virtual Priority Priority { get; set; }

		// 🔹 Court
		public int? CourtID { get; set; }

		[ForeignKey("CourtID")]
		public virtual Court Court { get; set; }

		// 🔹 Notes
		[Column(TypeName = "nvarchar(max)")]
		public string? Notes { get; set; }

		// 🔹 Status
		[Required]
		[StringLength(1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
		 
	}
}
