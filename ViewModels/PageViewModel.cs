using LawTrack.Models;

namespace LawTrack.ViewModels
{
	public class PageViewModel
	{
		public List<UserType> usertypes { get; set; }
		public List<Role> roles { get; set; }
		public List<User> users { get; set; }
		public List<ClientType> clientTypes { get; set; }

	}
}
