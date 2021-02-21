using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace exam.Models
{
    public partial class s19687Context : DbContext
    {
        public s19687Context()
        {
        }

        public s19687Context(DbContextOptions<s19687Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskType> TaskTypes { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        //public virtual DbSet<Organiser> Organisers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=s19687;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(e => e.IdArtist)
                    .HasName("TaskType_pk");

                entity.ToTable("TaskType");

                entity.Property(e => e.IdTaskType).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Task)
                    .HasName("Task_pk");

                entity.ToTable("Task");

                entity.Property(e => e.IdTeam).ValueGeneratedNever();

                entity.Property(e => e.PerformanceDate).HasColumnType("Deadline");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.IdTaskType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Event_Task");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.IdTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Team_Event_EVENT");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdTeam)
                    .HasName("Team_pk");

                entity.ToTable("Team");

                entity.Property(e => e.IdTeam).ValueGeneratedNever();

                entity.Property(e => e.deadline).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.IdTeamMember)
                    .HasName("Team_Member_pk");

                entity.ToTable("TeamMember");

                entity.Property(e => e.IdTeamMember).ValueGeneratedNever();

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_4_Event");

                
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
