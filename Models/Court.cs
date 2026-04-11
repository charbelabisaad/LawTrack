using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	public class Court : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[StringLength (100)]
		public string City { get; set; }

		[StringLength(100)]
		public string Address { get; set; }

		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
		 
	}
}
