using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{ 
	[Index(nameof(RoleID))]
	[Index(nameof(StatusID))]
	[Index(nameof(UserTypeID))]
	public class User : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		[Required]
		[StringLength(300)]
		public string Username {  get; set; }

		[Required]
		[Column(TypeName="text")]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		[StringLength(300)]
		public string Email { get; set; }

		[Required]
		public int RoleID { get; set; }

		[Required]
		[StringLength(3)]
		public string UserTypeID { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string StatusID { get; set; }

		[ForeignKey("RoleID")]
		public virtual Role Role { get; set; }

		[ForeignKey("UserTypeID")]
		public virtual UserType UserType { get; set; }
		 
		[ForeignKey("StatusID")]
		public virtual Status Status { get; set; }

	}
}
