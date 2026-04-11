using System.ComponentModel.DataAnnotations.Schema;

namespace LawTrack.Models
{
	public class BaseEntity
	{
		public int? CreatedUserID { get; set; }

		[ForeignKey("CreatedUserID")]
		public virtual User CreatedUser { get; set; }

		public DateTime? CreatedDate { get; set; }

		public int? UpdatedUserID { get; set; }

		[ForeignKey("UpdatedUserID")]
		public virtual User UpdatedUser { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public int? DeletedUserID { get; set; }

		[ForeignKey("DeletedUserID")]
		public virtual User DeletedUser { get; set; }

		public DateTime? DeletedDate { get; set; }
	}
}
