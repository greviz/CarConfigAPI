using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarConfigAPI.CarConfigAPI.Models
{
    public partial class carconfigapiContext : DbContext
    {
        public carconfigapiContext()
        {
        }

        public carconfigapiContext(DbContextOptions<carconfigapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableCarParts> AvailableCarParts { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<ConfigurationParts> ConfigurationParts { get; set; }
        public virtual DbSet<Configurations> Configurations { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=carconfigapi;user=root;pwd=root", x => x.ServerVersion("10.4.18-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableCarParts>(entity =>
            {
                entity.ToTable("available_car_parts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.CarId)
                    .HasColumnName("car_id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.PartId)
                    .HasColumnName("part_id")
                    .HasColumnType("int(128)");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.BodyType)
                    .IsRequired()
                    .HasColumnName("body_type")
                    .HasColumnType("enum('CONVERTIBLE','COUPE','HATCHBACK','KOMBI','LIMOUSINE','ROADSTER','SEDAN')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnName("brand")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.DrivetrainType)
                    .IsRequired()
                    .HasColumnName("drivetrain_type")
                    .HasColumnType("enum('FWD','RWD','AWD','')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.ImageFolder)
                    .IsRequired()
                    .HasColumnName("image_folder")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("int(128)");

                entity.Property(e => e.Unused).HasColumnName("unused");
            });

            modelBuilder.Entity<ConfigurationParts>(entity =>
            {
                entity.ToTable("configuration_parts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.ConfigurationId)
                    .HasColumnName("configuration_id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.PartId)
                    .HasColumnName("part_id")
                    .HasColumnType("int(128)");
            });

            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.ToTable("configurations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.CarId)
                    .HasColumnName("car_id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("int(128)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(265)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Private).HasColumnName("private");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("int(32)");
            });

            modelBuilder.Entity<Parts>(entity =>
            {
                entity.ToTable("parts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("int(64)");

                entity.Property(e => e.PrimaryType)
                    .IsRequired()
                    .HasColumnName("primary_type")
                    .HasColumnType("enum('EXTERIOR','INTERIOR','MECHANICAL','OPTIONAL')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.SecondaryType)
                    .IsRequired()
                    .HasColumnName("secondary_type")
                    .HasColumnType("enum('GEARBOX','SUSPENSION','ENGINE','COLOR','RIM','BRAKE','CAR_SEAT','INTERIOR_MATERIAL','ASSISTING_SYSTEM','INTERIOR_EQUIPMENT','AUDIO')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(128)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_polish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
