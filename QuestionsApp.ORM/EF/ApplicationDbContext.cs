using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.ORM.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("QuestionsAppDB") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<LectionEvent> LectionEvents { get; set; }
        public virtual DbSet<LectionHeader> LectionHeaders { get; set; }
        public virtual DbSet<LectionStatus> LectionStatus { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<UserContact> UserContacts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"DbUpdateException error details - {e.InnerException?.InnerException?.Message}");
                foreach (var eve in e.Entries)
                    sb.AppendLine($"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated");
                Debug.Write(sb.ToString());
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                        Debug.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
            }

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LectionHeader>().HasMany(e => e.LectionEvents).WithRequired(e => e.LectionHeader)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<LectionStatus>().HasMany(e => e.LectionEvents).WithRequired(e => e.LectionStatus)
                .HasForeignKey(e => e.LectionStatusId).WillCascadeOnDelete(true);

            modelBuilder.Entity<ReportType>().HasMany(e => e.Reports).WithRequired(e => e.ReportType)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserProfile>().HasMany(e => e.LectionHeaders).WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<UserProfile>().HasMany(e => e.Reports).WithRequired(e => e.UserProfile)
                .HasForeignKey(e => e.AuthorProfileId).WillCascadeOnDelete(true);

            modelBuilder.Entity<UserProfile>().HasMany(e => e.UserContacts).WithRequired(e => e.UserProfile)
                .WillCascadeOnDelete(true);
        }

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}