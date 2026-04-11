using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{ 
	[Index(nameof(TypeID))]
	[Index(nameof(StatusID))]
	public class Client : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(300)]
		public string Name { get; set; }

		[Required]
		[StringLength (50)]
		public string Mobile {  get; set; }
		 
		[StringLength (300)]
		public string? Email { get; set; }

		[StringLength(300)]
		public string? ContactPerson { get; set; }

		[StringLength(1000)]
		public string? Address {  get; set; }

		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string Gender { get; set; }

		[Required]
		[Column(TypeName ="nvarchar(max)")]
		public string? Notes { get; set; }

		[Required]
		public int TypeID { get; set; }

		[ForeignKey("TypeID")]
		public virtual ClientType ClientType { get; set; }
		 
		[Required]
		[StringLength(1, MinimumLength = 1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }
		  
	}
}
