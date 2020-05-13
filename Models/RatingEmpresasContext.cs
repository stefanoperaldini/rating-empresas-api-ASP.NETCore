using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rating_empresas_api_.NET.Models
{
    public partial class RatingEmpresasContext : DbContext
    {
        public RatingEmpresasContext()
        {
        }

        public RatingEmpresasContext(DbContextOptions<RatingEmpresasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CompaniesCities> CompaniesCities { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Sectors> Sectors { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersActivation> UsersActivation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TP1OEM8;Database=RatingEmpresas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("cities_fk_province_id_provinces_id_idx");

                entity.HasIndex(e => e.RegionId)
                    .HasName("cities_fk_region_id_regions_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId)
                    .IsRequired()
                    .HasColumnName("province_id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionId)
                    .IsRequired()
                    .HasColumnName("region_id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cities_province_id_province_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cities_region_id_region_id");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("companies");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.sector_id)
                    .HasName("fk_companies_sector_id_sector_id_idx");

                entity.HasIndex(e => e.sede_id)
                    .HasName("fk_companies_sede_id_city_id_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_companies_user_id_user_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Linkedin)
                    .HasColumnName("linkedin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.sector_id)
                    .IsRequired()
                    .HasColumnName("sector_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.sede_id)
                    .IsRequired()
                    .HasColumnName("sede_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.UrlLogo)
                    .HasColumnName("url_logo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UrlWeb)
                    .HasColumnName("url_web")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.sector_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies_sector_id_sector_id");

                entity.HasOne(d => d.Sede)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.sede_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies_sede_id_city_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies_user_id_user_id");
            });

            modelBuilder.Entity<CompaniesCities>(entity =>
            {
                entity.HasKey(e => new { e.CityId, e.CompanyId })
                    .HasName("PK__companie__40F6F68B8EF85865");

                entity.ToTable("companies_cities");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("companies_cities_fk_company_id_idx");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CompaniesCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies_cities_city_id_city_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompaniesCities)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies_cities_company_id_company_id");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.ToTable("positions");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.ToTable("provinces");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.ToTable("regions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews");

                entity.HasIndex(e => e.City_Id)
                    .HasName("fk_reviews_city_id_city_id_idx");

                entity.HasIndex(e => e.Company_Id)
                    .HasName("fk_reviews_company_id_company_id_idx");

                entity.HasIndex(e => e.Position_Id)
                    .HasName("fk_positions_position_id_position_id_idx");

                entity.HasIndex(e => e.User_Id)
                    .HasName("fk_reviews_1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City_Id)
                    .IsRequired()
                    .HasColumnName("city_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Comment_Title)
                    .IsRequired()
                    .HasColumnName("comment_title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Company_Id)
                    .IsRequired()
                    .HasColumnName("company_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Created_At)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Deleted_At)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.End_Year).HasColumnName("end_year");

                entity.Property(e => e.Growth_Opportunities)
                    .IsRequired()
                    .HasColumnName("growth_opportunities")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Inhouse_Training)
                    .IsRequired()
                    .HasColumnName("inhouse_training")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Personal_Life)
                    .IsRequired()
                    .HasColumnName("personal_life")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Position_Id)
                    .IsRequired()
                    .HasColumnName("position_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Salary_Valuation)
                    .IsRequired()
                    .HasColumnName("salary_valuation")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Start_Year).HasColumnName("start_year");

                entity.Property(e => e.User_Id)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Work_Enviroment)
                    .IsRequired()
                    .HasColumnName("work_enviroment")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Position_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reviews_position_id_position_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reviews_user_id_user_id");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => new { d.City_Id, d.Company_Id })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reviews_city_id_city_id_company_id_company_id");
            });

            modelBuilder.Entity<Sectors>(entity =>
            {
                entity.ToTable("sectors");

                entity.HasIndex(e => e.Sector)
                    .HasName("sector_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sector)
                    .IsRequired()
                    .HasColumnName("sector")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ActivatedAt)
                    .HasColumnName("activated_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Linkedin)
                    .HasColumnName("linkedin")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt)
                    .HasColumnName("modified_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UsersActivation>(entity =>
            {
                entity.ToTable("users_activation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.VerificationCode)
                    .IsRequired()
                    .HasColumnName("verification_code")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VerifiedAt)
                    .HasColumnName("verified_at")
                    .HasColumnType("datetime2(0)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UsersActivation)
                    .HasForeignKey<UsersActivation>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_activation_id_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
