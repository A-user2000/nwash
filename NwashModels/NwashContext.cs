using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.API;
using Wq_Surveillance.Models.MapData;

namespace Wq_Surveillance.NwashModels;

public partial class NwashContext : DbContext
{
    public NwashContext()
    {
    }

    public NwashContext(DbContextOptions<NwashContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Tap> Taps { get; set; }
    public virtual DbSet<WaterSource> WaterSources { get; set; }

    public virtual DbSet<DashboardNotice> DashboardNotices { get; set; }
    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Municipality> Municipalities { get; set; }

    public virtual DbSet<MunicipalityWardFormation> MunicipalityWardFormations { get; set; }

    public virtual DbSet<MunicipalityWiseHhPop> MunicipalityWiseHhPops { get; set; }

    public virtual DbSet<NepalPopulation2074> NepalPopulation2074s { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }


    public virtual DbSet<TapSanitary> TapSanitaries { get; set; }

    public virtual DbSet<TblDictionary> TblDictionaries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDocumentation> UserDocumentations { get; set; }

    public virtual DbSet<UsersAccessDistrict> UsersAccessDistricts { get; set; }

    public virtual DbSet<UsersAccessProCode> UsersAccessProCodes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=nwash;Username=postgres;Password=postgresql123;", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");



        modelBuilder.Entity<DashboardNotice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nt_pkey_id");

            entity.ToTable("dashboard_notices", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasColumnType("character varying")
                .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");
            entity.Property(e => e.Notices)
                .HasColumnType("character varying")
                .HasColumnName("notices");
            entity.Property(e => e.Status).HasColumnName("status");
        });



        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("district_pkey");

            entity.ToTable("district", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.DistrictCode)
                .HasColumnType("character varying")
                .HasColumnName("district_code");
            entity.Property(e => e.DistrictName)
                .HasColumnType("character varying")
                .HasColumnName("district_name");
            entity.Property(e => e.DistrictNameNep)
                .HasColumnType("character varying")
                .HasColumnName("district_name_nep");
            entity.Property(e => e.DistrictUuid)
                .HasMaxLength(100)
                .HasColumnName("district_uuid");
            entity.Property(e => e.ProvinceCode)
                .HasColumnType("character varying")
                .HasColumnName("province_code");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
        });


        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_id_pkey");

            entity.ToTable("documents", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasColumnType("character varying")
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasColumnType("character varying")
                .HasColumnName("added_date");
            entity.Property(e => e.DocTitle)
                .HasColumnType("character varying")
                .HasColumnName("doc_title");
            entity.Property(e => e.Filename)
                .HasColumnType("character varying")
                .HasColumnName("filename");
        });



        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("system_faq_id_pkey");

            entity.ToTable("faqs", "system");

            entity.Property(e => e.FaqId).HasColumnName("faq_id");
            entity.Property(e => e.Answers)
                .HasColumnType("character varying")
                .HasColumnName("answers");
            entity.Property(e => e.Groups)
                .HasColumnType("character varying")
                .HasColumnName("groups");
            entity.Property(e => e.Links)
                .HasColumnType("character varying")
                .HasColumnName("links");
            entity.Property(e => e.Questions)
                .HasColumnType("character varying")
                .HasColumnName("questions");
        });

        modelBuilder.Entity<Municipality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("municipality_pkey");

            entity.ToTable("municipality", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.DistrictCode)
                .HasColumnType("character varying")
                .HasColumnName("district_code");
            entity.Property(e => e.MunCode)
                .HasColumnType("character varying")
                .HasColumnName("mun_code");
            entity.Property(e => e.MunName)
                .HasColumnType("character varying")
                .HasColumnName("mun_name");
            entity.Property(e => e.MunNameNep)
                .HasColumnType("character varying")
                .HasColumnName("mun_name_nep");
            entity.Property(e => e.MunType)
                .HasColumnType("character varying")
                .HasColumnName("mun_type");
            entity.Property(e => e.MunUuid)
                .HasMaxLength(100)
                .HasColumnName("mun_uuid");
            entity.Property(e => e.ProvinceCode)
                .HasColumnType("character varying")
                .HasColumnName("province_code");
            entity.Property(e => e.TheGeom)
                .HasColumnType("geometry(Polygon,4326)")
                .HasColumnName("the_geom");
        });



        modelBuilder.Entity<MunicipalityWardFormation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mwc_pkey_id");

            entity.ToTable("municipality_ward_formation", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MunCode)
                .HasColumnType("character varying")
                .HasColumnName("mun_code");
            entity.Property(e => e.NewWardE)
                .HasColumnType("character varying")
                .HasColumnName("new_ward_e");
            entity.Property(e => e.NewWardN)
                .HasColumnType("character varying")
                .HasColumnName("new_ward_n");
            entity.Property(e => e.OldVdcE)
                .HasColumnType("character varying")
                .HasColumnName("old_vdc_e");
            entity.Property(e => e.OldVdcN)
                .HasColumnType("character varying")
                .HasColumnName("old_vdc_n");
            entity.Property(e => e.OldWardE)
                .HasColumnType("character varying")
                .HasColumnName("old_ward_e");
            entity.Property(e => e.OldWardN)
                .HasColumnType("character varying")
                .HasColumnName("old_ward_n");
        });

        modelBuilder.Entity<MunicipalityWiseHhPop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mun_pop_pkey");

            entity.ToTable("municipality_wise_hh_pop", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CensusYear)
                .HasDefaultValueSql("2011")
                .HasColumnName("census_year");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(32)
                .HasColumnName("district_code");
            entity.Property(e => e.Female).HasColumnName("female");
            entity.Property(e => e.Hh).HasColumnName("hh");
            entity.Property(e => e.Male).HasColumnName("male");
            entity.Property(e => e.MunCode)
                .HasMaxLength(32)
                .HasColumnName("mun_code");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(32)
                .HasColumnName("province_code");
            entity.Property(e => e.TotalPop).HasColumnName("total_pop");
            entity.Property(e => e.WardNo)
                .HasMaxLength(8)
                .HasColumnName("ward_no");
        });

        modelBuilder.Entity<NepalPopulation2074>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("total_pop_pkey");

            entity.ToTable("nepal_population_2074", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dcode)
                .HasMaxLength(8)
                .HasColumnName("dcode");
            entity.Property(e => e.MunCode)
                .HasMaxLength(8)
                .HasColumnName("mun_code");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(8)
                .HasColumnName("province_code");
        });


        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_pkey");

            entity.ToTable("organization", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.OrgName)
                .HasColumnType("character varying")
                .HasColumnName("org_name");
            entity.Property(e => e.OrgUuid)
                .HasMaxLength(100)
                .HasColumnName("org_uuid");
            entity.Property(e => e.PrgShortName)
                .HasColumnType("character varying")
                .HasColumnName("prg_short_name");
        });


        modelBuilder.Entity<ProjectDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_details_pkey");

            entity.ToTable("project_details", "existing_projects");

            entity.HasIndex(e => e.TheGeom, "project_details_geom_idx").HasMethod("gist");

            entity.HasIndex(e => e.ProCode, "unk_pro_code").IsUnique();

            entity.HasIndex(e => e.Uuid, "unk_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.ClimateResilience)
                .HasColumnType("character varying")
                .HasColumnName("climate_resilience");
            entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
            entity.Property(e => e.CollectedOn).HasColumnName("collected_on");
            entity.Property(e => e.ConsAgency)
                .HasColumnType("character varying")
                .HasColumnName("cons_agency");
            entity.Property(e => e.ConsAgencyId).HasColumnName("cons_agency_id");
            entity.Property(e => e.ConsAgencyOther)
                .HasColumnType("character varying")
                .HasColumnName("cons_agency_other");
            entity.Property(e => e.ConsYear).HasColumnName("cons_year");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.DistrictCode)
                .HasColumnType("character varying")
                .HasColumnName("district_code");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.InvAgency)
                .HasColumnType("character varying")
                .HasColumnName("inv_agency");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.MunicipalityCode)
                .HasColumnType("character varying")
                .HasColumnName("municipality_code");
            entity.Property(e => e.Photo1Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo1_desc");
            entity.Property(e => e.Photo1Path)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path");
            entity.Property(e => e.Photo1PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path_uuid");
            entity.Property(e => e.Photo2Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo2_desc");
            entity.Property(e => e.Photo2Path)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path");
            entity.Property(e => e.Photo2PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path_uuid");
            entity.Property(e => e.Photo3Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo3_desc");
            entity.Property(e => e.Photo3Path)
                .HasColumnType("character varying")
                .HasColumnName("photo3_path");
            entity.Property(e => e.Photo3PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo3_path_uuid");
            entity.Property(e => e.Photo4Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo4_desc");
            entity.Property(e => e.Photo4Path)
                .HasColumnType("character varying")
                .HasColumnName("photo4_path");
            entity.Property(e => e.Photo4PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo4_path_uuid");
            entity.Property(e => e.Photo5Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo5_desc");
            entity.Property(e => e.Photo5Path)
                .HasColumnType("character varying")
                .HasColumnName("photo5_path");
            entity.Property(e => e.Photo5PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo5_path_uuid");
            entity.Property(e => e.Photo6Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo6_desc");
            entity.Property(e => e.Photo6Path)
                .HasColumnType("character varying")
                .HasColumnName("photo6_path");
            entity.Property(e => e.Photo6PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo6_path_uuid");
            entity.Property(e => e.ProCode)
                .HasColumnType("character varying")
                .HasColumnName("pro_code");
            entity.Property(e => e.ProCodeNmip)
                .HasColumnType("character varying")
                .HasColumnName("pro_code_nmip");
            entity.Property(e => e.ProCodeOther)
                .HasColumnType("character varying")
                .HasColumnName("pro_code_other");
            entity.Property(e => e.ProCodeOtherProvider)
                .HasColumnType("character varying")
                .HasColumnName("pro_code_other_provider");
            entity.Property(e => e.ProFun).HasColumnName("pro_fun");
            entity.Property(e => e.ProName)
                .HasColumnType("character varying")
                .HasColumnName("pro_name");
            entity.Property(e => e.ProNameNep)
                .HasColumnType("character varying")
                .HasColumnName("pro_name_nep");
            entity.Property(e => e.ProSus).HasColumnName("pro_sus");
            entity.Property(e => e.ProType)
                .HasColumnType("character varying")
                .HasColumnName("pro_type");
            entity.Property(e => e.ProjectStatus)
                .HasColumnType("character varying")
                .HasColumnName("project_status");
            entity.Property(e => e.ProvinceCode)
                .HasColumnType("character varying")
                .HasColumnName("province_code");
            entity.Property(e => e.RehabAgency)
                .HasColumnType("character varying")
                .HasColumnName("rehab_agency");
            entity.Property(e => e.RehabAgencyOther)
                .HasColumnType("character varying")
                .HasColumnName("rehab_agency_other");
            entity.Property(e => e.RehabYear).HasColumnName("rehab_year");
            entity.Property(e => e.SettlementName)
                .HasColumnType("character varying")
                .HasColumnName("settlement_name");
            entity.Property(e => e.SoCode)
                .HasColumnType("character varying")
                .HasColumnName("so_code");
            entity.Property(e => e.SupAgency)
                .HasColumnType("character varying")
                .HasColumnName("sup_agency");
            entity.Property(e => e.SupAgencyOther)
                .HasColumnType("character varying")
                .HasColumnName("sup_agency_other");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
            entity.Property(e => e.WardNo)
                .HasColumnType("character varying")
                .HasColumnName("ward_no");
            entity.Property(e => e.WaterSafetyApproach)
                .HasColumnType("character varying")
                .HasColumnName("water_safety_approach");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("province_pkey");

            entity.ToTable("province", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.ProvinceCode)
                .HasColumnType("character varying")
                .HasColumnName("province_code");
            entity.Property(e => e.ProvinceName)
                .HasColumnType("character varying")
                .HasColumnName("province_name");
            entity.Property(e => e.ProvinceNameNep)
                .HasColumnType("character varying")
                .HasColumnName("province_name_nep");
            entity.Property(e => e.ProvinceUuid)
                .HasMaxLength(100)
                .HasColumnName("province_uuid");
            entity.Property(e => e.TheGeom)
                .HasColumnType("geometry(Polygon,4326)")
                .HasColumnName("the_geom");
        });

        modelBuilder.Entity<Tap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tap_pkey");

            entity.ToTable("tap", "existing_projects");

            entity.HasIndex(e => e.TheGeom, "tap_geom_idx").HasMethod("gist");

            entity.HasIndex(e => e.Uuid, "tap_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.BcHh).HasColumnName("bc_hh");
            entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
            entity.Property(e => e.CollectedOn).HasColumnName("collected_on");
            entity.Property(e => e.DalHh).HasColumnName("dal_hh");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.FemalePop).HasColumnName("female_pop");
            entity.Property(e => e.HhServerd).HasColumnName("hh_serverd");
            entity.Property(e => e.HhToilet).HasColumnName("hh_toilet");
            entity.Property(e => e.JanHh).HasColumnName("jan_hh");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.MalePop).HasColumnName("male_pop");
            entity.Property(e => e.MiHh).HasColumnName("mi_hh");
            entity.Property(e => e.NoLeakage).HasColumnName("no_leakage");
            entity.Property(e => e.Photo1Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo1_desc");
            entity.Property(e => e.Photo1Path)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path");
            entity.Property(e => e.Photo1PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path_uuid");
            entity.Property(e => e.Photo2Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo2_desc");
            entity.Property(e => e.Photo2Path)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path");
            entity.Property(e => e.Photo2PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path_uuid");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TankAvailable).HasColumnName("tank_available");
            entity.Property(e => e.TapComplaint).HasColumnName("tap_complaint");
            entity.Property(e => e.TapCond)
                .HasMaxLength(100)
                .HasColumnName("tap_cond");
            entity.Property(e => e.TapCons)
                .HasMaxLength(25)
                .HasColumnName("tap_cons");
            entity.Property(e => e.TapContact)
                .HasColumnType("character varying")
                .HasColumnName("tap_contact");
            entity.Property(e => e.TapEqk)
                .HasMaxLength(100)
                .HasColumnName("tap_eqk");
            entity.Property(e => e.TapFhours).HasColumnName("tap_fhours");
            entity.Property(e => e.TapFlowCon)
                .HasColumnType("character varying")
                .HasColumnName("tap_flow_con");
            entity.Property(e => e.TapMeter)
                .HasColumnType("character varying")
                .HasColumnName("tap_meter");
            entity.Property(e => e.TapNo)
                .HasMaxLength(50)
                .HasColumnName("tap_no");
            entity.Property(e => e.TapNrp)
                .HasMaxLength(25)
                .HasColumnName("tap_nrp");
            entity.Property(e => e.TapOwner)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("tap_owner");
            entity.Property(e => e.TapRem)
                .HasMaxLength(255)
                .HasColumnName("tap_rem");
            entity.Property(e => e.TapTur)
                .HasMaxLength(25)
                .HasColumnName("tap_tur");
            entity.Property(e => e.TapType)
                .HasMaxLength(100)
                .HasColumnName("tap_type");
            entity.Property(e => e.TapWaterQuality)
                .HasColumnType("character varying")
                .HasColumnName("tap_water_quality");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.Taps)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });

        modelBuilder.Entity<TblDictionary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dict_pk");

            entity.ToTable("tbl_dictionary", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FieldName)
                .HasMaxLength(100)
                .HasColumnName("field_name");
            entity.Property(e => e.FieldText)
                .HasMaxLength(200)
                .HasColumnName("field_text");
            entity.Property(e => e.ReturnIfNull)
                .HasMaxLength(50)
                .HasColumnName("return_if_null");
        });

        modelBuilder.Entity<TrainingHeld>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("training_held_pkey");

            entity.ToTable("training_held", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StartedBy)
                .HasColumnType("character varying")
                .HasColumnName("started_by");
            entity.Property(e => e.TrainingHappening).HasColumnName("training_happening");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pk");

            entity.ToTable("users", "system");

            entity.HasIndex(e => e.Name, "name_inx");

            entity.HasIndex(e => e.Email, "unq_email").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("nextval('system.users_user_id_seq1'::regclass)")
                .HasColumnName("user_id");
            entity.Property(e => e.AssignedArea)
                .HasColumnType("character varying")
                .HasColumnName("assigned_area");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("character varying")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("'2073-12-14'::date")
                .HasColumnName("created_date");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.Groups).HasColumnName("groups");
            entity.Property(e => e.InvAgency)
                .HasMaxLength(255)
                .HasColumnName("inv_agency");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.Municipality).HasColumnName("municipality");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
            entity.Property(e => e.Province)
                .HasColumnType("character varying")
                .HasColumnName("province");
            entity.Property(e => e.Salt)
                .HasMaxLength(500)
                .HasColumnName("salt");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TrainingUser)
                .HasDefaultValueSql("0")
                .HasColumnName("training_user");
            entity.Property(e => e.UserCategory)
                .HasDefaultValueSql("1")
                .HasColumnName("user_category");
            entity.Property(e => e.UserType)
                .HasMaxLength(500)
                .HasColumnName("user_type");
        });

        modelBuilder.Entity<UserDocumentation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ud_pkey");

            entity.ToTable("user_documentation", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentPath)
                .HasColumnType("character varying")
                .HasColumnName("document_path");
            entity.Property(e => e.DocumentTitle)
                .HasColumnType("character varying")
                .HasColumnName("document_title");
            entity.Property(e => e.MunCode)
                .HasColumnType("character varying")
                .HasColumnName("mun_code");
            entity.Property(e => e.UploadedBy)
                .HasColumnType("character varying")
                .HasColumnName("uploaded_by");
            entity.Property(e => e.UploadedDate).HasColumnName("uploaded_date");
        });

        modelBuilder.Entity<UsersAccessDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_access_district_pk");

            entity.ToTable("users_access_district", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UsersAccessProCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_access_pro_code_pk");

            entity.ToTable("users_access_pro_code", "system");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProCode)
                .HasColumnType("character varying")
                .HasColumnName("pro_code");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });
        modelBuilder.Entity<WaterSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("water_source_pkey");

            entity.ToTable("water_source", "existing_projects");

            entity.HasIndex(e => e.TheGeom, "source_geom_idx").HasMethod("gist");

            entity.HasIndex(e => e.Uuid, "source_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
            entity.Property(e => e.CollectedOn).HasColumnName("collected_on");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.FlowReg)
                .HasColumnType("character varying")
                .HasColumnName("flow_reg");
            entity.Property(e => e.IntType)
                .HasColumnType("character varying")
                .HasColumnName("int_type");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.MeaDate)
                .HasColumnType("character varying")
                .HasColumnName("mea_date");
            entity.Property(e => e.MeaDis).HasColumnName("mea_dis");
            entity.Property(e => e.MinYield).HasColumnName("min_yield");
            entity.Property(e => e.NeaCmu)
                .HasColumnType("character varying")
                .HasColumnName("nea_cmu");
            entity.Property(e => e.Photo1Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo1_desc");
            entity.Property(e => e.Photo1Path)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path");
            entity.Property(e => e.Photo1PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path_uuid");
            entity.Property(e => e.Photo2Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo2_desc");
            entity.Property(e => e.Photo2Path)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path");
            entity.Property(e => e.Photo2PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path_uuid");
            entity.Property(e => e.Photo3Desc)
                .HasColumnType("character varying")
                .HasColumnName("photo3_desc");
            entity.Property(e => e.Photo3Path)
                .HasColumnType("character varying")
                .HasColumnName("photo3_path");
            entity.Property(e => e.Photo3PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo3_path_uuid");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.RegYear).HasColumnName("reg_year");
            entity.Property(e => e.RtipTime).HasColumnName("rtip_time");
            entity.Property(e => e.SouCon)
                .HasColumnType("character varying")
                .HasColumnName("sou_con");
            entity.Property(e => e.SouDist).HasColumnName("sou_dist");
            entity.Property(e => e.SouEqk)
                .HasColumnType("character varying")
                .HasColumnName("sou_eqk");
            entity.Property(e => e.SouLoc)
                .HasColumnType("character varying")
                .HasColumnName("sou_loc");
            entity.Property(e => e.SouName)
                .HasColumnType("character varying")
                .HasColumnName("sou_name");
            entity.Property(e => e.SouPro)
                .HasColumnType("character varying")
                .HasColumnName("sou_pro");
            entity.Property(e => e.SouReg)
                .HasColumnType("character varying")
                .HasColumnName("sou_reg");
            entity.Property(e => e.SouRem)
                .HasColumnType("character varying")
                .HasColumnName("sou_rem");
            entity.Property(e => e.SouType)
                .HasColumnType("character varying")
                .HasColumnName("sou_type");
            entity.Property(e => e.SouUse)
                .HasColumnType("character varying")
                .HasColumnName("sou_use");
            entity.Property(e => e.StaEqk)
                .HasColumnType("character varying")
                .HasColumnName("sta_eqk");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.TreReq)
                .HasColumnType("character varying")
                .HasColumnName("tre_req");
            entity.Property(e => e.TrtConsYear).HasColumnName("trt_cons_year");
            entity.Property(e => e.TubewellDepth).HasColumnName("tubewell_depth");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
            entity.Property(e => e.WatQua)
                .HasColumnType("character varying")
                .HasColumnName("wat_qua");

            entity.HasOne(d => d.ProUu).WithMany(p => p.WaterSources)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });


        modelBuilder.HasSequence<int>("apk_details_id_seq", "apks");
        modelBuilder.HasSequence("drainage_lut_id_seq", "drainage");
        modelBuilder.HasSequence("hcf_lut1_id_seq", "health_care");
        modelBuilder.HasSequence("ins_lut1_id_seq", "institution");
        modelBuilder.HasSequence("junction_id_seq", "existing_projects");
        modelBuilder.HasSequence("pipe_id_seq", "existing_projects");
        modelBuilder.HasSequence("pt_lut1_id_seq", "public_toilet");
        modelBuilder.HasSequence("reservoir_id_seq", "existing_projects");
        modelBuilder.HasSequence("solid_waste_lut_id_seq", "solid_waste");
        modelBuilder.HasSequence<int>("solidwaste_lut_id_seq", "solidwaste_management");
        modelBuilder.HasSequence<int>("solidwaste_lut_id_seq_old", "solidwaste_management");
        modelBuilder.HasSequence("structure_id_seq", "existing_projects");
        modelBuilder.HasSequence("tap_id_seq", "existing_projects");
        modelBuilder.HasSequence("urban_sanitation_lut1_id_seq", "urban_sanitation");
        modelBuilder.HasSequence("users_user_id_seq", "system");
        modelBuilder.HasSequence("water_source_id_seq", "existing_projects");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
