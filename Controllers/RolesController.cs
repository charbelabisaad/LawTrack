using LawTrack.Data;
using LawTrack.DTO;
using LawTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LawTrack.Controllers
{
	public class RolesController : Controller
	{
		public readonly LawTrackDbContext _dbContext;
		public ILogger<RolesController> _logger;

		public RolesController(LawTrackDbContext dbContext, ILogger<RolesController> logger)
		{
			_dbContext = dbContext;
			_logger = logger;
		}

	

		public IActionResult Index()
		{
			return View("~/Views/Roles/Index.cshtml");
		}

		public IActionResult ListGetRoles()
		{
			try
			{
				var roles = GetRoles();
				return Json(new { data = roles, success = true });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Fetching Roles![ERROR].");

				return Json(new
				{
					data = new List<object>(),
					success = false,
					message = "An unexpected error occurred while loading roles!"
				});
			}

		}

		public List<RoleDto> GetRoles()
		{

			List<RoleDto> roles = new List<RoleDto>();

			try
			{



				roles = _dbContext.Roles
					.Where(r => r.DeletedDate == null && r.IsAdmin == false)
					.OrderBy(r => r.Name)
					.Select(r => new RoleDto
					{
						ID = r.ID,
						Name = r.Name,
						IsAdmin = r.IsAdmin,
						StatusID = r.Status.ID,
						StatusDescription = r.Status.Description,
						StatusColor = r.Status.Color

					}).ToList();
			}
			catch (Exception ex)
			{
				roles = null;
				_logger.LogError(ex, "Fetch Roles [ERROR]!");
			}
			return roles;

		}

		[HttpPost]
		public IActionResult SaveRole(int ID, string Name, string StatusID)
		{

			int RoleID;

			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				if (ID != 0)
				{
					var existingRole = _dbContext.Roles.FirstOrDefault(r => r.ID == ID);

					var existingRoleDescription = _dbContext.Roles.FirstOrDefault(r => r.Name.Trim().ToLower() == Name.Trim().ToLower() && r.ID != ID && r.DeletedDate == null);

					if (existingRoleDescription != null)
					{

						return Json(new { exists = true, message = "Description already exists!" });

					}

					existingRole.Name = Name;
					existingRole.StatusID = StatusID;
					existingRole.UpdatedUserID = string.IsNullOrEmpty(userId) ? null : Convert.ToInt32(userId);
					existingRole.UpdatedDate = DateTime.UtcNow;

					_dbContext.SaveChanges();

					RoleID = ID;

				}
				else
				{
					var existingRoleDescription = _dbContext.Roles.FirstOrDefault(r => r.Name.Trim().ToLower() == Name.Trim().ToLower());

					if (existingRoleDescription != null)
					{

						return Json(new { exists = true, message = "Description already exists!" });

					}

				

					var newRole = new Role
					{
						Name = Name,
						StatusID = StatusID,
						CreatedUserID = string.IsNullOrEmpty(userId) ? null : Convert.ToInt32(userId),
						CreatedDate = DateTime.UtcNow

					};

					_dbContext.Roles.Add(newRole);

					_dbContext.SaveChanges();

					RoleID = newRole.ID;

				}

				return Json(new { exists = false, roles = GetRoles() });

			}
			catch (Exception ex)
			{
				// Log the error (optional)
				_logger.LogError($"[Save Role ERROR]!\n\n{ex.Message}");

				return Json(new
				{
					exists = false,
					error = true,
					message = $"An unexpected error occurred while saving the role {Name}!"
				});
			}
		}

		public IActionResult DeleteRole(int ID)
		{
			var existingRole = _dbContext.Roles.FirstOrDefault(r => r.ID == ID);

			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				if (existingRole != null)
				{

					existingRole.DeletedUserID = string.IsNullOrEmpty(userId) ? null : Convert.ToInt32(userId);
					existingRole.DeletedDate = DateTime.UtcNow;
					_dbContext.SaveChanges();

				}

				return Json(new { success = true });

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Delete Role [ERROR]!");
				return Json(new { success = false, message = $"An unexpected error occurred while deleting role {existingRole.Name}!" });
			}
		}

	}
}
