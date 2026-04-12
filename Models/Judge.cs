using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(StatusID))]
	public class Judge : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100)]
		public string LastName { get; set; }

		[StringLength(50)]
		public string? MobileNumber { get; set; }

		[StringLength(100)]
		public string? OfficeNumber { get; set; }

		[StringLength(300)]
		public string? Email {  get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
	}
}
