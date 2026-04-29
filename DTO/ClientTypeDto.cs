using LawTrack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LawTrack.DTO
{
	public class ClientTypeDto
	{ 
		public int ID { get; set; }
		 
		public string Description { get; set; }

		public bool IsDefault { get; set; }

		public string StatusID { get; set; }
		 
		public string StatusDescription { get; set; }

		public string StatusColor { get; set; }
			 
	}
}
