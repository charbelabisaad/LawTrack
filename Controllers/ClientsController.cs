using LawTrack.Data;
using LawTrack.DTO;
using LawTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LawTrack.Controllers
{
	public class ClientsController : Controller
	{
		private readonly LawTrackDbContext _dbContext; 
		private ILogger<ClientsController> _logger;


		public ClientsController(LawTrackDbContext dbContext, ILogger<ClientsController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}


		public IActionResult Index()
		{ 
			return View("~/Views/Clients/Index.cshtml");
		}

		public List<ClientDto> GetClients() {

			return _dbContext.Clients
							.Where(c => c.DeletedDate == null)
							.Select(c => new ClientDto
							{
								ID = c.ID,
								Name = c.Name,
								Mobile = c.Mobile,
								Email = c.Email,
								ContactPerson = c.ContactPerson,
								Address = c.Address,
								Gender = c.Gender,
								Notes = c.Notes,
								TypeID = c.ClientType.ID,
								TypeName = c.ClientType.Description,
								StatusID = c.Status.ID, 
								StatusDescription = c.Status.Description,
								StatusColor = c.Status.Color 
							}).ToList();
							 
		}
		 
	}
}
