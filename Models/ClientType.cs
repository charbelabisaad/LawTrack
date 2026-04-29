using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	[Index(nameof(StatusID))]
	public class ClientType : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(50)]
		public string Description { get; set; }

		[Required]
		public bool IsDefault { get; set; } = false;

		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string StatusID { get; set; }
		 
		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
		 
	}
}
