using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	[Index(nameof(ActionID))]
	[Index(nameof(ModuleID))]
	[Index(nameof(StatusID))]
	public class Permission
	{ 
		[Key]
		public int ID { get; set; }

		[Required]
		[StringLength(30)]
		public string Code { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }
		
		[Required]
		[Column(TypeName = "text")]
		public string Description { get; set; }

		[Required]
		public int ActionID { get; set; }

		[ForeignKey("ActionID")]
		public virtual PermissionAction Action { get; set; }

		[Required]
		public int ModuleID { get; set; }

		[ForeignKey("ModuleID")]
		public virtual Module Module { get; set; }	

		[Required]
		[StringLength(1)]
		public string Type {  get; set; }

		[Required]
		[StringLength(20)]
		public string Values { get; set; }

		[Required]
		[StringLength(1 , MinimumLength = 1)]
		public string StatusID { get; set; }

		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }

	}
}
