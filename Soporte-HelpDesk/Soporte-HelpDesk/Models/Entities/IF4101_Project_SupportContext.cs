using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Soporte_HelpDesk.Models.Entities
{
    public partial class IF4101_Project_SupportContext : DbContext
    {
        public IF4101_Project_SupportContext()
        {
        }

        public IF4101_Project_SupportContext(DbContextOptions<IF4101_Project_SupportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Servicee> Servicees { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<Supporter> Supporters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=IF4101_Project_Support;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.IdIssue)
                    .HasName("PK_ISSUE");

                entity.ToTable("Issue");

                entity.Property(e => e.IdIssue).HasColumnName("id_issue");

                entity.Property(e => e.ClassificationIssue)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("classification_issue");

                entity.Property(e => e.IdNote).HasColumnName("id_note");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.IssueTimesTamp)
                    .HasColumnType("date")
                    .HasColumnName("issue_times_tamp");

                entity.Property(e => e.ReferenceIssue)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("reference_issue");

                entity.Property(e => e.ResolutionCommentIssue)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("resolution_comment_issue");

                entity.Property(e => e.StatusIssue)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status_issue");

                entity.HasOne(d => d.IdNoteNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IdNote)
                    .HasConstraintName("FK_ISSUE_NOTE");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("FK_ISSUE_SERVICEE");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.IdNote)
                    .HasName("PK_NOTE");

                entity.ToTable("Note");

                entity.Property(e => e.IdNote).HasColumnName("id_note");

                entity.Property(e => e.DescriptionNote)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("description_note");

                entity.Property(e => e.NoteTimeTamp)
                    .HasColumnType("date")
                    .HasColumnName("note_time_tamp");
            });

            modelBuilder.Entity<Servicee>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .HasName("PK_SERVICEE");

                entity.ToTable("Servicee");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.NameService)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_service");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasKey(e => e.IdSupervisor)
                    .HasName("PK_SUPERVISOR");

                entity.ToTable("Supervisor");

                entity.Property(e => e.IdSupervisor).HasColumnName("id_supervisor");

                entity.Property(e => e.DescriptionSupervisor)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("description_supervisor");

                entity.Property(e => e.EmailSupervisor)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("email_supervisor");

                entity.Property(e => e.FirstSurnameSupervisor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_surname_supervisor");

                entity.Property(e => e.IdIssue).HasColumnName("id_issue");

                entity.Property(e => e.IdNote).HasColumnName("id_note");

                entity.Property(e => e.NameSupervisor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_supervisor");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.SecondSurnameSupervisor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("second_surname_supervisor");

                entity.HasOne(d => d.IdIssueNavigation)
                    .WithMany(p => p.Supervisors)
                    .HasForeignKey(d => d.IdIssue)
                    .HasConstraintName("FK_SUPERVISOR_ISSUE");

                entity.HasOne(d => d.IdNoteNavigation)
                    .WithMany(p => p.Supervisors)
                    .HasForeignKey(d => d.IdNote)
                    .HasConstraintName("FK_SUPERVISOR_NOTE");
            });

            modelBuilder.Entity<Supporter>(entity =>
            {
                entity.HasKey(e => e.IdSoporter)
                    .HasName("PK_SUPPORTER");

                entity.ToTable("Supporter");

                entity.Property(e => e.IdSoporter).HasColumnName("id_soporter");

                entity.Property(e => e.EmailSupporter)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email_supporter");

                entity.Property(e => e.FirstSurnameSupporter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_surname_supporter");

                entity.Property(e => e.IdIssue).HasColumnName("id_issue");

                entity.Property(e => e.IdNote).HasColumnName("id_note");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.IdSupervisor).HasColumnName("id_supervisor");

                entity.Property(e => e.NameSupporter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_supporter");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.SecondSurnameSupporter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("second_surname_supporter");

                entity.HasOne(d => d.IdIssueNavigation)
                    .WithMany(p => p.Supporters)
                    .HasForeignKey(d => d.IdIssue)
                    .HasConstraintName("FK_SUPPORTER_ISSUE");

                entity.HasOne(d => d.IdNoteNavigation)
                    .WithMany(p => p.Supporters)
                    .HasForeignKey(d => d.IdNote)
                    .HasConstraintName("FK_SUPPORTER_NOTE");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Supporters)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("FK_SUPPORTER_SERVICEE");

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.Supporters)
                    .HasForeignKey(d => d.IdSupervisor)
                    .HasConstraintName("FK_SUPPORTER_SUPERVISOR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
