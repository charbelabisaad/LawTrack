using LawTrack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LawTrack.DTO
{
	public class RoleDto
	{ 
		public int ID { get; set; }
		 
		public string Name { get; set; }
		 
		public bool IsAdmin { get; set; } = false;
		 
		public string StatusID { get; set; }

		public string StatusDescription { get; set; }

		public string StatusColor { get; set; }
		 
	}
}
