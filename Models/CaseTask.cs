using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(AssignedUserID))]
	[Index(nameof(PriorityID))]
	[Index(nameof(StatusID))]
	public class CaseTask : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		// 🔹 Case
		[Required]
		public int CaseID { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }
		 
		[Required]
		[StringLength(50)]
		public string Title { get; set; }

		[Required]
		[Column(TypeName ="nvarchar(MAX)")]
		public string Description { get; set; }

		[Required]
		public int? AssignedUserID {  get; set; } // ID = 1,2,3 example

		[ForeignKey("AssignedUserID")]
		public virtual User AssignedUserTo { get; set; }

		[Required]
		public DateTime? AssignedDate { get; set; }

		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string PriorityID { get; set; }

		[ForeignKey("PriorityID")]
		public virtual Priority Priority { get; set; }

		[Column(TypeName = "nvarchar(max)")]
		public string? TaskRecap { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
		 
	}
}
