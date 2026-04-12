using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(StatusID))]
	public class DocumentType : BaseEntity
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		// 🔹 Optional: Description
		[StringLength(300)]
		public string? Description { get; set; }

		// 🔹 Status (Active/Inactive)
		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
	}
}
