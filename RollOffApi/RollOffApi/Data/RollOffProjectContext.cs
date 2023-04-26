using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RollOffApi
{
    public partial class RollOffProjectContext : DbContext
    {
        public RollOffProjectContext()
        {
        }

        public RollOffProjectContext(DbContextOptions<RollOffProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FeedbackForm> FeedbackForms { get; set; }
        public virtual DbSet<RollOffTable> RollOffTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN22004682\\SQLEXPRESS;Database=RollOffProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<FeedbackForm>(entity =>
            {
                entity.ToTable("FeedbackForm");

                entity.Property(e => e.Communication).HasMaxLength(255);

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(255)
                    .HasColumnName("Leave Type");

                entity.Property(e => e.LocalGrade)
                    .HasMaxLength(255)
                    .HasColumnName("Local Grade");

                entity.Property(e => e.LongLeave)
                    .HasMaxLength(255)
                    .HasColumnName("Long Leave");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.OtherReasons)
                    .HasMaxLength(255)
                    .HasColumnName("Other Reasons");

                entity.Property(e => e.PerformanceIssue)
                    .HasMaxLength(255)
                    .HasColumnName("Performance Issue");

                entity.Property(e => e.Practice).HasMaxLength(255);

                entity.Property(e => e.PrimarySkill)
                    .HasMaxLength(255)
                    .HasColumnName("Primary Skill");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(255)
                    .HasColumnName("Project Code");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("Project Name");

                entity.Property(e => e.ReasonForRollOff)
                    .HasMaxLength(255)
                    .HasColumnName("Reason for Roll Off");

                entity.Property(e => e.RelevantExperienceYears)
                    .HasMaxLength(255)
                    .HasColumnName("Relevant Experience(Years)");

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.Resigned).HasMaxLength(255);

                entity.Property(e => e.RoleCompetencies)
                    .HasMaxLength(255)
                    .HasColumnName("Role/Competencies");

                entity.Property(e => e.RollOffEndDate)
                    .HasMaxLength(255)
                    .HasColumnName("Roll-Off End Date");

                entity.Property(e => e.TechnicalSkill)
                    .HasMaxLength(255)
                    .HasColumnName("Technical Skill");

                entity.Property(e => e.ThisReleaseNeedsBackfillIsBackfilled)
                    .HasMaxLength(255)
                    .HasColumnName("This release needs backfill/is backfilled");

                entity.Property(e => e.UnderProbation)
                    .HasMaxLength(255)
                    .HasColumnName("Under Probation");
            });

            modelBuilder.Entity<RollOffTable>(entity =>
            {
                entity.HasKey(e => e.GlobalGroupId)
                    .HasName("PK__RollOffT__A8B3AC1A34C6E1D4");

                entity.ToTable("RollOffTable");

                entity.Property(e => e.GlobalGroupId).HasColumnName("Global Group ID");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeNo).HasColumnName("Employee no");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Joining Date");

                entity.Property(e => e.LocalGrade)
                    .HasMaxLength(255)
                    .HasColumnName("Local Grade");

                entity.Property(e => e.MainClient)
                    .HasMaxLength(255)
                    .HasColumnName("Main Client");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NewGlobalPractice)
                    .HasMaxLength(255)
                    .HasColumnName("New Global Practice");

                entity.Property(e => e.OfficeCity)
                    .HasMaxLength(255)
                    .HasColumnName("Office City");

                entity.Property(e => e.PeopleManagerPerformanceReviewer)
                    .HasMaxLength(255)
                    .HasColumnName("People Manager (Performance Reviewer)");

                entity.Property(e => e.Practice).HasMaxLength(255);

                entity.Property(e => e.ProjectCode).HasColumnName("Project Code");

                entity.Property(e => e.ProjectEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Project End Date");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("Project Name");

                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Project Start Date");

                entity.Property(e => e.PspName)
                    .HasMaxLength(255)
                    .HasColumnName("PSP Name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .HasColumnName("token");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
