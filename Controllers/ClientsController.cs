using LawTrack.Data;
using LawTrack.DTO;
using LawTrack.Models;
using LawTrack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

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
			var vm = new PageViewModel
			{
				clienttypes = GetClientTypes()
			};

			return View("~/Views/Clients/Index.cshtml", vm);
		}

		public IActionResult ListGetClients()
		{
			try
			{
			 
				return Json(new { clients = GetClients(), success = true });

			}
			catch (Exception ex) {

				_logger.LogError(ex, "Error Listing Clients");


				return Json(new { clients = new List<ClientDto>(), success = false, message = "Error Listing Clients" });
			
			}

			

		}

		public List<ClientType> GetClientTypes()
		{
			return _dbContext.ClientTypes.Where(ct => ct.StatusID == "A"
												   && ct.DeletedDate == null)
										 .OrderBy(ct => ct.Description)
										 .Select(ct => new ClientType
										 {
											 ID = ct.ID,
											 Description = ct.Description,
											 IsDefault = ct.IsDefault
										 }).ToList();
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
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SaveClient(Client model)
		{
			try
			{
				// =========================
				// VALIDATION
				// =========================
				if (string.IsNullOrWhiteSpace(model.Name))
					return Json(new { success = false, message = "Name is required" });

				if (string.IsNullOrWhiteSpace(model.Mobile))
					return Json(new { success = false, message = "Mobile is required" });

				if (string.IsNullOrWhiteSpace(model.Gender))
					return Json(new { success = false, message = "Gender is required" });

				if (model.TypeID <= 0)
					return Json(new { success = false, message = "Type is required" });

				if (string.IsNullOrWhiteSpace(model.StatusID))
					return Json(new { success = false, message = "Status is required" });

				// =========================
				// CREATE
				// =========================
				if (model.ID == 0)
				{
					_dbContext.Clients.Add(model);
				}
				// =========================
				// UPDATE
				// =========================
				else
				{
					var existing = _dbContext.Clients
						.FirstOrDefault(x => x.ID == model.ID && x.DeletedDate == null);

					if (existing == null)
						return Json(new { success = false, message = "Client not found" });

					existing.Name = model.Name;
					existing.Mobile = model.Mobile;
					existing.Email = model.Email;
					existing.ContactPerson = model.ContactPerson;
					existing.Address = model.Address;
					existing.Gender = model.Gender;
					existing.Notes = model.Notes; // optional
					existing.TypeID = model.TypeID;
					existing.StatusID = model.StatusID;
				}

				_dbContext.SaveChanges();

				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new
				{
					success = false,
					message = "Error saving client",
					details = ex.Message
				});
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteClient(int id)
		{
			try
			{
				var client = _dbContext.Clients
									   .FirstOrDefault(x => x.ID == id && x.DeletedDate == null);

				if (client == null)
					return Json(new { success = false, message = "Client not found" });

				// 🔥 Get current user ID
				int userId = 1; //int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

				// =========================
				// SOFT DELETE WITH AUDIT
				// =========================
				client.DeletedDate = DateTime.Now;
				client.DeletedUserID = userId;

				_dbContext.SaveChanges();

				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
		}

	}
}
