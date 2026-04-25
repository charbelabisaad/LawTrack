using LawTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace LawTrack.Data
{
	public class LawTrackDbContext:DbContext
	{
		public LawTrackDbContext(DbContextOptions<LawTrackDbContext> options) : base(options) { }

		public DbSet<Status> Statuses { get; set; }
		public DbSet<UserType>	UserTypes { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<ClientType> ClientTypes { get; set; }
		public DbSet<Client> Clients {  get; set; }	
		public DbSet<CaseType> CaseTypes { get; set; } 
		public DbSet<CaseStatus> CaseStatuses { get; set; }	
		public DbSet<Priority> Priorities { get; set; }
		public DbSet<Court> Courts { get; set; }
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<CurrencyConversion> CurrencyConversions { get; set; }
		public DbSet<Case> Cases { get; set; }
		public DbSet<Judge> Judges { get; set; }
		public DbSet<CourtSession> CourtSessions { get; set; }
		public DbSet<DocumentType> DocumentTypes { get; set; }
		public DbSet<CaseDocument> CaseDocuments { get; set; }
		public DbSet<CaseTask> CaseTasks { get; set; }
		public DbSet<ChargeType> ChargeTypes { get; set; }
		public DbSet<CaseCharge> CaseCharges { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<CasePayment> CasePayments { get; set; }
		public DbSet<Journal> Journals { get; set; }
		public DbSet<ModelStatus> ModelStatuses { get; set; }
		public DbSet<CaseCourt> CaseCourts { get; set; }
		public DbSet<Module> Modules { get; set; }	
		public DbSet<PermissionAction> PermissionActions { get; set; }
		public DbSet<PermissionValue> PermissionValues { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }
		  
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// 🔹 Handle audit relations globally
			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
				{
					modelBuilder.Entity(entityType.ClrType)
						.HasOne(typeof(User), "CreatedUser")
						.WithMany()
						.HasForeignKey("CreatedUserID");

					modelBuilder.Entity(entityType.ClrType)
						.HasOne(typeof(User), "UpdatedUser")
						.WithMany()
						.HasForeignKey("UpdatedUserID");

					modelBuilder.Entity(entityType.ClrType)
						.HasOne(typeof(User), "DeletedUser")
						.WithMany()
						.HasForeignKey("DeletedUserID");
				}
			}

			foreach (var relationship in modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

		}

	}
}
