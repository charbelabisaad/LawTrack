using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(StatusID))]
	public class ChargeType : BaseEntity
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(300)]
		public string? Description { get; set; }

		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
	}
}
