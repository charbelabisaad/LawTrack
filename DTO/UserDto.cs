using LawTrack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LawTrack.DTO
{
	public class UserDto
	{ 
		public int ID { get; set; }
		 
		public string Username { get; set; }
		 
		public string Password { get; set; }
		 
		public string FirstName { get; set; }
		 
		public string LastName { get; set; }
		 
		public string Email { get; set; }
		 
		public int RoleID { get; set; }

		public string RoleName { get; set; }
 
		public string UserTypeID { get; set; }

		public string UserTypeDescription { get; set; }
		 
		public string StatusID { get; set; }

		public string StatusDescription { get; set; }

		public string StatusColor { get; set; }
		  
	}
}
