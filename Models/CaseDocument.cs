using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Models
{
	[Index(nameof(CaseID))]
	[Index(nameof(DocumentTypeID))]
	public class CaseDocument : BaseEntity
	{
		[Key]
		public int ID { get; set; }

		// 🔹 Case
		[Required]
		public int CaseID { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[ForeignKey("CaseID")]
		public virtual Case Case { get; set; }

		// 🔹 File Name (original name)
		[Required]
		[StringLength(300)]
		public string FileName { get; set; }

		// 🔹 File Path (stored location)
		[Required]
		[StringLength(500)]
		public string FilePath { get; set; }

		// 🔹 Document Type
		public int? DocumentTypeID { get; set; }

		[ForeignKey("DocumentTypeID")]
		public virtual DocumentType DocumentType { get; set; }

		// 🔹 Upload Date
		public DateTime UploadedDate { get; set; }
	}
}
