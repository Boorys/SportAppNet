using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportAppNet.Entity
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DisciplineEntity> DisciplineEntity { get; set; }
        public virtual DbSet<MainTypSportEntity> MainTypSportEntity { get; set; }
        public virtual DbSet<OpinionEntity> OpinionEntity { get; set; }
        public virtual DbSet<UserEntity> UserEntity { get; set; }
        public virtual DbSet<UserMainTypSport> UserMainTypSport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=sport_app_net;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplineEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccurateName).IsUnicode(false);

                entity.Property(e => e.DisciplineName).IsUnicode(false);

                entity.HasOne(d => d.MainTypSport)
                    .WithMany(p => p.DisciplineEntity)
                    .HasForeignKey(d => d.MainTypSportId)
                    .HasConstraintName("DisciplineEntity_MainTypSportEntity_FK");
            });

            modelBuilder.Entity<MainTypSportEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MainNameOfSport).IsUnicode(false);
            });

            modelBuilder.Entity<OpinionEntity>(entity =>
            {
                entity.Property(e => e.GeneralComment).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OpinionEntity)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OpinionEntity_User_FK");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);
            });

            modelBuilder.Entity<UserMainTypSport>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserMainTypSport_MainTypSportEntity_FK");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserMainTypSport_User_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
