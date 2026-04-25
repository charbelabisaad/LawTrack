using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	[Index(nameof(RoleID))]
	[Index(nameof(PermissionID))]
	public class RolePermission
	{
		[Key]
		[Required]
		public int ID { get; set; }

		[Required]
		public int RoleID { get; set; }

		[ForeignKey("RoleID")]
		public Role Role { get; set; }

		[Required]
		public int PermissionID { get; set; }

		[ForeignKey("PermissionID")]
		public Permission Permission { get; set; }

		[Required]
		public string Values { get; set; }

	}
}
