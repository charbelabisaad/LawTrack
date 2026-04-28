using LawTrack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LawTrack.DTO
{
	public class ClientDto
	{ 
		public int ID { get; set; }
		 
		public string Name { get; set; }
		 
		public string Mobile { get; set; }
		 
		public string? Email { get; set; }
		 
		public string? ContactPerson { get; set; }
		 
		public string? Address { get; set; }
		 
		public string Gender { get; set; }
		 
		public string? Notes { get; set; }
		 
		public int TypeID { get; set; }

		public string TypeName { get; set; }
		   
		public string StatusID { get; set; } 

		public string StatusDescription { get; set; }

		public string StatusColor { get; set; }

	}
}
