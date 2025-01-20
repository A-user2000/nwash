using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.QueryTables;
using Wq_Surveillance.Models.API;
using Wq_Surveillance.Models.MapData;

namespace Wq_Surveillance.Models;

public partial class WqsContext : DbContext
{
    public WqsContext()
    {
    }

    public WqsContext(DbContextOptions<WqsContext> options)
        : base(options)
    {
    }
    public virtual DbSet<WSIncomeDetails> WSIncomeDetails { get; set; }
    public virtual DbSet<SustainabilityDetails> SustainabilityDetails { get; set; }
    public virtual DbSet<ProjectBasicDetails> ProjectBasicDetails { get; set; }
    public virtual DbSet<LocalLevelDetails> LocalLevelDetails { get; set; }
    public virtual DbSet<FuncWSDetails> FuncWSDetails { get; set; }
    public virtual DbSet<FunctionalityScoreDetails> FunctionalityScoreDetails { get; set; }
    public virtual DbSet<FunctionalityMunWiseDetails> FunctionalityMunWiseDetails { get; set; }

    public virtual DbSet<FunctionalityDistrictWiseDetail> FunctionalityDistrictWiseDetail { get; set; }

    public virtual DbSet<FuncTapDetails> FuncTapDetails { get; set; }
    public virtual DbSet<FuncStrDetails> FuncStrDetails { get; set; }
    public virtual DbSet<FuncProjectDetails> FuncProjectDetails { get; set; }
    public virtual DbSet<ProjectDetailData> ProjectDetailData { get; set; }
    
    public virtual DbSet<SyncFileCredential> SyncFileCredential { get; set; }
    public virtual DbSet<WaterSource> WaterSource { get; set; }
 

    public virtual DbSet<ApkDetail> ApkDetails { get; set; }

  

    public virtual DbSet<ArsenicHi> ArsenicHis { get; set; }

    

    public virtual DbSet<ColumnDictionary> ColumnDictionaries { get; set; }

    

    public virtual DbSet<DashboardNotice> DashboardNotices { get; set; }

   

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<DistrictBoundary> DistrictBoundaries { get; set; }

    public virtual DbSet<Document> Documents { get; set; }


    public virtual DbSet<Faq> Faqs { get; set; }

   

    public virtual DbSet<Form1a> Form1as { get; set; }

    public virtual DbSet<Form1b> Form1bs { get; set; }

    public virtual DbSet<Form2> Form2s { get; set; }

    public virtual DbSet<Form2datum> Form2data { get; set; }

    public virtual DbSet<Form3> Form3s { get; set; }

    public virtual DbSet<Functionality> Functionalities { get; set; }

   

    public virtual DbSet<Junction> Junctions { get; set; }


    public virtual DbSet<LabRegistration> LabRegistration { get; set; }


    public virtual DbSet<LayerDetail> LayerDetails { get; set; }

    public virtual DbSet<LeftoutTap> LeftoutTaps { get; set; }


    public virtual DbSet<LocalbodiesLine> LocalbodiesLines { get; set; }

    public virtual DbSet<LocalbodiesNepal> LocalbodiesNepals { get; set; }

    public virtual DbSet<Lrn1> Lrn1s { get; set; }

  

    public virtual DbSet<LutWq> LutWq_Surveillance { get; set; }

    public virtual DbSet<Municipality> Municipalities { get; set; }

      public virtual DbSet<MunicipalityWardFormation> MunicipalityWardFormations { get; set; }

    public virtual DbSet<MunicipalityWiseHhPop> MunicipalityWiseHhPops { get; set; }

    public virtual DbSet<NepalPopulation2074> NepalPopulation2074s { get; set; }

   

    public virtual DbSet<Organization> Organizations { get; set; }

    

    public virtual DbSet<Pipe> Pipes { get; set; }

    public virtual DbSet<PipeDrawnRoute> PipeDrawnRoutes { get; set; }

    

    public virtual DbSet<PipeRoutePoint> PipeRoutePoints { get; set; }

   

    public virtual DbSet<PopServed> PopServeds { get; set; }

  

    public virtual DbSet<ProjectCoverage> ProjectCoverages { get; set; }

   

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

   

    public virtual DbSet<Province> Provinces { get; set; }

    

    public virtual DbSet<ProvinceNepal> ProvinceNepals { get; set; }

   

    public virtual DbSet<Rate> Rates { get; set; }

    

    public virtual DbSet<ReportDatum> ReportData { get; set; }

    public virtual DbSet<Reservoir> Reservoirs { get; set; }


    public virtual DbSet<ReservoirSanitary> ReservoirSanitaries { get; set; }

   

    public virtual DbSet<SanitaryInspection> SanitaryInspections { get; set; }

    public virtual DbSet<SanitaryInspectionTemplate> SanitaryInspectionTemplates { get; set; }

    public virtual DbSet<SanitaryInspectionValue> SanitaryInspectionValues { get; set; }

    public virtual DbSet<Sanitation> Sanitations { get; set; }


    public virtual DbSet<Settlement> Settlements { get; set; }
    public virtual DbSet<SourceSanitary> SourceSanitaries { get; set; }

    public virtual DbSet<Srn> Srns { get; set; }

  

    public virtual DbSet<Structure> Structures { get; set; }


    public virtual DbSet<StructureSanitary> StructureSanitaries { get; set; }

    public virtual DbSet<Support> Supports { get; set; }

   

    public virtual DbSet<Sustainability> Sustainabilities { get; set; }

   

    public virtual DbSet<TableDictionary> TableDictionaries { get; set; }

    public virtual DbSet<Tap> Taps { get; set; }


    public virtual DbSet<TapSanitary> TapSanitaries { get; set; }

    public virtual DbSet<TblDictionary> TblDictionaries { get; set; }

   

    public virtual DbSet<TrainingHeld> TrainingHelds { get; set; }

    public virtual DbSet<Tubewell> Tubewells { get; set; }

   

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDocumentation> UserDocumentations { get; set; }

    public virtual DbSet<UsersAccessDistrict> UsersAccessDistricts { get; set; }

    public virtual DbSet<UsersAccessProCode> UsersAccessProCodes { get; set; }

    

    public virtual DbSet<WardBoundary45n> WardBoundary45ns { get; set; }

    public virtual DbSet<WardboundaryLine> WardboundaryLines { get; set; }

   

    public virtual DbSet<WaterQualitySample> WaterQualitySamples { get; set; }

    public virtual DbSet<WaterQualityTemplate> WaterQualityTemplates { get; set; }

    public virtual DbSet<WaterQualityValue> WaterQualityValues { get; set; }

    public virtual DbSet<WaterSource> WaterSources { get; set; }

  

    public virtual DbSet<WaterSourceMeasure> WaterSourceMeasures { get; set; }

   
    public virtual DbSet<WatersafeCommunity> WatersafeCommunities { get; set; }

    public virtual DbSet<WqGeneralLocation> WqGeneralLocations { get; set; }

    public virtual DbSet<WqGeneralValue> WqGeneralValues { get; set; }

    public virtual DbSet<WqIdentity> WqIdentities { get; set; }

    public virtual DbSet<WqSampleDetail> WqSampleDetails { get; set; }

    public virtual DbSet<WqSurvellianceMain> WqSurvellianceMains { get; set; }

    public virtual DbSet<WqTempMethodUsed> WqTempMethodUseds { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=wq_surveillance;Username=postgres;Password=123;", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");

       

        modelBuilder.Entity<ApkDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("apk_details_pkey");

            entity.ToTable("apk_details", "apks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApkIndex)
                .HasDefaultValueSql("0")
                .HasColumnName("apk_index");
            entity.Property(e => e.ApkPath)
                .HasColumnType("character varying")
                .HasColumnName("apk_path");
            entity.Property(e => e.AppDesc)
                .HasColumnType("character varying")
                .HasColumnName("app_desc");
            entity.Property(e => e.AppName)
                .HasColumnType("character varying")
                .HasColumnName("app_name");
            entity.Property(e => e.AppVersion)
                .HasColumnType("character varying")
                .HasColumnName("app_version");
            entity.Property(e => e.DownloadCount)
                .HasDefaultValueSql("0")
                .HasColumnName("download_count");
            entity.Property(e => e.LogoPath)
                .HasColumnType("character varying")
                .HasColumnName("logo_path");
            entity.Property(e => e.OtherDocs)
                .HasColumnType("character varying")
                .HasColumnName("other_docs");
            entity.Property(e => e.Requirements)
                .HasColumnType("character varying")
                .HasColumnName("requirements");
            entity.Property(e => e.Size)
                .HasColumnType("character varying")
                .HasColumnName("size");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.VersionCode)
                .HasDefaultValueSql("1")
                .HasColumnName("version_code");
        });

       

        modelBuilder.Entity<ArsenicHi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("arsenic_his_pkey");

            entity.ToTable("arsenic_his", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Agency).HasColumnName("agency");
            entity.Property(e => e.ArcConc).HasColumnName("arc_conc");
            entity.Property(e => e.Community).HasColumnName("community");
            entity.Property(e => e.ConBy).HasColumnName("con_by");
            entity.Property(e => e.ConYearAd).HasColumnName("con_year_ad");
            entity.Property(e => e.ConYearBs).HasColumnName("con_year_bs");
            entity.Property(e => e.Dcode).HasColumnName("dcode");
            entity.Property(e => e.DepthM).HasColumnName("depth_m");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Mcode).HasColumnName("mcode");
            entity.Property(e => e.NoHh).HasColumnName("no_hh");
            entity.Property(e => e.NoPop).HasColumnName("no_pop");
            entity.Property(e => e.OldWard).HasColumnName("old_ward");
            entity.Property(e => e.OtherTest).HasColumnName("other_test");
            entity.Property(e => e.OwnerName).HasColumnName("owner_name");
            entity.Property(e => e.Ownership).HasColumnName("ownership");
            entity.Property(e => e.Pcode).HasColumnName("pcode");
            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.Ptype).HasColumnName("ptype");
            entity.Property(e => e.PtypeDes).HasColumnName("ptype_des");
            entity.Property(e => e.SamDateAd).HasColumnName("sam_date_ad");
            entity.Property(e => e.SamDateBs).HasColumnName("sam_date_bs");
            entity.Property(e => e.TestType).HasColumnName("test_type");
            entity.Property(e => e.TheGeom)
                .HasColumnType("geometry(Point,4326)")
                .HasColumnName("the_geom");
            entity.Property(e => e.UserType).HasColumnName("user_type");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
            entity.Property(e => e.VdcCode).HasColumnName("vdc_code");
            entity.Property(e => e.VdcName).HasColumnName("vdc_name");
            entity.Property(e => e.WardNo).HasColumnName("ward_no");
            entity.Property(e => e.WellAge).HasColumnName("well_age");
        });


        modelBuilder.Entity<ColumnDictionary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("column_dictionary_id_pk");

            entity.ToTable("column_dictionary", "swmap");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColType)
                .HasMaxLength(10)
                .HasColumnName("col_type");
            entity.Property(e => e.Editable).HasColumnName("editable");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.PostgresCol)
                .HasColumnType("character varying")
                .HasColumnName("postgres_col");
            entity.Property(e => e.QbCols)
                .HasMaxLength(10)
                .HasColumnName("qb_cols");
            entity.Property(e => e.Show).HasColumnName("show");
            entity.Property(e => e.SqliteAttr)
                .HasMaxLength(200)
                .HasColumnName("sqlite_attr");
            entity.Property(e => e.TableId).HasColumnName("table_id");
        });

      

       

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

        modelBuilder.Entity<DistrictBoundary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("district_boundary_pkey");

            entity.ToTable("district_boundary", "basemap");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dcode).HasColumnName("dcode");
            entity.Property(e => e.DisNepali).HasColumnName("dis_nepali");
            entity.Property(e => e.Distname)
                .HasMaxLength(25)
                .HasColumnName("distname");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasColumnName("district");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.NewDcode).HasColumnName("new_dcode");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.Region)
                .HasMaxLength(13)
                .HasColumnName("region");
            entity.Property(e => e.Zone)
                .HasMaxLength(50)
                .HasColumnName("zone");
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

     

        modelBuilder.Entity<Form1a>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form1A_pkey");

            entity.ToTable("form_1a", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
            entity.Property(e => e.WspInitiativeDiedByDiarrhea)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_died_by_diarrhea");
            entity.Property(e => e.WspInitiativeInfectedByDiarrhea)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_infected_by_diarrhea");
            entity.Property(e => e.WspInitiativeNoticeSource)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_notice_source");
            entity.Property(e => e.WspInitiativeRemarks1)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_1");
            entity.Property(e => e.WspInitiativeRemarks2)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_2");
            entity.Property(e => e.WspInitiativeRemarks3)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_3");
            entity.Property(e => e.WspInitiativeRemarks4)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_4");
            entity.Property(e => e.WspInitiativeRemarks5)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_5");
            entity.Property(e => e.WspInitiativeRemarks6)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_6");
            entity.Property(e => e.WspInitiativeRemarks7)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_remarks_7");
            entity.Property(e => e.WspInitiativeSecurityPlan)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_security_plan");
            entity.Property(e => e.WspInitiativeStatus1)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_1");
            entity.Property(e => e.WspInitiativeStatus2)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_2");
            entity.Property(e => e.WspInitiativeStatus3)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_3");
            entity.Property(e => e.WspInitiativeStatus4)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_4");
            entity.Property(e => e.WspInitiativeStatus5)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_5");
            entity.Property(e => e.WspInitiativeStatus6)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_6");
            entity.Property(e => e.WspInitiativeStatus7)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_status_7");
            entity.Property(e => e.WspInitiativeSuggestion)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_suggestion");
            entity.Property(e => e.WspInitiativeWaterDisease)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_water_disease");
            entity.Property(e => e.WspInitiativeWaterQualityStatus)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_water_quality_status");
            entity.Property(e => e.WspInitiativeWrittenResult)
                .HasColumnType("character varying")
                .HasColumnName("wsp_initiative_written_result");
        });

        modelBuilder.Entity<Form1b>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form1B_pkey");

            entity.ToTable("form_1b", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CertificationPhoto)
                .HasColumnType("character varying")
                .HasColumnName("certification_photo");
            entity.Property(e => e.CertificationScore)
                .HasColumnType("character varying")
                .HasColumnName("certification_score");
            entity.Property(e => e.CollaborativeActivitiesPhoto)
                .HasColumnType("character varying")
                .HasColumnName("collaborative_activitiesPhoto");
            entity.Property(e => e.CollaborativeActivitiesScore)
                .HasColumnType("character varying")
                .HasColumnName("collaborative_activitiesScore");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.ImprovementPlanPhoto)
                .HasColumnType("character varying")
                .HasColumnName("improvement_plan_photo");
            entity.Property(e => e.ImprovementPlanScore)
                .HasColumnType("character varying")
                .HasColumnName("improvement_plan_score");
            entity.Property(e => e.MonitoringPhoto)
                .HasColumnType("character varying")
                .HasColumnName("monitoring_photo");
            entity.Property(e => e.MonitoringScore)
                .HasColumnType("character varying")
                .HasColumnName("monitoring_score");
            entity.Property(e => e.PollutionRiskControlMeasureScore)
                .HasColumnType("character varying")
                .HasColumnName("pollution_risk_control_measure_score");
            entity.Property(e => e.PollutionRiskControlPhoto)
                .HasColumnType("character varying")
                .HasColumnName("pollution_risk_control_photo");
            entity.Property(e => e.ReviewPhoto)
                .HasColumnType("character varying")
                .HasColumnName("review_photo");
            entity.Property(e => e.ReviewScore)
                .HasColumnType("character varying")
                .HasColumnName("review_score");
            entity.Property(e => e.SystemAnalysisPhoto)
                .HasColumnType("character varying")
                .HasColumnName("system_analysis_photo");
            entity.Property(e => e.SystemAnalysisScore)
                .HasColumnType("character varying")
                .HasColumnName("system_analysis_score");
            entity.Property(e => e.TeamFormationPhoto)
                .HasColumnType("character varying")
                .HasColumnName("team_formation_photo");
            entity.Property(e => e.TeamFormationScore)
                .HasColumnType("character varying")
                .HasColumnName("team_formation_score");
            entity.Property(e => e.TotalScore).HasColumnName("total_score");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
        });

        modelBuilder.Entity<Form2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form_data_2_pkey");

            entity.ToTable("form_2", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('Wq_Surveillance.form_data_2_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.DefDiedByDiarrhea)
                .HasMaxLength(255)
                .HasColumnName("def_died_by_diarrhea");
            entity.Property(e => e.DefInfectedByDiarrhea)
                .HasMaxLength(255)
                .HasColumnName("def_infected_by_diarrhea");
            entity.Property(e => e.DefNoticeSource)
                .HasMaxLength(255)
                .HasColumnName("def_notice_source");
            entity.Property(e => e.DefSuggestion)
                .HasMaxLength(255)
                .HasColumnName("def_suggestion");
            entity.Property(e => e.DefWaterDisease)
                .HasMaxLength(255)
                .HasColumnName("def_water_disease");
            entity.Property(e => e.DefWrittenResult)
                .HasMaxLength(255)
                .HasColumnName("def_written_result");
            entity.Property(e => e.FormId)
                .HasMaxLength(255)
                .HasColumnName("form_id");
            entity.Property(e => e.PipelineBasicEvaluation)
                .HasMaxLength(255)
                .HasColumnName("pipeline_basic_evaluation");
            entity.Property(e => e.PipelineBasicEvaluationRemarks)
                .HasMaxLength(255)
                .HasColumnName("pipeline_basic_evaluation_remarks");
            entity.Property(e => e.PollutionPossibility)
                .HasMaxLength(255)
                .HasColumnName("pollution_possibility");
            entity.Property(e => e.PollutionPossibilityTypes)
                .HasMaxLength(255)
                .HasColumnName("pollution_possibility_types");
            entity.Property(e => e.SourceBasicEvaluation)
                .HasMaxLength(255)
                .HasColumnName("source_basic_evaluation");
            entity.Property(e => e.SourceBasicEvaluationRemarks)
                .HasMaxLength(255)
                .HasColumnName("source_basic_evaluation_remarks");
            entity.Property(e => e.StorageUsageBasicEvaluation)
                .HasMaxLength(255)
                .HasColumnName("storage_usage_basic_evaluation");
            entity.Property(e => e.StorageUsageBasicEvaluationRemarks)
                .HasMaxLength(255)
                .HasColumnName("storage_usage_basic_evaluation_remarks");
            entity.Property(e => e.TreatmentCenterBasicEvaluation)
                .HasMaxLength(255)
                .HasColumnName("treatment_center_basic_evaluation");
            entity.Property(e => e.TreatmentCenterBasicEvaluationRemarks)
                .HasMaxLength(255)
                .HasColumnName("treatment_center_basic_evaluation_remarks");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
            entity.Property(e => e.WaterReservoirBasicEvaluation)
                .HasMaxLength(255)
                .HasColumnName("water_reservoir_basic_evaluation");
            entity.Property(e => e.WaterReservoirBasicEvaluationRemarks)
                .HasMaxLength(255)
                .HasColumnName("water_reservoir_basic_evaluation_remarks");
        });

        modelBuilder.Entity<Form2datum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form2data_pkey");

            entity.ToTable("form2data");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Defdiedbydiarrhea)
                .HasMaxLength(255)
                .HasColumnName("defdiedbydiarrhea");
            entity.Property(e => e.Definfectedbydiarrhea)
                .HasMaxLength(255)
                .HasColumnName("definfectedbydiarrhea");
            entity.Property(e => e.Defnoticesource)
                .HasMaxLength(255)
                .HasColumnName("defnoticesource");
            entity.Property(e => e.Defsuggestion)
                .HasMaxLength(255)
                .HasColumnName("defsuggestion");
            entity.Property(e => e.Defwaterdisease)
                .HasMaxLength(255)
                .HasColumnName("defwaterdisease");
            entity.Property(e => e.Defwrittenresult)
                .HasMaxLength(255)
                .HasColumnName("defwrittenresult");
            entity.Property(e => e.Formid)
                .HasMaxLength(255)
                .HasColumnName("formid");
            entity.Property(e => e.Pipelinebasicevaluation)
                .HasMaxLength(255)
                .HasColumnName("pipelinebasicevaluation");
            entity.Property(e => e.Pipelinebasicevaluationremarks)
                .HasMaxLength(255)
                .HasColumnName("pipelinebasicevaluationremarks");
            entity.Property(e => e.Pollutionpossibility)
                .HasMaxLength(255)
                .HasColumnName("pollutionpossibility");
            entity.Property(e => e.Pollutionpossibilitytypes)
                .HasMaxLength(255)
                .HasColumnName("pollutionpossibilitytypes");
            entity.Property(e => e.Sourcebasicevaluation)
                .HasMaxLength(255)
                .HasColumnName("sourcebasicevaluation");
            entity.Property(e => e.Sourcebasicevaluationremarks)
                .HasMaxLength(255)
                .HasColumnName("sourcebasicevaluationremarks");
            entity.Property(e => e.Storageusagebasicevaluation)
                .HasMaxLength(255)
                .HasColumnName("storageusagebasicevaluation");
            entity.Property(e => e.Storageusagebasicevaluationremarks)
                .HasMaxLength(255)
                .HasColumnName("storageusagebasicevaluationremarks");
            entity.Property(e => e.Treatmentcenterbasicevaluation)
                .HasMaxLength(255)
                .HasColumnName("treatmentcenterbasicevaluation");
            entity.Property(e => e.Treatmentcenterbasicevaluationremarks)
                .HasMaxLength(255)
                .HasColumnName("treatmentcenterbasicevaluationremarks");
            entity.Property(e => e.Waterreservoirbasicevaluation)
                .HasMaxLength(255)
                .HasColumnName("waterreservoirbasicevaluation");
            entity.Property(e => e.Waterreservoirbasicevaluationremarks)
                .HasMaxLength(255)
                .HasColumnName("waterreservoirbasicevaluationremarks");
        });

        modelBuilder.Entity<Form3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("form_3_pkey");

            entity.ToTable("form_3", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CholeraCount)
                .HasColumnType("character varying")
                .HasColumnName("cholera_count");
            entity.Property(e => e.DiarrheaCount)
                .HasColumnType("character varying")
                .HasColumnName("diarrhea_count");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.HepatitisCount)
                .HasColumnType("character varying")
                .HasColumnName("hepatitis_count");
            entity.Property(e => e.Month)
                .HasColumnType("character varying")
                .HasColumnName("month");
            entity.Property(e => e.TyphoidCount)
                .HasColumnType("character varying")
                .HasColumnName("typhoid_count"); 
            entity.Property(e => e.DysenteryCount)
                .HasColumnType("character varying")
                .HasColumnName("dysentery_count");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
        });

        modelBuilder.Entity<Functionality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("functionality_pkey");

            entity.ToTable("functionality", "existing_projects");

            entity.HasIndex(e => e.Uuid, "functionality_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.AnExp).HasColumnName("an_exp");
            entity.Property(e => e.AnIncome).HasColumnName("an_income");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.NoComplaints).HasColumnName("no_complaints");
            entity.Property(e => e.NoLeakYear).HasColumnName("no_leak_year");
            entity.Property(e => e.NoMeetDemand).HasColumnName("no_meet_demand");
            entity.Property(e => e.NoMonthsFlowAdequate).HasColumnName("no_months_flow_adequate");
            entity.Property(e => e.NoStr).HasColumnName("no_str");
            entity.Property(e => e.NoStrRepair).HasColumnName("no_str_repair");
            entity.Property(e => e.NoVmw).HasColumnName("no_vmw");
            entity.Property(e => e.NoVmwToolMeet).HasColumnName("no_vmw_tool_meet");
            entity.Property(e => e.PipeLen).HasColumnName("pipe_len");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.SupHours).HasColumnName("sup_hours");
            entity.Property(e => e.TapNoTurbidity).HasColumnName("tap_no_turbidity");
            entity.Property(e => e.TotalTap).HasColumnName("total_tap");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
            entity.Property(e => e.YardTap)
                .HasMaxLength(10)
                .HasColumnName("yard_tap");
        });

        modelBuilder.Entity<Junction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("junction_pkey");

            entity.ToTable("junction", "existing_projects");

            entity.HasIndex(e => e.Uuid, "junc_uuid").IsUnique();

            entity.HasIndex(e => e.TheGeom, "junction_geom_idx").HasMethod("gist");

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
            entity.Property(e => e.JuncNo)
                .HasMaxLength(20)
                .HasColumnName("junc_no");
            entity.Property(e => e.JuncType)
                .HasMaxLength(20)
                .HasColumnName("junc_type");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Photo1Desc).HasColumnName("photo1_desc");
            entity.Property(e => e.Photo1Path).HasColumnName("photo1_path");
            entity.Property(e => e.Photo1PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_path_uuid");
            entity.Property(e => e.Photo2Desc).HasColumnName("photo2_desc");
            entity.Property(e => e.Photo2Path).HasColumnName("photo2_path");
            entity.Property(e => e.Photo2PathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_path_uuid");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.Junctions)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("pro_uuid");
        });

     
        modelBuilder.Entity<LabRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lr_pkey");

            entity.ToTable("lab_registration", "wq_lab");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasColumnType("character varying")
                .HasColumnName("added_by");
            entity.Property(e => e.AddedOn)
                .HasColumnType("character varying")
                .HasColumnName("added_on");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.District)
                .HasColumnType("character varying")
                .HasColumnName("district");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FocalPerson)
                .HasColumnType("character varying")
                .HasColumnName("focal_person");
            entity.Property(e => e.FocalPersonNumber)
                .HasColumnType("character varying")
                .HasColumnName("focal_person_number");
            entity.Property(e => e.LabName)
                .HasColumnType("character varying")
                .HasColumnName("lab_name");
            entity.Property(e => e.LabRegNo)
                .HasColumnType("character varying")
                .HasColumnName("lab_reg_no");
            entity.Property(e => e.LabSubType)
                .HasDefaultValueSql("0")
                .HasColumnName("lab_sub_type");
            entity.Property(e => e.LabType).HasColumnName("lab_type");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.LogoPath)
                .HasColumnType("character varying")
                .HasColumnName("logo_path");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.ModuleFocalPerson)
                .HasColumnType("character varying")
                .HasColumnName("module_focal_person");
            entity.Property(e => e.ModuleFocalPersonNumber)
                .HasColumnType("character varying")
                .HasColumnName("module_focal_person_number");
            entity.Property(e => e.Municipality)
                .HasColumnType("character varying")
                .HasColumnName("municipality");
            entity.Property(e => e.Province)
                .HasColumnType("character varying")
                .HasColumnName("province");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SubName)
                .HasColumnType("character varying")
                .HasColumnName("sub_name");
            entity.Property(e => e.Telephone)
                .HasColumnType("character varying")
                .HasColumnName("telephone");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasColumnType("character varying")
                .HasColumnName("uuid");
        });


        modelBuilder.Entity<LayerDetail>(entity =>
        {
            entity.HasKey(e => e.LayerId).HasName("layer_info_pkey");

            entity.ToTable("layer_detail", "swmap");

            entity.Property(e => e.LayerId)
                .ValueGeneratedNever()
                .HasColumnName("layer_id");
            entity.Property(e => e.AttributesCol)
                .HasColumnType("character varying")
                .HasColumnName("attributes_col");
            entity.Property(e => e.AttributesDisplayName)
                .HasColumnType("character varying")
                .HasColumnName("attributes_display_name");
            entity.Property(e => e.AttributesEditable)
                .HasColumnType("character varying")
                .HasColumnName("attributes_editable");
            entity.Property(e => e.AttributesShow)
                .HasColumnType("character varying")
                .HasColumnName("attributes_show");
            entity.Property(e => e.GeomColName)
                .HasColumnType("character varying")
                .HasColumnName("geom_col_name");
            entity.Property(e => e.GeoserverTbl)
                .HasColumnType("character varying")
                .HasColumnName("geoserver_tbl");
            entity.Property(e => e.LayerDisplayName)
                .HasColumnType("character varying")
                .HasColumnName("layer_display_name");
            entity.Property(e => e.LayerGroup)
                .HasColumnType("character varying")
                .HasColumnName("layer_group");
            entity.Property(e => e.LayerType)
                .HasColumnType("character varying")
                .HasColumnName("layer_type");
            entity.Property(e => e.LineWidth).HasColumnName("line_width");
            entity.Property(e => e.ObjColorRgbOpacity)
                .HasColumnType("character varying")
                .HasColumnName("obj_color_rgb_opacity");
            entity.Property(e => e.ObjType)
                .HasColumnType("character varying")
                .HasColumnName("obj_type");
            entity.Property(e => e.PointImg)
                .HasColumnType("character varying")
                .HasColumnName("point_img");
            entity.Property(e => e.PointRadius).HasColumnName("point_radius");
            entity.Property(e => e.PointStrokeColor)
                .HasColumnType("character varying")
                .HasColumnName("point_stroke_color");
            entity.Property(e => e.ProjectName)
                .HasColumnType("character varying")
                .HasColumnName("project_name");
            entity.Property(e => e.Sector)
                .HasColumnType("character varying")
                .HasColumnName("sector");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.TblName)
                .HasColumnType("character varying")
                .HasColumnName("tbl_name");
        });

        modelBuilder.Entity<LeftoutTap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lotap_pkey");

            entity.ToTable("leftout_taps", "existing_projects");

            entity.HasIndex(e => e.TheGeom, "leftout_taps_geom_idx").HasMethod("gist");

            entity.HasIndex(e => e.Uuid, "ltap_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.BcHh).HasColumnName("bc_hh");
            entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
            entity.Property(e => e.CollectedOn).HasColumnName("collected_on");
            entity.Property(e => e.CurrentSource).HasColumnName("current_source");
            entity.Property(e => e.DalHh).HasColumnName("dal_hh");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.FemalePop).HasColumnName("female_pop");
            entity.Property(e => e.HhServed).HasColumnName("hh_served");
            entity.Property(e => e.HhToilet).HasColumnName("hh_toilet");
            entity.Property(e => e.JanHh).HasColumnName("jan_hh");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.LeftoutReason)
                .HasColumnType("character varying")
                .HasColumnName("leftout_reason");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.MalePop).HasColumnName("male_pop");
            entity.Property(e => e.MiHh).HasColumnName("mi_hh");
            entity.Property(e => e.PhotoPath).HasColumnName("photo_path");
            entity.Property(e => e.PhotoPathUuid)
                .HasColumnType("character varying")
                .HasColumnName("photo_path_uuid");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TapContact)
                .HasColumnType("character varying")
                .HasColumnName("tap_contact");
            entity.Property(e => e.TapNo)
                .HasColumnType("character varying")
                .HasColumnName("tap_no");
            entity.Property(e => e.TapOwner)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("tap_owner");
            entity.Property(e => e.TapType)
                .HasMaxLength(100)
                .HasColumnName("tap_type");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.LeftoutTaps)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });


        modelBuilder.Entity<LocalbodiesLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("localbodies_line_pkey");

            entity.ToTable("localbodies_line", "basemap");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiLineString,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.LeftFid).HasColumnName("left_fid");
            entity.Property(e => e.RightFid).HasColumnName("right_fid");
        });

        modelBuilder.Entity<LocalbodiesNepal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("localbodies_nepal_pkey");

            entity.ToTable("localbodies_nepal", "basemap");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaHa).HasColumnName("area_ha");
            entity.Property(e => e.AreaHa1).HasColumnName("area_ha_1");
            entity.Property(e => e.Dcode).HasColumnName("dcode");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasColumnName("district");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.LocBodies)
                .HasMaxLength(60)
                .HasColumnName("loc_bodies");
            entity.Property(e => e.LocCode).HasColumnName("loc_code");
            entity.Property(e => e.LocNepali)
                .HasMaxLength(250)
                .HasColumnName("loc_nepali");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.Zone)
                .HasMaxLength(50)
                .HasColumnName("zone");
        });

        modelBuilder.Entity<Lrn1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lrn1_pkey");

            entity.ToTable("lrn1", "basemap");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AadtClass)
                .HasMaxLength(25)
                .HasColumnName("aadt_class");
            entity.Property(e => e.AadtValue).HasColumnName("aadt_value");
            entity.Property(e => e.AccCon)
                .HasMaxLength(50)
                .HasColumnName("acc_con");
            entity.Property(e => e.AddDate)
                .HasMaxLength(20)
                .HasColumnName("add_date");
            entity.Property(e => e.BaseThick).HasColumnName("base_thick");
            entity.Property(e => e.Constructi)
                .HasMaxLength(11)
                .HasColumnName("constructi");
            entity.Property(e => e.Dcode).HasColumnName("dcode");
            entity.Property(e => e.Dyear)
                .HasMaxLength(11)
                .HasColumnName("dyear");
            entity.Property(e => e.ForWidth).HasColumnName("for_width");
            entity.Property(e => e.FromCh).HasColumnName("from_ch");
            entity.Property(e => e.FromLat).HasColumnName("from_lat");
            entity.Property(e => e.FromLong).HasColumnName("from_long");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiLineString,32644)")
                .HasColumnName("geom");
            entity.Property(e => e.HorCur)
                .HasMaxLength(25)
                .HasColumnName("hor_cur");
            entity.Property(e => e.Inotes)
                .HasMaxLength(150)
                .HasColumnName("inotes");
            entity.Property(e => e.Iprogram)
                .HasMaxLength(150)
                .HasColumnName("iprogram");
            entity.Property(e => e.IriRating)
                .HasMaxLength(25)
                .HasColumnName("iri_rating");
            entity.Property(e => e.IriValue).HasColumnName("iri_value");
            entity.Property(e => e.Iupdate)
                .HasMaxLength(11)
                .HasColumnName("iupdate");
            entity.Property(e => e.Iyear)
                .HasMaxLength(11)
                .HasColumnName("iyear");
            entity.Property(e => e.LastResur)
                .HasMaxLength(11)
                .HasColumnName("last_resur");
            entity.Property(e => e.LeftSho1)
                .HasMaxLength(100)
                .HasColumnName("left_sho_1");
            entity.Property(e => e.LeftShoul).HasColumnName("left_shoul");
            entity.Property(e => e.NoLanes).HasColumnName("no_lanes");
            entity.Property(e => e.PaveThick).HasColumnName("pave_thick");
            entity.Property(e => e.PaveType)
                .HasMaxLength(100)
                .HasColumnName("pave_type");
            entity.Property(e => e.PaveWidth).HasColumnName("pave_width");
            entity.Property(e => e.RightSh1)
                .HasMaxLength(100)
                .HasColumnName("right_sh_1");
            entity.Property(e => e.RightShou).HasColumnName("right_shou");
            entity.Property(e => e.RoadCateg)
                .HasMaxLength(150)
                .HasColumnName("road_categ");
            entity.Property(e => e.RoadCode)
                .HasMaxLength(50)
                .HasColumnName("road_code");
            entity.Property(e => e.RoadUuid)
                .HasMaxLength(100)
                .HasColumnName("road_uuid");
            entity.Property(e => e.SdiRating)
                .HasMaxLength(25)
                .HasColumnName("sdi_rating");
            entity.Property(e => e.SdiValue).HasColumnName("sdi_value");
            entity.Property(e => e.SecLen).HasColumnName("sec_len");
            entity.Property(e => e.SubbaseTh).HasColumnName("subbase_th");
            entity.Property(e => e.SubgradeT)
                .HasMaxLength(100)
                .HasColumnName("subgrade_t");
            entity.Property(e => e.Terrain)
                .HasMaxLength(25)
                .HasColumnName("terrain");
            entity.Property(e => e.ToCh).HasColumnName("to_ch");
            entity.Property(e => e.ToLat).HasColumnName("to_lat");
            entity.Property(e => e.ToLong).HasColumnName("to_long");
            entity.Property(e => e.UploadBy)
                .HasMaxLength(150)
                .HasColumnName("upload_by");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
        });

               modelBuilder.Entity<LutWq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lut_Wq_Surveillance_pkey");

            entity.ToTable("lut_Wq_Surveillance", "wqs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Index)
                .HasColumnType("character varying")
                .HasColumnName("index");
            entity.Property(e => e.Label)
                .HasColumnType("character varying")
                .HasColumnName("label");
            entity.Property(e => e.LabelDn)
                .HasColumnType("character varying")
                .HasColumnName("label_dn");
            entity.Property(e => e.LabelText)
                .HasColumnType("character varying")
                .HasColumnName("label_text");
            entity.Property(e => e.Options)
                .HasColumnType("character varying")
                .HasColumnName("options");
            entity.Property(e => e.QbCols)
                .HasColumnType("character varying")
                .HasColumnName("qb_cols");
            entity.Property(e => e.Scope)
                .HasColumnType("character varying")
                .HasColumnName("scope");
            entity.Property(e => e.ScopeId).HasColumnName("scope_id");
            entity.Property(e => e.TblName)
                .HasColumnType("character varying")
                .HasColumnName("tbl_name");
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

        modelBuilder.Entity<Pipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pipe_pkey");

            entity.ToTable("pipe", "existing_projects");

            entity.HasIndex(e => e.TheGeom, "pipe_geom_idx").HasMethod("gist");

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
            entity.Property(e => e.LeakageCount).HasColumnName("leakage_count");
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
            entity.Property(e => e.PipeClass)
                .HasMaxLength(20)
                .HasColumnName("pipe_class");
            entity.Property(e => e.PipeCond)
                .HasMaxLength(100)
                .HasColumnName("pipe_cond");
            entity.Property(e => e.PipeCons)
                .HasMaxLength(20)
                .HasColumnName("pipe_cons");
            entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");
            entity.Property(e => e.PipeEqk)
                .HasMaxLength(100)
                .HasColumnName("pipe_eqk");
            entity.Property(e => e.PipeLayCon)
                .HasMaxLength(100)
                .HasColumnName("pipe_lay_con");
            entity.Property(e => e.PipeLcon)
                .HasMaxLength(100)
                .HasColumnName("pipe_lcon");
            entity.Property(e => e.PipeLen).HasColumnName("pipe_len");
            entity.Property(e => e.PipeName)
                .HasMaxLength(200)
                .HasColumnName("pipe_name");
            entity.Property(e => e.PipePart)
                .HasMaxLength(25)
                .HasColumnName("pipe_part");
            entity.Property(e => e.PipeRem)
                .HasColumnType("character varying")
                .HasColumnName("pipe_rem");
            entity.Property(e => e.PipeType)
                .HasMaxLength(20)
                .HasColumnName("pipe_type");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.Pipes)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("pro_uuid");
        });

        modelBuilder.Entity<PipeDrawnRoute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pipe_drawn_route_pkey");

            entity.ToTable("pipe_drawn_route", "existing_projects");

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
            entity.Property(e => e.PipeClass)
                .HasMaxLength(20)
                .HasColumnName("pipe_class");
            entity.Property(e => e.PipeCond)
                .HasMaxLength(100)
                .HasColumnName("pipe_cond");
            entity.Property(e => e.PipeCons)
                .HasMaxLength(20)
                .HasColumnName("pipe_cons");
            entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");
            entity.Property(e => e.PipeEqk)
                .HasMaxLength(100)
                .HasColumnName("pipe_eqk");
            entity.Property(e => e.PipeLcon)
                .HasMaxLength(100)
                .HasColumnName("pipe_lcon");
            entity.Property(e => e.PipePart)
                .HasMaxLength(25)
                .HasColumnName("pipe_part");
            entity.Property(e => e.PipeType)
                .HasMaxLength(20)
                .HasColumnName("pipe_type");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
        });

    

        modelBuilder.Entity<PipeRoutePoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pipe_route_point_pkey");

            entity.ToTable("pipe_route_point", "existing_projects");

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
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.PipeClass)
                .HasMaxLength(20)
                .HasColumnName("pipe_class");
            entity.Property(e => e.PipeCond)
                .HasMaxLength(100)
                .HasColumnName("pipe_cond");
            entity.Property(e => e.PipeCons)
                .HasMaxLength(20)
                .HasColumnName("pipe_cons");
            entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");
            entity.Property(e => e.PipeEqk)
                .HasMaxLength(100)
                .HasColumnName("pipe_eqk");
            entity.Property(e => e.PipeLcon)
                .HasMaxLength(100)
                .HasColumnName("pipe_lcon");
            entity.Property(e => e.PipePart)
                .HasMaxLength(25)
                .HasColumnName("pipe_part");
            entity.Property(e => e.PipeType)
                .HasMaxLength(20)
                .HasColumnName("pipe_type");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.PipeRoutePoints)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });

        modelBuilder.Entity<PopServed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pop_served_pkey");

            entity.ToTable("pop_served", "existing_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.BcHh).HasColumnName("bc_hh");
            entity.Property(e => e.DalHh).HasColumnName("dal_hh");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.FemPop).HasColumnName("fem_pop");
            entity.Property(e => e.HhServerd).HasColumnName("hh_serverd");
            entity.Property(e => e.JanHh).HasColumnName("jan_hh");
            entity.Property(e => e.MalePop).HasColumnName("male_pop");
            entity.Property(e => e.MiHh).HasColumnName("mi_hh");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
        });

      

        modelBuilder.Entity<ProjectCoverage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_coverage_pkey");

            entity.ToTable("project_coverage", "existing_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");

            entity.HasOne(d => d.ProUu).WithMany(p => p.ProjectCoverages)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
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

       
        modelBuilder.Entity<ProvinceNepal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("province_wgs84_pkey");

            entity.ToTable("province_nepal", "basemap");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.ProvNepali).HasColumnName("prov_nepali");
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .HasColumnName("province");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");
        });

  
        modelBuilder.Entity<Rate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rate");

            entity.Property(e => e.Rate1).HasColumnName("rate");
        });

      

        modelBuilder.Entity<ReportDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rdata_pkey_id");

            entity.ToTable("report_data", "existing_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DistrictCode)
                .HasColumnType("character varying")
                .HasColumnName("district_code");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.MunicipalityCode)
                .HasColumnType("character varying")
                .HasColumnName("municipality_code");
            entity.Property(e => e.ProCode)
                .HasColumnType("character varying")
                .HasColumnName("pro_code");
            entity.Property(e => e.ProvinceCode)
                .HasColumnType("character varying")
                .HasColumnName("province_code");
            entity.Property(e => e.SchemeCondition)
                .HasColumnType("character varying")
                .HasColumnName("scheme_condition");
            entity.Property(e => e.SchemePrioritizationScore)
                .HasColumnType("character varying")
                .HasColumnName("scheme_prioritization_score");
            entity.Property(e => e.TotalPopulation)
                .HasColumnType("character varying")
                .HasColumnName("total_population");
        });

        modelBuilder.Entity<Reservoir>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservoir_pkey");

            entity.ToTable("reservoir", "existing_projects");

            entity.HasIndex(e => e.TheGeom, "reservoir_geom_idx").HasMethod("gist");

            entity.HasIndex(e => e.Uuid, "reservoir_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
            entity.Property(e => e.CollectedOn).HasColumnName("collected_on");
            entity.Property(e => e.ConsYear).HasColumnName("cons_year");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
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
            entity.Property(e => e.RvtCap).HasColumnName("rvt_cap");
            entity.Property(e => e.RvtCon)
                .HasMaxLength(100)
                .HasColumnName("rvt_con");
            entity.Property(e => e.RvtCons)
                .HasMaxLength(20)
                .HasColumnName("rvt_cons");
            entity.Property(e => e.RvtEqk)
                .HasMaxLength(100)
                .HasColumnName("rvt_eqk");
            entity.Property(e => e.RvtNo)
                .HasMaxLength(20)
                .HasColumnName("rvt_no");
            entity.Property(e => e.RvtQua)
                .HasMaxLength(100)
                .HasColumnName("rvt_qua");
            entity.Property(e => e.RvtRem)
                .HasColumnType("character varying")
                .HasColumnName("rvt_rem");
            entity.Property(e => e.RvtType)
                .HasMaxLength(100)
                .HasColumnName("rvt_type");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.Reservoirs)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });

      

        modelBuilder.Entity<ReservoirSanitary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reservoir_sanitary_pkey");

            entity.ToTable("reservoir_sanitary", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");
            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.ResorvoirSanitationCondition1)
                .HasColumnType("character varying")
                .HasColumnName("resorvoir_sanitation_condition_1");
            entity.Property(e => e.ResorvoirSanitationCondition2)
                .HasColumnType("character varying")
                .HasColumnName("resorvoir_sanitation_condition_2");
            entity.Property(e => e.ResorvoirSanitationCondition3)
                .HasColumnType("character varying")
                .HasColumnName("resorvoir_sanitation_condition_3");
            entity.Property(e => e.ResorvoirSanitationCondition4)
                .HasColumnType("character varying")
                .HasColumnName("resorvoir_sanitation_condition_4");
            entity.Property(e => e.ResorvoirSanitationCondition5)
                .HasColumnType("character varying")
                .HasColumnName("resorvoir_sanitation_condition_5");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
            entity.Property(e => e.VisitDate)
               .HasColumnType("character varying")
               .HasColumnName("visit_date");
        });

      

        modelBuilder.Entity<SanitaryInspection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sanitary_inspection_pkey");

            entity.ToTable("sanitary_inspection", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Elevation).HasColumnName("elevation");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.PointType).HasColumnName("point_type");
            entity.Property(e => e.ProjectUuid).HasColumnName("project_uuid");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<SanitaryInspectionTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sanitary_inspection_template_pkey");

            entity.ToTable("sanitary_inspection_template", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attribute).HasColumnName("attribute");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Options).HasColumnName("options");
            entity.Property(e => e.Qn).HasColumnName("qn");
            entity.Property(e => e.Question).HasColumnName("question");
        });

        modelBuilder.Entity<SanitaryInspectionValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sanitary_inspection_values_pkey");

            entity.ToTable("sanitary_inspection_values", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.SampleUuid).HasColumnName("sample_uuid");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Sanitation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sanitation_pkey");

            entity.ToTable("sanitation", "existing_projects");

            entity.HasIndex(e => e.Uuid, "san_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.OwnerContact)
                .HasColumnType("character varying")
                .HasColumnName("owner_contact");
            entity.Property(e => e.OwnerName)
                .HasColumnType("character varying")
                .HasColumnName("owner_name");
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
            entity.Property(e => e.SanOwner)
                .HasMaxLength(50)
                .HasColumnName("san_owner");
            entity.Property(e => e.SanRem)
                .HasColumnType("character varying")
                .HasColumnName("san_rem");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.ToiletTreatment)
                .HasColumnType("character varying")
                .HasColumnName("toilet_treatment");
            entity.Property(e => e.ToiletType)
                .HasColumnType("character varying")
                .HasColumnName("toilet_type");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.Sanitations)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });

       

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("settlement_pkey");

            entity.ToTable("settlement", "basemap");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(Point,4326)")
                .HasColumnName("geom");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });
        modelBuilder.Entity<SourceSanitary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("source_sanitary_pkey");

            entity.ToTable("source_sanitary", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.SourceSanitationCondition1)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_1");
            entity.Property(e => e.SourceSanitationCondition10)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_10");
            entity.Property(e => e.SourceSanitationCondition11)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_11");
            entity.Property(e => e.SourceSanitationCondition12)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_12");
            entity.Property(e => e.SourceSanitationCondition13)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_13");
            entity.Property(e => e.SourceSanitationCondition14)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_14");
            entity.Property(e => e.SourceSanitationCondition15)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_15");
            entity.Property(e => e.SourceSanitationCondition2)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_2");
            entity.Property(e => e.SourceSanitationCondition3)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_3");
            entity.Property(e => e.SourceSanitationCondition4)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_4");
            entity.Property(e => e.SourceSanitationCondition5)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_5");
            entity.Property(e => e.SourceSanitationCondition6)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_6");
            entity.Property(e => e.SourceSanitationCondition7)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_7");
            entity.Property(e => e.SourceSanitationCondition8)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_8");
            entity.Property(e => e.SourceSanitationCondition9)
                .HasColumnType("character varying")
                .HasColumnName("source_sanitation_condition_9");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
            entity.Property(e => e.VisitDate)
               .HasColumnType("character varying")
               .HasColumnName("visit_date");
        });

        modelBuilder.Entity<Srn>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("srn_pkey");

            entity.ToTable("srn", "basemap");

            entity.Property(e => e.Orderid)
                .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.AadtValue).HasColumnName("aadt_value");
            entity.Property(e => e.AddDate)
                .HasMaxLength(20)
                .HasColumnName("add_date");
            entity.Property(e => e.BaseThick).HasColumnName("base_thick");
            entity.Property(e => e.ComVeh).HasColumnName("com_veh");
            entity.Property(e => e.ConstructionYear)
                .HasMaxLength(11)
                .HasColumnName("construction_year");
            entity.Property(e => e.Dcode).HasColumnName("dcode");
            entity.Property(e => e.Dyear)
                .HasMaxLength(11)
                .HasColumnName("dyear");
            entity.Property(e => e.ForWidth).HasColumnName("for_width");
            entity.Property(e => e.FromCh).HasColumnName("from_ch");
            entity.Property(e => e.FromLat).HasColumnName("from_lat");
            entity.Property(e => e.FromLong).HasColumnName("from_long");
            entity.Property(e => e.Inotes)
                .HasMaxLength(150)
                .HasColumnName("inotes");
            entity.Property(e => e.Iprogram)
                .HasMaxLength(150)
                .HasColumnName("iprogram");
            entity.Property(e => e.IriValue).HasColumnName("iri_value");
            entity.Property(e => e.Iupdate)
                .HasMaxLength(11)
                .HasColumnName("iupdate");
            entity.Property(e => e.Iyear)
                .HasMaxLength(11)
                .HasColumnName("iyear");
            entity.Property(e => e.LastResurface)
                .HasMaxLength(11)
                .HasColumnName("last_resurface");
            entity.Property(e => e.LeftShoulderType)
                .HasMaxLength(100)
                .HasColumnName("left_shoulder_type");
            entity.Property(e => e.LeftShoulderWidth).HasColumnName("left_shoulder_width");
            entity.Property(e => e.NoLanes).HasColumnName("no_lanes");
            entity.Property(e => e.PaveThick).HasColumnName("pave_thick");
            entity.Property(e => e.PaveType)
                .HasMaxLength(100)
                .HasColumnName("pave_type");
            entity.Property(e => e.PaveWidth).HasColumnName("pave_width");
            entity.Property(e => e.RightShoulderType)
                .HasMaxLength(100)
                .HasColumnName("right_shoulder_type");
            entity.Property(e => e.RightShoulderWidth).HasColumnName("right_shoulder_width");
            entity.Property(e => e.RoadCode)
                .HasMaxLength(50)
                .HasColumnName("road_code");
            entity.Property(e => e.SdiValue).HasColumnName("sdi_value");
            entity.Property(e => e.SubbaseThick).HasColumnName("subbase_thick");
            entity.Property(e => e.SubgradeType)
                .HasMaxLength(100)
                .HasColumnName("subgrade_type");
            entity.Property(e => e.TheGeom)
                .HasColumnType("geometry(LineString,32644)")
                .HasColumnName("the_geom");
            entity.Property(e => e.ToCh).HasColumnName("to_ch");
            entity.Property(e => e.ToLat).HasColumnName("to_lat");
            entity.Property(e => e.ToLong).HasColumnName("to_long");
            entity.Property(e => e.UploadBy)
                .HasMaxLength(150)
                .HasColumnName("upload_by");
        });


        modelBuilder.Entity<Structure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("structure_pkey");

            entity.ToTable("structure", "existing_projects");

            entity.HasIndex(e => e.Uuid, "structure_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
            entity.Property(e => e.CollectedOn).HasColumnName("collected_on");
            entity.Property(e => e.ConsYear).HasColumnName("cons_year");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
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
            entity.Property(e => e.StrCond)
                .HasMaxLength(100)
                .HasColumnName("str_cond");
            entity.Property(e => e.StrCons)
                .HasMaxLength(25)
                .HasColumnName("str_cons");
            entity.Property(e => e.StrDim)
                .HasColumnType("character varying")
                .HasColumnName("str_dim");
            entity.Property(e => e.StrDimHeight).HasColumnName("str_dim_height");
            entity.Property(e => e.StrDimLen).HasColumnName("str_dim_len");
            entity.Property(e => e.StrDimWidth).HasColumnName("str_dim_width");
            entity.Property(e => e.StrEqk)
                .HasMaxLength(100)
                .HasColumnName("str_eqk");
            entity.Property(e => e.StrNo)
                .HasMaxLength(50)
                .HasColumnName("str_no");
            entity.Property(e => e.StrNrp)
                .HasMaxLength(100)
                .HasColumnName("str_nrp");
            entity.Property(e => e.StrOther)
                .HasColumnType("character varying")
                .HasColumnName("str_other");
            entity.Property(e => e.StrRem)
                .HasColumnType("character varying")
                .HasColumnName("str_rem");
            entity.Property(e => e.StrType)
                .HasMaxLength(100)
                .HasColumnName("str_type");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.Structures)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });


        modelBuilder.Entity<StructureSanitary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("structure_sanitary_pkey");

            entity.ToTable("structure_sanitary", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.StructureSanitationCondition1)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_1");
            entity.Property(e => e.StructureSanitationCondition10)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_10");
            entity.Property(e => e.StructureSanitationCondition2)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_2");
            entity.Property(e => e.StructureSanitationCondition3)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_3");
            entity.Property(e => e.StructureSanitationCondition4)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_4");
            entity.Property(e => e.StructureSanitationCondition5)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_5");
            entity.Property(e => e.StructureSanitationCondition6)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_6");
            entity.Property(e => e.StructureSanitationCondition7)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_7");
            entity.Property(e => e.StructureSanitationCondition8)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_8");
            entity.Property(e => e.StructureSanitationCondition9)
                .HasColumnType("character varying")
                .HasColumnName("structure_sanitation_condition_9");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
                          .HasColumnName("uuid");
            entity.Property(e => e.VisitDate)
    .HasColumnType("character varying")
    .HasColumnName("visit_date");

        });

        modelBuilder.Entity<Support>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("support_pkey");

            entity.ToTable("support", "existing_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.SupportAgencyId).HasColumnName("support_agency_id");
            entity.Property(e => e.SupportAmount).HasColumnName("support_amount");
            entity.Property(e => e.SupportNote)
                .HasColumnType("character varying")
                .HasColumnName("support_note");
            entity.Property(e => e.SupportTypeId).HasColumnName("support_type_id");
            entity.Property(e => e.SupportYear).HasColumnName("support_year");
        });


        modelBuilder.Entity<Sustainability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sustainability_pkey");

            entity.ToTable("sustainability", "existing_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.AddDate).HasColumnName("add_date");
            entity.Property(e => e.DataYear).HasColumnName("data_year");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.NoWomenWuscMem).HasColumnName("no_women_wusc_mem");
            entity.Property(e => e.NoWuscMem).HasColumnName("no_wusc_mem");
            entity.Property(e => e.ProUuid)
                .HasMaxLength(100)
                .HasColumnName("pro_uuid");
            entity.Property(e => e.SusAcc)
                .HasColumnType("character varying")
                .HasColumnName("sus_acc");
            entity.Property(e => e.SusAgm)
                .HasColumnType("character varying")
                .HasColumnName("sus_agm");
            entity.Property(e => e.SusBookeeping)
                .HasColumnType("character varying")
                .HasColumnName("sus_bookeeping");
            entity.Property(e => e.SusInsurance)
                .HasColumnType("character varying")
                .HasColumnName("sus_insurance");
            entity.Property(e => e.SusNoMeeting)
                .HasColumnType("character varying")
                .HasColumnName("sus_no_meeting");
            entity.Property(e => e.SusPerHh)
                .HasColumnType("character varying")
                .HasColumnName("sus_per_hh");
            entity.Property(e => e.SusSop)
                .HasColumnType("character varying")
                .HasColumnName("sus_sop");
            entity.Property(e => e.SusSourceReg)
                .HasColumnType("character varying")
                .HasColumnName("sus_source_reg");
            entity.Property(e => e.SusSourceSafety)
                .HasColumnType("character varying")
                .HasColumnName("sus_source_safety");
            entity.Property(e => e.SusVmw)
                .HasColumnType("character varying")
                .HasColumnName("sus_vmw");
            entity.Property(e => e.SusWaterQuality)
                .HasColumnType("character varying")
                .HasColumnName("sus_water_quality");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<TableDictionary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("care_ims_01_id_pk");

            entity.ToTable("table_dictionary", "swmap");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LayerType)
                .HasColumnType("character varying")
                .HasColumnName("layer_type");
            entity.Property(e => e.PostgresSchema)
                .HasMaxLength(200)
                .HasColumnName("postgres_schema");
            entity.Property(e => e.PostgresTable)
                .HasColumnType("character varying")
                .HasColumnName("postgres_table");
            entity.Property(e => e.SqliteLayer)
                .HasMaxLength(200)
                .HasColumnName("sqlite_layer");
            entity.Property(e => e.Status).HasColumnName("status");
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


        modelBuilder.Entity<TapSanitary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tap_sanitary_pkey");

            entity.ToTable("tap_sanitary", "wqs");
            entity.Property(e => e.AddedBy)
               .HasColumnType("character varying")
               .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.FormId)
                .HasColumnType("character varying")
                .HasColumnName("form_id");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.TapSanitationCondition1)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_1");
            entity.Property(e => e.TapSanitationCondition2)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_2");
            entity.Property(e => e.TapSanitationCondition3)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_3");
            entity.Property(e => e.TapSanitationCondition4)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_4");
            entity.Property(e => e.TapSanitationCondition5)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_5");
            entity.Property(e => e.TapSanitationCondition6)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_6");
            entity.Property(e => e.TapSanitationCondition7)
                .HasColumnType("character varying")
                .HasColumnName("tap_sanitation_condition_7");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.Uuid)
              .HasColumnType("character varying")
              .HasColumnName("uuid");
            entity.Property(e => e.VisitDate)
               .HasColumnType("character varying")
               .HasColumnName("visit_date");
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

        modelBuilder.Entity<Tubewell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tw_pkey");

            entity.ToTable("tubewells", "existing_projects");

            entity.HasIndex(e => e.Uuid, "tubewell_uuid").IsUnique();

            entity.HasIndex(e => e.Uuid, "u_uuid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddBy)
                .HasColumnType("character varying")
                .HasColumnName("add_by");
            entity.Property(e => e.CommunityName)
                .HasColumnType("character varying")
                .HasColumnName("community_name");
            entity.Property(e => e.Condition)
                .HasColumnType("character varying")
                .HasColumnName("condition");
            entity.Property(e => e.ConsYear).HasColumnName("cons_year");
            entity.Property(e => e.DepthFt).HasColumnName("depth_ft");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.FemalePop).HasColumnName("female_pop");
            entity.Property(e => e.HhServed).HasColumnName("hh_served");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.MalePop).HasColumnName("male_pop");
            entity.Property(e => e.MunCode)
                .HasColumnType("character varying")
                .HasColumnName("mun_code");
            entity.Property(e => e.OwnerName)
                .HasColumnType("character varying")
                .HasColumnName("owner_name");
            entity.Property(e => e.Photo1)
                .HasColumnType("character varying")
                .HasColumnName("photo1");
            entity.Property(e => e.Photo1Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_uuid");
            entity.Property(e => e.Photo2)
                .HasColumnType("character varying")
                .HasColumnName("photo2");
            entity.Property(e => e.Photo2Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_uuid");
            entity.Property(e => e.PlatformCondition)
                .HasColumnType("character varying")
                .HasColumnName("platform_condition");
            entity.Property(e => e.PopServed).HasColumnName("pop_served");
            entity.Property(e => e.ProjectBeingConstructed).HasColumnName("project_being_constructed");
            entity.Property(e => e.RecTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("rec_time");
            entity.Property(e => e.Remarks)
                .HasColumnType("character varying")
                .HasColumnName("remarks");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.TubewellType)
                .HasColumnType("character varying")
                .HasColumnName("tubewell_type");
            entity.Property(e => e.UploadTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("upload_time");
            entity.Property(e => e.Uuid)
                .HasMaxLength(100)
                .HasColumnName("uuid");
            entity.Property(e => e.WardNo).HasColumnName("ward_no");
            entity.Property(e => e.WsSchemePresent).HasColumnName("ws_scheme_present");
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

        modelBuilder.Entity<WardBoundary45n>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ward_boundary_45N_pkey");

            entity.ToTable("ward_boundary_45N", "basemap");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaHa).HasColumnName("area_ha");
            entity.Property(e => e.Dcode).HasColumnName("dcode");
            entity.Property(e => e.DcodeNew).HasColumnName("dcode_new");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasColumnName("district");
            entity.Property(e => e.GapaNapa).HasColumnName("gapa_napa");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiPolygon,32645)")
                .HasColumnName("geom");
            entity.Property(e => e.LocBodies)
                .HasMaxLength(60)
                .HasColumnName("loc_bodies");
            entity.Property(e => e.LocCode).HasColumnName("loc_code");
            entity.Property(e => e.Pcode).HasColumnName("pcode");
            entity.Property(e => e.ProtectAr).HasColumnName("protect_ar");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.TypeGn).HasColumnName("type_gn");
            entity.Property(e => e.WardNepali).HasColumnName("ward_nepali");
            entity.Property(e => e.Wno).HasColumnName("wno");
            entity.Property(e => e.Zone)
                .HasMaxLength(50)
                .HasColumnName("zone");
        });

        modelBuilder.Entity<WardboundaryLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wardboundary_line_pkey");

            entity.ToTable("wardboundary_line", "basemap");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Geom)
                .HasColumnType("geometry(MultiLineString,32645)")
                .HasColumnName("geom");
            entity.Property(e => e.LeftFid).HasColumnName("left_fid");
            entity.Property(e => e.RightFid).HasColumnName("right_fid");
        });

        modelBuilder.Entity<WaterQualitySample>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("water_quality_sample_pkey");

            entity.ToTable("water_quality_sample", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Completed)
                .HasDefaultValueSql("0")
                .HasColumnName("completed");
            entity.Property(e => e.DescPhoto1).HasColumnName("desc_photo1");
            entity.Property(e => e.DescPhoto2).HasColumnName("desc_photo2");
            entity.Property(e => e.DescPhoto3).HasColumnName("desc_photo3");
            entity.Property(e => e.DescPhoto4).HasColumnName("desc_photo4");
            entity.Property(e => e.Elevation).HasColumnName("elevation");
            entity.Property(e => e.Geom).HasColumnName("geom");
            entity.Property(e => e.InstrumentsUsed).HasColumnName("instruments_used");
            entity.Property(e => e.LabTest).HasColumnName("lab_test");
            entity.Property(e => e.LabUuid)
                .HasColumnType("character varying")
                .HasColumnName("lab_uuid");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Photo1).HasColumnName("photo1");
            entity.Property(e => e.Photo1Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_uuid");
            entity.Property(e => e.Photo2).HasColumnName("photo2");
            entity.Property(e => e.Photo2Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_uuid");
            entity.Property(e => e.Photo3).HasColumnName("photo3");
            entity.Property(e => e.Photo3Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo3_uuid");
            entity.Property(e => e.Photo4).HasColumnName("photo4");
            entity.Property(e => e.Photo4Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo4_uuid");
            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.PointType).HasColumnName("point_type");
            entity.Property(e => e.ProjectUuid).HasColumnName("project_uuid");
            entity.Property(e => e.SampleCode).HasColumnName("sample_code");
            entity.Property(e => e.SamplingTime).HasColumnName("sampling_time");
            entity.Property(e => e.TestingTime).HasColumnName("testing_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<WaterQualityTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("water_quality_template_pkey");

            entity.ToTable("water_quality_template", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.DataType).HasColumnName("data_type");
            entity.Property(e => e.LowerRange).HasColumnName("lower_range");
            entity.Property(e => e.MethodUsed)
                .HasColumnType("character varying")
                .HasColumnName("method_used");
            entity.Property(e => e.ParameterName).HasColumnName("parameter_name");
            entity.Property(e => e.Range).HasColumnName("range");
            entity.Property(e => e.Unit).HasColumnName("unit");
            entity.Property(e => e.UpperRange).HasColumnName("upper_range");
        });

        modelBuilder.Entity<WaterQualityValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("water_quality_values_pkey");

            entity.ToTable("water_quality_values", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.LabTest).HasColumnName("lab_test");
            entity.Property(e => e.MethodUsed).HasColumnName("method_used");
            entity.Property(e => e.ParameterId).HasColumnName("parameter_id");
            entity.Property(e => e.SampleUuid).HasColumnName("sample_uuid");
            entity.Property(e => e.Value).HasColumnName("value");
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

        modelBuilder.Entity<WaterSourceMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("water_source_measure_pkey");

            entity.ToTable("water_source_measure", "existing_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.MeaDate)
                .HasColumnType("character varying")
                .HasColumnName("mea_date");
            entity.Property(e => e.MeaDis).HasColumnName("mea_dis");
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
            entity.Property(e => e.SourceUuid)
                .HasMaxLength(100)
                .HasColumnName("source_uuid");

            entity.HasOne(d => d.ProUu).WithMany(p => p.WaterSourceMeasures)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.ProUuid)
                .HasConstraintName("pro_uuid");
        });

     

        modelBuilder.Entity<WatersafeCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ws_comm_pkey");

            entity.ToTable("watersafe_community", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.MunCode)
                .HasColumnType("character varying")
                .HasColumnName("mun_code");
            entity.Property(e => e.ProName)
                .HasColumnType("character varying")
                .HasColumnName("pro_name");
            entity.Property(e => e.Test).HasColumnName("test");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
        });

      

        modelBuilder.Entity<WqGeneralLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wq_general_location_pkey");

            entity.ToTable("wq_general_location", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescPhoto1).HasColumnName("desc_photo1");
            entity.Property(e => e.DescPhoto2).HasColumnName("desc_photo2");
            entity.Property(e => e.DescPhoto3).HasColumnName("desc_photo3");
            entity.Property(e => e.DescPhoto4).HasColumnName("desc_photo4");
            entity.Property(e => e.Elevation).HasColumnName("elevation");
            entity.Property(e => e.IdentityId).HasColumnName("identity_id");
            entity.Property(e => e.InstrumentsUsed).HasColumnName("instruments_used");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.MunCode).HasColumnName("mun_code");
            entity.Property(e => e.Photo1).HasColumnName("photo1");
            entity.Property(e => e.Photo1Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo1_uuid");
            entity.Property(e => e.Photo2).HasColumnName("photo2");
            entity.Property(e => e.Photo2Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo2_uuid");
            entity.Property(e => e.Photo3).HasColumnName("photo3");
            entity.Property(e => e.Photo3Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo3_uuid");
            entity.Property(e => e.Photo4).HasColumnName("photo4");
            entity.Property(e => e.Photo4Uuid)
                .HasColumnType("character varying")
                .HasColumnName("photo4_uuid");
            entity.Property(e => e.PointType).HasColumnName("point_type");
            entity.Property(e => e.SamplingTime).HasColumnName("sampling_time");
            entity.Property(e => e.TestingTime).HasColumnName("testing_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
            entity.Property(e => e.WqCode).HasColumnName("wq_code");
        });

        modelBuilder.Entity<WqGeneralValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wq_general_values_pkey");

            entity.ToTable("wq_general_values", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LocationUuid).HasColumnName("location_uuid");
            entity.Property(e => e.ParameterId).HasColumnName("parameter_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<WqIdentity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wq_identity_pkey");

            entity.ToTable("wq_identity", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrgUuid).HasColumnName("org_uuid");
            entity.Property(e => e.ProjectName).HasColumnName("project_name");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        modelBuilder.Entity<WqSampleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wq_sample_pkey");

            entity.ToTable("wq_sample_details", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnalysisDate)
                .HasColumnType("character varying")
                .HasColumnName("analysis_date");
            entity.Property(e => e.AnalyzedBy)
                .HasColumnType("character varying")
                .HasColumnName("analyzed_by");
            entity.Property(e => e.AnalyzedDate)
                .HasColumnType("character varying")
                .HasColumnName("analyzed_date");
            entity.Property(e => e.ApprovedBy)
                .HasColumnType("character varying")
                .HasColumnName("approved_by");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("character varying")
                .HasColumnName("approved_date");
            entity.Property(e => e.ClientName)
                .HasColumnType("character varying")
                .HasColumnName("client_name");
            entity.Property(e => e.CompletionDate)
                .HasColumnType("character varying")
                .HasColumnName("completion_date");
            entity.Property(e => e.Dyear).HasColumnName("dyear");
            entity.Property(e => e.EnteredBy)
                .HasColumnType("character varying")
                .HasColumnName("entered_by");
            entity.Property(e => e.Gps)
                .HasColumnType("character varying")
                .HasColumnName("gps");
            entity.Property(e => e.ReportDate)
                .HasColumnType("character varying")
                .HasColumnName("report_date");
            entity.Property(e => e.SampleCollectionDate)
                .HasColumnType("character varying")
                .HasColumnName("sample_collection_date");
            entity.Property(e => e.SampleLocation)
                .HasColumnType("character varying")
                .HasColumnName("sample_location");
            entity.Property(e => e.SampleUuid)
                .HasColumnType("character varying")
                .HasColumnName("sample_uuid");
            entity.Property(e => e.SampledBy)
                .HasColumnType("character varying")
                .HasColumnName("sampled_by");
            entity.Property(e => e.SampledByLabUuid)
                .HasColumnType("character varying")
                .HasColumnName("sampled_by_lab_uuid");
            entity.Property(e => e.SamplingPoint)
                .HasColumnType("character varying")
                .HasColumnName("sampling_point");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<WqSurvellianceMain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Wq_Surveillanceurelliance_pkey");

            entity.ToTable("wq_survelliance_main", "wqs");

            entity.Property(e => e.Id)
                 .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasColumnType("character varying")
                .HasColumnName("added_by");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Altitude).HasColumnName("altitude");
            entity.Property(e => e.DbName)
                .HasColumnType("character varying")
                .HasColumnName("db_name");
            entity.Property(e => e.District)
                .HasColumnType("character varying")
                .HasColumnName("district");
            entity.Property(e => e.EditedBy)
                .HasColumnType("character varying")
                .HasColumnName("edited_by");
            entity.Property(e => e.EditedOn).HasColumnName("edited_on");
            entity.Property(e => e.FiscalYear)
                .HasColumnType("character varying")
                .HasColumnName("fiscal_year");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Municipality)
                .HasColumnType("character varying")
                .HasColumnName("municipality");
            entity.Property(e => e.Others)
                .HasColumnType("character varying")
                .HasColumnName("others");
            entity.Property(e => e.ProjectName)
                .HasColumnType("character varying")
                .HasColumnName("project_name");
            entity.Property(e => e.Province)
                .HasColumnType("character varying")
                .HasColumnName("province");
            entity.Property(e => e.SopCondition)
                .HasColumnType("character varying")
                .HasColumnName("sop_condition");
            entity.Property(e => e.SopPhoto)
                .HasColumnType("character varying")
                .HasColumnName("sop_photo");
            entity.Property(e => e.SourceName)
                .HasColumnType("character varying")
                .HasColumnName("source_name");
            entity.Property(e => e.SourceType)
                .HasColumnType("character varying")
                .HasColumnName("source_type");
            entity.Property(e => e.Surveyor)
                .HasColumnType("character varying")
                .HasColumnName("surveyor");
            entity.Property(e => e.SystemType)
                .HasColumnType("character varying")
                .HasColumnName("system_type");
            entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            entity.Property(e => e.TotalBenificiaryPopulation).HasColumnName("total_benificiary_population");
            entity.Property(e => e.TotalHhServed).HasColumnName("total_hh_served");
            entity.Property(e => e.Uuid)
                .HasColumnType("character varying")
                .HasColumnName("uuid");
            entity.Property(e => e.VisitDate)
                .HasColumnType("character varying")
                .HasColumnName("visit_date");
            entity.Property(e => e.WspCondtion)
                .HasColumnType("character varying")
                .HasColumnName("wsp_condtion");
            entity.Property(e => e.WspPhoto)
                .HasColumnType("character varying")
                .HasColumnName("wsp_photo");
        });

        modelBuilder.Entity<WqTempMethodUsed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wq_method_used_pkey");

            entity.ToTable("wq_temp_method_used", "water_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Options)
                .HasColumnType("character varying")
                .HasColumnName("options");
            entity.Property(e => e.WqTempId).HasColumnName("wq_temp_id");
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
