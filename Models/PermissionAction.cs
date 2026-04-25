using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	[Index(nameof(StatusID))]
	public class PermissionAction
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ID { get; set; }

		[Required]
		[StringLength(2)]
		public string Code { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		public bool IsForFeature { get; set; } = false;

		[Required]
		[StringLength(1 ,MinimumLength = 1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }

	}
}
