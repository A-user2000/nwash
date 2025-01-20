//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Nwash.Models.API;
//using Nwash.Models.CwisTables;
//using Nwash.Models.QueryTables;
//using Nwash.Models.ReportApi;
//using Nwash.Models.MapData;
//using Nwash.Models.WashSummary;
//using Nwash.Models.Estimation;
//using Nwash.Models.Reports;
//using Nwash.Models.WaterQuality;
//using Nwash.Models.ProvinceDashboardProject;
//using Nwash.Models.MapEdit;
//using Nwash.ViewModels;
//using Nwash.Models.QueryBuilder;

//namespace Nwash.Models
//{
//    public partial class nwash_dnContext : DbContext
//    {
//        public nwash_dnContext()
//        {
//        }

//        public nwash_dnContext(DbContextOptions<nwash_dnContext> options)
//             : base(options)
//        {
//        }
//        //Projector Mun charts 

//        public virtual DbSet<DistinctMunData> DistinctMunData { get; set; }

//        //Wash status Report 
//        public virtual DbSet<GovernancePivot> GovernancePivot { get; set; }
//        public virtual DbSet<WpStatusResult> WpStatusResult { get; set; } //wpplan export

//        public virtual DbSet<WqMethUsed> WqMethUsed { get; set; }
//        public virtual DbSet<TxtOnlyVal> TxtOnlyVals { get; set; }
//        public virtual DbSet<NumberOnly> NumberOnly { get; set; }
//        public virtual DbSet<SingleTxt> SingleTxt { get; set; }

//        public virtual DbSet<TblWasteManagementService> TblWasteManagementServices { get; set; }

//        public virtual DbSet<AgewiseCapMaintenanceCost> AgewiseCapMaintenanceCost { get; set; }
//        public virtual DbSet<ApkDetails> ApkDetails { get; set; }
//        public virtual DbSet<Pipedsys> Pipedsys { get; set; }
//        public virtual DbSet<TapPop> TapPop { get; set; }
//        public virtual DbSet<SourcesLut> SourcesLut { get; set; }
//        public virtual DbSet<TblSources> TblSources { get; set; }
//        public virtual DbSet<HcfCostYrly> HcfCostYrly { get; set; }
//        public virtual DbSet<ToiletNameDetails> ToiletNameDetails { get; set; }
//        public virtual DbSet<InventoryCrudTracker> InventoryCrudTracker { get; set; }
//        public virtual DbSet<ProjectCrudTracker> ProjectCrudTracker { get; set; }
//        public virtual DbSet<WashToolCrudTracker> WashToolCrudTracker { get; set; }
//        public virtual DbSet<SustainabilityCrudTracker> SustainabilityCrudTracker { get; set; }
//        public virtual DbSet<PipeLength> PipeLength { get; set; }
//        public virtual DbSet<TrainingHeld> TrainingHeld { get; set; }
//        public virtual DbSet<UuidChk> UuidChk { get; set; }
//        public virtual DbSet<CheckUuid> CheckUuid { get; set; }
//        public virtual DbSet<SanCostYrly> SanCostYrly { get; set; }
//        public virtual DbSet<SchoolCostYrly> SchoolCostYrly { get; set; }
//        public virtual DbSet<PublicPlaceCostYrly> PublicPlaceCostYrly { get; set; }
//        public virtual DbSet<WssCostYrly> WssCostYrly { get; set; }
//        public virtual DbSet<AgricultureProduct> AgricultureProduct { get; set; }
//        public virtual DbSet<AgroEcological> AgroEcological { get; set; }
//        public virtual DbSet<AnnualGrowthRate> AnnualGrowthRate { get; set; }
//        public virtual DbSet<ApprovedDocs> ApprovedDocs { get; set; }
//        public virtual DbSet<WashStatusApprovedDocs> WashStatusApprovedDocs { get; set; }
//        public virtual DbSet<PipedsystemGraphData> PipedsystemGraphData { get; set; }
//        public virtual DbSet<HhsanitationGraphData> HhsanitationGraphData { get; set; }
//        public virtual DbSet<ArsenicHis> ArsenicHis { get; set; }
//        public virtual DbSet<AsFsm> AsFsm { get; set; }
//        public virtual DbSet<AsHcf> AsHcf { get; set; }
//        public virtual DbSet<AsHhs> AsHhs { get; set; }
//        public virtual DbSet<AsLutFsm> AsLutFsm { get; set; }
//        public virtual DbSet<AsLutHcf> AsLutHcf { get; set; }
//        public virtual DbSet<AsLutHh> AsLutHh { get; set; }
//        public virtual DbSet<AsLutPublicPlace> AsLutPublicPlace { get; set; }
//        public virtual DbSet<AsLutSchool> AsLutSchool { get; set; }
//        public virtual DbSet<AsLutSwm> AsLutSwm { get; set; }
//        public virtual DbSet<AsLutWs> AsLutWs { get; set; }
//        public virtual DbSet<AsLutWwtp> AsLutWwtp { get; set; }
//        public virtual DbSet<AsPublicPlace> AsPublicPlace { get; set; }
//        public virtual DbSet<AsSchools> AsSchools { get; set; }
//        public virtual DbSet<AsSwm> AsSwm { get; set; }
//        public virtual DbSet<AsWaterSupply> AsWaterSupply { get; set; }
//        public virtual DbSet<AsWwtp> AsWwtp { get; set; }
//        public virtual DbSet<AverageTemperature> AverageTemperature { get; set; }
//        public virtual DbSet<Benchmarking> Benchmarking { get; set; }
//        public virtual DbSet<BenchmarkingOld> BenchmarkingOld { get; set; }
//        public virtual DbSet<CapmaexMaintenanceAgewiseCostPc> CapmaexMaintenanceAgewiseCostPc { get; set; }
//        public virtual DbSet<Climate> Climate { get; set; }
//        public virtual DbSet<ColumnDictionary> ColumnDictionary { get; set; }
//        public virtual DbSet<CostCalculatedTable> CostCalculatedTable { get; set; }
//        public virtual DbSet<CostDetails> CostDetails { get; set; }
//        public virtual DbSet<CostTablePipe> CostTablePipe { get; set; }
//        public virtual DbSet<ProjectBankWsExt> ProjectBankWsExt { get; set; }
//        public virtual DbSet<ProjectBankWsOng> ProjectBankWsOng { get; set; }
//        public virtual DbSet<ProjectBankWsNew> ProjectBankWsNew { get; set; }
//        public virtual DbSet<ProjectBankSanExt> ProjectBankSanExt { get; set; }
//        public virtual DbSet<ProjectBankSanOng> ProjectBankSanOng { get; set; }
//        public virtual DbSet<ProjectBankSanNew> ProjectBankSanNew { get; set; }
//        public virtual DbSet<ProjectBankSkl> ProjectBankSkl { get; set; }
//        public virtual DbSet<ProjectBankHcf> ProjectBankHcf { get; set; }
//        public virtual DbSet<ProjectBankPtoilet> ProjectBankPtoilet { get; set; }
//        public virtual DbSet<CostingMethod> CostingMethod { get; set; }
//        public virtual DbSet<CriteriaForWashInPublicPlaces> CriteriaForWashInPublicPlaces { get; set; }
//        public virtual DbSet<CsExistingSanitationSystem> CsExistingSanitationSystem { get; set; }
//        public virtual DbSet<CsFiles> CsFiles { get; set; }
//        public virtual DbSet<PlanningProgress> PlanningProgress { get; set; }
//        public virtual DbSet<CsInitialDetails> CsInitialDetails { get; set; }
//        public virtual DbSet<CsNewSanitationSystem> CsNewSanitationSystem { get; set; }
//        public virtual DbSet<CsObservedLocations> CsObservedLocations { get; set; }
//        public virtual DbSet<CsObservedLocationsOld> CsObservedLocationsOld { get; set; }
//        public virtual DbSet<CsOngoingSanitationSystem> CsOngoingSanitationSystem { get; set; }
//        public virtual DbSet<CsProjectInfo> CsProjectInfo { get; set; }
//        public virtual DbSet<DashboardNotices> DashboardNotices { get; set; }
//        public virtual DbSet<DirectSupportCost> DirectSupportCost { get; set; }
//        public virtual DbSet<DirectSupportCs> DirectSupportCs { get; set; }
//        public virtual DbSet<DirectSupportWashInSchool> DirectSupportWashInSchool { get; set; }
//        public virtual DbSet<DisposalPoint> DisposalPoint { get; set; }
//        public virtual DbSet<District> District { get; set; }
//        public virtual DbSet<DistrictBoundary> DistrictBoundary { get; set; }
//        public virtual DbSet<DistrictLine> DistrictLine { get; set; }
//        public virtual DbSet<Documents> Documents { get; set; }
//        public virtual DbSet<DrainageLut> DrainageLut { get; set; }
//        public virtual DbSet<DrainagePoint> DrainagePoint { get; set; }
//        public virtual DbSet<DrnProjectInfo> DrnProjectInfo { get; set; }
//        public virtual DbSet<DssWsReferenceCost> DssWsReferenceCost { get; set; }
//        public virtual DbSet<ExistingSanitationPriority> ExistingSanitationPriority { get; set; }
//        public virtual DbSet<ExistingSanitationTreatmentCost> ExistingSanitationTreatmentCost { get; set; }
//        public virtual DbSet<ExistingWss> ExistingWss { get; set; }
//        public virtual DbSet<Faqs> Faqs { get; set; }
//        public virtual DbSet<PublicToiletOld> PublicToiletOld { get; set; }
//        public virtual DbSet<TblHouseholdOld> TblHouseholdOld { get; set; }
//        public virtual DbSet<TblSolidwasteManagement> TblSolidwasteManagements { get; set; }
//        public virtual DbSet<SolidwasteMngLut> SolidwasteMngLuts { get; set; }
//        public virtual DbSet<WasteMngLut> WasteMngLuts { get; set; }

//        public virtual DbSet<TblHcfOld> TblHcfOld { get; set; }
//        public virtual DbSet<FloodBenchmarking> FloodBenchmarking { get; set; }
//        public virtual DbSet<Functionality> Functionality { get; set; }
//        public virtual DbSet<FunctionalityHistory> FunctionalityHistory { get; set; }
//        public virtual DbSet<FunctionalityNewScore> FunctionalityNewScore { get; set; }
//        public virtual DbSet<FunctionalityScore> FunctionalityScore { get; set; }
//        public virtual DbSet<GrDistrict> GrDistrict { get; set; }
//        public virtual DbSet<GrFile> GrFile { get; set; }
//        public virtual DbSet<GrGeneral> GrGeneral { get; set; }
//        public virtual DbSet<GrMunicipality> GrMunicipality { get; set; }
//        public virtual DbSet<GrProblem> GrProblem { get; set; }
//        public virtual DbSet<GrProvince> GrProvince { get; set; }
//        public virtual DbSet<GrTblLogs> GrTblLogs { get; set; }
//        public virtual DbSet<HcfCols> HcfCols { get; set; }
//        public virtual DbSet<HcfLut> HcfLut { get; set; }
//        public virtual DbSet<HcfLut1> HcfLut1 { get; set; }
//        public virtual DbSet<HcfServiceLevelData> HcfServiceLevelData { get; set; }
//        public virtual DbSet<ServiceLevelData> ServiceLevelData { get; set; }
//        public virtual DbSet<ServiceLevelDataSkl> ServiceLevelDataSkl { get; set; }
//        public virtual DbSet<ServiceLevelDataHcf> ServiceLevelDataHcf { get; set; }
//        public virtual DbSet<HcfServiceStatus> HcfServiceStatus { get; set; }
//        public virtual DbSet<HcfWashPriority> HcfWashPriority { get; set; }
//        public virtual DbSet<HealthCareFacility> HealthCareFacility { get; set; }
//        public virtual DbSet<HhCapexFactorDependingOnYear> HhCapexFactorDependingOnYear { get; set; }
//        public virtual DbSet<HhCols> HhCols { get; set; }
//        public virtual DbSet<HhInvestmentSafelyManagedWater> HhInvestmentSafelyManagedWater { get; set; }
//        public virtual DbSet<HhLut> HhLut { get; set; }
//        public virtual DbSet<HhLut1> HhLut1 { get; set; }
//        public virtual DbSet<HhOpexSanitationComponent> HhOpexSanitationComponent { get; set; }
//        public virtual DbSet<HhSanitaionYearsPlanned> HhSanitaionYearsPlanned { get; set; }
//        public virtual DbSet<HhSanitationConsCost> HhSanitationConsCost { get; set; }
//        public virtual DbSet<HhSolidWasteComponentPerYear> HhSolidWasteComponentPerYear { get; set; }
//        public virtual DbSet<InsLut> InsLut { get; set; }
//        public virtual DbSet<InsLut1> InsLut1 { get; set; }
//        public virtual DbSet<Junction> Junction { get; set; }
//        public virtual DbSet<JunctionHistory> JunctionHistory { get; set; }
//        public virtual DbSet<LabRegistration> LabRegistration { get; set; }
//        public virtual DbSet<LandUse> LandUse { get; set; }
//        public virtual DbSet<LeftoutTaps> LeftoutTaps { get; set; }
//        public virtual DbSet<LeftoutTapsHistory> LeftoutTapsHistory { get; set; }
//        public virtual DbSet<LocalbodiesNepal> LocalbodiesNepal { get; set; }
//        public virtual DbSet<LutCs> LutCs { get; set; }
//        public virtual DbSet<LutDrainage> LutDrainage { get; set; }
//        public virtual DbSet<LutSolidWaste> LutSolidWaste { get; set; }
//        public virtual DbSet<LutSustainability> LutSustainability { get; set; }
//        public virtual DbSet<WqMigrate> WqMigrate { get; set; }
//        public virtual DbSet<LutUnserved> LutUnserved { get; set; }
//        public virtual DbSet<Manhole> Manhole { get; set; }
//        public virtual DbSet<MatInvData> MatInvData { get; set; }
//        public virtual DbSet<MatWashObsCount> MatWashObsCount { get; set; }
//        public virtual DbSet<MatWashWeekly> MatWashWeekly { get; set; }
//        public virtual DbSet<MonthDataComSan> MonthDataComSan { get; set; }
//        public virtual DbSet<MonthDataHcf> MonthDataHcf { get; set; }
//        public virtual DbSet<MonthDataPublicToilet> MonthDataPublicToilet { get; set; }
//        public virtual DbSet<MonthDataSchool> MonthDataSchool { get; set; }
//        public virtual DbSet<MonthDataTap> MonthDataTap { get; set; }
//        public virtual DbSet<MonthDataUnserved> MonthDataUnserved { get; set; }
//        public virtual DbSet<MunCodes> MunCodes { get; set; }
//        public virtual DbSet<Municipality> Municipality { get; set; }
//        public virtual DbSet<MunicipalityCensusPop2078> MunicipalityCensusPop2078 { get; set; }
//        public virtual DbSet<MunicipalityPopulation> MunicipalityPopulation { get; set; }
//        public virtual DbSet<MunicipalityRate> MunicipalityRate { get; set; }
//        public virtual DbSet<MunicipalitySectorwiseCostComponent> MunicipalitySectorwiseCostComponent { get; set; }
//        public virtual DbSet<MunicipalityWardFormation> MunicipalityWardFormation { get; set; }
//        public virtual DbSet<MunicipalityWiseHhPop> MunicipalityWiseHhPop { get; set; }
//        public virtual DbSet<NepalPopulation2074> NepalPopulation2074 { get; set; }
//        public virtual DbSet<NewSanitationPriority> NewSanitationPriority { get; set; }
//        public virtual DbSet<OngoingSanitationConstructionTrendYear> OngoingSanitationConstructionTrendYear { get; set; }
//        public virtual DbSet<OngoingSanitationPriority> OngoingSanitationPriority { get; set; }
//        public virtual DbSet<OpexPerToilet> OpexPerToilet { get; set; }
//        public virtual DbSet<OpexSanitationFacilities> OpexSanitationFacilities { get; set; }
//        public virtual DbSet<OpexSchemeComponent> OpexSchemeComponent { get; set; }
//        public virtual DbSet<Organization> Organization { get; set; }
//        public virtual DbSet<OsLut> OsLut { get; set; }
//        public virtual DbSet<OtherWaterUsage> OtherWaterUsage { get; set; }
//        public virtual DbSet<Outfall> Outfall { get; set; }
//        public virtual DbSet<Pipe> Pipe { get; set; }
//        public virtual DbSet<PipeDrawnRoute> PipeDrawnRoute { get; set; }
//        public virtual DbSet<PipeDrawnRouteHistory> PipeDrawnRouteHistory { get; set; }
//        public virtual DbSet<PipeHistory> PipeHistory { get; set; }
//        public virtual DbSet<PipeRoutePoint> PipeRoutePoint { get; set; }
//        public virtual DbSet<PipeRoutePointHistory> PipeRoutePointHistory { get; set; }
//        public virtual DbSet<PopServed> PopServed { get; set; }
//        public virtual DbSet<PopServedHistory> PopServedHistory { get; set; }
//        public virtual DbSet<PotentialSource> PotentialSource { get; set; }
//        public virtual DbSet<PpServiceData> PpServiceData { get; set; }
//        public virtual DbSet<ProjectCoverage> ProjectCoverage { get; set; }
//        public virtual DbSet<ProjectCoverageHistory> ProjectCoverageHistory { get; set; }
//        public virtual DbSet<ProjectDetails> ProjectDetails { get; set; }
//        public virtual DbSet<ProjectDetailsHistory> ProjectDetailsHistory { get; set; }
//        public virtual DbSet<Province> Province { get; set; }
//        public virtual DbSet<ProvinceCensusPop2078> ProvinceCensusPop2078 { get; set; }
//        public virtual DbSet<ProvinceHhServiceLevel> ProvinceHhServiceLevel { get; set; }
//        public virtual DbSet<ProvinceLine> ProvinceLine { get; set; }
//        public virtual DbSet<ProvinceNepal> ProvinceNepal { get; set; }
//        public virtual DbSet<ProvincePipeTubewellData> ProvincePipeTubewellData { get; set; }
//        public virtual DbSet<ProvinceSchoolStatus> ProvinceSchoolStatus { get; set; }
//        public virtual DbSet<ProvinceToiletType> ProvinceToiletType { get; set; }
//        public virtual DbSet<ProvinceToiletYesno> ProvinceToiletYesno { get; set; }
//        public virtual DbSet<ProvinceWashSystem> ProvinceWashSystem { get; set; }
//        public virtual DbSet<ProvinceWsTechnology> ProvinceWsTechnology { get; set; }
//        public virtual DbSet<PtCols> PtCols { get; set; }
//        public virtual DbSet<PtLut> PtLut { get; set; }
//        public virtual DbSet<PtLut1> PtLut1 { get; set; }
//        public virtual DbSet<PublicToilet> PublicToilet { get; set; }
//        public virtual DbSet<RainInlet> RainInlet { get; set; }
//        public virtual DbSet<Rainfall> Rainfall { get; set; }
//        public virtual DbSet<Rate> Rate { get; set; }
//        public virtual DbSet<Rates> Rates { get; set; }
//        public virtual DbSet<ReferenceData> ReferenceData { get; set; }
//        public virtual DbSet<Religion> Religion { get; set; }
//        public virtual DbSet<ReligionLut> ReligionLut { get; set; }
//        public virtual DbSet<ReportData> ReportData { get; set; }
//        public virtual DbSet<ReportDataHistory> ReportDataHistory { get; set; }
//        public virtual DbSet<Reservoir> Reservoir { get; set; }
//        public virtual DbSet<ReservoirHistory> ReservoirHistory { get; set; }
//        public virtual DbSet<RoutePoint> RoutePoint { get; set; }
//        public virtual DbSet<RoutePointOld> RoutePointOld { get; set; }
//        public virtual DbSet<SanitaryInspection> SanitaryInspection { get; set; }
//        public virtual DbSet<SanitaryInspectionTemplate> SanitaryInspectionTemplate { get; set; }
//        public virtual DbSet<SanitaryInspectionValues> SanitaryInspectionValues { get; set; }
//        public virtual DbSet<Sanitation> Sanitation { get; set; }
//        public virtual DbSet<SanitationBenchmarking> SanitationBenchmarking { get; set; }
//        public virtual DbSet<SanitationHistory> SanitationHistory { get; set; }
//        public virtual DbSet<SanitationSystemRepair> SanitationSystemRepair { get; set; }
//        public virtual DbSet<SchemePriority> SchemePriority { get; set; }
//        public virtual DbSet<SchemePriortization> SchemePriortization { get; set; }
//        public virtual DbSet<SchemeTotalCost> SchemeTotalCost { get; set; }
//        public virtual DbSet<SchoolCols> SchoolCols { get; set; }
//        public virtual DbSet<SchoolLut> SchoolLut { get; set; }
//        public virtual DbSet<SchoolLut1> SchoolLut1 { get; set; }
//        public virtual DbSet<SchoolWashStatusPriority> SchoolWashStatusPriority { get; set; }
//        public virtual DbSet<Skips> Skips { get; set; }
//        public virtual DbSet<SkipsOld> SkipsOld { get; set; }
//        public virtual DbSet<SolidWasteLut> SolidWasteLut { get; set; }
//        public virtual DbSet<StreetSweeping> StreetSweeping { get; set; }
//        public virtual DbSet<StreetSweepingOld> StreetSweepingOld { get; set; }
//        public virtual DbSet<Structure> Structure { get; set; }
//        public virtual DbSet<StructureHistory> StructureHistory { get; set; }
//        public virtual DbSet<Support> Support { get; set; }
//        public virtual DbSet<SupportHistory> SupportHistory { get; set; }
//        public virtual DbSet<Sustainability> Sustainability { get; set; }
//        public virtual DbSet<SustainabilityHistory> SustainabilityHistory { get; set; }
//        public virtual DbSet<SustainabilityNewScore> SustainabilityNewScore { get; set; }
//        public virtual DbSet<SustainabilityScore> SustainabilityScore { get; set; }
//        public virtual DbSet<SwProjectInfo> SwProjectInfo { get; set; }
//        public virtual DbSet<Table32> Table32 { get; set; }
//        public virtual DbSet<Table33> Table33 { get; set; }
//        public virtual DbSet<Table34> Table34 { get; set; }
//        public virtual DbSet<Table35> Table35 { get; set; }
//        public virtual DbSet<Table36> Table36 { get; set; }
//        public virtual DbSet<Table37> Table37 { get; set; }
//        public virtual DbSet<Table38> Table38 { get; set; }
//        public virtual DbSet<Table39> Table39 { get; set; }
//        public virtual DbSet<TableDictionary> TableDictionary { get; set; }
//        public virtual DbSet<Tap> Tap { get; set; }
//        public virtual DbSet<TapHistory> TapHistory { get; set; }
//        public virtual DbSet<TblDictionary> TblDictionary { get; set; }
//        public virtual DbSet<TblHousehold> TblHousehold { get; set; }
//        public virtual DbSet<TblInstitution> TblInstitution { get; set; }
//        public virtual DbSet<TblLog> TblLog { get; set; }
//        public virtual DbSet<TblOtherService> TblOtherService { get; set; }
//        public virtual DbSet<TblSchool> TblSchool { get; set; }
//        public virtual DbSet<TblSchoolOld> TblSchoolOld { get; set; }
//        public virtual DbSet<TblUrbanSanitation> TblUrbanSanitation { get; set; }
//        public virtual DbSet<ToiletConstructionCost> ToiletConstructionCost { get; set; }
//        public virtual DbSet<ToiletWashPriority> ToiletWashPriority { get; set; }
//        public virtual DbSet<Topography> Topography { get; set; }
//        public virtual DbSet<TubewellPrioritization> TubewellPrioritization { get; set; }
//        public virtual DbSet<Tubewells> Tubewells { get; set; }
//        public virtual DbSet<TubewellsHistory> TubewellsHistory { get; set; }
//        public virtual DbSet<UnservedCommunity> UnservedCommunity { get; set; }
//        public virtual DbSet<UnservedFiles> UnservedFiles { get; set; }
//        public virtual DbSet<UnservedInitialDetails> UnservedInitialDetails { get; set; }
//        public virtual DbSet<UnservedLut1> UnservedLut1 { get; set; }
//        public virtual DbSet<UnservedNewSystem> UnservedNewSystem { get; set; }
//        public virtual DbSet<UnservedOngoingSystem> UnservedOngoingSystem { get; set; }
//        public virtual DbSet<UnservedProjectInfo> UnservedProjectInfo { get; set; }
//        public virtual DbSet<UrbanSanitationLut1> UrbanSanitationLut1 { get; set; }
//        public virtual DbSet<UserDocumentation> UserDocumentation { get; set; }
//        public virtual DbSet<Users> Users { get; set; }
//        public virtual DbSet<UsersAccessDistrict> UsersAccessDistrict { get; set; }
//        public virtual DbSet<UsersAccessProCode> UsersAccessProCode { get; set; }
//        public virtual DbSet<VmwDetails> VmwDetails { get; set; }
//        public virtual DbSet<VmwPayment> VmwPayment { get; set; }
//        public virtual DbSet<Ward> Ward { get; set; }
//        public virtual DbSet<WardLine> WardLine { get; set; }
//        public virtual DbSet<WardwisePopulation> WardwisePopulation { get; set; }
//        public virtual DbSet<WashAgency> WashAgency { get; set; }
//        public virtual DbSet<WashFunding> WashFunding { get; set; }
//        public virtual DbSet<WashInPublicToilet> WashInPublicToilet { get; set; }
//        public virtual DbSet<WaterQualitySample> WaterQualitySample { get; set; }
//        public virtual DbSet<WaterQualityTemplate> WaterQualityTemplate { get; set; }
//        public virtual DbSet<WaterQualityValues> WaterQualityValues { get; set; }
//        public virtual DbSet<WaterSource> WaterSource { get; set; }
//        public virtual DbSet<WaterSourceCondition> WaterSourceCondition { get; set; }
//        public virtual DbSet<WaterSourceHistory> WaterSourceHistory { get; set; }
//        public virtual DbSet<WaterSourceMeasure> WaterSourceMeasure { get; set; }
//        public virtual DbSet<WaterSourceMeasureHistory> WaterSourceMeasureHistory { get; set; }
//        public virtual DbSet<WatersafeCommunity> WatersafeCommunity { get; set; }
//        public virtual DbSet<WgData> WgData { get; set; }
//        public virtual DbSet<WqTempMethodUsed> WqTempMethodUsed { get; set; }
//        public virtual DbSet<WgLut> WgLut { get; set; }
//        public virtual DbSet<WgLutData> WgLutData { get; set; }
//        public virtual DbSet<WpProgressStatus> WpProgressStatus { get; set; }
//        public virtual DbSet<WqGeneralLocation> WqGeneralLocation { get; set; }
//        public virtual DbSet<WqGeneralValues> WqGeneralValues { get; set; }
//        public virtual DbSet<WqIdentity> WqIdentity { get; set; }
//        public virtual DbSet<Wq_SurveillanceampleDetails> Wq_SurveillanceampleDetails { get; set; }
//        public virtual DbSet<WqView> WqView { get; set; }
//        public virtual DbSet<WsReferenceCost> WsReferenceCost { get; set; }
//        public virtual DbSet<WsTreatmentRef> WsTreatmentRef { get; set; }
//        public virtual DbSet<WssNewPriority> WssNewPriority { get; set; }
//        public virtual DbSet<WssOngoingPriority> WssOngoingPriority { get; set; }
//        public virtual DbSet<WuaAccountKeeping> WuaAccountKeeping { get; set; }
//        public virtual DbSet<WuaAgm> WuaAgm { get; set; }
//        public virtual DbSet<WuaAudit> WuaAudit { get; set; }
//        public virtual DbSet<WuaBank> WuaBank { get; set; }
//        public virtual DbSet<WuaDetails> WuaDetails { get; set; }
//        public virtual DbSet<WuaIncomeExp> WuaIncomeExp { get; set; }
//        public virtual DbSet<WuaInsurance> WuaInsurance { get; set; }
//        public virtual DbSet<WuaMeeting> WuaMeeting { get; set; }
//        public virtual DbSet<WuaSop> WuaSop { get; set; }
//        public virtual DbSet<WuaStructure> WuaStructure { get; set; }

//        public virtual DbSet<FunctionalityHistory> FunctionalityHistories { get; set; }
//        public virtual DbSet<JunctionHistory> JunctionHistories { get; set; }
//        public virtual DbSet<LeftoutTapsHistory> LeftoutTapsHistories { get; set; }
//        public virtual DbSet<PipeDrawnRouteHistory> PipeDrawnRouteHistories { get; set; }
//        public virtual DbSet<PipeHistory> PipeHistories { get; set; }
//        public virtual DbSet<PipeRoutePointHistory> PipeRoutePointHistories { get; set; }
//        public virtual DbSet<PopServedHistory> PopServedHistories { get; set; }
//        public virtual DbSet<ProjectCoverageHistory> ProjectCoverageHistories { get; set; }
//        public virtual DbSet<ProjectDetailsHistory> ProjectDetailsHistories { get; set; }
//        public virtual DbSet<ReportDataHistory> ReportDataHistories { get; set; }
//        public virtual DbSet<ReservoirHistory> ReservoirHistories { get; set; }
//        public virtual DbSet<SanitationHistory> SanitationHistories { get; set; }
//        public virtual DbSet<StructureHistory> StructureHistories { get; set; }
//        public virtual DbSet<SupportHistory> SupportHistories { get; set; }
//        public virtual DbSet<SustainabilityHistory> SustainabilityHistories { get; set; }
//        public virtual DbSet<TapHistory> TapHistories { get; set; }
//        public virtual DbSet<TubewellsHistory> TubewellsHistories { get; set; }
//        public virtual DbSet<WaterSourceHistory> WaterSourceHistories { get; set; }
//        public virtual DbSet<WaterSourceMeasureHistory> WaterSourceMeasureHistories { get; set; }
//        public virtual DbSet<TblUrbanSanitationOld> TblUrbanSanitationOld { get; set; }


//        public virtual DbSet<UserList> UserLists { get; set; }
//        public virtual DbSet<UserList1> UserLists1 { get; set; }
//        public virtual DbSet<UserList2> UserLists2 { get; set; }
//        public virtual DbSet<ProjectList> ProjectList { get; set; }
//        public virtual DbSet<FuncTapDetails> FuncTapDetails { get; set; }
//        public virtual DbSet<FuncWSDetails> FuncWSDetails { get; set; }
//        public virtual DbSet<FuncStrDetails> FuncStrDetails { get; set; }
//        public virtual DbSet<ProjectBasicDetails> ProjectBasicDetails { get; set; }
//        public virtual DbSet<SustainabilityDetails> SustainabilityDetails { get; set; }
//        public virtual DbSet<WSIncomeDetails> WSIncomeDetails { get; set; }
//        public virtual DbSet<PlanExistingWSS> PlanExistingWSS { get; set; }
//        public virtual DbSet<ExistingWSSPlanTool> ExistingWSSPlanTool { get; set; }
//        public virtual DbSet<ExistingMunicipalityRates> ExistingMunicipalityRates { get; set; }
//        public virtual DbSet<ExistingSantitationDetails> ExistingSantitationDetails { get; set; }
//        public virtual DbSet<HHSanitationOpexComponent> HHSanitationOpexComponent { get; set; }
//        public virtual DbSet<HHSanitationSolidWasteComponent> HHSanitationSolidWasteComponent { get; set; }
//        public virtual DbSet<SchoolDetails> SchoolDetails { get; set; }
//        public virtual DbSet<PublicToiletDetails> PublicToiletDetails { get; set; }
//        public virtual DbSet<HcfDetails> HcfDetails { get; set; }
//        public virtual DbSet<CommunitySanitationDetails> CommunitySanitationDetails { get; set; }
//        public virtual DbSet<NewWssDetails> NewWssDetails { get; set; }
//        public virtual DbSet<OngoingWssDetail> OngoingWssDetail { get; set; }
//        public virtual DbSet<TubewellDetails> TubewellDetails { get; set; }
//        public virtual DbSet<SyncFileCredential> SyncFileCredential { get; set; }
//        public virtual DbSet<CheckUser> CheckUser { get; set; }
//        public virtual DbSet<LocalLevelDetails> LocalLevelDetails { get; set; }
//        public virtual DbSet<UnservedCommunityDetails> UnservedCommunityDetails { get; set; }
//        public virtual DbSet<OngoingSanitationDetails> OngoingSanitationDetails { get; set; }
//        public virtual DbSet<NewSanitationDetails> NewSanitationDetails { get; set; }
//        public virtual DbSet<HouseholdServed> HouseholdServed { get; set; }
//        public virtual DbSet<PhysicalStructure> PhysicalStructure { get; set; }
//        public virtual DbSet<InventoryReport> InventoryReport { get; set; }
//        public virtual DbSet<InstitutionDetail> InstitutionDetail { get; set; }
//        public virtual DbSet<FuncProjectDetails> FuncProjectDetails { get; set; }
//        public virtual DbSet<FunctionalityScoreDetails> FunctionalityScoreDetails { get; set; }
//        public virtual DbSet<FunctionalityMunWiseDetails> FunctionalityMunWiseDetails { get; set; }
//        public virtual DbSet<FunctionalityDistrictWiseDetail> FunctionalityDistrictWiseDetail { get; set; }
//        public virtual DbSet<AgencyProjectDetails> AgencyProjectDetails { get; set; }
//        public virtual DbSet<AgencyProjectCount> AgencyProjectCount { get; set; }
//        public virtual DbSet<TapSummaryDetails> TapSummaryDetails { get; set; }
//        public virtual DbSet<AgencySummaryDetail> AgencySummaryDetail { get; set; }

//        //CostEstimation
//        public virtual DbSet<PipeCondition> PipeCondition { get; set; }
//        public virtual DbSet<TapPropertyDetail> TapPropertyDetail { get; set; }
//        public virtual DbSet<WsDetails> WsDetails { get; set; }
//        public virtual DbSet<StructureDetails> StructureDetails { get; set; }
//        public virtual DbSet<RvtDetails> RvtDetails { get; set; }
//        public virtual DbSet<TapQualityDetail> TapQualityDetail { get; set; }
//        public virtual DbSet<PipeBurialCondition> PipeBurialCondition { get; set; }
//        public virtual DbSet<RvtAdequacyDetail> RvtAdequacyDetail { get; set; }

//        // Functionality Report
//        public virtual DbSet<ProjDetails> ProjDetails { get; set; }
//        public virtual DbSet<WsucComposition> WsucComposition { get; set; }
//        public virtual DbSet<VmwNumDetails> VmwNumDetails { get; set; }
//        public virtual DbSet<WsConditionDetail> WsConditionDetail { get; set; }
//        public virtual DbSet<TapFlowConditionDetail> TapFlowConditionDetail { get; set; }
//        public virtual DbSet<OperationRatioDetail> OperationRatioDetail { get; set; }
//        public virtual DbSet<StructureCountDetails> StructureCountDetails { get; set; }
//        public virtual DbSet<IntakeCountDetail> IntakeCountDetail { get; set; }
//        public virtual DbSet<SchemeRankDetail> SchemeRankDetail { get; set; }
//        public virtual DbSet<wsSourceDetails> wsSourceDetails { get; set; }
//        /*public virtual DbSet<QueryBuilderModel> QueryBuilderModel { get; set; }*/
//        public virtual DbSet<AgencyDetails> AgencyDetails { get; set; }
//        public virtual DbSet<MunAgencyDetails> MunAgencyDetails { get; set; }
//        public virtual DbSet<MunDetails> MunDetails { get; set; }
//        public virtual DbSet<MunAgencyCount> MunAgencyCount { get; set; }
//        public virtual DbSet<MunTapFlowDetails> MunTapFlowDetails { get; set; }
//        public virtual DbSet<MunProjectListDetail> MunProjectListDetail { get; set; }
//        public virtual DbSet<MunWsDetails> MunWsDetails { get; set; }
//        public virtual DbSet<MunSafeYields> MunSafeYields { get; set; }
//        public virtual DbSet<MunStructureDetails> MunStructureDetails { get; set; }
//        public virtual DbSet<MunTapIntDetails> MunTapIntDetails { get; set; }
//        public virtual DbSet<MunRvtDetails> MunRvtDetails { get; set; }
//        public virtual DbSet<MunPipeAssessDetails> MunPipeAssessDetails { get; set; }
//        public virtual DbSet<MunPipeBurialDetails> MunPipeBurialDetails { get; set; }
//        public virtual DbSet<MunSchemeLeakage> MunSchemeLeakage { get; set; }
//        public virtual DbSet<MunRvtAdequacy> MunRvtAdequacy { get; set; }
//        public virtual DbSet<MunSchemeCondition> MunSchemeCondition { get; set; }
//        public virtual DbSet<SustainabilityAssessment> SustainabilityAssessment { get; set; }
//        public virtual DbSet<MunSystemCategorization> MunSystemCategorization { get; set; }
//        public virtual DbSet<TapWiseScoreDetails> TapWiseScoreDetails { get; set; }
//        public virtual DbSet<MunFuncTapDetails> MunFuncTapDetails { get; set; }
//        public virtual DbSet<FuncSchemeAgeDetail> FuncSchemeAgeDetail { get; set; }
//        public virtual DbSet<SusSchemeAgeDetail> SusSchemeAgeDetail { get; set; }
//        public virtual DbSet<MunFuncSchemeAgeDetail> MunFuncSchemeAgeDetail { get; set; }
//        public virtual DbSet<MunImpAgencyDetail> MunImpAgencyDetail { get; set; }
//        public virtual DbSet<MunCostContribution> MunCostContribution { get; set; }
//        public virtual DbSet<DataSummaryHcf> DataSummaryHcf { get; set; }
//        public virtual DbSet<DataSummarySkl> DataSummarySkl { get; set; }
//        public virtual DbSet<DataSummaryTap> DataSummaryTap { get; set; }
//        public virtual DbSet<DataSummaryMunSlWss> DataSummaryMunSlWss { get; set; }
//        public virtual DbSet<DataSummaryHhSan> DataSummaryHhSan { get; set; }
//        public virtual DbSet<MunSummary1> MunSummary1 { get; set; }
//        public virtual DbSet<MunSummary2> MunSummary2 { get; set; }
//        public virtual DbSet<MunSummary3> MunSummary3 { get; set; }

//        //Map
//        public virtual DbSet<MunDistrictDetail> MunDistrictDetail { get; set; }
//        public virtual DbSet<MuniExtent> MuniExtent { get; set; }
//        public virtual DbSet<DistrictExtent> DistrictExtent { get; set; }
//        public virtual DbSet<ProvinceExtent> ProvinceExtent { get; set; }
//        public virtual DbSet<ProjectExtent> ProjectExtent { get; set; }
//        public virtual DbSet<ProjectDetailData> ProjectDetailData { get; set; }
//        public virtual DbSet<PrintData> PrintData { get; set; }
//        public virtual DbSet<SWMap> SWMaps { get; set; }

//        //MapEdit
//        public virtual DbSet<LayersList> LayersLists { get; set; }
//        public virtual DbSet<LayerDetail> LayerDetails { get; set; }

//        //CWIS Tables
//        public virtual DbSet<ContainmentAccessibility> ContainmentAccessibility { get; set; }
//        public virtual DbSet<DisposalReuse> DisposalReuse { get; set; }
//        public virtual DbSet<EmptyingTransportation> EmptyingTransportation { get; set; }
//        public virtual DbSet<GenderInclusion> GenderInclusion { get; set; }
//        public virtual DbSet<PolicyAwareness> PolicyAwareness { get; set; }
//        public virtual DbSet<RespondentInfo> RespondentInfo { get; set; }
//        public virtual DbSet<SanitationFacilities> SanitationFacilities { get; set; }
//        public virtual DbSet<SolidWM> SolidWM { get; set; }
//        public virtual DbSet<StormWaterMgmt> StormWaterMgmt { get; set; }
//        public virtual DbSet<WaterSourceMgmt> WaterSourceMgmt { get; set; }

//        //WashSummary
//        public virtual DbSet<WSBenifittedHh> WSBenifittedHh { get; set; }
//        public virtual DbSet<WSFunctionality> WSFunctionality { get; set; }
//        public virtual DbSet<WSHhSource> WSHhSource { get; set; }
//        public virtual DbSet<WSHhStatusAccess> WSHhStatusAccess { get; set; }
//        public virtual DbSet<WsLifeSpan> WsLifeSpan { get; set; }
//        public virtual DbSet<WSMajorStructure> WSMajorStructure { get; set; }
//        public virtual DbSet<WsTapStructure> WsTapStructure { get; set; }
//        public virtual DbSet<WSRegularityStatus> WSRegularityStatus { get; set; }
//        public virtual DbSet<WSSustainability> WSSustainability { get; set; }

//        //School Summary
//        public virtual DbSet<SchoolStatus> SchoolStatus { get; set; }
//        public virtual DbSet<SchoolStarCompilation> SchoolStarCompilation { get; set; }
//        public virtual DbSet<SchoolMHM> SchoolMHM { get; set; }
//        public virtual DbSet<SchoolWaterSupply> SchoolWaterSupply { get; set; }
//        public virtual DbSet<SchoolHandWash> SchoolHandWash { get; set; }
//        public virtual DbSet<SchoolWasteManagement> SchoolWasteManagement { get; set; }
//        public virtual DbSet<SchoolManagementMechanism> SchoolManagementMechanism { get; set; }
//        public virtual DbSet<SchoolSanitationStatus> SchoolSanitationStatus { get; set; }

//        //HCF Summary
//        public virtual DbSet<HCFDrinkingWater> HCFDrinkingWater { get; set; }
//        public virtual DbSet<HCFToilet> HCFToilet { get; set; }
//        public virtual DbSet<HcfToiletCount> HcfToiletCount { get; set; }       // For NEpReport
//        public virtual DbSet<HHWaterSourceCount> HHWaterSourceCount { get; set; }       // For NEpReport
//        public virtual DbSet<HHCommunityData> HHCommunityData { get; set; }       // For NEpReport
//        public virtual DbSet<HCFWaste> HCFWaste { get; set; }

//        //HOusehold Summary
//        public virtual DbSet<HSDrinkingWater> HSDrinkingWater { get; set; }
//        public virtual DbSet<HSWaterSupplyLadder> HSWaterSupplyLadder { get; set; }
//        public virtual DbSet<HSSanitationLadder> HSSanitationLadder { get; set; }
//        public virtual DbSet<HSToilet> HSToilet { get; set; }
//        public virtual DbSet<HSHandWash> HSHandWash { get; set; }
//        public virtual DbSet<HSThosPadartha> HSThosPadartha { get; set; }
//        public virtual DbSet<HSDishaJanya> HSDishaJanya { get; set; }

//        // API REPORT
//        public virtual DbSet<ActivitySummaryFields> ActivitySummaryFields { get; set; }
//        public virtual DbSet<MunicipalityFields> MunicipalityFields { get; set; }
//        public virtual DbSet<PopAndHhs> PopAndHhs { get; set; }
//        public virtual DbSet<MunicipalityWashSystemField> MunicipalityWashSystemField { get; set; }
//        public virtual DbSet<MunicipalityWashSystemFieldNep> MunicipalityWashSystemFieldNep { get; set; }

//        public virtual DbSet<TapCondtion> TapConditions { get; set; }

//        public virtual DbSet<SchemeCondition> SchemeConditions { get; set; }
//        public virtual DbSet<SchemeAssess> SchemeAssesses { get; set; }
//        public virtual DbSet<FuncTotalProject> FuncTotalProjects { get; set; }

//        public virtual DbSet<FunctionalityAssessment> FunctionalityAssessments { get; set; }
//        public virtual DbSet<WsucFea> WsucFeas { get; set; }
//        public virtual DbSet<VmwProjectDetail> VmwProjectDetails { get; set; }
//        public virtual DbSet<MunWardwisePopulation> MunWardwisePopulation { get; set; }
//        public virtual DbSet<ReligionPercent> ReligionPercent { get; set; }
//        public virtual DbSet<AgricultureproductList> AgricultureproductList { get; set; }
//        public virtual DbSet<AgroecologicalZones> AgroecologicalZones { get; set; }
//        public virtual DbSet<SchoolLevelCount> SchoolLevelCount { get; set; }

//        //aDDED by ppap LM
//        public virtual DbSet<SummaryofBridgingtheGap_HCF> SummaryofBridgingtheGap_HCF { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGap_PP> SummaryofBridgingtheGap_PP { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGap_School> SummaryofBridgingtheGap_School { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGap_SH> SummaryofBridgingtheGap_SH { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGap_WS> SummaryofBridgingtheGap_WS { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGapFSM> SummaryofBridgingtheGapFSM { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGapSWM> SummaryofBridgingtheGapSWM { get; set; }
//        public virtual DbSet<SummaryofBridgingtheGapWWTP> SummaryofBridgingtheGapWWTP { get; set; }


//        //Water Quality
//        public virtual DbSet<WqGeneralValue> WqGeneralValue { get; set; }
//        public virtual DbSet<Wq_SurveillanceufficientTapPopulation> Wq_SurveillanceufficientTapPopulation { get; set; }
//        public virtual DbSet<WqParameterData> WqParameterData { get; set; }

//        //Dashboard
//        public virtual DbSet<MonthlyObservationPt> MonthlyObservationPt { get; set; }
//        public virtual DbSet<MonthlyObservationHh> MonthlyObservationHh { get; set; }
//        public virtual DbSet<MonthlyObservationHcf> MonthlyObservationHcf { get; set; }
//        public virtual DbSet<MonthlyObservationSch> MonthlyObservationSch { get; set; }
//        public virtual DbSet<MonthlyObservationCs> MonthlyObservationCs { get; set; }
//        public virtual DbSet<MonthlyObservationUn> MonthlyObservationUn { get; set; }
//        public virtual DbSet<MonthlyObservationTap> MonthlyObservationTap { get; set; }
//        public virtual DbSet<NewWashDatahh> NewWashDatahh { get; set; }
//        public virtual DbSet<WashObsCount> WashObsCount { get; set; }
//        public virtual DbSet<InvCountData> InvCountData { get; set; }
//        public virtual DbSet<TotalInvestmentGap> TotalInvestmentGap { get; set; }
//        public virtual DbSet<Toilethh> Toilethh { get; set; }
//        public virtual DbSet<Notice> Notice { get; set; }
//        public virtual DbSet<Fsmoptions> Fsmoptions { get; set; }
//        public virtual DbSet<LabDetails> LabDetails { get; set; }
//        public virtual DbSet<LabValue> LabValue { get; set; }
//        public virtual DbSet<LabInfo> LabInfo { get; set; }
//        public virtual DbSet<WaterQualityValuesForm> WaterQualityValuesForm { get; set; }
//        public virtual DbSet<LabModule> LabModule { get; set; }
//        public virtual DbSet<AgencyWashplan> AgencyWashplan { get; set; }

//        //Wash Gov Del 
//        public virtual DbSet<WgDelReturn> WgDelReturn { get; set; }
//        public virtual DbSet<HcfServiceStatus> HcfServiceStatuses { get; set; }
//        public virtual DbSet<ProvinceHhServiceLevel> ProvinceHhServiceLevels { get; set; }
//        public virtual DbSet<ProvinceSchoolStatus> ProvinceSchoolStatuses { get; set; }
//        public virtual DbSet<ProvinceToiletType> ProvinceToiletTypes { get; set; }
//        public virtual DbSet<ProvinceToiletYesno> ProvinceToiletYesnos { get; set; }
//        public virtual DbSet<ProvinceWashSystem> ProvinceWashSystems { get; set; }
//        public virtual DbSet<ProvinceWsTechnology> ProvinceWsTechnologies { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseNpgsql(AppConfiguration.ConnectionString, o => o.UseNetTopologySuite());
//            }
//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasPostgresExtension("postgis");

//            modelBuilder.Entity<WgLut>(entity =>
//            {
//                entity.HasKey(e => new { e.Id, e.IndexVal })
//                         .HasName("wg_lut_id");

//                entity.ToTable("wg_lut", "wash_governance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .ValueGeneratedOnAdd();

//                entity.Property(e => e.IndexVal)
//                         .HasColumnName("index_val")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ColInfo)
//                         .HasColumnName("col_info")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ColName)
//                         .HasColumnName("col_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InputType)
//                         .HasColumnName("input_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelGrp)
//                         .HasColumnName("label_grp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelGrpid)
//                         .HasColumnName("label_grpid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelQuestion)
//                         .HasColumnName("label_question")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WgLutData>(entity =>
//            {
//                entity.ToTable("wg_lut_data", "wash_governance");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.SurveyYear).HasColumnName("survey_year");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.AgencyInvestigationByMunicipality)
//                         .HasColumnName("agency_investigation_by_municipality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SurveyDate)
//                         .HasColumnName("survey_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BudgetHcf).HasColumnName("budget_hcf");

//                entity.Property(e => e.BudgetHh).HasColumnName("budget_hh");

//                entity.Property(e => e.BudgetPp).HasColumnName("budget_pp");

//                entity.Property(e => e.BudgetSchool).HasColumnName("budget_school");

//                entity.Property(e => e.CapacityStrentheningMpAvailable)
//                         .HasColumnName("capacity_strenthening_mp_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CleanlinessBudgetCapex).HasColumnName("cleanliness_budget_capex");

//                entity.Property(e => e.CleanlinessBudgetCapmanex).HasColumnName("cleanliness_budget_capmanex");

//                entity.Property(e => e.CleanlinessBudgetDs).HasColumnName("cleanliness_budget_ds");

//                entity.Property(e => e.CleanlinessBudgetOp).HasColumnName("cleanliness_budget_op");

//                entity.Property(e => e.CleanlinessBudgetTotal).HasColumnName("cleanliness_budget_total");

//                entity.Property(e => e.CleanlinessExpenseCapex).HasColumnName("cleanliness_expense_capex");

//                entity.Property(e => e.CleanlinessExpenseCapmanex).HasColumnName("cleanliness_expense_capmanex");

//                entity.Property(e => e.CleanlinessExpenseDs).HasColumnName("cleanliness_expense_ds");

//                entity.Property(e => e.CleanlinessExpenseOp).HasColumnName("cleanliness_expense_op");

//                entity.Property(e => e.CleanlinessExpenseTotal).HasColumnName("cleanliness_expense_total");

//                entity.Property(e => e.ExpenditureInWashPastYear).HasColumnName("expenditure_in_wash_past_year");

//                entity.Property(e => e.ExpenseHcf).HasColumnName("expense_hcf");

//                entity.Property(e => e.ExpenseHh).HasColumnName("expense_hh");

//                entity.Property(e => e.ExpensePp).HasColumnName("expense_pp");

//                entity.Property(e => e.ExpenseSchool).HasColumnName("expense_school");

//                entity.Property(e => e.HcfDiskRiskFilename)
//                         .HasColumnName("hcf_disk_risk_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfEnvCleanlinessFilename)
//                         .HasColumnName("hcf_env_cleanliness_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfMenstrualHygieneGuidelineFilename)
//                         .HasColumnName("hcf_menstrual_hygiene_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfOtherFilename)
//                         .HasColumnName("hcf_other_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfWashHcfFilename)
//                         .HasColumnName("hcf_wash_hcf_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfWasteGuidelineFilename)
//                         .HasColumnName("hcf_waste_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncomeHhOwn).HasColumnName("income_hh_own");

//                entity.Property(e => e.IncomeIgno).HasColumnName("income_igno");

//                entity.Property(e => e.IncomeLocalGov).HasColumnName("income_local_gov");

//                entity.Property(e => e.IncomeProvinceGov).HasColumnName("income_province_gov");

//                entity.Property(e => e.IncomeTariff).HasColumnName("income_tariff");

//                entity.Property(e => e.IntegratedOthersFilename)
//                         .HasColumnName("integrated_others_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashActFilename)
//                         .HasColumnName("integrated_wash_act_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashContingencyFilename)
//                         .HasColumnName("integrated_wash_contingency_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashGuidelineFilename)
//                         .HasColumnName("integrated_wash_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashPolicyFilename)
//                         .HasColumnName("integrated_wash_policy_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InvestmentByAgency)
//                         .HasColumnName("investment_by_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisDataInPlanning)
//                         .HasColumnName("mis_data_in_planning")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisFocalPersonAvailable)
//                         .HasColumnName("mis_focal_person_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisFocalPersonContact)
//                         .HasColumnName("mis_focal_person_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisFocalPersonName)
//                         .HasColumnName("mis_focal_person_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisUpdated)
//                         .HasColumnName("mis_updated")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("muncode")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MwashCcFormation)
//                         .HasColumnName("mwash_cc_formation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NwashUnitEmployee).HasColumnName("nwash_unit_employee");

//                entity.Property(e => e.NwashUnitEstablished)
//                         .HasColumnName("nwash_unit_established")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpOtherFilename)
//                         .HasColumnName("pp_other_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpToiletConstructionFilename)
//                         .HasColumnName("pp_toilet_construction_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpToiletGuidelineFilename)
//                         .HasColumnName("pp_toilet_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpWashFilename)
//                         .HasColumnName("pp_wash_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid).HasColumnName("pro_uuid");

//                entity.Property(e => e.SanCwisGuidelineFilename)
//                         .HasColumnName("san_cwis_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanExpenseDs).HasColumnName("san_expense_ds");

//                entity.Property(e => e.SanExpenseTotal).HasColumnName("san_expense_total");

//                entity.Property(e => e.SanLocalmasterplanFilename)
//                         .HasColumnName("san_localmasterplan_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanOdfGuidelineFilename)
//                         .HasColumnName("san_odf_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanOtherFilename)
//                         .HasColumnName("san_other_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanSopFilename)
//                         .HasColumnName("san_sop_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanToiletConsGuidelineFilename)
//                         .HasColumnName("san_toilet_cons_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchDisasterRiskFilename)
//                         .HasColumnName("sch_disaster_risk_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchEnvironmentCleanlinessFilename)
//                         .HasColumnName("sch_environment_cleanliness_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchHygieneFilename)
//                         .HasColumnName("sch_hygiene_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchOtherFilename)
//                         .HasColumnName("sch_other_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchSchoolGuidelineFilename)
//                         .HasColumnName("sch_school_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SnExpenseDs).HasColumnName("sn_expense_ds");

//                entity.Property(e => e.SnExpenseTotal).HasColumnName("sn_expense_total");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WgLutId).HasColumnName("wg_lut_id");

//                entity.Property(e => e.WashActivitiesPerformed)
//                         .HasColumnName("wash_activities_performed")
//                         .HasColumnType("character varying[]");

//                entity.Property(e => e.WashAssociatedAvailability)
//                         .HasColumnName("wash_associated_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashAssociatedAgency)
//                         .HasColumnName("wash_associated_agency")
//                         .HasColumnType("character varying[]");

//                entity.Property(e => e.WashBudget).HasColumnName("wash_budget");

//                entity.Property(e => e.WashFocalPersonAvailable)
//                         .HasColumnName("wash_focal_person_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashFocalPersonContact)
//                         .HasColumnName("wash_focal_person_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashFocalPersonName)
//                         .HasColumnName("wash_focal_person_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashHumanResourceSufficiency)
//                         .HasColumnName("wash_human_resource_sufficiency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashNontechnicalHumanResource).HasColumnName("wash_nontechnical_human_resource");

//                entity.Property(e => e.WashTechincalHumanResource).HasColumnName("wash_techincal_human_resource");

//                entity.Property(e => e.WashTotalHumanResource).HasColumnName("wash_total_human_resource");

//                entity.Property(e => e.WashplanImplementation)
//                         .HasColumnName("washplan_implementation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteWaterQualityTest)
//                         .HasColumnName("waste_water_quality_test")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityMeasurementAvailability)
//                         .HasColumnName("water_quality_measurement_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityMeasurementTool)
//                         .HasColumnName("water_quality_measurement_tool")
//                         .HasColumnType("character varying[]");

//                entity.Property(e => e.WpFormulationNwash)
//                         .HasColumnName("wp_formulation_nwash")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpImplementationInMun)
//                         .HasColumnName("wp_implementation_in_mun")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsBudgetCapex).HasColumnName("ws_budget_capex");

//                entity.Property(e => e.WsBudgetCapmanex).HasColumnName("ws_budget_capmanex");

//                entity.Property(e => e.WsBudgetDs).HasColumnName("ws_budget_ds");

//                entity.Property(e => e.WsBudgetOp).HasColumnName("ws_budget_op");

//                entity.Property(e => e.WsBudgetTotal).HasColumnName("ws_budget_total");

//                entity.Property(e => e.WsDwQualityStdFilename)
//                         .HasColumnName("ws_dw_quality_std_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsExpenseCapex).HasColumnName("ws_expense_capex");

//                entity.Property(e => e.WsExpenseCapmanex).HasColumnName("ws_expense_capmanex");

//                entity.Property(e => e.WsExpenseDs).HasColumnName("ws_expense_ds");

//                entity.Property(e => e.WsExpenseOp).HasColumnName("ws_expense_op");

//                entity.Property(e => e.WsExpenseTotal).HasColumnName("ws_expense_total");

//                entity.Property(e => e.WsOthersFilename)
//                         .HasColumnName("ws_others_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsSafeCommGuidelineFilename)
//                         .HasColumnName("ws_safe_comm_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsSafetyAuditFilename)
//                         .HasColumnName("ws_safety_audit_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsSopFilename)
//                         .HasColumnName("ws_sop_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsTariffRegFilename)
//                         .HasColumnName("ws_tariff_reg_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsWqGuidelineFilename)
//                         .HasColumnName("ws_wq_guideline_filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EnteredBy)
//                         .HasColumnName("entered_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashFocalPersonOption)
//                         .HasColumnName("wash_focal_person_option")
//                         .HasColumnType("character varying[]");

//                entity.Property(e => e.MisFocalPersonOption)
//                         .HasColumnName("mis_focal_person_option")
//                         .HasColumnType("character varying[]");

//                entity.Property(e => e.Status).HasColumnName("status");

//                //DESCRIPTION

//                entity.Property(e => e.IntegratedWashActDescription)
//                    .HasColumnName("integrated_wash_act_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashPolicyDescription)
//                    .HasColumnName("integrated_wash_policy_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashGuidelineDescription)
//                    .HasColumnName("integrated_wash_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedWashContingencyDescription)
//                    .HasColumnName("integrated_wash_contingency_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IntegratedOthersDescription)
//                    .HasColumnName("integrated_others_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsWqGuidelineDescription)
//                    .HasColumnName("ws_wq_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsDwQualityStdDescription)
//                    .HasColumnName("ws_dw_quality_std_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsSafetyAuditDescription)
//                    .HasColumnName("ws_safety_audit_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsSafeCommGuidelineDescription)
//                    .HasColumnName("ws_safe_comm_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsTariffRegDescription)
//                    .HasColumnName("ws_tariff_reg_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsSopDescription)
//                    .HasColumnName("ws_sop_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WsOthersDescription)
//                    .HasColumnName("ws_others_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SanLocalmasterplanDescription)
//                    .HasColumnName("san_localmasterplan_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SanOdfGuidelineDescription)
//                    .HasColumnName("san_odf_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SanToiletConsGuidelineDescription)
//                    .HasColumnName("san_toilet_cons_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SanCwisGuidelineDescription)
//                    .HasColumnName("san_cwis_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SanSopDescription)
//                    .HasColumnName("san_sop_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SanOtherDescription)
//                    .HasColumnName("san_other_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SchSchoolGuidelineDescription)
//                    .HasColumnName("sch_school_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SchEnvironmentCleanlinessDescription)
//                    .HasColumnName("sch_environment_cleanliness_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SchDisasterRiskDescription)
//                    .HasColumnName("sch_disaster_risk_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SchHygieneDescription)
//                    .HasColumnName("sch_hygiene_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SchOtherDescription)
//                    .HasColumnName("sch_other_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfWashHcfDescription)
//                    .HasColumnName("hcf_wash_hcf_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfEnvCleanlinessDescription)
//                    .HasColumnName("hcf_env_cleanliness_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfDiskRiskDescription)
//                    .HasColumnName("hcf_disk_risk_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfMenstrualHygieneGuidelineDescription)
//                    .HasColumnName("hcf_menstrual_hygiene_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfWasteGuidelineDescription)
//                    .HasColumnName("hcf_waste_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfOtherDescription)
//                    .HasColumnName("hcf_other_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PpWashDescription)
//                    .HasColumnName("pp_wash_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PpToiletGuidelineDescription)
//                    .HasColumnName("pp_toilet_guideline_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PpToiletConstructionDescription)
//                    .HasColumnName("pp_toilet_construction_description")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PpOtherDescription)
//                    .HasColumnName("pp_other_description")
//                    .HasColumnType("character varying");

//            });

//            modelBuilder.Entity<AgewiseCapMaintenanceCost>(entity =>
//            {
//                entity.ToTable("agewise_cap_maintenance_cost", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AdoptedCost).HasColumnName("adopted_cost");

//                entity.Property(e => e.RefDataPer).HasColumnName("ref_data_per");

//                entity.Property(e => e.SchemeAge)
//                         .HasColumnName("scheme_age")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AgricultureProduct>(entity =>
//            {
//                entity.ToTable("agriculture_product", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Category)
//                         .HasColumnName("category")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DYear).HasColumnName("d_year");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Source)
//                         .HasColumnName("source")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<AgroEcological>(entity =>
//            {
//                entity.ToTable("agro_ecological", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DYear).HasColumnName("d_year");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Source)
//                         .HasColumnName("source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Zone)
//                         .HasColumnName("zone")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<HcfCostYrly>(entity =>
//            {
//                entity.ToTable("hcf_cost_yrly", "yearly_cost");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Year0).HasColumnName("year0");
//                entity.Property(e => e.Year1).HasColumnName("year1");
//                entity.Property(e => e.Year2).HasColumnName("year2");
//                entity.Property(e => e.Year3).HasColumnName("year3");
//                entity.Property(e => e.Year4).HasColumnName("year4");
//                entity.Property(e => e.Year5).HasColumnName("year5");
//                entity.Property(e => e.Year6).HasColumnName("year6");
//                entity.Property(e => e.Year7).HasColumnName("year7");
//                entity.Property(e => e.Year8).HasColumnName("year8");
//                entity.Property(e => e.Year9).HasColumnName("year9");
//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostComp)
//                         .HasColumnName("cost_comp")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SanCostYrly>(entity =>
//            {
//                entity.ToTable("san_cost_yrly", "yearly_cost");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Year0).HasColumnName("year0");
//                entity.Property(e => e.Year1).HasColumnName("year1");
//                entity.Property(e => e.Year2).HasColumnName("year2");
//                entity.Property(e => e.Year3).HasColumnName("year3");
//                entity.Property(e => e.Year4).HasColumnName("year4");
//                entity.Property(e => e.Year5).HasColumnName("year5");
//                entity.Property(e => e.Year6).HasColumnName("year6");
//                entity.Property(e => e.Year7).HasColumnName("year7");
//                entity.Property(e => e.Year8).HasColumnName("year8");
//                entity.Property(e => e.Year9).HasColumnName("year9");
//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostComp)
//                         .HasColumnName("cost_comp")
//                         .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<SchoolCostYrly>(entity =>
//            {
//                entity.ToTable("school_cost_yrly", "yearly_cost");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Year0).HasColumnName("year0");
//                entity.Property(e => e.Year1).HasColumnName("year1");
//                entity.Property(e => e.Year2).HasColumnName("year2");
//                entity.Property(e => e.Year3).HasColumnName("year3");
//                entity.Property(e => e.Year4).HasColumnName("year4");
//                entity.Property(e => e.Year5).HasColumnName("year5");
//                entity.Property(e => e.Year6).HasColumnName("year6");
//                entity.Property(e => e.Year7).HasColumnName("year7");
//                entity.Property(e => e.Year8).HasColumnName("year8");
//                entity.Property(e => e.Year9).HasColumnName("year9");
//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostComp)
//                         .HasColumnName("cost_comp")
//                         .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<PublicPlaceCostYrly>(entity =>
//            {
//                entity.ToTable("public_place_cost_yrly", "yearly_cost");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Year0).HasColumnName("year0");
//                entity.Property(e => e.Year1).HasColumnName("year1");
//                entity.Property(e => e.Year2).HasColumnName("year2");
//                entity.Property(e => e.Year3).HasColumnName("year3");
//                entity.Property(e => e.Year4).HasColumnName("year4");
//                entity.Property(e => e.Year5).HasColumnName("year5");
//                entity.Property(e => e.Year6).HasColumnName("year6");
//                entity.Property(e => e.Year7).HasColumnName("year7");
//                entity.Property(e => e.Year8).HasColumnName("year8");
//                entity.Property(e => e.Year9).HasColumnName("year9");
//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostComp)
//                         .HasColumnName("cost_comp")
//                         .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<TrainingHeld>(entity =>
//            {
//                entity.ToTable("training_held", "system");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.TrainingHappening).HasColumnName("training_happening")
//                .HasColumnType("boolean");
//                entity.Property(e => e.StartDate)
//                        .HasColumnName("start_date")
//                        .HasColumnType("date");
//                entity.Property(e => e.StartedBy)
//                         .HasColumnName("started_by")
//                         .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<WssCostYrly>(entity =>
//            {
//                entity.ToTable("wss_cost_yrly", "yearly_cost");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Year0).HasColumnName("year0");
//                entity.Property(e => e.Year1).HasColumnName("year1");
//                entity.Property(e => e.Year2).HasColumnName("year2");
//                entity.Property(e => e.Year3).HasColumnName("year3");
//                entity.Property(e => e.Year4).HasColumnName("year4");
//                entity.Property(e => e.Year5).HasColumnName("year5");
//                entity.Property(e => e.Year6).HasColumnName("year6");
//                entity.Property(e => e.Year7).HasColumnName("year7");
//                entity.Property(e => e.Year8).HasColumnName("year8");
//                entity.Property(e => e.Year9).HasColumnName("year9");
//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostComp)
//                         .HasColumnName("cost_comp")
//                         .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<AnnualGrowthRate>(entity =>
//            {
//                entity.ToTable("annual_growth_rate", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AvgAnnualGrowthRate).HasColumnName("avg_annual_growth_rate");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.YoungFemale).HasColumnName("young_female");

//                entity.Property(e => e.YoungMale).HasColumnName("young_male");

//                entity.Property(e => e.YoungTotal).HasColumnName("young_total");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<ApprovedDocs>(entity =>
//            {
//                entity.HasKey(e => e.DocId)
//                         .HasName("updoc_pkey_id");

//                entity.ToTable("approved_docs", "wash_plan");

//                entity.HasComment(@"Status
//0-Uploaded
//1-Veririfed
//2-Approved");

//                entity.Property(e => e.DocId).HasColumnName("doc_id");

//                entity.Property(e => e.ApprovedBy)
//                         .HasColumnName("approved_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ApprovedDate)
//                         .HasColumnName("approved_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Filename)
//                         .HasColumnName("filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Status).HasColumnName("status");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VerifiedBy)
//                         .HasColumnName("verified_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VerifiedDate)
//                         .HasColumnName("verified_date")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WashStatusApprovedDocs>(entity =>
//            {
//                entity.HasKey(e => e.DocId)
//                         .HasName("wdoc_pkey_id");

//                entity.ToTable("wash_status_approved_docs", "wash_plan");

//                entity.HasComment(@"Status
//                                0-deactive
//                                1-active");

//                entity.Property(e => e.DocId).HasColumnName("doc_id");

//                entity.Property(e => e.Filename)
//                         .HasColumnName("filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Status).HasColumnName("status");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ProjectBankWsExt>(entity =>
//            {
//                entity.ToTable("project_bank_ws_ext", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                     .HasColumnName("procode")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankWsNew>(entity =>
//            {
//                entity.ToTable("project_bank_ws_new", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.PriorityUuid)
//                     .HasColumnName("priority_uuid")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankWsOng>(entity =>
//            {
//                entity.ToTable("project_bank_ws_ong", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.PriorityUuid)
//                     .HasColumnName("priority_uuid")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });

//            modelBuilder.Entity<ProjectBankSanExt>(entity =>
//            {
//                entity.ToTable("project_bank_san_ext", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.PriorityUuid)
//                     .HasColumnName("priority_uuid")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankSanNew>(entity =>
//            {
//                entity.ToTable("project_bank_san_new", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.PriorityUuid)
//                     .HasColumnName("priority_uuid")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankSanOng>(entity =>
//            {
//                entity.ToTable("project_bank_san_ong", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.PriorityUuid)
//                     .HasColumnName("priority_uuid")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankHcf>(entity =>
//            {
//                entity.ToTable("project_bank_hcf", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");

//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.HcfUuid)
//                     .HasColumnName("hcf_uuid")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankSkl>(entity =>
//            {
//                entity.ToTable("project_bank_skl", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.SklUuid)
//                     .HasColumnName("skl_uuid")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ProjectBankPtoilet>(entity =>
//            {
//                entity.ToTable("project_bank_ptoilet", "wash_project_bank");
//                entity.Property(e => e.Id)
//                         .HasColumnName("id");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.OtherSupportOrg)
//                     .HasColumnName("other_support_org")
//                     .HasColumnType("character varying");
//                entity.Property(e => e.PtUuid)
//                     .HasColumnName("pt_uuid")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.AddedBy)
//                     .HasColumnName("added_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProSelectedBy)
//                     .HasColumnName("pro_selected_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                     .HasColumnName("mun_code")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OfficeName)
//                     .HasColumnName("office_name")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.OtherSupport)
//                     .HasColumnName("other_support")
//                     .HasColumnType("character varying");

//            });
//            modelBuilder.Entity<ArsenicHis>(entity =>
//            {
//                entity.ToTable("arsenic_his", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Agency).HasColumnName("agency");

//                entity.Property(e => e.ArcConc).HasColumnName("arc_conc");

//                entity.Property(e => e.Community).HasColumnName("community");

//                entity.Property(e => e.ConBy).HasColumnName("con_by");

//                entity.Property(e => e.ConYearAd).HasColumnName("con_year_ad");

//                entity.Property(e => e.ConYearBs).HasColumnName("con_year_bs");

//                entity.Property(e => e.Dcode).HasColumnName("dcode");

//                entity.Property(e => e.DepthM).HasColumnName("depth_m");

//                entity.Property(e => e.District).HasColumnName("district");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.Mcode).HasColumnName("mcode");

//                entity.Property(e => e.NoHh).HasColumnName("no_hh");

//                entity.Property(e => e.NoPop).HasColumnName("no_pop");

//                entity.Property(e => e.OldWard).HasColumnName("old_ward");

//                entity.Property(e => e.OtherTest).HasColumnName("other_test");

//                entity.Property(e => e.OwnerName).HasColumnName("owner_name");

//                entity.Property(e => e.Ownership).HasColumnName("ownership");

//                entity.Property(e => e.Pcode).HasColumnName("pcode");

//                entity.Property(e => e.PointId).HasColumnName("point_id");

//                entity.Property(e => e.Ptype).HasColumnName("ptype");

//                entity.Property(e => e.PtypeDes).HasColumnName("ptype_des");

//                entity.Property(e => e.SamDateAd)
//                         .HasColumnName("sam_date_ad")
//                         .HasColumnType("date");

//                entity.Property(e => e.SamDateBs).HasColumnName("sam_date_bs");

//                entity.Property(e => e.TestType).HasColumnName("test_type");

//                entity.Property(e => e.TheGeom)
//                         .HasColumnName("the_geom")
//                         .HasColumnType("geometry(Point,4326)");

//                entity.Property(e => e.UserType).HasColumnName("user_type");

//                entity.Property(e => e.Uuid).HasColumnName("uuid");

//                entity.Property(e => e.VdcCode).HasColumnName("vdc_code");

//                entity.Property(e => e.VdcName).HasColumnName("vdc_name");

//                entity.Property(e => e.WardNo).HasColumnName("ward_no");

//                entity.Property(e => e.WellAge).HasColumnName("well_age");
//            });

//            modelBuilder.Entity<AsFsm>(entity =>
//            {
//                entity.ToTable("as_fsm", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsHcf>(entity =>
//            {
//                entity.ToTable("as_hcf", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsHhs>(entity =>
//            {
//                entity.ToTable("as_hhs", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsLutFsm>(entity =>
//            {
//                entity.ToTable("as_lut_fsm", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutHcf>(entity =>
//            {
//                entity.ToTable("as_lut_hcf", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutHh>(entity =>
//            {
//                entity.ToTable("as_lut_hh", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutPublicPlace>(entity =>
//            {
//                entity.ToTable("as_lut_public_place", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutSchool>(entity =>
//            {
//                entity.ToTable("as_lut_school", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutSwm>(entity =>
//            {
//                entity.ToTable("as_lut_swm", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutWs>(entity =>
//            {
//                entity.ToTable("as_lut_ws", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataField)
//                         .HasColumnName("data_field")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NumberField)
//                         .HasColumnName("number_field")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsLutWwtp>(entity =>
//            {
//                entity.ToTable("as_lut_wwtp", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.CostCategory)
//                         .HasColumnName("cost_category")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<AsPublicPlace>(entity =>
//            {
//                entity.ToTable("as_public_place", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsSchools>(entity =>
//            {
//                entity.ToTable("as_schools", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsSwm>(entity =>
//            {
//                entity.ToTable("as_swm", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsWaterSupply>(entity =>
//            {
//                entity.ToTable("as_water_supply", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AsWwtp>(entity =>
//            {
//                entity.ToTable("as_wwtp", "washplan_activity_summary");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.AmountRequired).HasColumnName("amount_required");

//                entity.Property(e => e.AvailableInvestment).HasColumnName("available_investment");

//                entity.Property(e => e.BridgeGapBondCost).HasColumnName("bridge_gap_bond_cost");

//                entity.Property(e => e.BridgeGapBondPc).HasColumnName("bridge_gap_bond_pc");

//                entity.Property(e => e.BridgeGapEquityCost).HasColumnName("bridge_gap_equity_cost");

//                entity.Property(e => e.BridgeGapEquityPc).HasColumnName("bridge_gap_equity_pc");

//                entity.Property(e => e.BridgeGapShareCost).HasColumnName("bridge_gap_share_cost");

//                entity.Property(e => e.BridgeGapSharePc).HasColumnName("bridge_gap_share_pc");

//                entity.Property(e => e.BridgeGapTotalCost).HasColumnName("bridge_gap_total_cost");

//                entity.Property(e => e.BridgeGapTradeCost).HasColumnName("bridge_gap_trade_cost");

//                entity.Property(e => e.BridgeGapTradePc).HasColumnName("bridge_gap_trade_pc");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.HhInvestmentInSelfSupply).HasColumnName("hh_investment_in_self_supply");

//                entity.Property(e => e.HhTariffFees).HasColumnName("hh_tariff_fees");

//                entity.Property(e => e.HhTaxes).HasColumnName("hh_taxes");

//                entity.Property(e => e.HhTransfers).HasColumnName("hh_transfers");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.TotalEstimatedGap).HasColumnName("total_estimated_gap");
//            });

//            modelBuilder.Entity<AverageTemperature>(entity =>
//            {
//                entity.ToTable("average_temperature", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CensusYear).HasColumnName("census_year");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Source)
//                         .HasColumnName("source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Temperature).HasColumnName("temperature");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");

//            });

//            modelBuilder.Entity<Benchmarking>(entity =>
//            {
//                entity.ToTable("benchmarking", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.BenchmarkingCollectionEffectiveness)
//                         .HasColumnName("benchmarking_collection_effectiveness")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingPhoto1)
//                         .HasColumnName("benchmarking_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingPhoto2)
//                         .HasColumnName("benchmarking_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingStreetSweepingEffectiveness)
//                         .HasColumnName("benchmarking_street_sweeping_effectiveness")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingTariffLevel)
//                         .HasColumnName("benchmarking_tariff_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<BenchmarkingOld>(entity =>
//            {
//                entity.ToTable("benchmarking_old", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.BenchmarkingCollectionEffectiveness)
//                         .HasColumnName("benchmarking_collection_effectiveness")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingPhoto1)
//                         .HasColumnName("benchmarking_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingPhoto2)
//                         .HasColumnName("benchmarking_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingStreetSweepingEffectiveness)
//                         .HasColumnName("benchmarking_street_sweeping_effectiveness")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BenchmarkingTariffLevel)
//                         .HasColumnName("benchmarking_tariff_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CapmaexMaintenanceAgewiseCostPc>(entity =>
//            {
//                entity.ToTable("capmaex_maintenance_agewise_cost_pc", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AdpotedPc).HasColumnName("adpoted_pc");

//                entity.Property(e => e.RefDataPc).HasColumnName("ref_data_pc");

//                entity.Property(e => e.SchemeAge)
//                         .HasColumnName("scheme_age")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Climate>(entity =>
//            {
//                entity.ToTable("climate", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Category)
//                         .HasColumnName("category")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Value).HasColumnName("value");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<ColumnDictionary>(entity =>
//            {
//                entity.ToTable("column_dictionary", "swmap");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ColType)
//                         .HasColumnName("col_type")
//                         .HasMaxLength(10);

//                entity.Property(e => e.Editable).HasColumnName("editable");

//                entity.Property(e => e.Options).HasColumnName("options");

//                entity.Property(e => e.PostgresCol)
//                         .HasColumnName("postgres_col")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Show).HasColumnName("show");

//                entity.Property(e => e.SqliteAttr)
//                         .HasColumnName("sqlite_attr")
//                         .HasMaxLength(200);

//                entity.Property(e => e.TableId).HasColumnName("table_id");
//                entity.Property(e => e.QbCols)
//         .HasColumnName("qb_cols")
//         .HasColumnType("character varying")
//         .HasMaxLength(10);

//            });

//            modelBuilder.Entity<CostCalculatedTable>(entity =>
//            {
//                entity.ToTable("cost_calculated_table", "cost_estimation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CapacityDevelopmentImp)
//                         .HasColumnName("capacity_development_imp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContingenciesImp)
//                         .HasColumnName("contingencies_imp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContingenciesWsuc)
//                         .HasColumnName("contingencies_wsuc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ImpAgencyContribution)
//                         .HasColumnName("imp_agency_contribution")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaintenanceCivilStructureImp)
//                         .HasColumnName("maintenance_civil_structure_imp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaintenanceCivilStructureWsuc)
//                         .HasColumnName("maintenance_civil_structure_wsuc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaintenancePipelineImp)
//                         .HasColumnName("maintenance_pipeline_imp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaintenancePipelineWsuc)
//                         .HasColumnName("maintenance_pipeline_wsuc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaintenanceWorkImp)
//                         .HasColumnName("maintenance_work_imp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaintenanceWorkWsuc)
//                         .HasColumnName("maintenance_work_wsuc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MgmtImpCost)
//                         .HasColumnName("mgmt_imp_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MgmtImpPerCapitaCost)
//                         .HasColumnName("mgmt_imp_per_capita_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhysicalImpCost)
//                         .HasColumnName("physical_imp_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhysicalImpPerCapitaCost)
//                         .HasColumnName("physical_imp_per_capita_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProcurementOfGoodsImp)
//                         .HasColumnName("procurement_of_goods_imp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProcurementOfGoodsWsuc)
//                         .HasColumnName("procurement_of_goods_wsuc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabCost)
//                         .HasColumnName("rehab_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabPerCapitaCost)
//                         .HasColumnName("rehab_per_capita_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalCost)
//                         .HasColumnName("total_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsucContribution)
//                         .HasColumnName("wsuc_contribution")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CostDetails>(entity =>
//            {
//                entity.ToTable("cost_details", "cost_estimation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ItemCategory)
//                         .HasColumnName("item_category")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ItemSf)
//                         .HasColumnName("item_sf")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ItemShortName)
//                         .HasColumnName("item_short_name")
//                         .HasMaxLength(512);

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasMaxLength(512);

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasMaxLength(3);

//                entity.Property(e => e.SubGroup)
//                         .HasColumnName("sub_group")
//                         .HasMaxLength(3);

//                entity.Property(e => e.Unit)
//                         .HasColumnName("unit")
//                         .HasMaxLength(36);

//                entity.Property(e => e.UnitRate)
//                         .HasColumnName("unit_rate")
//                         .HasMaxLength(128);

//                entity.Property(e => e.Year)
//                         .HasColumnName("year")
//                         .HasMaxLength(8);
//            });

//            modelBuilder.Entity<CostTablePipe>(entity =>
//            {
//                entity.ToTable("cost_table_pipe", "cost_estimation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ExcavationBms)
//                         .HasColumnName("excavation_bms")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ExcavationHardSoil)
//                         .HasColumnName("excavation_hard_soil")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ExcavationSoftSoil)
//                         .HasColumnName("excavation_soft_soil")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ExcavationTotal)
//                         .HasColumnName("excavation_total")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.PipeCost)
//                         .HasColumnName("pipe_cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.PipeJointing)
//                         .HasColumnName("pipe_jointing")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.PipeSize)
//                         .HasColumnName("pipe_size")
//                         .HasMaxLength(128);

//                entity.Property(e => e.RefillingBms)
//                         .HasColumnName("refilling_bms")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.RefillingHardSoil)
//                         .HasColumnName("refilling_hard_soil")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.RefillingSoftSoil)
//                         .HasColumnName("refilling_soft_soil")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.RefillingTotal)
//                         .HasColumnName("refilling_total")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Sn)
//                         .HasColumnName("sn")
//                         .HasMaxLength(6);

//                entity.Property(e => e.TotalCostPerMeter)
//                         .HasColumnName("total_cost_per_meter")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<CostingMethod>(entity =>
//            {
//                entity.ToTable("costing_method", "cost_estimation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CostSharing)
//                         .HasColumnName("cost_sharing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostingProcess)
//                         .HasColumnName("costing_process")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Title)
//                         .HasColumnName("title")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CriteriaForWashInPublicPlaces>(entity =>
//            {
//                entity.ToTable("criteria_for_wash_in_public_places", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Cost).HasColumnName("cost");

//                entity.Property(e => e.Criteria)
//                         .HasColumnName("criteria")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsExistingSanitationSystem>(entity =>
//            {
//                entity.ToTable("cs_existing_sanitation_system", "community_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AvailabilityOfTreatmentPlant)
//                         .HasColumnName("availability_of_treatment_plant")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CompletedYear)
//                         .HasColumnName("completed_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConveyanceAssetValue).HasColumnName("conveyance_asset_value");

//                entity.Property(e => e.ConveyanceAssetValueStatus)
//                         .HasColumnName("conveyance_asset_value_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConveyanceRepairCondition)
//                         .HasColumnName("conveyance_repair_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IniUuid)
//                         .HasColumnName("ini_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationSystemName)
//                         .HasColumnName("sanitation_system_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationSystemType)
//                         .HasColumnName("sanitation_system_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentAssetValue).HasColumnName("treatment_asset_value");

//                entity.Property(e => e.TreatmentAssetValueStatus)
//                         .HasColumnName("treatment_asset_value_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentRepairCondition)
//                         .HasColumnName("treatment_repair_condition")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsFiles>(entity =>
//            {
//                entity.ToTable("cs_files", "community_sanitation");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('community_sanitation.tbl_files_id_seq'::regclass)");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Filename)
//                         .HasColumnName("filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsInitialDetails>(entity =>
//            {
//                entity.ToTable("cs_initial_details", "community_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AgencyName)
//                         .HasColumnName("agency_name")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                         .HasColumnName("additional_photo_1_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                         .HasColumnName("additional_photo_2_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                         .HasColumnName("additional_photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DalitHh)
//                         .HasColumnName("dalit_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.JanajatiHh)
//                         .HasColumnName("janajati_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MadesiHh)
//                         .HasColumnName("madesi_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ObcHh)
//                         .HasColumnName("obc_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationSystem)
//                         .HasColumnName("sanitation_system")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TotalHh)
//                         .HasColumnName("total_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalPopulation)
//                         .HasColumnName("total_population")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VisitDate)
//                         .HasColumnName("visit_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WardNo)
//                         .HasColumnName("ward_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WomenHeadedHh)
//                         .HasColumnName("women_headed_hh")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsNewSanitationSystem>(entity =>
//            {
//                entity.ToTable("cs_new_sanitation_system", "community_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.IniUuid)
//                         .HasColumnName("ini_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewProjectName)
//                         .HasColumnName("new_project_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewSchemeType)
//                         .HasColumnName("new_scheme_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalEstimateAsPerDpr).HasColumnName("total_estimate_as_per_dpr");

//                entity.Property(e => e.TotalEstimateAsPerDprStatus)
//                         .HasColumnName("total_estimate_as_per_dpr_status")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsObservedLocations>(entity =>
//            {
//                entity.ToTable("cs_observed_locations", "community_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DalitHh)
//                         .HasColumnName("dalit_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.HhHavingDrainageProblem)
//                         .HasColumnName("hh_having_drainage_problem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhPracticingOwnDisposal)
//                         .HasColumnName("hh_practicing_own_disposal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhPracticingSolidWasteSeparation)
//                         .HasColumnName("hh_practicing_solid_waste_separation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhUsingPublicToilet)
//                         .HasColumnName("hh_using_public_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhWithSewerageConn)
//                         .HasColumnName("hh_with_sewerage_conn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhWithToilet)
//                         .HasColumnName("hh_with_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.JanajatiHh)
//                         .HasColumnName("janajati_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MadhesiHh)
//                         .HasColumnName("madhesi_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorityHh)
//                         .HasColumnName("minority_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SepticTankCleaningFacility)
//                         .HasColumnName("septic_tank_cleaning_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SludgeDisposal)
//                         .HasColumnName("sludge_disposal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoildWasteCollectionFacility)
//                         .HasColumnName("soild_waste_collection_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TotalHh)
//                         .HasColumnName("total_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WomenHeadedHh)
//                         .HasColumnName("women_headed_hh")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsObservedLocationsOld>(entity =>
//            {
//                entity.ToTable("cs_observed_locations_old", "community_sanitation");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('community_sanitation.tbl_observed_locations_old_id_seq'::regclass)");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DalitHh)
//                         .HasColumnName("dalit_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.HhHavingDrainageProblem)
//                         .HasColumnName("hh_having_drainage_problem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhPracticingOwnDisposal)
//                         .HasColumnName("hh_practicing_own_disposal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhPracticingSolidWasteSeparation)
//                         .HasColumnName("hh_practicing_solid_waste_separation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhUsingPublicToilet)
//                         .HasColumnName("hh_using_public_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhWithSewerageConn)
//                         .HasColumnName("hh_with_sewerage_conn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhWithToilet)
//                         .HasColumnName("hh_with_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.JanajatiHh)
//                         .HasColumnName("janajati_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MadhesiHh)
//                         .HasColumnName("madhesi_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorityHh)
//                         .HasColumnName("minority_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SepticTankCleaningFacility)
//                         .HasColumnName("septic_tank_cleaning_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SludgeDisposal)
//                         .HasColumnName("sludge_disposal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoildWasteCollectionFacility)
//                         .HasColumnName("soild_waste_collection_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TotalHh)
//                         .HasColumnName("total_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WomenHeadedHh)
//                         .HasColumnName("women_headed_hh")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<CsOngoingSanitationSystem>(entity =>
//            {
//                entity.ToTable("cs_ongoing_sanitation_system", "community_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DprAvailability)
//                         .HasColumnName("dpr_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IniUuid)
//                         .HasColumnName("ini_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OngoingProjectName)
//                         .HasColumnName("ongoing_project_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OngoingProjectStartYear)
//                         .HasColumnName("ongoing_project_start_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OngoingSchemeType)
//                         .HasColumnName("ongoing_scheme_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectCostAsPerDpr).HasColumnName("project_cost_as_per_dpr");

//                entity.Property(e => e.ProjectExp2020KnownStatus)
//                         .HasColumnName("project_exp_2020_known_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectExpTill2020).HasColumnName("project_exp_till_2020");
//            });

//            modelBuilder.Entity<CsProjectInfo>(entity =>
//            {
//                entity.ToTable("cs_project_info", "community_sanitation");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('community_sanitation.tbl_project_info_id_seq'::regclass)");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<DashboardNotices>(entity =>
//            {
//                entity.ToTable("dashboard_notices", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.Notices)
//                         .HasColumnName("notices")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Status).HasColumnName("status");
//            });

//            modelBuilder.Entity<DirectSupportCost>(entity =>
//            {
//                entity.ToTable("direct_support_cost", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Particular)
//                         .HasColumnName("particular")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Quantity).HasColumnName("quantity");

//                entity.Property(e => e.TblrateId).HasColumnName("tblrate_id");
//            });

//            modelBuilder.Entity<DirectSupportCs>(entity =>
//            {
//                entity.ToTable("direct_support_cs", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Cost)
//                         .HasColumnName("cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Notes)
//                         .HasColumnName("notes")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Particulars)
//                         .HasColumnName("particulars")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<DirectSupportWashInSchool>(entity =>
//            {
//                entity.ToTable("direct_support_wash_in_school", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Frequency)
//                         .HasColumnName("frequency")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Particular)
//                         .HasColumnName("particular")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TblrateId).HasColumnName("tblrate_id");
//            });

//            modelBuilder.Entity<DisposalPoint>(entity =>
//            {
//                entity.ToTable("disposal_point", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisposalCollectionInterval)
//                         .HasColumnName("disposal_collection_interval")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisposalPhoto1)
//                         .HasColumnName("disposal_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisposalPhoto2)
//                         .HasColumnName("disposal_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisposalProblemDesc)
//                         .HasColumnName("disposal_problem_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisposalVolume)
//                         .HasColumnName("disposal_volume")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisposalWasteComp)
//                         .HasColumnName("disposal_waste_comp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<District>(entity =>
//            {
//                entity.ToTable("district", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictName)
//                         .HasColumnName("district_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictNameNep)
//                         .HasColumnName("district_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictUuid)
//                         .HasColumnName("district_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<DistrictBoundary>(entity =>
//            {
//                entity.ToTable("district_boundary", "basemap");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Dcode).HasColumnName("dcode");

//                entity.Property(e => e.DisNepali).HasColumnName("dis_nepali");

//                entity.Property(e => e.Distname)
//                         .HasColumnName("distname")
//                         .HasMaxLength(25);

//                entity.Property(e => e.District)
//                         .HasColumnName("district")
//                         .HasMaxLength(50);

//                entity.Property(e => e.Geom)
//                         .HasColumnName("geom")
//                         .HasColumnType("geometry(MultiPolygon,4326)");

//                entity.Property(e => e.NewDcode).HasColumnName("new_dcode");

//                entity.Property(e => e.Objectid).HasColumnName("objectid");

//                entity.Property(e => e.Province).HasColumnName("province");

//                entity.Property(e => e.Region)
//                         .HasColumnName("region")
//                         .HasMaxLength(13);

//                entity.Property(e => e.Zone)
//                         .HasColumnName("zone")
//                         .HasMaxLength(50);
//            });

//            modelBuilder.Entity<DistrictLine>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("district_line", "system");

//                entity.Property(e => e.DistrictCode).HasColumnName("district_code");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .ValueGeneratedOnAdd();

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<Documents>(entity =>
//            {
//                entity.ToTable("documents", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DocTitle)
//                         .HasColumnName("doc_title")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Filename)
//                         .HasColumnName("filename")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<DrainageLut>(entity =>
//            {
//                entity.ToTable("drainage_lut", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DataType)
//                         .HasColumnName("data_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Layer)
//                         .HasColumnName("layer")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<DrainagePoint>(entity =>
//            {
//                entity.ToTable("drainage_point", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageCondition)
//                         .HasColumnName("drainage_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageConduit)
//                         .HasColumnName("drainage_conduit")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageConduitMaterial)
//                         .HasColumnName("drainage_conduit_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageConstructionYear)
//                         .HasColumnName("drainage_construction_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageDepth)
//                         .HasColumnName("drainage_depth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageDiameter)
//                         .HasColumnName("drainage_diameter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageFunction)
//                         .HasColumnName("drainage_function")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageIntvnRequired)
//                         .HasColumnName("drainage_intvn_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainagePavementType)
//                         .HasColumnName("drainage_pavement_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainagePhoto1)
//                         .HasColumnName("drainage_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainagePhoto2)
//                         .HasColumnName("drainage_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainagePointCode)
//                         .HasColumnName("drainage_point_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageRehabYear)
//                         .HasColumnName("drainage_rehab_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageRoadWidth)
//                         .HasColumnName("drainage_road_width")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageSideSlope)
//                         .HasColumnName("drainage_side_slope")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageUpstreamCode)
//                         .HasColumnName("drainage_upstream_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<DrnProjectInfo>(entity =>
//            {
//                entity.ToTable("drn_project_info", "drainage");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('drainage.tbl_project_info_id_seq'::regclass)");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<DssWsReferenceCost>(entity =>
//            {
//                entity.ToTable("dss_ws_reference_cost", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DirectSupport)
//                         .HasColumnName("direct_support")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManDays)
//                         .HasColumnName("man_days")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfTrainingPerYear).HasColumnName("no_of_training_per_year");

//                entity.Property(e => e.Notes)
//                         .HasColumnName("notes")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupportCost)
//                         .HasColumnName("support_cost")
//                         .HasColumnType("numeric")
//                         .HasComment("for training and monitoring cost, the cost is calculated with reference to rate. ");

//                entity.Property(e => e.Transportation)
//                         .HasColumnName("transportation")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ExistingSanitationPriority>(entity =>
//            {
//                entity.ToTable("existing_sanitation_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ApkDetails>(entity =>
//            {
//                entity.ToTable("apk_details", "apks");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AppName)
//                         .HasColumnName("app_name")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.VersionCode)
//                         .HasColumnName("version_code");
//                entity.Property(e => e.ApkPath)
//                         .HasColumnName("apk_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Requirements)
//                         .HasColumnName("requirements")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Size)
//                         .HasColumnName("size")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.LogoPath)
//                             .HasColumnName("logo_path")
//                             .HasColumnType("character varying");
//                entity.Property(e => e.OtherDocs)
//                             .HasColumnName("other_docs")
//                             .HasColumnType("character varying");
//                entity.Property(e => e.AppDesc)
//                             .HasColumnName("app_desc")
//                             .HasColumnType("character varying");
//                entity.Property(e => e.Status)
//                             .HasColumnName("status");
//                entity.Property(e => e.UpdatedDate)
//                             .HasColumnName("updated_date")
//                             .HasColumnType("date");
//                entity.Property(e => e.ApkIndex)
//                             .HasColumnName("apk_index");
//                entity.Property(e => e.DownloadCount)
//                             .HasColumnName("download_count");
//            });

//            modelBuilder.Entity<ExistingSanitationTreatmentCost>(entity =>
//            {
//                entity.ToTable("existing_sanitation_treatment_cost", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Amount).HasColumnName("amount");

//                entity.Property(e => e.CostType)
//                         .HasColumnName("cost_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SystemType)
//                         .HasColumnName("system_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ExistingWss>(entity =>
//            {
//                entity.ToTable("existing_wss", "wash_costplan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CostType)
//                         .HasColumnName("cost_type")
//                         .HasColumnType("character varying")
//                         .HasComment(@"Cost Type
//CapEx
//OpEx
//CapManEx
//DsEx");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Year0).HasColumnName("year0");

//                entity.Property(e => e.Year1).HasColumnName("year1");

//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.Year2).HasColumnName("year2");

//                entity.Property(e => e.Year3).HasColumnName("year3");

//                entity.Property(e => e.Year4).HasColumnName("year4");

//                entity.Property(e => e.Year5).HasColumnName("year5");

//                entity.Property(e => e.Year6).HasColumnName("year6");

//                entity.Property(e => e.Year7).HasColumnName("year7");

//                entity.Property(e => e.Year8).HasColumnName("year8");

//                entity.Property(e => e.Year9).HasColumnName("year9");
//            });

//            modelBuilder.Entity<Faqs>(entity =>
//            {
//                entity.HasKey(e => e.FaqId)
//                         .HasName("system_faq_id_pkey");

//                entity.ToTable("faqs", "system");

//                entity.Property(e => e.FaqId).HasColumnName("faq_id");

//                entity.Property(e => e.Answers)
//                         .HasColumnName("answers")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Groups)
//                         .HasColumnName("groups")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Links)
//                         .HasColumnName("links")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Questions)
//                         .HasColumnName("questions")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<FloodBenchmarking>(entity =>
//            {
//                entity.ToTable("flood_benchmarking", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FloodBenchmarkingObservedLevel)
//                         .HasColumnName("flood_benchmarking_observed_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FloodFrequency)
//                         .HasColumnName("flood_frequency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FloodPhoto1)
//                         .HasColumnName("flood_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FloodPhoto2)
//                         .HasColumnName("flood_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FloodingDuration)
//                         .HasColumnName("flooding_duration")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FoodEffect)
//                         .HasColumnName("food_effect")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Functionality>(entity =>
//            {
//                entity.ToTable("functionality", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.AnExp).HasColumnName("an_exp");

//                entity.Property(e => e.AnIncome).HasColumnName("an_income");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.NoComplaints).HasColumnName("no_complaints");

//                entity.Property(e => e.NoLeakYear).HasColumnName("no_leak_year");

//                entity.Property(e => e.NoMeetDemand).HasColumnName("no_meet_demand");

//                entity.Property(e => e.NoMonthsFlowAdequate).HasColumnName("no_months_flow_adequate");

//                entity.Property(e => e.NoStr).HasColumnName("no_str");

//                entity.Property(e => e.NoStrRepair).HasColumnName("no_str_repair");

//                entity.Property(e => e.NoVmw).HasColumnName("no_vmw");

//                entity.Property(e => e.NoVmwToolMeet).HasColumnName("no_vmw_tool_meet");

//                entity.Property(e => e.PipeLen).HasColumnName("pipe_len");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SupHours).HasColumnName("sup_hours");

//                entity.Property(e => e.TapNoTurbidity).HasColumnName("tap_no_turbidity");

//                entity.Property(e => e.TotalTap).HasColumnName("total_tap");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.YardTap)
//                         .HasColumnName("yard_tap")
//                         .HasMaxLength(10);
//            });

//            modelBuilder.Entity<FunctionalityHistory>(entity =>
//            {
//                entity.ToTable("functionality_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.functionality_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.AnExp).HasColumnName("an_exp");

//                entity.Property(e => e.AnIncome).HasColumnName("an_income");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.NoComplaints).HasColumnName("no_complaints");

//                entity.Property(e => e.NoLeakYear).HasColumnName("no_leak_year");

//                entity.Property(e => e.NoMeetDemand).HasColumnName("no_meet_demand");

//                entity.Property(e => e.NoMonthsFlowAdequate).HasColumnName("no_months_flow_adequate");

//                entity.Property(e => e.NoStr).HasColumnName("no_str");

//                entity.Property(e => e.NoStrRepair).HasColumnName("no_str_repair");

//                entity.Property(e => e.NoVmw).HasColumnName("no_vmw");

//                entity.Property(e => e.NoVmwToolMeet).HasColumnName("no_vmw_tool_meet");

//                entity.Property(e => e.PipeLen).HasColumnName("pipe_len");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SupHours).HasColumnName("sup_hours");

//                entity.Property(e => e.TapNoTurbidity).HasColumnName("tap_no_turbidity");

//                entity.Property(e => e.TotalTap).HasColumnName("total_tap");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.YardTap)
//                         .HasColumnName("yard_tap")
//                         .HasMaxLength(10);
//            });

//            modelBuilder.Entity<FunctionalityNewScore>(entity =>
//            {
//                entity.ToTable("functionality_new_score", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CurrentYear)
//                         .HasColumnName("current_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Effect)
//                         .HasColumnName("effect")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FuncPopulation)
//                         .HasColumnName("func_population")
//                         .HasMaxLength(8)
//                         .HasComment("functional population percent");

//                entity.Property(e => e.FuncTapPer)
//                         .HasColumnName("func_tap_per")
//                         .HasColumnType("character varying")
//                         .HasComment("functional tap percent");

//                entity.Property(e => e.InputScore)
//                         .HasColumnName("input_score")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.OutputScore)
//                         .HasColumnName("output_score")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(256);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.SchemeAge)
//                         .HasColumnName("scheme_age")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Year1)
//                         .HasColumnName("year1")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year2)
//                         .HasColumnName("year2")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year3)
//                         .HasColumnName("year3")
//                         .HasMaxLength(8);
//            });

//            modelBuilder.Entity<FunctionalityScore>(entity =>
//            {
//                entity.ToTable("functionality_score", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.ProjectCode)
//                         .HasColumnName("project_code")
//                         .HasMaxLength(128);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year1).HasColumnName("year1");

//                entity.Property(e => e.Year2).HasColumnName("year2");

//                entity.Property(e => e.Year3).HasColumnName("year3");
//            });

//            modelBuilder.Entity<GrDistrict>(entity =>
//            {
//                entity.ToTable("gr_district", "grievance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('grievance.district_id_seq'::regclass)");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictName)
//                         .HasColumnName("district_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictNameNep)
//                         .HasColumnName("district_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<GrFile>(entity =>
//            {
//                entity.HasKey(e => e.FileId)
//                         .HasName("pkey_file");

//                entity.ToTable("gr_file", "grievance");

//                entity.Property(e => e.FileId)
//                         .HasColumnName("file_id")
//                         .HasDefaultValueSql("nextval('grievance.file_file_id_seq'::regclass)");

//                entity.Property(e => e.FileName)
//                         .HasColumnName("file_name")
//                         .HasMaxLength(256);

//                entity.Property(e => e.GeneralId)
//                         .HasColumnName("general_id")
//                         .HasComment("id of tbl_general");

//                entity.Property(e => e.SchemeCode)
//                         .HasColumnName("scheme_code")
//                         .HasMaxLength(32);

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasMaxLength(32);
//            });

//            modelBuilder.Entity<GrGeneral>(entity =>
//            {
//                entity.ToTable("gr_general", "grievance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('grievance.general_id_seq'::regclass)");

//                entity.Property(e => e.District)
//                         .HasColumnName("district")
//                         .HasMaxLength(32);

//                entity.Property(e => e.Elevation)
//                         .HasColumnName("elevation")
//                         .HasMaxLength(32);

//                entity.Property(e => e.FormId)
//                         .HasColumnName("form_id")
//                         .HasMaxLength(256)
//                         .HasComment("for the map image located @ grievance-mapimgs");

//                entity.Property(e => e.Iscustomer)
//                         .HasColumnName("iscustomer")
//                         .HasMaxLength(32);

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.Municipality)
//                         .HasColumnName("municipality")
//                         .HasMaxLength(50);

//                entity.Property(e => e.PhoneNo)
//                         .HasColumnName("phone_no")
//                         .HasMaxLength(64);

//                entity.Property(e => e.Province)
//                         .HasColumnName("province")
//                         .HasMaxLength(50);

//                entity.Property(e => e.SchemeCode)
//                         .HasColumnName("scheme_code")
//                         .HasMaxLength(32);

//                entity.Property(e => e.State)
//                         .HasColumnName("state")
//                         .HasMaxLength(256);

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasMaxLength(32);
//            });

//            modelBuilder.Entity<GrMunicipality>(entity =>
//            {
//                entity.ToTable("gr_municipality", "grievance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('grievance.municipality_id_seq'::regclass)");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunName)
//                         .HasColumnName("mun_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<GrProblem>(entity =>
//            {
//                entity.ToTable("gr_problem", "grievance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('grievance.problem_id_seq'::regclass)");

//                entity.Property(e => e.GeneralId)
//                         .HasColumnName("general_id")
//                         .HasComment(" id of tbl_general");

//                entity.Property(e => e.PCode)
//                         .HasColumnName("p_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.PName)
//                         .HasColumnName("p_name")
//                         .HasMaxLength(128);

//                entity.Property(e => e.SchemeCode)
//                         .HasColumnName("scheme_code")
//                         .HasMaxLength(32);

//                entity.Property(e => e.SchemeState)
//                         .HasColumnName("scheme_state")
//                         .HasMaxLength(128);

//                entity.Property(e => e.Status).HasColumnName("status");
//            });

//            modelBuilder.Entity<GrProvince>(entity =>
//            {
//                entity.ToTable("gr_province", "grievance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('grievance.province_id_seq'::regclass)");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasMaxLength(128);

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceName)
//                         .HasColumnName("province_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceNameNep)
//                         .HasColumnName("province_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<GrTblLogs>(entity =>
//            {
//                entity.ToTable("gr_tbl_logs", "grievance");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('grievance.tbl_logs_id_seq'::regclass)");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasMaxLength(50);

//                entity.Property(e => e.FileName)
//                         .HasColumnName("file_name")
//                         .HasMaxLength(128);

//                entity.Property(e => e.Status)
//                         .HasColumnName("status")
//                         .HasMaxLength(500);

//                entity.Property(e => e.SyncedBy)
//                         .HasColumnName("synced_by")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<HcfCols>(entity =>
//            {
//                entity.ToTable("hcf_cols", "health_care");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('health_care.cols_id_seq'::regclass)");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HcfLut>(entity =>
//            {
//                entity.ToTable("hcf_lut", "health_care");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('health_care.look_up_new_id_seq'::regclass)");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HcfLut1>(entity =>
//            {
//                entity.ToTable("hcf_lut1", "health_care");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.QbCols)
//         .HasColumnName("qb_cols")
//         .HasColumnType("character varying")
//         .HasMaxLength(10);

//            });

//            modelBuilder.Entity<HcfServiceLevelData>(entity =>
//            {
//                entity.ToTable("hcf_service_level_data", "wp_sgd");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('wp_sgd.hcf_service_level_id_seq'::regclass)");

//                entity.Property(e => e.AlcoholBasedRubInOpd).HasColumnName("alcohol_based_rub_in_opd");

//                entity.Property(e => e.DisableFriendlyToilet).HasColumnName("disable_friendly_toilet");

//                entity.Property(e => e.IncineratorForHazardousWaste).HasColumnName("incinerator_for_hazardous_waste");

//                entity.Property(e => e.IncineratorForMhm).HasColumnName("incinerator_for_mhm");

//                entity.Property(e => e.PlacentaPit).HasColumnName("placenta_pit");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SharpWasteSeparatelyDisposed).HasColumnName("sharp_waste_separately_disposed");

//                entity.Property(e => e.SoapPresentHandwashing).HasColumnName("soap_present_handwashing");

//                entity.Property(e => e.UsableFemaleToilet).HasColumnName("usable_female_toilet");

//                entity.Property(e => e.UsableFemaleToiletWithMhm).HasColumnName("usable_female_toilet_with_mhm");

//                entity.Property(e => e.UsableHandwashingStation).HasColumnName("usable_handwashing_station");

//                entity.Property(e => e.UsableMaleToilet).HasColumnName("usable_male_toilet");

//                entity.Property(e => e.WithAdequateWater).HasColumnName("with_adequate_water");

//                entity.Property(e => e.WithBins).HasColumnName("with_bins");

//                entity.Property(e => e.WithTreatment).HasColumnName("with_treatment");
//            });

//            modelBuilder.Entity<HcfServiceStatus>(entity =>
//            {
//                entity.ToTable("hcf_service_status", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.HcfWsStatus)
//                         .HasColumnName("hcf_ws_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneStatus)
//                         .HasColumnName("hygiene_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationStatus)
//                         .HasColumnName("sanitation_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SwmStatus)
//                         .HasColumnName("swm_status")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HcfWashPriority>(entity =>
//            {
//                entity.ToTable("hcf_wash_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PlanningProgress>(entity =>
//            {
//                entity.ToTable("planning_progress", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.InceptionFile1)
//                         .HasColumnName("inception_file1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.InceptionFile2)
//                         .HasColumnName("inception_file2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.DatacolFile1)
//                         .HasColumnName("datacol_file1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.DatacolFile2)
//                         .HasColumnName("datacol_file2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ValidationFile1)
//                         .HasColumnName("validation_file1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ValidationFile2)
//                         .HasColumnName("validation_file2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.PrioritizationFile1)
//                         .HasColumnName("prioritization_file1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.PrioritizationFile2)
//                         .HasColumnName("prioritization_file2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ReviewFile1)
//                         .HasColumnName("review_file1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ReviewFile2)
//                         .HasColumnName("review_file2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EndorsementFile1)
//                         .HasColumnName("endorsement_file1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EndorsementFile2)
//                         .HasColumnName("endorsement_file2")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HealthCareFacility>(entity =>
//            {
//                entity.ToTable("health_care_facility", "health_care");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AcuteContagiousWasteSeparation)
//                         .HasColumnName("acute_contagious_waste_separation")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedDate)
//                     .HasColumnName("edited_date")
//                     .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy)
//                         .HasColumnName("collected_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AgencyName)
//                         .HasColumnName("agency_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AlcoholBasedRubAvailability)
//                         .HasColumnName("alcohol_based_rub_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AlternativeWaterSource)
//                         .HasColumnName("alternative_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AlternativeWaterSourceLastingPeriod)
//                         .HasColumnName("alternative_water_source_lasting_period")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BirthingCenterStatus)
//                         .HasColumnName("birthing_center_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildrenAdequateSoap)
//                         .HasColumnName("children_adequate_soap")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildrenEasyAccess)
//                         .HasColumnName("children_easy_access")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContactName)
//                         .HasColumnName("contact_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContactNumber)
//                         .HasColumnName("contact_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Dbname)
//                         .HasColumnName("dbname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DeliveryRoomCleanStatus)
//                         .HasColumnName("delivery_room_clean_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DeliveryRoomStatus)
//                         .HasColumnName("delivery_room_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledAccessWater)
//                         .HasColumnName("disabled_access_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFriendlyWorkingTaps)
//                         .HasColumnName("disabled_friendly_working_taps")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterAccessibleStatus)
//                         .HasColumnName("drinking_water_accessible_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterStationStatus)
//                         .HasColumnName("drinking_water_station_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterTank)
//                         .HasColumnName("drinking_water_tank")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinInFemaleToilet)
//                         .HasColumnName("dustbin_in_female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinNumber)
//                         .HasColumnName("dustbin_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinOther)
//                         .HasColumnName("dustbin_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinWithLidInFemaleToilet)
//                         .HasColumnName("dustbin_with_lid_in_female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinsLabelled)
//                         .HasColumnName("dustbins_labelled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.EnvironmentalSanitationProtocol)
//                         .HasColumnName("environmental_sanitation_protocol")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EnvironmentalSanitationStaff)
//                         .HasColumnName("environmental_sanitation_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FecalContamination)
//                         .HasColumnName("fecal_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemalePatient)
//                         .HasColumnName("female_patient")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleStaff)
//                         .HasColumnName("female_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationCondition)
//                         .HasColumnName("hand_washing_station_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationConditionInDr)
//                         .HasColumnName("hand_washing_station_condition_in_dr")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationConditionInOpd)
//                         .HasColumnName("hand_washing_station_condition_in_opd")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationInDr)
//                         .HasColumnName("hand_washing_station_in_dr")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationInOpd)
//                         .HasColumnName("hand_washing_station_in_opd")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationNearToilet)
//                         .HasColumnName("hand_washing_station_near_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HazardousWasteIncineratorCondition)
//                         .HasColumnName("hazardous_waste_incinerator_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfDrinkingWaterInsideStatus)
//                         .HasColumnName("hcf_drinking_water_inside_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfDrinkingWaterStatus)
//                         .HasColumnName("hcf_drinking_water_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfSourceOfWater)
//                         .HasColumnName("hcf_source_of_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfSourceOfWaterStatus)
//                         .HasColumnName("hcf_source_of_water_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfSourceOfWaterStatusPlan)
//                         .HasColumnName("hcf_source_of_water_status_plan")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfToilstatus)
//                         .HasColumnName("hcf_toilstatus")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfType)
//                         .HasColumnName("hcf_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfTypeOther)
//                         .HasColumnName("hcf_type_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfWaterSufficientStatus)
//                         .HasColumnName("hcf_water_sufficient_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HealthCareKind)
//                         .HasColumnName("health_care_kind")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorAvailabilityForMhm)
//                         .HasColumnName("incinerator_availability_for_mhm")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorCondition)
//                         .HasColumnName("incinerator_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorForHazardousWaste)
//                         .HasColumnName("incinerator_for_hazardous_waste")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.KeyRespondent)
//                         .HasColumnName("key_respondent")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MajorHandwashingRepair)
//                         .HasColumnName("major_handwashing_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MajorTapsRepair)
//                         .HasColumnName("major_taps_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MajorToiletRepair)
//                         .HasColumnName("major_toilet_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MalePatient)
//                         .HasColumnName("male_patient")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleStaff)
//                         .HasColumnName("male_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorHandwashingRepair)
//                         .HasColumnName("minor_handwashing_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorTapsRepair)
//                         .HasColumnName("minor_taps_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorToiletRepair)
//                         .HasColumnName("minor_toilet_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NameOfCommunity)
//                         .HasColumnName("name_of_community")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NameOfHcf)
//                         .HasColumnName("name_of_hcf")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfPatientsDaily)
//                         .HasColumnName("no_of_patients_daily")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfUrinal)
//                         .HasColumnName("no_of_urinal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OrganisationComitteeStatus)
//                         .HasColumnName("organisation_comittee_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OrganisationComitteeWork)
//                         .HasColumnName("organisation_comittee_work")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OwnBuilding)
//                         .HasColumnName("own_building")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoDustbin1)
//                         .HasColumnName("photo_dustbin_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet1)
//                         .HasColumnName("photo_female_toilet_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet2)
//                         .HasColumnName("photo_female_toilet_2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToiletDustbin1)
//                         .HasColumnName("photo_female_toilet_dustbin_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationOpd1)
//                         .HasColumnName("photo_hand_washing_station_opd_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationToilet1)
//                         .HasColumnName("photo_hand_washing_station_toilet_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf1)
//                         .HasColumnName("photo_hcf1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf2)
//                         .HasColumnName("photo_hcf2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf3)
//                         .HasColumnName("photo_hcf3")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AdditionalPhoto1)
//                         .HasColumnName("additional_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2)
//                         .HasColumnName("additional_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3)
//                         .HasColumnName("additional_photo_3")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4)
//                         .HasColumnName("additional_photo_4")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu1)
//                         .HasColumnName("photo_toilet_mdu_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu2)
//                         .HasColumnName("photo_toilet_mdu_2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletRamp1)
//                         .HasColumnName("photo_toilet_ramp_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterStation1)
//                         .HasColumnName("photo_water_station_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterTank1)
//                         .HasColumnName("photo_water_tank_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoDustbin1Uuid)
//                         .HasColumnName("photo_dustbin_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet1Uuid)
//                         .HasColumnName("photo_female_toilet_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet2Uuid)
//                         .HasColumnName("photo_female_toilet_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToiletDustbin1Uuid)
//                         .HasColumnName("photo_female_toilet_dustbin_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationOpd1Uuid)
//                         .HasColumnName("photo_hand_washing_station_opd_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationToilet1Uuid)
//                         .HasColumnName("photo_hand_washing_station_toilet_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf1Uuid)
//                         .HasColumnName("photo_hcf1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf2Uuid)
//                         .HasColumnName("photo_hcf2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf3Uuid)
//                         .HasColumnName("photo_hcf3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                         .HasColumnName("additional_photo_1_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                         .HasColumnName("additional_photo_2_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                         .HasColumnName("additional_photo_3_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4Uuid)
//                         .HasColumnName("additional_photo_4_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu1Uuid)
//                         .HasColumnName("photo_toilet_mdu_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu2Uuid)
//                         .HasColumnName("photo_toilet_mdu_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletRamp1Uuid)
//                         .HasColumnName("photo_toilet_ramp_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterStation1Uuid)
//                         .HasColumnName("photo_water_station_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterTank1Uuid)
//                         .HasColumnName("photo_water_tank_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityChemicalContamination)
//                         .HasColumnName("priority_chemical_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RampOutsideToilet)
//                         .HasColumnName("ramp_outside_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReasonForNoToilet)
//                         .HasColumnName("reason_for_no_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededHandwashing)
//                         .HasColumnName("reconstruction_needed_handwashing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededTaps)
//                         .HasColumnName("reconstruction_needed_taps")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededToilet)
//                         .HasColumnName("reconstruction_needed_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ResuableMedicalInstrumentsCleaned)
//                         .HasColumnName("resuable_medical_instruments_cleaned")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SalnalCondition)
//                         .HasColumnName("salnal_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SalnalCovered)
//                         .HasColumnName("salnal_covered")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SalnalStatus)
//                         .HasColumnName("salnal_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SalnalType)
//                         .HasColumnName("salnal_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SalnalVentilator)
//                         .HasColumnName("salnal_ventilator")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SeparateFemaleToilet)
//                         .HasColumnName("separate_female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapWaterInHandwashingStation)
//                         .HasColumnName("soap_water_in_handwashing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StatusOfToilet)
//                         .HasColumnName("status_of_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficientSpaceInToilet)
//                         .HasColumnName("sufficient_space_in_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TankSize)
//                         .HasColumnName("tank_size")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToBringWater)
//                         .HasColumnName("time_to_bring_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleanSchedule)
//                         .HasColumnName("toilet_clean_schedule")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAll)
//                         .HasColumnName("toilet_for_all")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAllUnused)
//                         .HasColumnName("toilet_for_all_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAllUsed)
//                         .HasColumnName("toilet_for_all_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAllWithWater)
//                         .HasColumnName("toilet_for_all_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatient)
//                         .HasColumnName("toilet_for_patient")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatientUnused)
//                         .HasColumnName("toilet_for_patient_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatientUsed)
//                         .HasColumnName("toilet_for_patient_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatientWithWater)
//                         .HasColumnName("toilet_for_patient_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaff)
//                         .HasColumnName("toilet_for_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaffUnused)
//                         .HasColumnName("toilet_for_staff_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaffUsed)
//                         .HasColumnName("toilet_for_staff_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaffWithWater)
//                         .HasColumnName("toilet_for_staff_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletHygiene)
//                         .HasColumnName("toilet_hygiene")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletInDr)
//                         .HasColumnName("toilet_in_dr")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletLockSystem)
//                         .HasColumnName("toilet_lock_system")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletSecurity)
//                         .HasColumnName("toilet_security")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToilet)
//                         .HasColumnName("total_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletUnused)
//                         .HasColumnName("total_toilet_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletUsed)
//                         .HasColumnName("total_toilet_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletWithWater)
//                         .HasColumnName("total_toilet_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfDustbins)
//                         .HasColumnName("type_of_dustbins")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfLatrine)
//                         .HasColumnName("type_of_latrine")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfLatrineOther)
//                         .HasColumnName("type_of_latrine_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalStatus)
//                         .HasColumnName("urinal_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableDisabledFriendlyToilet)
//                         .HasColumnName("usable_disabled_friendly_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToilet)
//                         .HasColumnName("usable_female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToiletWithMhm)
//                         .HasColumnName("usable_female_toilet_with_mhm")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableHandwashingStation)
//                         .HasColumnName("usable_handwashing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableMaleToilet)
//                         .HasColumnName("usable_male_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableStaffToilet)
//                         .HasColumnName("usable_staff_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(256);

//                entity.Property(e => e.WardNumber)
//                         .HasColumnName("ward_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteDisposed)
//                         .HasColumnName("waste_disposed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteNirmulikaran)
//                         .HasColumnName("waste_nirmulikaran")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterInsufficient)
//                         .HasColumnName("water_insufficient")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterManaged)
//                         .HasColumnName("water_managed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierAvailability)
//                         .HasColumnName("water_purifier_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierCondition)
//                         .HasColumnName("water_purifier_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityTestedResult)
//                         .HasColumnName("water_quality_tested_result")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityTestedStatus)
//                         .HasColumnName("water_quality_tested_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterSafeToDrink)
//                         .HasColumnName("water_safe_to_drink")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterStorageTank)
//                         .HasColumnName("water_storage_tank")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankCoveredStatus)
//                         .HasColumnName("water_tank_covered_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentStatus)
//                         .HasColumnName("water_treatment_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentType)
//                         .HasColumnName("water_treatment_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentTypeOther)
//                         .HasColumnName("water_treatment_type_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WhoCleansLatrineHp)
//                         .HasColumnName("who_cleans_latrine_hp")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WorkingTaps)
//                         .HasColumnName("working_taps")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationTrainingStatus)
//                         .HasColumnName("sanitation_training_status")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WaterAvailabilityDuringSurvey)
//                         .HasColumnName("water_availability_during_survey")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherWasteDisposed)
//                         .HasColumnName("other_waste_disposed")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SharpWasteMgmtAndTreatment)
//                         .HasColumnName("sharp_waste_mgmt_and_treatment")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherSharpWasteMgmtAndTreatment)
//                         .HasColumnName("other_sharp_waste_mgmt_and_treatment")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UsableCommunalToilet).HasColumnName("usable_communal_toilet");
//                entity.Property(e => e.UsableFemaleToiletWithoutMhm).HasColumnName("usable_female_toilet_without_mhm");
//                entity.Property(e => e.UnusedMinorRepairNeededToilet).HasColumnName("unused_minor_repair_needed_toilet");
//                entity.Property(e => e.UnusedMajorRepairNeededToilet).HasColumnName("unused_major_repair_needed_toilet");
//            });

//            modelBuilder.Entity<TblWasteManagementService>(entity =>
//            {
//                entity.HasKey(e => e.Id).HasName("tbl_waste_management_service_pkey");

//                entity.ToTable("tbl_waste_management_service", "waste_management_service");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.AdminEmployeesNumber).HasColumnName("admin_employees_number");
//                entity.Property(e => e.AnnualMunTaxPaid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("annual_mun_tax_paid");
//                entity.Property(e => e.OtherFacilities)
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_facilities");
//                entity.Property(e => e.AppVersion)
//                    .HasColumnType("character varying")
//                    .HasColumnName("app_version");
//                entity.Property(e => e.CapacityBuildingTrainingPeriod)
//                    .HasColumnType("character varying")
//                    .HasColumnName("capacity_building_training_period");
//                entity.Property(e => e.Caption1)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption1");
//                entity.Property(e => e.Caption2)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption2");
//                entity.Property(e => e.Caption3)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption3");
//                entity.Property(e => e.Caption4)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption4");
//                entity.Property(e => e.CertifiedWasteContractorOpportunity)
//                    .HasColumnType("character varying")
//                    .HasColumnName("certified_waste_contractor_opportunity");
//                entity.Property(e => e.CommercialCustomers).HasColumnName("commercial_customers");
//                entity.Property(e => e.CommercialWmFee).HasColumnName("commercial_wm_fee");
//                entity.Property(e => e.CompanyAnnualIncome).HasColumnName("company_annual_income");
//                entity.Property(e => e.CompanyAnnualProfit).HasColumnName("company_annual_profit");
//                entity.Property(e => e.CompanyName)
//                    .HasColumnType("character varying")
//                    .HasColumnName("company_name");
//                entity.Property(e => e.CompostManureNrs).HasColumnName("compost_manure_nrs");
//                entity.Property(e => e.CompostPercentage).HasColumnName("compost_percentage");
//                entity.Property(e => e.CompostingWasteSellInfo)
//                    .HasColumnType("character varying")
//                    .HasColumnName("composting_waste_sell_info");
//                entity.Property(e => e.ContributionForEffectiveSwm)
//                    .HasColumnType("character varying")
//                    .HasColumnName("contribution_for_effective_swm");
//                entity.Property(e => e.CustomerSupportInWs)
//                    .HasColumnType("character varying")
//                    .HasColumnName("customer_support_in_ws");
//                entity.Property(e => e.DbName)
//                    .HasColumnType("character varying")
//                    .HasColumnName("db_name");
//                entity.Property(e => e.DistrictCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("district_code");
//                entity.Property(e => e.EditedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("edited_by");
//                entity.Property(e => e.EditedOn).HasColumnName("edited_on").HasColumnType("date");
//                entity.Property(e => e.EffectivePlansGuidelinesStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("effective_plans_guidelines_status");
//                entity.Property(e => e.Elevation).HasColumnName("elevation");
//                entity.Property(e => e.EstablishedDate)
//                    .HasColumnType("character varying")
//                    .HasColumnName("established_date");
//                entity.Property(e => e.GardenCustomers).HasColumnName("garden_customers");
//                entity.Property(e => e.HealthCareWmFee).HasColumnName("health_care_wm_fee");
//                entity.Property(e => e.HealthCustomers).HasColumnName("health_customers");
//                entity.Property(e => e.HouseholdCustomers).HasColumnName("household_customers");
//                entity.Property(e => e.HouseholdWmFee).HasColumnName("household_wm_fee");
//                entity.Property(e => e.PlasticFractions).HasColumnName("plastic_fractions");
//                entity.Property(e => e.PaperAndCartonFractions).HasColumnName("paper_and_carton_fractions");
//                entity.Property(e => e.FoodWasteFractions).HasColumnName("food_waste_fractions");
//                entity.Property(e => e.GlassFractions).HasColumnName("glass_fractions");
//                entity.Property(e => e.TextileFractions).HasColumnName("textile_fractions");
//                entity.Property(e => e.MetalFractions).HasColumnName("metal_fractions");
//                entity.Property(e => e.RubberAndLeatherFractions).HasColumnName("rubber_and_leather_fractions");
//                entity.Property(e => e.WoodFractions).HasColumnName("wood_fractions");
//                entity.Property(e => e.HazardousWasteFractions).HasColumnName("hazardous_waste_fractions");
//                entity.Property(e => e.BulkyWasteFractions).HasColumnName("bulky_waste_fractions");
//                entity.Property(e => e.IdealWasteMgmtOpinion)
//                    .HasColumnType("character varying")
//                    .HasColumnName("ideal_waste_mgmt_opinion");
//                entity.Property(e => e.IncinerationPercentage).HasColumnName("incineration_percentage");
//                entity.Property(e => e.IndustrialCustomers).HasColumnName("industrial_customers");
//                entity.Property(e => e.IndustrialWmFee).HasColumnName("industrial_wm_fee");
//                entity.Property(e => e.InstitutionalCustomers).HasColumnName("institutional_customers");
//                entity.Property(e => e.InstitutionalWmFee).HasColumnName("institutional_wm_fee");
//                entity.Property(e => e.InterviewerName)
//                    .HasColumnType("character varying")
//                    .HasColumnName("interviewer_name");
//                entity.Property(e => e.LandfillPercentage).HasColumnName("landfill_percentage");
//                entity.Property(e => e.Latitude).HasColumnName("latitude");
//                entity.Property(e => e.Longitude).HasColumnName("longitude");
//                entity.Property(e => e.MechanicalEquipmentsTypeUsed)
//                    .HasColumnType("character varying")
//                    .HasColumnName("mechanical_equipments_type_used");
//                entity.Property(e => e.MunGoalForSwmOpinion)
//                    .HasColumnType("character varying")
//                    .HasColumnName("mun_goal_for_swm_opinion");
//                entity.Property(e => e.MuniCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("muni_code");
//                entity.Property(e => e.UniqueCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("unique_code");
//                entity.Property(e => e.NeededSupportByCompany)
//                    .HasColumnType("character varying")
//                    .HasColumnName("needed_support_by_company");
//                entity.Property(e => e.OfficeAddress)
//                    .HasColumnType("character varying")
//                    .HasColumnName("office_address");
//                entity.Property(e => e.OthersWmFee).HasColumnName("others_wm_fee");
//                entity.Property(e => e.OtherWasteNrs).HasColumnName("other_waste_nrs");
//                entity.Property(e => e.OtherWasteSellInfo)
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_waste_sell_info");
//                entity.Property(e => e.OtherWsCustomerType)
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_ws_customer_type");
//                entity.Property(e => e.OthersCustomers).HasColumnName("others_customers");
//                entity.Property(e => e.OthersEmployeesNumber).HasColumnName("others_employees_number");
//                entity.Property(e => e.Photo1)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo1");
//                entity.Property(e => e.Photo2)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo2");
//                entity.Property(e => e.Photo3)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo3");
//                entity.Property(e => e.Photo4)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo4");
//                entity.Property(e => e.PpeProvidedStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("ppe_provided_status");
//                entity.Property(e => e.FieldOfficeAddress)
//                    .HasColumnType("character varying")
//                    .HasColumnName("field_office_address");
//                entity.Property(e => e.ProvinceCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("province_code");
//                entity.Property(e => e.RecyclableWasteNrs).HasColumnName("recyclable_waste_nrs");
//                entity.Property(e => e.RecyclableWasteSellInfo)
//                    .HasColumnType("character varying")
//                    .HasColumnName("recyclable_waste_sell_info");
//                entity.Property(e => e.RecyclePercentage).HasColumnName("recycle_percentage");
//                entity.Property(e => e.ReusableWasteNrs).HasColumnName("reusable_waste_nrs");
//                entity.Property(e => e.ReusableWasteSellInfo)
//                    .HasColumnType("character varying")
//                    .HasColumnName("reusable_waste_sell_info");
//                entity.Property(e => e.ReusePercentage).HasColumnName("reuse_percentage");
//                entity.Property(e => e.SafeDisposalMethodology)
//                    .HasColumnType("character varying")
//                    .HasColumnName("safe_disposal_methodology");
//                entity.Property(e => e.SegregatedWasteCollectionStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("segregated_waste_collection_status");
//                entity.Property(e => e.SolutionForWsImplementation)
//                    .HasColumnType("character varying")
//                    .HasColumnName("solution_for_ws_implementation");
//                entity.Property(e => e.SuggestionForEffectiveSwm)
//                    .HasColumnType("character varying")
//                    .HasColumnName("suggestion_for_effective_swm");
//                entity.Property(e => e.SwmPlansStarted)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_plans_started");
//                entity.Property(e => e.SwmTrainingStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_training_status");
//                entity.Property(e => e.SwmTrainingTypes)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_training_types");
//                entity.Property(e => e.SwmsCoveragePercent).HasColumnName("swms_coverage_percent");
//                entity.Property(e => e.TechnicalStaffNumber).HasColumnName("technical_staff_number");
//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//                entity.Property(e => e.TransferStationAddress)
//                    .HasColumnType("character varying")
//                    .HasColumnName("transfer_station_address");
//                entity.Property(e => e.TransferStationArea)
//                    .HasColumnType("character varying")
//                    .HasColumnName("transfer_station_area");
//                entity.Property(e => e.UnskilledEmployeesNumber).HasColumnName("unskilled_employees_number");
//                entity.Property(e => e.UploadedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("uploaded_by");
//                entity.Property(e => e.UploadedOn)
//                    .HasColumnType("character varying")
//                    .HasColumnName("uploaded_on");
//                entity.Property(e => e.Uuid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("uuid");
//                entity.Property(e => e.VisitDate)
//                    .HasColumnType("character varying")
//                    .HasColumnName("visit_date");
//                entity.Property(e => e.WasteFractionsTreatments)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_fractions_treatments");
//                entity.Property(e => e.WcServiceMunArea)
//                    .HasColumnType("character varying")
//                    .HasColumnName("wc_service_mun_area");
//                entity.Property(e => e.WmMunicipalitySupport)
//                    .HasColumnType("character varying")
//                    .HasColumnName("wm_municipality_support");
//                entity.Property(e => e.WmMunicipalitySupportStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("wm_municipality_support_status");
//                entity.Property(e => e.WmpSatisfactionStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("wmp_satisfaction_status");
//                entity.Property(e => e.WorkersHealthAndSafetyMeasures)
//                    .HasColumnType("character varying")
//                    .HasColumnName("workers_health_and_safety_measures");
//                entity.Property(e => e.WorkersHealthAndSafetyMeasuresStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("workers_health_and_safety_measures_status");
//                entity.Property(e => e.WorkersUsingPpe).HasColumnName("workers_using_ppe");
//                entity.Property(e => e.WsCustomerType)
//                    .HasColumnType("character varying")
//                    .HasColumnName("ws_customer_type");
//            });

//            modelBuilder.Entity<HhCapexFactorDependingOnYear>(entity =>
//            {
//                entity.ToTable("hh_capex_factor_depending_on_year", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CapexFactor)
//                         .HasColumnName("capex_factor")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.NoOfYears).HasColumnName("no_of_years");

//                entity.Property(e => e.Years).HasColumnName("years");
//            });

//            modelBuilder.Entity<HhCols>(entity =>
//            {
//                entity.ToTable("hh_cols", "household");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('household.cols_id_seq'::regclass)");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Pipedsys>(entity =>
//            {
//                entity.ToTable("pipedsys", "temptbl_munidashboard");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.MunName)
//                         .HasColumnName("mun_name")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Safely)
//                         .HasColumnName("safely");
//                entity.Property(e => e.Basic)
//                         .HasColumnName("basic");
//                entity.Property(e => e.Unimproved)
//                         .HasColumnName("unimproved");
//                entity.Property(e => e.Unserved)
//                         .HasColumnName("unserved");
//            });

//            modelBuilder.Entity<HhInvestmentSafelyManagedWater>(entity =>
//            {
//                entity.ToTable("hh_investment_safely_managed_water", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.NrsPerCapitaPerYear)
//                         .HasColumnName("nrs_per_capita_per_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.NrsPerHhPerYear)
//                         .HasColumnName("nrs_per_hh_per_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Particular)
//                         .HasColumnName("particular")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HhLut>(entity =>
//            {
//                entity.ToTable("hh_lut", "household");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('household.look_up_new_id_seq'::regclass)");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HhLut1>(entity =>
//            {
//                entity.ToTable("hh_lut1", "household");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.QbCols)
//         .HasColumnName("qb_cols")
//         .HasColumnType("character varying")
//         .HasMaxLength(10);


//                entity.Property(e => e.ScopeId)
//                         .HasColumnName("scope_id")
//                         .HasComment(@"1->db_info
//2->loc
//3->info
//4->respondent_info
//5->respondent_info1
//6->household_info
//7->household_info0
//8->tubewell_info
//9->toilet_info
//10->water_info
//11->water_info_new
//12->clean_info
//13->pit_info
//14->pit_info0
//15->waste_manage
//16->photo");
//            });

//            modelBuilder.Entity<HhOpexSanitationComponent>(entity =>
//            {
//                entity.ToTable("hh_opex_sanitation_component", "wash_plan_reference");

//                entity.HasComment("Amount to be calculate with reference to rate table");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.QuantityRequiredPerYear)
//                         .HasColumnName("quantity_required_per_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.RateId).HasColumnName("rate_id");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HhSanitaionYearsPlanned>(entity =>
//            {
//                entity.ToTable("hh_sanitaion_years_planned", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.YearsPlanned).HasColumnName("years_planned");
//            });

//            modelBuilder.Entity<HhSanitationConsCost>(entity =>
//            {
//                entity.ToTable("hh_sanitation_cons_cost", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Amount).HasColumnName("amount");

//                entity.Property(e => e.FlushType)
//                         .HasColumnName("flush_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                         .HasColumnName("toilet_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HhSolidWasteComponentPerYear>(entity =>
//            {
//                entity.ToTable("hh_solid_waste_component_per_year", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Quantity)
//                         .HasColumnName("quantity")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.RateId).HasColumnName("rate_id");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<InsLut>(entity =>
//            {
//                entity.ToTable("ins_lut", "institution");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('institution.look_up_new_id_seq'::regclass)");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<InsLut1>(entity =>
//            {
//                entity.ToTable("ins_lut1", "institution");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<InventoryCrudTracker>(entity =>
//            {
//                entity.ToTable("inventory_crud_tracker", "crud_track");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Table)
//                         .HasColumnName("table")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Column)
//                         .HasColumnName("column")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Action)
//                         .HasColumnName("action")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.PreviousVal)
//                         .HasColumnName("previous_val")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedFrom)
//                         .HasColumnName("edited_from")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedId)
//                         .HasColumnName("edited_id")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//            });
//            modelBuilder.Entity<ProjectCrudTracker>(entity =>
//            {
//                entity.ToTable("project_crud_tracker", "crud_track");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Action)
//                         .HasColumnName("action")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ProCode)
//                         .HasColumnName("previous_val")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//            });
//            modelBuilder.Entity<SustainabilityCrudTracker>(entity =>
//            {
//                entity.ToTable("sustainability_crud_tracker", "crud_track");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Table)
//                         .HasColumnName("table")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Column)
//                         .HasColumnName("column")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Action)
//                         .HasColumnName("action")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.PreviousVal)
//                         .HasColumnName("previous_val")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedFrom)
//                         .HasColumnName("edited_from")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedId)
//                         .HasColumnName("edited_id")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//            });
//            modelBuilder.Entity<WashToolCrudTracker>(entity =>
//            {
//                entity.ToTable("wash_tool_crud_tracker", "crud_track");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Table)
//                         .HasColumnName("table")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Column)
//                         .HasColumnName("column")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Action)
//                         .HasColumnName("action")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.PreviousVal)
//                         .HasColumnName("previous_val")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedFrom)
//                         .HasColumnName("edited_from")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedId)
//                         .HasColumnName("edited_id")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//            });

//            modelBuilder.Entity<Junction>(entity =>
//            {
//                entity.ToTable("junction", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.JuncNo)
//                         .HasColumnName("junc_no")
//                         .HasMaxLength(20);

//                entity.Property(e => e.Photo1Desc).HasColumnName("photo1_desc");

//                entity.Property(e => e.Photo1Path).HasColumnName("photo1_path");
//                entity.Property(e => e.Photo1PathUuid).HasColumnName("photo1_path_uuid");

//                entity.Property(e => e.Photo2Desc).HasColumnName("photo2_desc");

//                entity.Property(e => e.Photo2Path).HasColumnName("photo2_path");
//                entity.Property(e => e.Photo2PathUuid).HasColumnName("photo2_path_uuid");

//                entity.Property(e => e.JuncType)
//                         .HasColumnName("junc_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.Junction)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .HasConstraintName("pro_uuid");

//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//            });

//            modelBuilder.Entity<JunctionHistory>(entity =>
//            {
//                entity.ToTable("junction_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.junction_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.JuncNo)
//                         .HasColumnName("junc_no")
//                         .HasMaxLength(20);

//                entity.Property(e => e.JuncType)
//                         .HasColumnName("junc_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.JunctionHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<LabRegistration>(entity =>
//            {
//                entity.ToTable("lab_registration", "wq_lab");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.FocalPerson)
//                         .HasColumnName("focal_person")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.FocalPersonNumber)
//                         .HasColumnName("focal_person_number")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ModuleFocalPerson)
//                         .HasColumnName("module_focal_person")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ModuleFocalPersonNumber)
//                         .HasColumnName("module_focal_person_number")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AddedOn)
//                         .HasColumnName("added_on")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Address)
//                         .HasColumnName("address")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.District)
//                         .HasColumnName("district")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Email)
//                         .HasColumnName("email")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabName)
//                         .HasColumnName("lab_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabRegNo)
//                         .HasColumnName("lab_reg_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabSubType)
//                         .HasColumnName("lab_sub_type")
//                         .HasDefaultValueSql("0")
//                         .HasComment(@"Under Lab type 1: Government Lab
//1 - Laboratories under DWSSM
//2 - Laboratories of surveillance Agencies
//3 - Provincial Lab
//4 - Municipality Lab");

//                entity.Property(e => e.LabType)
//                         .HasColumnName("lab_type")
//                         .HasComment(@"1- Govt Lab
//2 - Private Lab
//3 - User Committee Lab
//4 - I/NGO Lab");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LogoPath)
//                         .HasColumnName("logo_path")
//                         .HasColumnType("character varying")
//                         .HasComment("letterhead");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.Municipality)
//                         .HasColumnName("municipality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Province)
//                         .HasColumnName("province")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Status).HasColumnName("status");

//                entity.Property(e => e.SubName)
//                         .HasColumnName("sub_name")
//                         .HasColumnType("character varying")
//                         .HasComment("Office/Project name");

//                entity.Property(e => e.Telephone)
//                         .HasColumnName("telephone")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<LandUse>(entity =>
//            {
//                entity.ToTable("land_use", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AreaHa).HasColumnName("area_ha");

//                entity.Property(e => e.Category)
//                         .HasColumnName("category")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Muncode)
//                         .HasColumnName("muncode")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<LeftoutTaps>(entity =>
//            {
//                entity.ToTable("leftout_taps", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DalHh)
//                         .HasColumnName("dal_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FemalePop).HasColumnName("female_pop");

//                entity.Property(e => e.HhServed)
//                         .HasColumnName("hh_served")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.HhToilet).HasColumnName("hh_toilet");

//                entity.Property(e => e.JanHh)
//                         .HasColumnName("jan_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.LeftoutReason)
//                         .HasColumnName("leftout_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MiHh)
//                         .HasColumnName("mi_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapContact)
//                         .HasColumnName("tap_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapNo)
//                         .HasColumnName("tap_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapOwner)
//                         .HasColumnName("tap_owner")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("''::character varying");

//                entity.Property(e => e.TapType)
//                         .HasColumnName("tap_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.CurrentSource).HasColumnName("current_source");

//                entity.Property(e => e.PhotoPath).HasColumnName("photo_path");
//                entity.Property(e => e.PhotoPathUuid).HasColumnName("photo_path_uuid");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.LeftoutTaps)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<LeftoutTapsHistory>(entity =>
//            {
//                entity.ToTable("leftout_taps_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.leftout_taps_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DalHh)
//                         .HasColumnName("dal_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FemalePop).HasColumnName("female_pop");

//                entity.Property(e => e.HhServed)
//                         .HasColumnName("hh_served")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.HhToilet).HasColumnName("hh_toilet");

//                entity.Property(e => e.JanHh)
//                         .HasColumnName("jan_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.LeftoutReason)
//                         .HasColumnName("leftout_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MiHh)
//                         .HasColumnName("mi_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapContact)
//                         .HasColumnName("tap_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapNo)
//                         .HasColumnName("tap_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapOwner)
//                         .HasColumnName("tap_owner")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("''::character varying");

//                entity.Property(e => e.TapType)
//                         .HasColumnName("tap_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.LeftoutTapsHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<LocalbodiesNepal>(entity =>
//            {
//                entity.ToTable("localbodies_nepal", "basemap");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AreaHa).HasColumnName("area_ha");

//                entity.Property(e => e.AreaHa1).HasColumnName("area_ha_1");

//                entity.Property(e => e.Dcode).HasColumnName("dcode");

//                entity.Property(e => e.District)
//                         .HasColumnName("district")
//                         .HasMaxLength(50);

//                entity.Property(e => e.Geom)
//                         .HasColumnName("geom")
//                         .HasColumnType("geometry(MultiPolygon,4326)");

//                entity.Property(e => e.LocBodies)
//                         .HasColumnName("loc_bodies")
//                         .HasMaxLength(60);

//                entity.Property(e => e.LocCode).HasColumnName("loc_code");

//                entity.Property(e => e.LocNepali)
//                         .HasColumnName("loc_nepali")
//                         .HasMaxLength(250);

//                entity.Property(e => e.Province).HasColumnName("province");

//                entity.Property(e => e.Zone)
//                         .HasColumnName("zone")
//                         .HasMaxLength(50);
//            });

//            modelBuilder.Entity<LutCs>(entity =>
//            {
//                entity.ToTable("lut_cs", "community_sanitation");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('community_sanitation.lut_sanitation_id_seq'::regclass)");

//                entity.Property(e => e.DataType)
//                         .HasColumnName("data_type")
//                         .HasColumnType("character varying")
//                         .HasComment(@"Table names
//");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<LutDrainage>(entity =>
//            {
//                entity.ToTable("lut_drainage", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DataType)
//                         .HasColumnName("data_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Layer)
//                         .HasColumnName("layer")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<LutSolidWaste>(entity =>
//            {
//                entity.ToTable("lut_solid_waste", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DataType)
//                         .HasColumnName("data_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Layer)
//                         .HasColumnName("layer")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<LutSustainability>(entity =>
//            {
//                entity.ToTable("lut_sustainability", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Eng)
//                         .HasColumnName("eng")
//                         .HasMaxLength(100);

//                entity.Property(e => e.Nep)
//                         .HasColumnName("nep")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<LutUnserved>(entity =>
//            {
//                entity.ToTable("lut_unserved", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DataType)
//                         .HasColumnName("data_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Layer)
//                         .HasColumnName("layer")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Manhole>(entity =>
//            {
//                entity.ToTable("manhole", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CombinedWithRainInlet)
//                         .HasColumnName("combined_with_rain_inlet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConditionOfCover)
//                         .HasColumnName("condition_of_cover")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConstructionYear)
//                         .HasColumnName("construction_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CouldOpen)
//                         .HasColumnName("could_open")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverDiameter)
//                         .HasColumnName("cover_diameter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverInterventionRequired)
//                         .HasColumnName("cover_intervention_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverMaterial)
//                         .HasColumnName("cover_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverShape)
//                         .HasColumnName("cover_shape")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverThickness)
//                         .HasColumnName("cover_thickness")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverWidth)
//                         .HasColumnName("cover_width")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DebrisComposition)
//                         .HasColumnName("debris_composition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DebrisDepth)
//                         .HasColumnName("debris_depth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DepthToBottom)
//                         .HasColumnName("depth_to_bottom")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FlowComposition)
//                         .HasColumnName("flow_composition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ManholeCode)
//                         .HasColumnName("manhole_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeCondition)
//                         .HasColumnName("manhole_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeDiameter)
//                         .HasColumnName("manhole_diameter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeInterventionRequired)
//                         .HasColumnName("manhole_intervention_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeLocation)
//                         .HasColumnName("manhole_location")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeMaterial)
//                         .HasColumnName("manhole_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeShape)
//                         .HasColumnName("manhole_shape")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeToplevel)
//                         .HasColumnName("manhole_toplevel")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManholeWidth)
//                         .HasColumnName("manhole_width")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PavementTypeManhole)
//                         .HasColumnName("pavement_type_manhole")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Manhole)
//                         .HasColumnName("photo1_manhole")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Manhole)
//                         .HasColumnName("photo2_manhole")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PipeBlocking)
//                         .HasColumnName("pipe_blocking")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReasonForNotOpening)
//                         .HasColumnName("reason_for_not_opening")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabilitationYear)
//                         .HasColumnName("rehabilitation_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<MatInvData>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("mat_inv_data");

//                entity.Property(e => e.CountData).HasColumnName("count_data");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.NoOfData)
//                         .HasColumnName("no_of_data")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<MatWashObsCount>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("mat_wash_obs_count");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.WashSector).HasColumnName("wash_sector");
//            });

//            modelBuilder.Entity<MatWashWeekly>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("mat_wash_weekly");

//                entity.Property(e => e.CsObs).HasColumnName("cs_obs");

//                entity.Property(e => e.Day)
//                         .HasColumnName("day")
//                         .HasColumnType("date");

//                entity.Property(e => e.HcfObs).HasColumnName("hcf_obs");

//                entity.Property(e => e.HhObs).HasColumnName("hh_obs");

//                entity.Property(e => e.Nday).HasColumnName("nday");

//                entity.Property(e => e.PtObs).HasColumnName("pt_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");

//                entity.Property(e => e.SklObs).HasColumnName("skl_obs");

//                entity.Property(e => e.UnObs).HasColumnName("un_obs");
//            });

//            modelBuilder.Entity<MonthDataComSan>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("month_data_com_san");

//                entity.Property(e => e.Dmonth).HasColumnName("dmonth");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");
//            });

//            modelBuilder.Entity<MonthDataHcf>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("month_data_hcf");

//                entity.Property(e => e.Dmonth).HasColumnName("dmonth");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");
//            });

//            modelBuilder.Entity<MonthDataPublicToilet>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("month_data_public_toilet");

//                entity.Property(e => e.Dmonth).HasColumnName("dmonth");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");
//            });

//            modelBuilder.Entity<MonthDataSchool>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("month_data_school");

//                entity.Property(e => e.Dmonth).HasColumnName("dmonth");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");
//            });

//            modelBuilder.Entity<MonthDataTap>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("month_data_tap");

//                entity.Property(e => e.Dmonth).HasColumnName("dmonth");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");
//            });

//            modelBuilder.Entity<MonthDataUnserved>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("month_data_unserved");

//                entity.Property(e => e.Dmonth).HasColumnName("dmonth");

//                entity.Property(e => e.NoOfObs).HasColumnName("no_of_obs");

//                entity.Property(e => e.RowNumber).HasColumnName("row_number");
//            });

//            modelBuilder.Entity<MunCodes>(entity =>
//            {
//                entity.ToTable("mun_codes", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Municipality>(entity =>
//            {
//                entity.ToTable("municipality", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunName)
//                         .HasColumnName("mun_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunNameNep)
//                         .HasColumnName("mun_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunType)
//                         .HasColumnName("mun_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunUuid)
//                         .HasColumnName("mun_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom)
//                         .HasColumnName("the_geom")
//                         .HasColumnType("geometry(Polygon,4326)");
//            });
//            modelBuilder.Entity<TblSolidwasteManagement>(entity =>
//            {
//                entity.HasKey(e => e.Id).HasName("tbl_solidwaste_management_pkey");

//                entity.ToTable("tbl_solidwaste_management", "solidwaste_management");

//                entity.HasIndex(e => e.Uuid, "tbl_solidwaste_management_uuid_key").IsUnique();

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");
//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.TotalWasteGeneratedP)
//                         .HasColumnName("total_waste_generated_p");
//                entity.Property(e => e.RespondentName)
//                         .HasColumnName("respondent_name")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.TotalWasteGenerated)
//                         .HasColumnName("total_waste_generated")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UploadedBy)
//                        .HasColumnName("uploaded_by")
//                        .HasColumnType("character varying");
//                entity.Property(e => e.EditedDate)
//                         .HasColumnName("edited_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.AgeGroup)
//                    .HasColumnType("character varying")
//                    .HasColumnName("age_group");
//                entity.Property(e => e.AppVersion)
//                    .HasColumnType("character varying")
//                    .HasColumnName("app_version");
//                entity.Property(e => e.MajorOccupation)
//                    .HasColumnType("character varying")
//                    .HasColumnName("major_occupation");
//                entity.Property(e => e.CollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("collected_by");
//                entity.Property(e => e.BulkyWasteCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("bulky_waste_collected_by");
//                entity.Property(e => e.BulkyWasteGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("bulky_waste_generated_wt");
//                entity.Property(e => e.Caption1)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption1");
//                entity.Property(e => e.Caption2)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption2");
//                entity.Property(e => e.Caption3)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption3");
//                entity.Property(e => e.Caption4)
//                    .HasColumnType("character varying")
//                    .HasColumnName("caption4");
//                entity.Property(e => e.CollectedSolidWasteMgmt)
//                    .HasColumnType("character varying")
//                    .HasColumnName("collected_solid_waste_mgmt");
//                entity.Property(e => e.ContributionForEffectiveSwm)
//                    .HasColumnType("character varying")
//                    .HasColumnName("contribution_for_effective_swm");
//                entity.Property(e => e.DbName)
//                    .HasColumnType("character varying")
//                    .HasColumnName("db_name");
//                entity.Property(e => e.DistrictCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("district_code");
//                entity.Property(e => e.DurationLivedInWard)
//                    .HasColumnType("character varying")
//                    .HasColumnName("duration_lived_in_ward");
//                entity.Property(e => e.EducationLevel)
//                    .HasColumnType("character varying")
//                    .HasColumnName("education_level");
//                entity.Property(e => e.Elevation).HasColumnName("elevation");
//                entity.Property(e => e.ExcellentWasteMgmtServiceBenefits)
//                    .HasColumnType("character varying")
//                    .HasColumnName("excellent_waste_mgmt_service_benefits");
//                entity.Property(e => e.ExcellentWasteMgmtServiceOpinion)
//                    .HasColumnType("character varying")
//                    .HasColumnName("excellent_waste_mgmt_service_opinion");
//                entity.Property(e => e.FoodWasteCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("food_waste_collected_by");
//                entity.Property(e => e.FoodWasteGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("food_waste_generated_wt");
//                entity.Property(e => e.GardenWasteCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("garden_waste_collected_by");
//                entity.Property(e => e.GardenWasteGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("garden_waste_generated_wt");
//                entity.Property(e => e.Gender)
//                    .HasColumnType("character varying")
//                    .HasColumnName("gender");
//                entity.Property(e => e.GlassCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("glass_collected_by");
//                entity.Property(e => e.GlassGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("glass_generated_wt");
//                entity.Property(e => e.HaphazardWasteDisposalImpacts)
//                    .HasColumnType("character varying")
//                    .HasColumnName("haphazard_waste_disposal_impacts");
//                entity.Property(e => e.HazardousWasteCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("hazardous_waste_collected_by");
//                entity.Property(e => e.HazardousWasteGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("hazardous_waste_generated_wt");
//                entity.Property(e => e.HhMonthlyIncome).HasColumnName("hh_monthly_income");
//                entity.Property(e => e.HhSize).HasColumnName("hh_size");
//                entity.Property(e => e.Latitude).HasColumnName("latitude");
//                entity.Property(e => e.Longitude).HasColumnName("longitude");
//                entity.Property(e => e.MetalsCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("metals_collected_by");
//                entity.Property(e => e.MetalsGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("metals_generated_wt");
//                entity.Property(e => e.MuniCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("muni_code");
//                entity.Property(e => e.MunicipalityCollectionRating)
//                    .HasColumnType("character varying")
//                    .HasColumnName("municipality_collection_rating");
//                //entity.Property(e => e.OtherSolidWasteType)
//                //    .HasColumnType("character varying")
//                //    .HasColumnName("other_solid_waste_type");
//                entity.Property(e => e.OtherTimeToReachPublicBins)
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_time_to_reach_public_bins");
//                entity.Property(e => e.OtherWasteContainerType)
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_waste_container_type");
//                entity.Property(e => e.OtherWasteGenerated)
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_waste_generated");
//                entity.Property(e => e.OtherWasteGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("other_waste_generated_wt");
//                entity.Property(e => e.PaperAndCartoonCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("paper_and_cartoon_collected_by");
//                entity.Property(e => e.PaperAndCartoonGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("paper_and_cartoon_generated_wt");
//                entity.Property(e => e.Photo1Uuid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo1_uuid");
//                entity.Property(e => e.Photo2Uuid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo2_uuid");
//                entity.Property(e => e.Photo3Uuid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo3_uuid");
//                entity.Property(e => e.Photo4Uuid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("photo4_uuid");
//                entity.Property(e => e.PlasticsCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("plastics_collected_by");
//                entity.Property(e => e.PlasticsGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("plastics_generated_wt");
//                entity.Property(e => e.ProvinceCode)
//                    .HasColumnType("character varying")
//                    .HasColumnName("province_code");
//                entity.Property(e => e.PublicBinsCondition)
//                    .HasColumnType("character varying")
//                    .HasColumnName("public_bins_condition");
//                entity.Property(e => e.PublicBinsEmptyStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("public_bins_empty_status");
//                entity.Property(e => e.PublicBinsUseStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("public_bins_use_status");
//                entity.Property(e => e.PvtCompanyCollectionRating)
//                    .HasColumnType("character varying")
//                    .HasColumnName("pvt_company_collection_rating");
//                entity.Property(e => e.RecyclingImportance)
//                    .HasColumnType("character varying")
//                    .HasColumnName("recycling_importance");
//                entity.Property(e => e.RubberAndLeatherCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("rubber_and_leather_collected_by");
//                entity.Property(e => e.RubberAndLeatherGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("rubber_and_leather_generated_wt");
//                entity.Property(e => e.GoodServices)
//                    .HasColumnType("character varying")
//                    .HasColumnName("good_services");
//                entity.Property(e => e.PoorServices)
//                    .HasColumnType("character varying")
//                    .HasColumnName("poor_services");
//                entity.Property(e => e.SwmTrainingNoParticipationReason)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_training_no_participation_reason");
//                entity.Property(e => e.PublicBinsConditionOthers)
//                    .HasColumnType("character varying")
//                    .HasColumnName("public_bins_condition_others");
//                entity.Property(e => e.AmtWillingToPay)
//                    .HasColumnName("amt_willing_to_pay");
//                entity.Property(e => e.SolidWasteAndMgmtInfoSource)
//                    .HasColumnType("character varying")
//                    .HasColumnName("solid_waste_and_mgmt_info_source");
//                entity.Property(e => e.SolidWasteType)
//                    .HasColumnType("character varying")
//                    .HasColumnName("solid_waste_type");
//                entity.Property(e => e.SwmResponsibilityStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_responsibility_status");
//                entity.Property(e => e.SwmServiceNoPreferenceReason)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_service_no_preference_reason");
//                entity.Property(e => e.SwmServicePreferenceStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_service_preference_status");
//                entity.Property(e => e.SwmTrainingNoParticipationReasonOthers)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_training_no_participation_reason_others");
//                entity.Property(e => e.SwmTrainingParticipation)
//                    .HasColumnType("character varying")
//                    .HasColumnName("swm_training_participation");
//                entity.Property(e => e.TextileCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("textile_collected_by");
//                entity.Property(e => e.TextileGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("textile_generated_wt");
//                entity.Property(e => e.TimetoReachPublicBins)
//                    .HasColumnType("character varying")
//                    .HasColumnName("timeto_reach_public_bins");
//                entity.Property(e => e.Tole)
//                    .HasColumnType("character varying")
//                    .HasColumnName("tole");
//                entity.Property(e => e.Uuid)
//                    .HasColumnType("character varying")
//                    .HasColumnName("uuid");
//                entity.Property(e => e.VisitDate).HasColumnType("character varying").HasColumnName("visit_date");
//                entity.Property(e => e.Ward)
//                    .HasColumnType("character varying")
//                    .HasColumnName("ward");
//                entity.Property(e => e.WasteBurningOnOpenSpaceImpacts)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_burning_on_open_space_impacts");
//                entity.Property(e => e.WasteContainerEmptyTime)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_container_empty_time");
//                entity.Property(e => e.WasteContainerType)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_container_type");
//                entity.Property(e => e.WasteDisposalAsProblem)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_disposal_as_problem");
//                entity.Property(e => e.WasteDisposalCostPerMonth).HasColumnName("waste_disposal_cost_per_month");
//                entity.Property(e => e.WasteSegregationContributionStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_segregation_contribution_status");
//                entity.Property(e => e.WasteSegregationNoContributionReason)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_segregation_no_contribution_reason");
//                entity.Property(e => e.WasteSegregationStatus)
//                    .HasColumnType("character varying")
//                    .HasColumnName("waste_segregation_status");
//                entity.Property(e => e.WillingToPayForEffectiveSwm)
//                    .HasColumnType("character varying")
//                    .HasColumnName("willing_to_pay_for_effective_swm");
//                entity.Property(e => e.WoodCollectedBy)
//                    .HasColumnType("character varying")
//                    .HasColumnName("wood_collected_by");
//                entity.Property(e => e.WoodGeneratedWt)
//                    .HasDefaultValueSql("'0'::character varying")
//                    .HasColumnType("character varying")
//                    .HasColumnName("wood_generated_wt");
//            });
//            modelBuilder.Entity<MunicipalityCensusPop2078>(entity =>
//            {
//                entity.ToTable("municipality_census_pop_2078", "census_data");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AvgHh).HasColumnName("avg_hh");

//                entity.Property(e => e.Female).HasColumnName("female");

//                entity.Property(e => e.Hhs).HasColumnName("hhs");

//                entity.Property(e => e.Male).HasColumnName("male");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SexRatio).HasColumnName("sex_ratio");

//                entity.Property(e => e.TotalPop).HasColumnName("total_pop");
//                //entity.Property(e => e.TubewellHh).HasColumnName("tubewell_hh");
//                //entity.Property(e => e.TubewellPop).HasColumnName("tubewell_pop");
//            });

//            modelBuilder.Entity<MunicipalityPopulation>(entity =>
//            {
//                entity.ToTable("municipality_population", "wash_plan");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('wash_plan.total_population_id_seq'::regclass)");

//                entity.Property(e => e.ExistingWssPop)
//                         .HasColumnName("existing_wss_pop")
//                         .HasDefaultValueSql("0")
//                         .HasComment("From Inventory Data");

//                entity.Property(e => e.ExtrapolatedPopOfTubewell)
//                         .HasColumnName("extrapolated_pop_of_tubewell")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewWssPopulation)
//                         .HasColumnName("new_wss_population")
//                         .HasDefaultValueSql("0")
//                         .HasComment(@"From Unserved Community Survey Data
//pop = totalHH*4.6");

//                entity.Property(e => e.OngoingWssPop)
//                         .HasColumnName("ongoing_wss_pop")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.TubewellWithinNewOngoingArea)
//                         .HasColumnName("tubewell_within_new_ongoing_area")
//                         .HasDefaultValueSql("0");
//            });

//            modelBuilder.Entity<MunicipalityRate>(entity =>
//            {
//                entity.ToTable("municipality_rate", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Rate)
//                         .HasColumnName("rate")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.RateYear).HasColumnName("rate_year");

//                entity.Property(e => e.TblrateId).HasColumnName("tblrate_id");

//                entity.HasOne(d => d.Tblrate)
//                         .WithMany(p => p.MunicipalityRate)
//                         .HasForeignKey(d => d.TblrateId)
//                         .HasConstraintName("wp_rate_fkey_rateid");
//            });

//            modelBuilder.Entity<MunicipalitySectorwiseCostComponent>(entity =>
//            {
//                entity.ToTable("municipality_sectorwise_cost_component", "wash_plan");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('wash_plan.municipality_cost_components_id_seq'::regclass)");

//                entity.Property(e => e.Capex)
//                         .HasColumnName("capex")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Capmanex)
//                         .HasColumnName("capmanex")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Ds)
//                         .HasColumnName("ds")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Opex)
//                         .HasColumnName("opex")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Sector)
//                         .HasColumnName("sector")
//                         .HasColumnType("character varying")
//                         .HasComment(@"WSS
//Sanitation
//School
//HCF
//PP
//");

//                entity.Property(e => e.TotalCost)
//                         .HasColumnName("total_cost")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<MunicipalityWardFormation>(entity =>
//            {
//                entity.ToTable("municipality_ward_formation", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewWardE)
//                         .HasColumnName("new_ward_e")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewWardN)
//                         .HasColumnName("new_ward_n")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OldVdcE)
//                         .HasColumnName("old_vdc_e")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OldVdcN)
//                         .HasColumnName("old_vdc_n")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OldWardE)
//                         .HasColumnName("old_ward_e")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OldWardN)
//                         .HasColumnName("old_ward_n")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<MunicipalityWiseHhPop>(entity =>
//            {
//                entity.ToTable("municipality_wise_hh_pop", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CensusYear)
//                         .HasColumnName("census_year")
//                         .HasDefaultValueSql("2011");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasMaxLength(32);

//                entity.Property(e => e.Female).HasColumnName("female");

//                entity.Property(e => e.Hh).HasColumnName("hh");

//                entity.Property(e => e.Male).HasColumnName("male");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasMaxLength(32);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasMaxLength(32);

//                entity.Property(e => e.TotalPop).HasColumnName("total_pop");

//                entity.Property(e => e.WardNo)
//                         .HasColumnName("ward_no")
//                         .HasMaxLength(8);
//            });

//            modelBuilder.Entity<NepalPopulation2074>(entity =>
//            {
//                entity.ToTable("nepal_population_2074", "system");

//                entity.HasComment("Municipality wise population details");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Dcode)
//                         .HasColumnName("dcode")
//                         .HasMaxLength(8);

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Population).HasColumnName("population");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasMaxLength(8);
//            });

//            modelBuilder.Entity<NewSanitationPriority>(entity =>
//            {
//                entity.ToTable("new_sanitation_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear)
//                         .HasColumnName("priority_year")
//                         .HasDefaultValueSql("2020");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<OngoingSanitationConstructionTrendYear>(entity =>
//            {
//                entity.ToTable("ongoing_sanitation_construction_trend_year", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.PercentValue).HasColumnName("percent_value");

//                entity.Property(e => e.Years).HasColumnName("years");
//            });

//            modelBuilder.Entity<OngoingSanitationPriority>(entity =>
//            {
//                entity.ToTable("ongoing_sanitation_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear)
//                         .HasColumnName("priority_year")
//                         .HasDefaultValueSql("2020");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<OpexPerToilet>(entity =>
//            {
//                entity.ToTable("opex_per_toilet", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Cost)
//                         .HasColumnName("cost")
//                         .HasColumnType("numeric")
//                         .HasComment("Table rate id.");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Qty)
//                         .HasColumnName("qty")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<OpexSanitationFacilities>(entity =>
//            {
//                entity.ToTable("opex_sanitation_facilities", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.OpexWithTreatment).HasColumnName("opex_with_treatment");

//                entity.Property(e => e.OpexWithoutTreatment).HasColumnName("opex_without_treatment");

//                entity.Property(e => e.TypeOfSystem)
//                         .HasColumnName("type_of_system")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<OpexSchemeComponent>(entity =>
//            {
//                entity.ToTable("opex_scheme_component", "wash_plan_reference");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('wash_plan_reference.ref_opex_scheme_component_id_seq'::regclass)");

//                entity.Property(e => e.BasicPerCapitaYear)
//                         .HasColumnName("basic_per_capita_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.BasicPerSchemeYear)
//                         .HasColumnName("basic_per_scheme_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.SafelyManagedPerCapitaYear)
//                         .HasColumnName("safely_managed_per_capita_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.SafelyManagedSchemeYear)
//                         .HasColumnName("safely_managed_scheme_year")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.SchemeType)
//                         .HasColumnName("scheme_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Organization>(entity =>
//            {
//                entity.ToTable("organization", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.Address)
//                         .HasColumnName("address")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OrgName)
//                         .HasColumnName("org_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OrgUuid)
//                         .HasColumnName("org_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PrgShortName)
//                         .HasColumnName("prg_short_name")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<OsLut>(entity =>
//            {
//                entity.ToTable("os_lut", "washplan_other_service");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Particulars)
//                         .HasColumnName("particulars")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SnGrp).HasColumnName("sn_grp");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Year0)
//                         .HasColumnName("year0")
//                         .HasDefaultValueSql("0")
//                         .HasComment("Cost value for years is ID for the municipality rate table");

//                entity.Property(e => e.Year1)
//                         .HasColumnName("year1")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year10)
//                         .HasColumnName("year10")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year2)
//                         .HasColumnName("year2")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year3)
//                         .HasColumnName("year3")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year4)
//                         .HasColumnName("year4")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year5)
//                         .HasColumnName("year5")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year6)
//                         .HasColumnName("year6")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year7)
//                         .HasColumnName("year7")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year8)
//                         .HasColumnName("year8")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Year9)
//                         .HasColumnName("year9")
//                         .HasDefaultValueSql("0");
//            });

//            modelBuilder.Entity<OtherWaterUsage>(entity =>
//            {
//                entity.ToTable("other_water_usage", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.WaterUsageEng)
//                         .HasColumnName("water_usage_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterUsageNep)
//                         .HasColumnName("water_usage_nep")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Outfall>(entity =>
//            {
//                entity.ToTable("outfall", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.OutfallCode)
//                         .HasColumnName("outfall_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallCondition)
//                         .HasColumnName("outfall_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallConstructionYear)
//                         .HasColumnName("outfall_construction_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallDepthToInvert)
//                         .HasColumnName("outfall_depth_to_invert")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallIntvnRequired)
//                         .HasColumnName("outfall_intvn_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallOutletTo)
//                         .HasColumnName("outfall_outlet_to")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallPhoto1)
//                         .HasColumnName("outfall_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallPhoto2)
//                         .HasColumnName("outfall_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallProtection)
//                         .HasColumnName("outfall_protection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallRehabilitationYear)
//                         .HasColumnName("outfall_rehabilitation_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallVideo1)
//                         .HasColumnName("outfall_video1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OutfallVideo2)
//                         .HasColumnName("outfall_video2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PercapitaCostWsComponenet>(entity =>
//            {
//                entity.ToTable("percapita_cost_ws_componenet", "wash_plan_reference");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('wash_plan_reference.ref_percapita_cost_ws_componenet_id_seq'::regclass)");

//                entity.Property(e => e.BasicCost)
//                         .HasColumnName("basic_cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.BsBothCost)
//                         .HasColumnName("bs_both_cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.BsPremisesCost)
//                         .HasColumnName("bs_premises_cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.BsWqiCost)
//                         .HasColumnName("bs_wqi_cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.SafelyManagedCost)
//                         .HasColumnName("safely_managed_cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.SchemeType)
//                         .HasColumnName("scheme_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Pipe>(entity =>
//            {
//                entity.ToTable("pipe", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PipeClass)
//                         .HasColumnName("pipe_class")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeCond)
//                         .HasColumnName("pipe_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeCons)
//                         .HasColumnName("pipe_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");

//                entity.Property(e => e.PipeEqk)
//                         .HasColumnName("pipe_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLayCon)
//                         .HasColumnName("pipe_lay_con")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLcon)
//                         .HasColumnName("pipe_lcon")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLen).HasColumnName("pipe_len");
//                entity.Property(e => e.LeakageCount).HasColumnName("leakage_count");

//                entity.Property(e => e.PipeName)
//                         .HasColumnName("pipe_name")
//                         .HasMaxLength(200);

//                entity.Property(e => e.PipePart)
//                         .HasColumnName("pipe_part")
//                         .HasMaxLength(25);

//                entity.Property(e => e.PipeRem)
//                         .HasColumnName("pipe_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PipeType)
//                         .HasColumnName("pipe_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.Pipe)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<PipeDrawnRoute>(entity =>
//            {
//                entity.ToTable("pipe_drawn_route", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.PipeClass)
//                         .HasColumnName("pipe_class")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeCond)
//                         .HasColumnName("pipe_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeCons)
//                         .HasColumnName("pipe_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");

//                entity.Property(e => e.PipeEqk)
//                         .HasColumnName("pipe_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLcon)
//                         .HasColumnName("pipe_lcon")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipePart)
//                         .HasColumnName("pipe_part")
//                         .HasMaxLength(25);

//                entity.Property(e => e.PipeType)
//                         .HasColumnName("pipe_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<PipeDrawnRouteHistory>(entity =>
//            {
//                entity.ToTable("pipe_drawn_route_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.pipe_drawn_route_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.PipeClass)
//                         .HasColumnName("pipe_class")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeCond)
//                         .HasColumnName("pipe_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeCons)
//                         .HasColumnName("pipe_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");

//                entity.Property(e => e.PipeEqk)
//                         .HasColumnName("pipe_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLcon)
//                         .HasColumnName("pipe_lcon")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipePart)
//                         .HasColumnName("pipe_part")
//                         .HasMaxLength(25);

//                entity.Property(e => e.PipeType)
//                         .HasColumnName("pipe_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<PipeHistory>(entity =>
//            {
//                entity.ToTable("pipe_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.pipe_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PipeClass)
//                         .HasColumnName("pipe_class")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeCond)
//                         .HasColumnName("pipe_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeCons)
//                         .HasColumnName("pipe_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");

//                entity.Property(e => e.PipeEqk)
//                         .HasColumnName("pipe_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLayCon)
//                         .HasColumnName("pipe_lay_con")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLcon)
//                         .HasColumnName("pipe_lcon")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLen).HasColumnName("pipe_len");

//                entity.Property(e => e.PipeName)
//                         .HasColumnName("pipe_name")
//                         .HasMaxLength(200);

//                entity.Property(e => e.PipePart)
//                         .HasColumnName("pipe_part")
//                         .HasMaxLength(25);

//                entity.Property(e => e.PipeRem)
//                         .HasColumnName("pipe_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PipeType)
//                         .HasColumnName("pipe_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.PipeHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .OnDelete(DeleteBehavior.Cascade)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<PipeRoutePoint>(entity =>
//            {
//                entity.ToTable("pipe_route_point", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.PipeClass)
//                         .HasColumnName("pipe_class")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeCond)
//                         .HasColumnName("pipe_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeCons)
//                         .HasColumnName("pipe_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");

//                entity.Property(e => e.PipeEqk)
//                         .HasColumnName("pipe_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLcon)
//                         .HasColumnName("pipe_lcon")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipePart)
//                         .HasColumnName("pipe_part")
//                         .HasMaxLength(25);

//                entity.Property(e => e.PipeType)
//                         .HasColumnName("pipe_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.PipeRoutePoint)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<PipeRoutePointHistory>(entity =>
//            {
//                entity.ToTable("pipe_route_point_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.pipe_route_point_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.PipeClass)
//                         .HasColumnName("pipe_class")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeCond)
//                         .HasColumnName("pipe_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeCons)
//                         .HasColumnName("pipe_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.PipeDia).HasColumnName("pipe_dia");

//                entity.Property(e => e.PipeEqk)
//                         .HasColumnName("pipe_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipeLcon)
//                         .HasColumnName("pipe_lcon")
//                         .HasMaxLength(100);

//                entity.Property(e => e.PipePart)
//                         .HasColumnName("pipe_part")
//                         .HasMaxLength(25);

//                entity.Property(e => e.PipeType)
//                         .HasColumnName("pipe_type")
//                         .HasMaxLength(20);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.PipeRoutePointHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<PopServed>(entity =>
//            {
//                entity.ToTable("pop_served", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.BcHh).HasColumnName("bc_hh");

//                entity.Property(e => e.DalHh).HasColumnName("dal_hh");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FemPop).HasColumnName("fem_pop");

//                entity.Property(e => e.HhServerd).HasColumnName("hh_serverd");

//                entity.Property(e => e.JanHh).HasColumnName("jan_hh");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MiHh).HasColumnName("mi_hh");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<PopServedHistory>(entity =>
//            {
//                entity.ToTable("pop_served_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.pop_served_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.BcHh).HasColumnName("bc_hh");

//                entity.Property(e => e.DalHh).HasColumnName("dal_hh");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.FemPop).HasColumnName("fem_pop");

//                entity.Property(e => e.HhServerd).HasColumnName("hh_serverd");

//                entity.Property(e => e.JanHh).HasColumnName("jan_hh");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MiHh).HasColumnName("mi_hh");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");
//            });

//            modelBuilder.Entity<PotentialSource>(entity =>
//            {
//                entity.ToTable("potential_source", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistanceFromCommunity)
//                         .HasColumnName("distance_from_community")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DroughtVul)
//                         .HasColumnName("drought_vul")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FloodVul)
//                         .HasColumnName("flood_vul")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowMeasurement)
//                         .HasColumnName("flow_measurement")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowRegularity)
//                         .HasColumnName("flow_regularity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LandslideVul)
//                         .HasColumnName("landslide_vul")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.LiftRequired)
//                         .HasColumnName("lift_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MinYield)
//                         .HasColumnName("min_yield")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PresentWaterUse)
//                         .HasColumnName("present_water_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RoundTripTime)
//                         .HasColumnName("round_trip_time")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SettlementAboveSource)
//                         .HasColumnName("settlement_above_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceName)
//                         .HasColumnName("source_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceOwnership)
//                         .HasColumnName("source_ownership")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TypeOfSource)
//                         .HasColumnName("type_of_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQuality)
//                         .HasColumnName("water_quality")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PpServiceData>(entity =>
//            {
//                entity.ToTable("pp_service_data", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AdequateWaterAvailability)
//                         .HasColumnName("adequate_water_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BlockWithHandwashing).HasColumnName("block_with_handwashing");

//                entity.Property(e => e.BlockWithoutHandwashing).HasColumnName("block_without_handwashing");

//                entity.Property(e => e.ChildrenFriendlyToilet)
//                         .HasColumnName("children_friendly_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFriendlyToilet)
//                         .HasColumnName("disabled_friendly_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleToilet).HasColumnName("female_toilet");

//                entity.Property(e => e.HandwashingAccessibility)
//                         .HasColumnName("handwashing_accessibility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleToilet).HasColumnName("male_toilet");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapAvailableInHandwashing)
//                         .HasColumnName("soap_available_in_handwashing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToilet).HasColumnName("total_toilet");

//                entity.Property(e => e.WaterTankAvailability)
//                         .HasColumnName("water_tank_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankReserveSufficient)
//                         .HasColumnName("water_tank_reserve_sufficient")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ProjectCoverage>(entity =>
//            {
//                entity.ToTable("project_coverage", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.Area).HasColumnName("area");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.ProjectCoverage)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<ProjectCoverageHistory>(entity =>
//            {
//                entity.ToTable("project_coverage_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.project_coverage_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.Area).HasColumnName("area");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.ProjectCoverageHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<ProjectDetails>(entity =>
//            {
//                entity.ToTable("project_details", "existing_projects");

//                entity.HasIndex(e => e.ProCode)
//                         .HasName("unk_pro_code")
//                         .IsUnique();

//                entity.HasIndex(e => e.Uuid)
//                         .HasName("unk_uuid")
//                         .IsUnique();

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterSafetyApproach)
//                         .HasColumnName("water_safety_approach")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ClimateResilience)
//                         .HasColumnName("climate_resilience")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.ConsAgency)
//                         .HasColumnName("cons_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConsAgencyId).HasColumnName("cons_agency_id");

//                entity.Property(e => e.ConsAgencyOther)
//                         .HasColumnName("cons_agency_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConsYear).HasColumnName("cons_year");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.InvAgency)
//                         .HasColumnName("inv_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Desc)
//                         .HasColumnName("photo3_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Path)
//                         .HasColumnName("photo3_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo3PathUuid)
//                         .HasColumnName("photo3_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Desc)
//                         .HasColumnName("photo4_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Path)
//                         .HasColumnName("photo4_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo4PathUuid)
//                         .HasColumnName("photo4_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5Desc)
//                         .HasColumnName("photo5_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5Path)
//                         .HasColumnName("photo5_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo5PathUuid)
//                         .HasColumnName("photo5_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6Desc)
//                         .HasColumnName("photo6_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6Path)
//                         .HasColumnName("photo6_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo6PathUuid)
//                         .HasColumnName("photo6_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCodeNmip)
//                         .HasColumnName("pro_code_nmip")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCodeOther)
//                         .HasColumnName("pro_code_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCodeOtherProvider)
//                         .HasColumnName("pro_code_other_provider")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProFun).HasColumnName("pro_fun");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProNameNep)
//                         .HasColumnName("pro_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProSus).HasColumnName("pro_sus");

//                entity.Property(e => e.ProType)
//                         .HasColumnName("pro_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectStatus)
//                         .HasColumnName("project_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabAgency)
//                         .HasColumnName("rehab_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabAgencyOther)
//                         .HasColumnName("rehab_agency_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabYear).HasColumnName("rehab_year");

//                entity.Property(e => e.SettlementName)
//                         .HasColumnName("settlement_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoCode)
//                         .HasColumnName("so_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupAgency)
//                         .HasColumnName("sup_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupAgencyOther)
//                         .HasColumnName("sup_agency_other")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .IsRequired()
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.WardNo)
//                         .HasColumnName("ward_no")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ProjectDetailsHistory>(entity =>
//            {
//                entity.ToTable("project_details_history", "existing_projects_history");

//                entity.HasIndex(e => e.ProCode)
//                         .HasName("unk_pro_code")
//                         .IsUnique();

//                entity.HasIndex(e => e.Uuid)
//                         .HasName("unk_uuid")
//                         .IsUnique();

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.project_details_id_seq'::regclass)");


//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.ConsAgency)
//                         .HasColumnName("cons_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConsAgencyId).HasColumnName("cons_agency_id");

//                entity.Property(e => e.ConsAgencyOther)
//                         .HasColumnName("cons_agency_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConsYear).HasColumnName("cons_year");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.InvAgency)
//                         .HasColumnName("inv_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Desc)
//                         .HasColumnName("photo3_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Path)
//                         .HasColumnName("photo3_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Desc)
//                         .HasColumnName("photo4_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Path)
//                         .HasColumnName("photo4_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5Desc)
//                         .HasColumnName("photo5_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5Path)
//                         .HasColumnName("photo5_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6Desc)
//                         .HasColumnName("photo6_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6Path)
//                         .HasColumnName("photo6_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCodeNmip)
//                         .HasColumnName("pro_code_nmip")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCodeOther)
//                         .HasColumnName("pro_code_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCodeOtherProvider)
//                         .HasColumnName("pro_code_other_provider")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProFun).HasColumnName("pro_fun");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProNameNep)
//                         .HasColumnName("pro_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProSus).HasColumnName("pro_sus");

//                entity.Property(e => e.ProType)
//                         .HasColumnName("pro_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectStatus)
//                         .HasColumnName("project_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabAgency)
//                         .HasColumnName("rehab_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabAgencyOther)
//                         .HasColumnName("rehab_agency_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RehabYear).HasColumnName("rehab_year");

//                entity.Property(e => e.SettlementName)
//                         .HasColumnName("settlement_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoCode)
//                         .HasColumnName("so_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupAgency)
//                         .HasColumnName("sup_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupAgencyOther)
//                         .HasColumnName("sup_agency_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .IsRequired()
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.WardNo)
//                         .HasColumnName("ward_no")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Province>(entity =>
//            {
//                entity.ToTable("province", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceName)
//                         .HasColumnName("province_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceNameNep)
//                         .HasColumnName("province_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceUuid)
//                         .HasColumnName("province_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom)
//                         .HasColumnName("the_geom")
//                         .HasColumnType("geometry(Polygon,4326)");
//            });

//            modelBuilder.Entity<ProvinceCensusPop2078>(entity =>
//            {
//                entity.ToTable("province_census_pop_2078", "census_data");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AvgHh).HasColumnName("avg_hh");

//                entity.Property(e => e.Female).HasColumnName("female");

//                entity.Property(e => e.Male).HasColumnName("male");

//                entity.Property(e => e.Province)
//                         .HasColumnName("province")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalHh).HasColumnName("total_hh");

//                entity.Property(e => e.TotalPop).HasColumnName("total_pop");
//            });

//            modelBuilder.Entity<ProvinceHhServiceLevel>(entity =>
//            {
//                entity.ToTable("province_hh_service_level", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Decision)
//                         .HasColumnName("decision")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalPop)
//                         .HasColumnName("total_pop")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<ProvinceLine>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("province_line", "system");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .ValueGeneratedOnAdd();

//                entity.Property(e => e.ProvinceCode).HasColumnName("province_code");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<ProvinceNepal>(entity =>
//            {
//                entity.ToTable("province_nepal", "basemap");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .ValueGeneratedNever();

//                entity.Property(e => e.Geom)
//                         .HasColumnName("geom")
//                         .HasColumnType("geometry(MultiPolygon,4326)");

//                entity.Property(e => e.ProvNepali).HasColumnName("prov_nepali");

//                entity.Property(e => e.Province)
//                         .HasColumnName("province")
//                         .HasMaxLength(50);

//                entity.Property(e => e.State)
//                         .HasColumnName("state")
//                         .HasMaxLength(50);
//            });

//            modelBuilder.Entity<ProvincePipeTubewellData>(entity =>
//            {
//                entity.ToTable("province_pipe_tubewell_data", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Activities)
//                         .HasColumnName("activities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AmountReq)
//                         .HasColumnName("amount_req")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Numbers).HasColumnName("numbers");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ProvinceSchoolStatus>(entity =>
//            {
//                entity.ToTable("province_school_status", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.BoysSeparateToiletsUsed).HasColumnName("boys_separate_toilets_used");

//                entity.Property(e => e.DisabledFriendlyToilet).HasColumnName("disabled_friendly_toilet");

//                entity.Property(e => e.GirlsSeparateToiletsUsed).HasColumnName("girls_separate_toilets_used");

//                entity.Property(e => e.GirlsUsableToiletWithMhm).HasColumnName("girls_usable_toilet_with_mhm");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolHygieneStatus)
//                         .HasColumnName("school_hygiene_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolSanitationStatus)
//                         .HasColumnName("school_sanitation_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWsStatus)
//                         .HasColumnName("school_ws_status")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ProvinceToiletType>(entity =>
//            {
//                entity.ToTable("province_toilet_type", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                         .HasColumnName("toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalPop)
//                         .HasColumnName("total_pop")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<ProvinceToiletYesno>(entity =>
//            {
//                entity.ToTable("province_toilet_yesno", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.NoOfHh).HasColumnName("no_of_hh");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletNo).HasColumnName("toilet_no");

//                entity.Property(e => e.ToiletYes).HasColumnName("toilet_yes");
//            });

//            modelBuilder.Entity<ProvinceWashSystem>(entity =>
//            {
//                entity.ToTable("province_wash_system", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.NoOfSystem)
//                         .HasColumnName("no_of_system")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalPopulation).HasColumnName("total_population");

//                entity.Property(e => e.TypeOfServices)
//                         .HasColumnName("type_of_services")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WhatItIs)
//                         .HasColumnName("what_it_is")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ProvinceWsTechnology>(entity =>
//            {
//                entity.ToTable("province_ws_technology", "wp_sgd");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SystemType).HasColumnName("system_type");

//                entity.Property(e => e.WsType)
//                         .HasColumnName("ws_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PtCols>(entity =>
//            {
//                entity.ToTable("pt_cols", "public_toilet");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('public_toilet.cols_id_seq'::regclass)");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PtLut>(entity =>
//            {
//                entity.ToTable("pt_lut", "public_toilet");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('public_toilet.look_up_new_id_seq'::regclass)");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PtLut1>(entity =>
//            {
//                entity.ToTable("pt_lut1", "public_toilet");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.QbCols)
//         .HasColumnName("qb_cols")
//         .HasColumnType("character varying")
//         .HasMaxLength(10);

//            });

//            modelBuilder.Entity<PublicToilet>(entity =>
//            {
//                entity.ToTable("public_toilet", "public_toilet");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AgencyName)
//                         .HasColumnName("agency_name")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedDate)
//                     .HasColumnName("edited_date")
//                     .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy)
//                         .HasColumnName("collected_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AvailableFund)
//                         .HasColumnName("available_fund")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContactNumber)
//                         .HasColumnName("contact_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DailyCollection)
//                         .HasColumnName("daily_collection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Dbname)
//                         .HasColumnName("dbname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisableAccessible)
//                         .HasColumnName("disable_accessible")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinFacility)
//                         .HasColumnName("dustbin_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.FemaleToilet)
//                         .HasColumnName("female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FundCollection)
//                         .HasColumnName("fund_collection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingBasin)
//                         .HasColumnName("hand_washing_basin")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingFacilitySections)
//                         .HasColumnName("hand_washing_facility_sections")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingPlaceAccess)
//                         .HasColumnName("hand_washing_place_access")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HaveToPayToUse)
//                         .HasColumnName("have_to_pay_to_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Image1)
//                         .HasColumnName("image1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                         .HasColumnName("additional_photo_1_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                         .HasColumnName("additional_photo_2_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                         .HasColumnName("additional_photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Image2)
//                         .HasColumnName("image2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Image3)
//                         .HasColumnName("image3")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Image1Uuid)
//                         .HasColumnName("image1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Image2Uuid)
//                         .HasColumnName("image2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Image3Uuid)
//                         .HasColumnName("image3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LockSystem)
//                         .HasColumnName("lock_system")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MaleToilet)
//                         .HasColumnName("male_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaterialCost)
//                         .HasColumnName("material_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Name)
//                         .HasColumnName("name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfPublicToilet)
//                         .HasColumnName("no_of_public_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfUsers)
//                         .HasColumnName("no_of_users")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfUsersAccessAtATime)
//                         .HasColumnName("no_of_users_access_at_a_time")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Odour)
//                         .HasColumnName("odour")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OperatorCost)
//                         .HasColumnName("operator_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PadAvailability)
//                         .HasColumnName("pad_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvisionOfToiletForChildren)
//                         .HasColumnName("provision_of_toilet_for_children")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvisionOfToiletForDisabled)
//                         .HasColumnName("provision_of_toilet_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletCondition)
//                         .HasColumnName("public_toilet_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletInUse)
//                         .HasColumnName("public_toilet_in_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletNotInUseReason)
//                         .HasColumnName("public_toilet_not_in_use_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletState)
//                         .HasColumnName("public_toilet_state")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RepairCost)
//                         .HasColumnName("repair_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RunningPt)
//                         .HasColumnName("running_pt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RunningPtOther)
//                         .HasColumnName("running_pt_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SeparateLatrine)
//                         .HasColumnName("separate_latrine")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ShopRunning)
//                         .HasColumnName("shop_running")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapAvailableInBasin)
//                         .HasColumnName("soap_available_in_basin")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SpaceForShop)
//                         .HasColumnName("space_for_shop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficientWaterSupply)
//                         .HasColumnName("sufficient_water_supply")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletChildFriendly)
//                         .HasColumnName("toilet_child_friendly")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConnection)
//                         .HasColumnName("toilet_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletLocated)
//                         .HasColumnName("toilet_located")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletLocatedOther)
//                         .HasColumnName("toilet_located_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletName)
//                         .HasColumnName("toilet_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUseAmount)
//                         .HasColumnName("toilet_use_amount")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUseAmountForUrination)
//                         .HasColumnName("toilet_use_amount_for_urination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToleName)
//                         .HasColumnName("tole_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentFacility)
//                         .HasColumnName("treatment_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfFacility)
//                         .HasColumnName("type_of_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Urinal)
//                         .HasColumnName("urinal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalFemale)
//                         .HasColumnName("urinal_female")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalMale)
//                         .HasColumnName("urinal_male")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.Ventilated)
//                         .HasColumnName("ventilated")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WardNumber)
//                         .HasColumnName("ward_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterFacilityAvailable)
//                         .HasColumnName("water_facility_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankAvailability)
//                         .HasColumnName("water_tank_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankSufficiency)
//                         .HasColumnName("water_tank_sufficiency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WithoutHandWashingFacilitySections)
//                         .HasColumnName("without_hand_washing_facility_sections")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<RainInlet>(entity =>
//            {
//                entity.ToTable("rain_inlet", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CoverCondRain)
//                         .HasColumnName("cover_cond_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverDiameterRain)
//                         .HasColumnName("cover_diameter_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverIntvnReqRain)
//                         .HasColumnName("cover_intvn_req_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverMaterialRain)
//                         .HasColumnName("cover_material_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverShapeRain)
//                         .HasColumnName("cover_shape_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverWidthRain)
//                         .HasColumnName("cover_width_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.PavementTypeRain)
//                         .HasColumnName("pavement_type_rain")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletCode)
//                         .HasColumnName("rain_inlet_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletCondition)
//                         .HasColumnName("rain_inlet_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletDepth)
//                         .HasColumnName("rain_inlet_depth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletDiameter)
//                         .HasColumnName("rain_inlet_diameter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletIntvnRequired)
//                         .HasColumnName("rain_inlet_intvn_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletMaterial)
//                         .HasColumnName("rain_inlet_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletOpen)
//                         .HasColumnName("rain_inlet_open")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletShape)
//                         .HasColumnName("rain_inlet_shape")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainInletWidth)
//                         .HasColumnName("rain_inlet_width")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainPhoto1)
//                         .HasColumnName("rain_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainPhoto2)
//                         .HasColumnName("rain_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainReasonForNotOpening)
//                         .HasColumnName("rain_reason_for_not_opening")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Rainfall>(entity =>
//            {
//                entity.ToTable("rainfall", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CensusYear).HasColumnName("census_year");

//                entity.Property(e => e.MaxRainfall).HasColumnName("max_rainfall");

//                entity.Property(e => e.MinRainfall).HasColumnName("min_rainfall");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Source)
//                         .HasColumnName("source")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<Rate>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("rate");

//                entity.Property(e => e.Rate1)
//                         .HasColumnName("rate")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<Rates>(entity =>
//            {
//                entity.ToTable("rates", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Particular).HasColumnName("particular");

//                entity.Property(e => e.Rate)
//                         .HasColumnName("rate")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Unit)
//                         .HasColumnName("unit")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ReferenceData>(entity =>
//            {
//                entity.ToTable("reference_data", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Rate)
//                         .HasColumnName("rate")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Religion>(entity =>
//            {
//                entity.ToTable("religion", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CensusYear).HasColumnName("census_year");

//                entity.Property(e => e.Household).HasColumnName("household");

//                entity.Property(e => e.Householdpercent).HasColumnName("householdpercent");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Population).HasColumnName("population");

//                entity.Property(e => e.Religiontype)
//                         .HasColumnName("religiontype")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Source)
//                         .HasColumnName("source")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<ReligionLut>(entity =>
//            {
//                entity.ToTable("religion_lut", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ReligionEng)
//                         .HasColumnName("religion_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReligionNep)
//                         .HasColumnName("religion_nep")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ReportData>(entity =>
//            {
//                entity.ToTable("report_data", "existing_projects");

//                entity.HasComment("stores the scheme condition and prioritization score for each pro_code for the functionality report");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchemeCondition)
//                         .HasColumnName("scheme_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchemePrioritizationScore)
//                         .HasColumnName("scheme_prioritization_score")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalPopulation)
//                         .HasColumnName("total_population")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ReportDataHistory>(entity =>
//            {
//                entity.ToTable("report_data_history", "existing_projects_history");

//                entity.HasComment("stores the scheme condition and prioritization score for each pro_code for the functionality report");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.report_data_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchemeCondition)
//                         .HasColumnName("scheme_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchemePrioritizationScore)
//                         .HasColumnName("scheme_prioritization_score")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalPopulation)
//                         .HasColumnName("total_population")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");
//            });

//            modelBuilder.Entity<Reservoir>(entity =>
//            {
//                entity.ToTable("reservoir", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ConsYear).HasColumnName("cons_year");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtCap).HasColumnName("rvt_cap");

//                entity.Property(e => e.RvtCon)
//                         .HasColumnName("rvt_con")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtCons)
//                         .HasColumnName("rvt_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.RvtEqk)
//                         .HasColumnName("rvt_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtNo)
//                         .HasColumnName("rvt_no")
//                         .HasMaxLength(20);

//                entity.Property(e => e.RvtQua)
//                         .HasColumnName("rvt_qua")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtRem)
//                         .HasColumnName("rvt_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RvtType)
//                         .HasColumnName("rvt_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.Reservoir)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<ReservoirHistory>(entity =>
//            {
//                entity.ToTable("reservoir_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.reservoir_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtCap).HasColumnName("rvt_cap");

//                entity.Property(e => e.RvtCon)
//                         .HasColumnName("rvt_con")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtCons)
//                         .HasColumnName("rvt_cons")
//                         .HasMaxLength(20);

//                entity.Property(e => e.RvtEqk)
//                         .HasColumnName("rvt_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtNo)
//                         .HasColumnName("rvt_no")
//                         .HasMaxLength(20);

//                entity.Property(e => e.RvtQua)
//                         .HasColumnName("rvt_qua")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RvtRem)
//                         .HasColumnName("rvt_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RvtType)
//                         .HasColumnName("rvt_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.ReservoirHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<RoutePoint>(entity =>
//            {
//                entity.ToTable("route_point", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RpPhoto1)
//                         .HasColumnName("rp_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RpRouteNo)
//                         .HasColumnName("rp_route_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<RoutePointOld>(entity =>
//            {
//                entity.ToTable("route_point_old", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RpPhoto1)
//                         .HasColumnName("rp_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RpRouteNo)
//                         .HasColumnName("rp_route_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SanitaryInspection>(entity =>
//            {
//                entity.ToTable("sanitary_inspection", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.PointId).HasColumnName("point_id");

//                entity.Property(e => e.PointType).HasColumnName("point_type");

//                entity.Property(e => e.ProjectUuid).HasColumnName("project_uuid");

//                entity.Property(e => e.Time)
//                         .HasColumnName("time")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.UserId).HasColumnName("user_id");

//                entity.Property(e => e.Uuid).HasColumnName("uuid");
//            });

//            modelBuilder.Entity<SanitaryInspectionTemplate>(entity =>
//            {
//                entity.ToTable("sanitary_inspection_template", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Attribute).HasColumnName("attribute");

//                entity.Property(e => e.Layer).HasColumnName("layer");

//                entity.Property(e => e.Options).HasColumnName("options");

//                entity.Property(e => e.Qn).HasColumnName("qn");

//                entity.Property(e => e.Question).HasColumnName("question");
//            });

//            modelBuilder.Entity<SanitaryInspectionValues>(entity =>
//            {
//                entity.ToTable("sanitary_inspection_values", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.QuestionId).HasColumnName("question_id");

//                entity.Property(e => e.SampleUuid).HasColumnName("sample_uuid");

//                entity.Property(e => e.Value).HasColumnName("value");
//            });

//            modelBuilder.Entity<Sanitation>(entity =>
//            {
//                entity.ToTable("sanitation", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.OwnerContact)
//                         .HasColumnName("owner_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OwnerName)
//                         .HasColumnName("owner_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SanOwner)
//                         .HasColumnName("san_owner")
//                         .HasMaxLength(50);

//                entity.Property(e => e.SanRem)
//                         .HasColumnName("san_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletTreatment)
//                         .HasColumnName("toilet_treatment")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                         .HasColumnName("toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.Sanitation)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<SanitationBenchmarking>(entity =>
//            {
//                entity.ToTable("sanitation_benchmarking", "drainage");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationOnsiteTreatment)
//                         .HasColumnName("sanitation_onsite_treatment")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationPhoto1)
//                         .HasColumnName("sanitation_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationPhoto2)
//                         .HasColumnName("sanitation_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationSeptageCollection)
//                         .HasColumnName("sanitation_septage_collection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationSeptageCollectionTariff)
//                         .HasColumnName("sanitation_septage_collection_tariff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationSourceOfWaterSupply)
//                         .HasColumnName("sanitation_source_of_water_supply")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitationToiletType)
//                         .HasColumnName("sanitation_toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<PipedsystemGraphData>(entity =>
//            {
//                entity.ToTable("pipedsystem_graph_data", "graph_to_tbl");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.BasicPercent).HasColumnName("basic_percent");
//                entity.Property(e => e.Basic).HasColumnName("basic");
//                entity.Property(e => e.LimitedPercent).HasColumnName("limited_percent");
//                entity.Property(e => e.Limited).HasColumnName("limited");
//                entity.Property(e => e.SafelyManagedPercent).HasColumnName("safely_managed_percent");
//                entity.Property(e => e.SafelyManaged).HasColumnName("safely_managed");
//                entity.Property(e => e.Unserved).HasColumnName("unserved");
//                entity.Property(e => e.UnservedPercent).HasColumnName("unserved_percent");
//                entity.Property(e => e.TheGeom).HasColumnName("mun_geom");
//                entity.Property(e => e.MunName)
//                        .HasColumnName("mun_name")
//                        .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<HhsanitationGraphData>(entity =>
//            {
//                entity.ToTable("hhsanitation_graph_data", "graph_to_tbl");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Basic).HasColumnName("basic");
//                entity.Property(e => e.BasicPercent).HasColumnName("basic_percent");
//                entity.Property(e => e.SafelyManaged).HasColumnName("safely_managed");
//                entity.Property(e => e.SafelyManagedPercent).HasColumnName("safely_managed_percent");
//                entity.Property(e => e.Limited).HasColumnName("limited");
//                entity.Property(e => e.LimitedPercent).HasColumnName("limited_percent");
//                entity.Property(e => e.Unimproved).HasColumnName("unimproved");
//                entity.Property(e => e.UnimprovedPercent).HasColumnName("unimproved_percent");
//                entity.Property(e => e.Noservice).HasColumnName("noservice");
//                entity.Property(e => e.NoservicePercent).HasColumnName("noservice_percent");
//                entity.Property(e => e.MunGeom).HasColumnName("mun_geom");
//            });


//            modelBuilder.Entity<SanitationHistory>(entity =>
//            {
//                entity.ToTable("sanitation_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.sanitation_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.OwnerContact)
//                         .HasColumnName("owner_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OwnerName)
//                         .HasColumnName("owner_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SanOwner)
//                         .HasColumnName("san_owner")
//                         .HasMaxLength(50);

//                entity.Property(e => e.SanRem)
//                         .HasColumnName("san_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletTreatment)
//                         .HasColumnName("toilet_treatment")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                         .HasColumnName("toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.SanitationHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<SanitationSystemRepair>(entity =>
//            {
//                entity.ToTable("sanitation_system_repair", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CapexFraction).HasColumnName("capex_fraction");

//                entity.Property(e => e.RepairCondition)
//                         .HasColumnName("repair_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RepairType)
//                         .HasColumnName("repair_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SchemePriority>(entity =>
//            {
//                entity.ToTable("scheme_priority", "wash_plan");

//                entity.HasComment("Water Supply System");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Status).HasColumnName("status");
//            });

//            modelBuilder.Entity<SchemePriortization>(entity =>
//            {
//                entity.ToTable("scheme_priortization", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.CostScore)
//                         .HasColumnName("cost_score")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.EffectScore)
//                         .HasColumnName("effect_score")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.MgmtScore)
//                         .HasColumnName("mgmt_score")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OverallWeightedScore)
//                         .HasColumnName("overall_weighted_score")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Rank)
//                         .HasColumnName("rank")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SbhScore)
//                         .HasColumnName("sbh_score")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<SchemeTotalCost>(entity =>
//            {
//                entity.ToTable("scheme_total_cost", "cost_estimation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalCost)
//                         .HasColumnName("total_cost")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<SchoolCols>(entity =>
//            {
//                entity.ToTable("school_cols", "school");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('school.cols_id_seq'::regclass)");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SchoolLut>(entity =>
//            {
//                entity.ToTable("school_lut", "school");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('school.look_up_new_id_seq'::regclass)");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SchoolLut1>(entity =>
//            {
//                entity.ToTable("school_lut1", "school");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.QbCols)
//         .HasColumnName("qb_cols")
//         .HasColumnType("character varying")
//         .HasMaxLength(10);

//            });

//            modelBuilder.Entity<SchoolWashStatusPriority>(entity =>
//            {
//                entity.ToTable("school_wash_status_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.SchoolUuid)
//                         .HasColumnName("school_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPlannedStatus)
//                         .HasColumnName("wash_planned_status")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Skips>(entity =>
//            {
//                entity.ToTable("skips", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipCondition)
//                         .HasColumnName("skip_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipIntvnReq)
//                         .HasColumnName("skip_intvn_req")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipPhoto1)
//                         .HasColumnName("skip_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipPhoto2)
//                         .HasColumnName("skip_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipSchedule)
//                         .HasColumnName("skip_schedule")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipType)
//                         .HasColumnName("skip_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipVolume)
//                         .HasColumnName("skip_volume")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SkipsOld>(entity =>
//            {
//                entity.ToTable("skips_old", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipCondition)
//                         .HasColumnName("skip_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipIntvnReq)
//                         .HasColumnName("skip_intvn_req")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipPhoto1)
//                         .HasColumnName("skip_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipPhoto2)
//                         .HasColumnName("skip_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipSchedule)
//                         .HasColumnName("skip_schedule")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipType)
//                         .HasColumnName("skip_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkipVolume)
//                         .HasColumnName("skip_volume")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<SolidWasteLut>(entity =>
//            {
//                entity.ToTable("solid_waste_lut", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DataType)
//                         .HasColumnName("data_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Layer)
//                         .HasColumnName("layer")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<StreetSweeping>(entity =>
//            {
//                entity.ToTable("street_sweeping", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetCondition)
//                         .HasColumnName("street_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetFrequency)
//                         .HasColumnName("street_frequency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetName)
//                         .HasColumnName("street_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetPhoto1)
//                         .HasColumnName("street_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetPhoto2)
//                         .HasColumnName("street_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<StreetSweepingOld>(entity =>
//            {
//                entity.ToTable("street_sweeping_old", "solid_waste");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetCondition)
//                         .HasColumnName("street_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetFrequency)
//                         .HasColumnName("street_frequency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetName)
//                         .HasColumnName("street_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetPhoto1)
//                         .HasColumnName("street_photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetPhoto2)
//                         .HasColumnName("street_photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Structure>(entity =>
//            {
//                entity.ToTable("structure", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.DataYear).HasColumnName("data_year");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrCond)
//                         .HasColumnName("str_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrCons)
//                         .HasColumnName("str_cons")
//                         .HasMaxLength(25);

//                entity.Property(e => e.StrDim)
//                         .HasColumnName("str_dim")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StrDimHeight)
//                         .HasColumnName("str_dim_height")
//                         .HasComment("structure dimension height");

//                entity.Property(e => e.StrDimLen)
//                         .HasColumnName("str_dim_len")
//                         .HasComment("structure dimension length");

//                entity.Property(e => e.StrDimWidth)
//                         .HasColumnName("str_dim_width")
//                         .HasComment("structure dimension breadth");

//                entity.Property(e => e.StrEqk)
//                         .HasColumnName("str_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrNo)
//                         .HasColumnName("str_no")
//                         .HasMaxLength(50);

//                entity.Property(e => e.StrNrp)
//                         .HasColumnName("str_nrp")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrOther)
//                         .HasColumnName("str_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StrRem)
//                         .HasColumnName("str_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StrType)
//                         .HasColumnName("str_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//                entity.Property(e => e.ConsYear).HasColumnName("cons_year");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.Structure)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<StructureHistory>(entity =>
//            {
//                entity.ToTable("structure_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.structure_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrCond)
//                         .HasColumnName("str_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrCons)
//                         .HasColumnName("str_cons")
//                         .HasMaxLength(25);

//                entity.Property(e => e.StrDim)
//                         .HasColumnName("str_dim")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StrDimHeight)
//                         .HasColumnName("str_dim_height")
//                         .HasComment("structure dimension height");

//                entity.Property(e => e.StrDimLen)
//                         .HasColumnName("str_dim_len")
//                         .HasComment("structure dimension length");

//                entity.Property(e => e.StrDimWidth)
//                         .HasColumnName("str_dim_width")
//                         .HasComment("structure dimension breadth");

//                entity.Property(e => e.StrEqk)
//                         .HasColumnName("str_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrNo)
//                         .HasColumnName("str_no")
//                         .HasMaxLength(50);

//                entity.Property(e => e.StrNrp)
//                         .HasColumnName("str_nrp")
//                         .HasMaxLength(100);

//                entity.Property(e => e.StrOther)
//                         .HasColumnName("str_other")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StrRem)
//                         .HasColumnName("str_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StrType)
//                         .HasColumnName("str_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.StructureHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<Support>(entity =>
//            {
//                entity.ToTable("support", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SupportAgencyId).HasColumnName("support_agency_id");

//                entity.Property(e => e.SupportAmount).HasColumnName("support_amount");

//                entity.Property(e => e.SupportNote)
//                         .HasColumnName("support_note")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupportTypeId).HasColumnName("support_type_id");

//                entity.Property(e => e.SupportYear).HasColumnName("support_year");
//            });

//            modelBuilder.Entity<SupportHistory>(entity =>
//            {
//                entity.ToTable("support_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.support_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SupportAgencyId).HasColumnName("support_agency_id");

//                entity.Property(e => e.SupportAmount).HasColumnName("support_amount");

//                entity.Property(e => e.SupportNote)
//                         .HasColumnName("support_note")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SupportTypeId).HasColumnName("support_type_id");

//                entity.Property(e => e.SupportYear).HasColumnName("support_year");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");
//            });

//            modelBuilder.Entity<Sustainability>(entity =>
//            {
//                entity.ToTable("sustainability", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.NoWomenWuscMem).HasColumnName("no_women_wusc_mem");

//                entity.Property(e => e.NoWuscMem).HasColumnName("no_wusc_mem");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SusAcc)
//                         .HasColumnName("sus_acc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusAgm)
//                         .HasColumnName("sus_agm")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusBookeeping)
//                         .HasColumnName("sus_bookeeping")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusInsurance)
//                         .HasColumnName("sus_insurance")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusNoMeeting)
//                         .HasColumnName("sus_no_meeting")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusPerHh)
//                         .HasColumnName("sus_per_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusSop)
//                         .HasColumnName("sus_sop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusSourceReg)
//                         .HasColumnName("sus_source_reg")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusSourceSafety)
//                         .HasColumnName("sus_source_safety")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusVmw)
//                         .HasColumnName("sus_vmw")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusWaterQuality)
//                         .HasColumnName("sus_water_quality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<SustainabilityHistory>(entity =>
//            {
//                entity.ToTable("sustainability_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.sustainability_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.NoWomenWuscMem).HasColumnName("no_women_wusc_mem");

//                entity.Property(e => e.NoWuscMem).HasColumnName("no_wusc_mem");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SusAcc)
//                         .HasColumnName("sus_acc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusAgm)
//                         .HasColumnName("sus_agm")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusBookeeping)
//                         .HasColumnName("sus_bookeeping")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusInsurance)
//                         .HasColumnName("sus_insurance")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusNoMeeting)
//                         .HasColumnName("sus_no_meeting")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusPerHh)
//                         .HasColumnName("sus_per_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusSop)
//                         .HasColumnName("sus_sop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusSourceReg)
//                         .HasColumnName("sus_source_reg")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusSourceSafety)
//                         .HasColumnName("sus_source_safety")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusVmw)
//                         .HasColumnName("sus_vmw")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SusWaterQuality)
//                         .HasColumnName("sus_water_quality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<SustainabilityNewScore>(entity =>
//            {
//                entity.ToTable("sustainability_new_score", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.InputScore)
//                         .HasColumnName("input_score")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.OutputScore)
//                         .HasColumnName("output_score")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year1)
//                         .HasColumnName("year1")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year2)
//                         .HasColumnName("year2")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year3)
//                         .HasColumnName("year3")
//                         .HasMaxLength(8);
//            });

//            modelBuilder.Entity<SustainabilityScore>(entity =>
//            {
//                entity.ToTable("sustainability_score", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.Input)
//                         .HasColumnName("input")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunicipalityCode)
//                         .HasColumnName("municipality_code")
//                         .HasMaxLength(16);

//                entity.Property(e => e.Output)
//                         .HasColumnName("output")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectCode)
//                         .HasColumnName("project_code")
//                         .HasMaxLength(128);

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasMaxLength(8);

//                entity.Property(e => e.Year1).HasColumnName("year1");

//                entity.Property(e => e.Year2).HasColumnName("year2");

//                entity.Property(e => e.Year3).HasColumnName("year3");
//            });

//            modelBuilder.Entity<SwProjectInfo>(entity =>
//            {
//                entity.ToTable("sw_project_info", "solid_waste");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('solid_waste.tbl_project_info_id_seq'::regclass)");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table32>(entity =>
//            {
//                entity.ToTable("table_3_2", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Facilities)
//                         .HasColumnName("facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmPc)
//                         .HasColumnName("fsm_pc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmPop)
//                         .HasColumnName("fsm_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhPc)
//                         .HasColumnName("hh_pc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhPop)
//                         .HasColumnName("hh_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sn).HasColumnName("sn");

//                entity.Property(e => e.SwmPc)
//                         .HasColumnName("swm_pc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SwmPop)
//                         .HasColumnName("swm_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPc)
//                         .HasColumnName("tubewell_pc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPop)
//                         .HasColumnName("tubewell_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsPc)
//                         .HasColumnName("ws_pc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsPop)
//                         .HasColumnName("ws_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WwtpPc)
//                         .HasColumnName("wwtp_pc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WwtpPop)
//                         .HasColumnName("wwtp_pop")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table33>(entity =>
//            {
//                entity.ToTable("table_3_3", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DisabledFriendlyToilet)
//                         .HasColumnName("disabled_friendly_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Facilities)
//                         .HasColumnName("facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Hhs)
//                         .HasColumnName("hhs")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HwPresent)
//                         .HasColumnName("hw_present")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Pop)
//                         .HasColumnName("pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PvtToilet)
//                         .HasColumnName("pvt_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sn).HasColumnName("sn");

//                entity.Property(e => e.SoapNearHw)
//                         .HasColumnName("soap_near_hw")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterInToilet)
//                         .HasColumnName("water_in_toilet")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table34>(entity =>
//            {
//                entity.ToTable("table_3_4", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Facilities)
//                         .HasColumnName("facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfAdv)
//                         .HasColumnName("hcf_adv")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfBasic)
//                         .HasColumnName("hcf_basic")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfLimited)
//                         .HasColumnName("hcf_limited")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfNo)
//                         .HasColumnName("hcf_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HcfTotal)
//                         .HasColumnName("hcf_total")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpAdv)
//                         .HasColumnName("pp_adv")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpBasic)
//                         .HasColumnName("pp_basic")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpLimited)
//                         .HasColumnName("pp_limited")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpNo)
//                         .HasColumnName("pp_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PpTotal)
//                         .HasColumnName("pp_total")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolAdv)
//                         .HasColumnName("school_adv")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolBasic)
//                         .HasColumnName("school_basic")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLimited)
//                         .HasColumnName("school_limited")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolNo)
//                         .HasColumnName("school_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolTotal)
//                         .HasColumnName("school_total")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sn).HasColumnName("sn");
//            });

//            modelBuilder.Entity<Table35>(entity =>
//            {
//                entity.ToTable("table_3_5", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Schools)
//                         .HasColumnName("schools")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Students)
//                         .HasColumnName("students")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsSystem)
//                         .HasColumnName("ws_system")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table36>(entity =>
//            {
//                entity.ToTable("table_3_6", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.HygSchool)
//                         .HasColumnName("hyg_school")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygSchoolPop)
//                         .HasColumnName("hyg_school_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanSchool)
//                         .HasColumnName("san_school")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanSchoolPop)
//                         .HasColumnName("san_school_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ServiceLevel)
//                         .HasColumnName("service_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsSchoolPop)
//                         .HasColumnName("ws_school_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsSchools)
//                         .HasColumnName("ws_schools")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table37>(entity =>
//            {
//                entity.ToTable("table_3_7", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Boys)
//                         .HasColumnName("boys")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFriendly)
//                         .HasColumnName("disabled_friendly")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Girls)
//                         .HasColumnName("girls")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmFac)
//                         .HasColumnName("mhm_fac")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ServiceLevel)
//                         .HasColumnName("service_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table38>(entity =>
//            {
//                entity.ToTable("table_3_8", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.HygHcf)
//                         .HasColumnName("hyg_hcf")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygPop)
//                         .HasColumnName("hyg_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanHcf)
//                         .HasColumnName("san_hcf")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanPop)
//                         .HasColumnName("san_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ServiceLevel)
//                         .HasColumnName("service_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SwmHcf)
//                         .HasColumnName("swm_hcf")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SwmPop)
//                         .HasColumnName("swm_pop")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsHcf)
//                         .HasColumnName("ws_hcf")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WsPop)
//                         .HasColumnName("ws_pop")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Table39>(entity =>
//            {
//                entity.ToTable("table_3_9", "data_extraction");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Numbers)
//                         .HasColumnName("numbers")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Parameter)
//                         .HasColumnName("parameter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<TableDictionary>(entity =>
//            {
//                entity.ToTable("table_dictionary", "swmap");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.PostgresSchema)
//                         .HasColumnName("postgres_schema")
//                         .HasMaxLength(200);

//                entity.Property(e => e.PostgresTable)
//                         .HasColumnName("postgres_table")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SqliteLayer)
//                         .HasColumnName("sqlite_layer")
//                         .HasMaxLength(200);
//                entity.Property(e => e.LayerType)
//                         .HasColumnName("layer_type");
//                entity.Property(e => e.Status).HasColumnName("status");
//            });

//            modelBuilder.Entity<Tap>(entity =>
//            {
//                entity.ToTable("tap", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DalHh)
//                         .HasColumnName("dal_hh")
//                         .HasColumnType("numeric");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FemalePop).HasColumnName("female_pop");

//                entity.Property(e => e.HhServerd)
//                         .HasColumnName("hh_serverd")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.HhToilet).HasColumnName("hh_toilet");

//                entity.Property(e => e.TankAvailable).HasColumnName("tank_available");

//                entity.Property(e => e.JanHh)
//                         .HasColumnName("jan_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MiHh)
//                         .HasColumnName("mi_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.NoLeakage).HasColumnName("no_leakage");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapComplaint).HasColumnName("tap_complaint");

//                entity.Property(e => e.TapCond)
//                         .HasColumnName("tap_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapCons)
//                         .HasColumnName("tap_cons")
//                         .HasMaxLength(25);

//                entity.Property(e => e.TapContact)
//                         .HasColumnName("tap_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapEqk)
//                         .HasColumnName("tap_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapFhours).HasColumnName("tap_fhours");

//                entity.Property(e => e.TapFlowCon)
//                         .HasColumnName("tap_flow_con")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapMeter)
//                         .HasColumnName("tap_meter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapNo)
//                         .HasColumnName("tap_no")
//                         .HasMaxLength(50);

//                entity.Property(e => e.TapNrp)
//                         .HasColumnName("tap_nrp")
//                         .HasMaxLength(25);

//                entity.Property(e => e.TapOwner)
//                         .HasColumnName("tap_owner")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("''::character varying");

//                entity.Property(e => e.TapRem)
//                         .HasColumnName("tap_rem")
//                         .HasMaxLength(255);

//                entity.Property(e => e.TapTur)
//                         .HasColumnName("tap_tur")
//                         .HasMaxLength(25);

//                entity.Property(e => e.TapType)
//                         .HasColumnName("tap_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapWaterQuality)
//                         .HasColumnName("tap_water_quality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.Tap)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<TapHistory>(entity =>
//            {
//                entity.ToTable("tap_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.tap_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DalHh)
//                         .HasColumnName("dal_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FemalePop).HasColumnName("female_pop");

//                entity.Property(e => e.HhServerd)
//                         .HasColumnName("hh_serverd")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.HhToilet).HasColumnName("hh_toilet");

//                entity.Property(e => e.JanHh)
//                         .HasColumnName("jan_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MiHh)
//                         .HasColumnName("mi_hh")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.NoLeakage).HasColumnName("no_leakage");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapComplaint).HasColumnName("tap_complaint");

//                entity.Property(e => e.TapCond)
//                         .HasColumnName("tap_cond")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapCons)
//                         .HasColumnName("tap_cons")
//                         .HasMaxLength(25);

//                entity.Property(e => e.TapContact)
//                         .HasColumnName("tap_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapEqk)
//                         .HasColumnName("tap_eqk")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapFhours).HasColumnName("tap_fhours");

//                entity.Property(e => e.TapFlowCon)
//                         .HasColumnName("tap_flow_con")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapMeter)
//                         .HasColumnName("tap_meter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapNo)
//                         .HasColumnName("tap_no")
//                         .HasMaxLength(50);

//                entity.Property(e => e.TapNrp)
//                         .HasColumnName("tap_nrp")
//                         .HasMaxLength(25);

//                entity.Property(e => e.TapOwner)
//                         .HasColumnName("tap_owner")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("''::character varying");

//                entity.Property(e => e.TapRem)
//                         .HasColumnName("tap_rem")
//                         .HasMaxLength(255);

//                entity.Property(e => e.TapTur)
//                         .HasColumnName("tap_tur")
//                         .HasMaxLength(25);

//                entity.Property(e => e.TapType)
//                         .HasColumnName("tap_type")
//                         .HasMaxLength(100);

//                entity.Property(e => e.TapWaterQuality)
//                         .HasColumnName("tap_water_quality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.TapHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<TblDictionary>(entity =>
//            {
//                entity.ToTable("tbl_dictionary", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.FieldName)
//                         .HasColumnName("field_name")
//                         .HasMaxLength(100);

//                entity.Property(e => e.FieldText)
//                         .HasColumnName("field_text")
//                         .HasMaxLength(200);

//                entity.Property(e => e.ReturnIfNull)
//                         .HasColumnName("return_if_null")
//                         .HasMaxLength(50);
//            });

//            modelBuilder.Entity<TblHousehold>(entity =>
//            {
//                entity.ToTable("tbl_household", "household");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AccessibilityOfWater)
//                         .HasColumnName("accessibility_of_water")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedOn)
//                   .HasColumnName("edited_on")
//                   .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AgencyName)
//                         .HasColumnName("agency_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AvailabilityOfSoapWater)
//                         .HasColumnName("availability_of_soap_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoyBelow5Num)
//                         .HasColumnName("boy_below_5_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CleaningFacilities)
//                         .HasColumnName("cleaning_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContactNo)
//                         .HasColumnName("contact_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoverForPit)
//                         .HasColumnName("cover_for_pit")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Defecation)
//                         .HasColumnName("defecation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFriendlyToilet)
//                         .HasColumnName("disabled_friendly_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMemberNum)
//                         .HasColumnName("disabled_member_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DishWasteWaterDest)
//                         .HasColumnName("dish_waste_water_dest")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DryDishesInSunStatus)
//                         .HasColumnName("dry_dishes_in_sun_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DryDishesPlace)
//                         .HasColumnName("dry_dishes_place")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.FaecalSludgeTreatment)
//                         .HasColumnName("faecal_sludge_treatment")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FaecalWasteTransportation)
//                         .HasColumnName("faecal_waste_transportation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FamHeadContactNo)
//                         .HasColumnName("fam_head_contact_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FamHeadEthnicity)
//                         .HasColumnName("fam_head_ethnicity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FamHeadName)
//                         .HasColumnName("fam_head_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FamNo)
//                         .HasColumnName("fam_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleBelow18Num)
//                         .HasColumnName("female_below_18_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleFamHeadStatus)
//                         .HasColumnName("female_fam_head_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleNum)
//                         .HasColumnName("female_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleUsingToiletDuringPeriodStatus)
//                         .HasColumnName("female_using_toilet_during_period_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FixedDishWashStation)
//                         .HasColumnName("fixed_dish_wash_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FullTankPeriod)
//                         .HasColumnName("full_tank_period")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlBelow5Num)
//                         .HasColumnName("girl_below_5_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingFacilities)
//                         .HasColumnName("hand_washing_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingTimeWithSoap)
//                         .HasColumnName("hand_washing_time_with_soap")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HouseCleanlinessObserved)
//                         .HasColumnName("house_cleanliness_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HouseCleanlinessStatus)
//                         .HasColumnName("house_cleanliness_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HouseholdsUsingTubewell)
//                         .HasColumnName("households_using_tubewell")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InformerAge)
//                         .HasColumnName("informer_age")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InformerEthnicity)
//                         .HasColumnName("informer_ethnicity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InformerGender)
//                         .HasColumnName("informer_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InformerName)
//                         .HasColumnName("informer_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LandFieldDistanceFromCommunity)
//                         .HasColumnName("land_field_distance_from_community")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LandFieldLocation)
//                         .HasColumnName("land_field_location")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LatrineFloorType)
//                         .HasColumnName("latrine_floor_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MainFamIncomeSource)
//                         .HasColumnName("main_fam_income_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleBelow18Num)
//                         .HasColumnName("male_below_18_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleNum)
//                         .HasColumnName("male_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NumUsingToilet)
//                         .HasColumnName("num_using_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherIncomeSource)
//                         .HasColumnName("other_income_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherNum)
//                         .HasColumnName("other_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherWaterPurificationMethod)
//                         .HasColumnName("other_water_purification_method")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                         .HasColumnName("photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                         .HasColumnName("photo_2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3)
//                         .HasColumnName("photo_3")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4)
//                         .HasColumnName("photo_4")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5)
//                         .HasColumnName("photo_5")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6)
//                         .HasColumnName("photo_6")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1Uuid)
//                         .HasColumnName("photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Uuid)
//                         .HasColumnName("photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Uuid)
//                         .HasColumnName("photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Uuid)
//                         .HasColumnName("photo_4_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5Uuid)
//                         .HasColumnName("photo_5_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6Uuid)
//                         .HasColumnName("photo_6_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PitLeakageStatus)
//                         .HasColumnName("pit_leakage_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PitLineStatus)
//                         .HasColumnName("pit_line_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PopulationUsingTubewell)
//                         .HasColumnName("population_using_tubewell")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PresenceOfWaterInToilet)
//                         .HasColumnName("presence_of_water_in_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PrivateToilet)
//                         .HasColumnName("private_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PublicSpaceForSludgeTreatment)
//                         .HasColumnName("public_space_for_sludge_treatment")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RecyclableNonrecyclableSeparation)
//                         .HasColumnName("recyclable_nonrecyclable_separation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SeparateWasteMgmt)
//                         .HasColumnName("separate_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ServiceSatisfaction)
//                         .HasColumnName("service_satisfaction")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapHandWashingFacilities)
//                         .HasColumnName("soap_hand_washing_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapInHandWashingStation)
//                         .HasColumnName("soap_in_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteTransportCost)
//                         .HasColumnName("solid_waste_transport_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteTransportFacility)
//                         .HasColumnName("solid_waste_transport_facility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteTransporter)
//                         .HasColumnName("solid_waste_transporter")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceOfWater)
//                         .HasColumnName("source_of_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SpaceForPitConstruction)
//                         .HasColumnName("space_for_pit_construction")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TankCleaner)
//                         .HasColumnName("tank_cleaner")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TankCleaningCost)
//                         .HasColumnName("tank_cleaning_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToBringWater)
//                         .HasColumnName("time_to_bring_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletAvailability)
//                         .HasColumnName("toilet_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleanlinessObserved)
//                         .HasColumnName("toilet_cleanliness_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConnection)
//                         .HasColumnName("toilet_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConstructionCost)
//                         .HasColumnName("toilet_construction_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConstructionYrMnth)
//                         .HasColumnName("toilet_construction_yr_mnth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletGasPipeUsed)
//                         .HasColumnName("toilet_gas_pipe_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletPitCleaner)
//                         .HasColumnName("toilet_pit_cleaner")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletRenovationStatus)
//                         .HasColumnName("toilet_renovation_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletRenovationType)
//                         .HasColumnName("toilet_renovation_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletRoofMaterial)
//                         .HasColumnName("toilet_roof_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletSuperstructureType)
//                         .HasColumnName("toilet_superstructure_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                         .HasColumnName("toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletTypeUsed)
//                         .HasColumnName("toilet_type_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUsedByNeighbours)
//                         .HasColumnName("toilet_used_by_neighbours")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUsedStatus)
//                         .HasColumnName("toilet_used_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletWallMaterial)
//                         .HasColumnName("toilet_wall_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentLandArea)
//                         .HasColumnName("treatment_land_area")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellArsenicContamination)
//                         .HasColumnName("tubewell_arsenic_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellArsenicTest)
//                         .HasColumnName("tubewell_arsenic_test")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellArsenicTestStatus)
//                         .HasColumnName("tubewell_arsenic_test_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellClothesStained)
//                         .HasColumnName("tubewell_clothes_stained")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellCondition)
//                         .HasColumnName("tubewell_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellConstructedYear)
//                         .HasColumnName("tubewell_constructed_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellConstructionCost)
//                         .HasColumnName("tubewell_construction_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellDepth)
//                         .HasColumnName("tubewell_depth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellFecalContamination)
//                         .HasColumnName("tubewell_fecal_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPhoto)
//                         .HasColumnName("tubewell_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.TubewellPhotoUuid)
//                         .HasColumnName("tubewell_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPipeSysProjectStatus)
//                         .HasColumnName("tubewell_pipe_sys_project_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPlatform)
//                         .HasColumnName("tubewell_platform")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellTreatmentSystem)
//                         .HasColumnName("tubewell_treatment_system")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellType)
//                         .HasColumnName("tubewell_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterAdequacy)
//                         .HasColumnName("tubewell_water_adequacy")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterColor)
//                         .HasColumnName("tubewell_water_color")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterEffectOnTeeth)
//                         .HasColumnName("tubewell_water_effect_on_teeth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterSmell)
//                         .HasColumnName("tubewell_water_smell")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterTaste)
//                         .HasColumnName("tubewell_water_taste")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterTurbidity)
//                         .HasColumnName("tubewell_water_turbidity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsedWaterDrinkablePerception)
//                         .HasColumnName("used_water_drinkable_perception")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(256);

//                entity.Property(e => e.Village)
//                         .HasColumnName("village")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WardNo)
//                         .HasColumnName("ward_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteTransportPeriod)
//                         .HasColumnName("waste_transport_period")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Water12mnthsAvailability)
//                         .HasColumnName("water_12mnths_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterInHandWashingStation)
//                         .HasColumnName("water_in_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurificationDone)
//                         .HasColumnName("water_purification_done")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurificationMethod)
//                         .HasColumnName("water_purification_method")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterSourceDistanceFromPit)
//                         .HasColumnName("water_source_distance_from_pit")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<TblInstitution>(entity =>
//            {
//                entity.ToTable("tbl_institution", "institution");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Age)
//                         .HasColumnName("age")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AlternativeWaterSupplyDays)
//                         .HasColumnName("alternative_water_supply_days")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AlternativeWaterSupplyStatus)
//                         .HasColumnName("alternative_water_supply_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AppropriateToiletLock)
//                         .HasColumnName("appropriate_toilet_lock")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildrenEasyAccessToSoapWater)
//                         .HasColumnName("children_easy_access_to_soap_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildrenToiletAccessibility)
//                         .HasColumnName("children_toilet_accessibility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContactNo)
//                         .HasColumnName("contact_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterStation)
//                         .HasColumnName("drinking_water_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterStationPhoto)
//                         .HasColumnName("drinking_water_station_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.DrinkingWaterStationPhotoUuid)
//                         .HasColumnName("drinking_water_station_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterTankObserved)
//                         .HasColumnName("drinking_water_tank_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterTankPhoto)
//                         .HasColumnName("drinking_water_tank_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.DrinkingWaterTankPhotoUuid)
//                         .HasColumnName("drinking_water_tank_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterTankStatus)
//                         .HasColumnName("drinking_water_tank_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinInFemaleToilet)
//                         .HasColumnName("dustbin_in_female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinUsedForWasteMgmt)
//                         .HasColumnName("dustbin_used_for_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EasyToiletAccessForDisabled)
//                         .HasColumnName("easy_toilet_access_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EasyWaterAccessForVisitors)
//                         .HasColumnName("easy_water_access_for_visitors")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EasyWaterAccessToDisabled)
//                         .HasColumnName("easy_water_access_to_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.ExteriorToiletPhoto)
//                         .HasColumnName("exterior_toilet_photo")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleToiletPhoto)
//                         .HasColumnName("female_toilet_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ExteriorToiletPhotoUuid)
//                         .HasColumnName("exterior_toilet_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleToiletPhotoUuid)
//                         .HasColumnName("female_toilet_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Gender)
//                         .HasColumnName("gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InformerEthnicity)
//                         .HasColumnName("informer_ethnicity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InformerName)
//                         .HasColumnName("informer_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InstituteEnvironmentCleanliness)
//                         .HasColumnName("institute_environment_cleanliness")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InstitutionName)
//                         .HasColumnName("institution_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InstitutionPhoto)
//                         .HasColumnName("institution_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.InstitutionPhotoUuid)
//                         .HasColumnName("institution_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InstitutionType)
//                         .HasColumnName("institution_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherDustbinUsedForWasteMgmt)
//                         .HasColumnName("other_dustbin_used_for_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherToiletType)
//                         .HasColumnName("other_toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherWaterPurificationMethod)
//                         .HasColumnName("other_water_purification_method")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReasonForNoToilet)
//                         .HasColumnName("reason_for_no_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SeparateFemaleToilet)
//                         .HasColumnName("separate_female_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceOfWater)
//                         .HasColumnName("source_of_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficiencyOfWater)
//                         .HasColumnName("sufficiency_of_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletAvailability)
//                         .HasColumnName("toilet_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleaner)
//                         .HasColumnName("toilet_cleaner")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleaningTimetable)
//                         .HasColumnName("toilet_cleaning_timetable")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleanlinessObserved)
//                         .HasColumnName("toilet_cleanliness_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletPrivacySecurityObserved)
//                         .HasColumnName("toilet_privacy_security_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                         .HasColumnName("toilet_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUseObserved)
//                         .HasColumnName("toilet_use_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalAvailability)
//                         .HasColumnName("urinal_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalPhoto)
//                         .HasColumnName("urinal_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UrinalPhotoUuid)
//                         .HasColumnName("urinal_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalRoomsNum)
//                         .HasColumnName("urinal_rooms_num")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Village)
//                         .HasColumnName("village")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WardNo)
//                         .HasColumnName("ward_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterDrinkableStatus)
//                         .HasColumnName("water_drinkable_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurificationMethod)
//                         .HasColumnName("water_purification_method")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurificationStatus)
//                         .HasColumnName("water_purification_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityTest)
//                         .HasColumnName("water_quality_test")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityTestStatus)
//                         .HasColumnName("water_quality_test_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterStationNearToilet)
//                         .HasColumnName("water_station_near_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterStationPhoto)
//                         .HasColumnName("water_station_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WaterStationPhotoUuid)
//                         .HasColumnName("water_station_photo_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterStationUsecaseObserved)
//                         .HasColumnName("water_station_usecase_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankCoverObserved)
//                         .HasColumnName("water_tank_cover_observed")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<TblLog>(entity =>
//            {
//                entity.ToTable("tbl_log", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Email)
//                         .HasColumnName("email")
//                         .HasMaxLength(128);

//                entity.Property(e => e.FileName)
//                         .HasColumnName("file_name")
//                         .HasMaxLength(128);

//                entity.Property(e => e.Message)
//                         .HasColumnName("message")
//                         .HasMaxLength(128);

//                entity.Property(e => e.SyncDate)
//                         .HasColumnName("sync_date")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<TblOtherService>(entity =>
//            {
//                entity.ToTable("tbl_other_service", "washplan_other_service");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Particulars)
//                         .HasColumnName("particulars")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno)
//                         .HasColumnName("sno")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Year0).HasColumnName("year0");

//                entity.Property(e => e.Year1).HasColumnName("year1");

//                entity.Property(e => e.Year10).HasColumnName("year10");

//                entity.Property(e => e.Year2).HasColumnName("year2");

//                entity.Property(e => e.Year3).HasColumnName("year3");

//                entity.Property(e => e.Year4).HasColumnName("year4");

//                entity.Property(e => e.Year5).HasColumnName("year5");

//                entity.Property(e => e.Year6).HasColumnName("year6");

//                entity.Property(e => e.Year7).HasColumnName("year7");

//                entity.Property(e => e.Year8).HasColumnName("year8");

//                entity.Property(e => e.Year9).HasColumnName("year9");
//            });


//            modelBuilder.Entity<TblSchool>(entity =>
//            {
//                entity.ToTable("tbl_school", "school");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.UnusedMinorRepairNeededToilet).HasColumnName("unused_minor_repair_needed_toilet");
//                entity.Property(e => e.UnusedMajorRepairNeededToilet).HasColumnName("unused_major_repair_needed_toilet");
//                entity.Property(e => e.AdequacyOfWater)
//                         .HasColumnName("adequacy_of_water")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedDate)
//                     .HasColumnName("edited_date")
//                     .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy)
//                         .HasColumnName("collected_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AvailabilityOfDrinkingWater)
//                         .HasColumnName("availability_of_drinking_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AvailabilityOfDrinkingWaterForChildren)
//                         .HasColumnName("availability_of_drinking_water_for_children")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BathroomCleanCondn)
//                         .HasColumnName("bathroom_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BathroomUsingCondn)
//                         .HasColumnName("bathroom_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BlindStudent)
//                         .HasColumnName("blind_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BlindTeacher)
//                         .HasColumnName("blind_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToilets)
//                         .HasColumnName("boys_separate_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToiletsUnused)
//                         .HasColumnName("boys_separate_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToiletsUsed)
//                         .HasColumnName("boys_separate_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToiletsWithWater)
//                         .HasColumnName("boys_separate_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChairPersonGender)
//                         .HasColumnName("chair_person_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildClubActiveStatus)
//                         .HasColumnName("child_club_active_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildClubStatus)
//                         .HasColumnName("child_club_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClassFiveStatus)
//                         .HasColumnName("class_five_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CleanedRegularly)
//                         .HasColumnName("cleaned_regularly")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CleanlinessActivitiesInvolvedStatus)
//                         .HasColumnName("cleanliness_activities_involved_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClubInWashStatus)
//                         .HasColumnName("club_in_wash_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClubMemberTrainingStatus)
//                         .HasColumnName("club_member_training_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToilets)
//                         .HasColumnName("communal_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToiletsUnused)
//                         .HasColumnName("communal_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToiletsUsed)
//                         .HasColumnName("communal_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToiletsWithWater)
//                         .HasColumnName("communal_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoordinationCommitteeFormedStatus)
//                         .HasColumnName("coordination_committee_formed_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DailyCleanedStatus)
//                         .HasColumnName("daily_cleaned_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFemaleStudent)
//                         .HasColumnName("disabled_female_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFemaleTeacher)
//                         .HasColumnName("disabled_female_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMaleStudent)
//                         .HasColumnName("disabled_male_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMaleTeacher)
//                         .HasColumnName("disabled_male_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledStudentTeacherStatus)
//                         .HasColumnName("disabled_student_teacher_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisasterPreparednessStatus)
//                         .HasColumnName("disaster_preparedness_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DoorLockEasyAccessByChildren)
//                         .HasColumnName("door_lock_easy_access_by_children")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageSystem)
//                         .HasColumnName("drainage_system")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterAccessForAll)
//                         .HasColumnName("drinking_water_access_for_all")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinInFemaleToilets)
//                         .HasColumnName("dustbin_in_female_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.ExtraActivityInVacantLandStatus)
//                         .HasColumnName("extra_activity_in_vacant_land_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FecalContamination)
//                         .HasColumnName("fecal_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleStaff)
//                         .HasColumnName("female_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleStudent)
//                         .HasColumnName("female_student")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SchoolCode)
//                        .HasColumnName("school_code")
//                        .HasColumnType("character varying");

//                entity.Property(e => e.FemaleTeacher)
//                         .HasColumnName("female_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleUrinalCleanCondn)
//                         .HasColumnName("female_urinal_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleUrinalUsingCondn)
//                         .HasColumnName("female_urinal_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FullyDamagedPoints)
//                         .HasColumnName("fully_damaged_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToilets)
//                         .HasColumnName("girls_separate_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToiletsUnused)
//                         .HasColumnName("girls_separate_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToiletsUsed)
//                         .HasColumnName("girls_separate_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToiletsWithWater)
//                         .HasColumnName("girls_separate_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStation)
//                         .HasColumnName("hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationUsingCondn)
//                         .HasColumnName("hand_washing_station_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStatus)
//                         .HasColumnName("hand_washing_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingWithSoap)
//                         .HasColumnName("hand_washing_with_soap")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneCornerStatus)
//                         .HasColumnName("hygiene_corner_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneRatingStatus)
//                         .HasColumnName("hygiene_rating_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneTaughtStatus)
//                         .HasColumnName("hygiene_taught_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorAvailability)
//                         .HasColumnName("incinerator_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorCleanCondn)
//                         .HasColumnName("incinerator_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorCondition)
//                         .HasColumnName("incinerator_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorUsingCondn)
//                         .HasColumnName("incinerator_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.KeyRespondents)
//                         .HasColumnName("key_respondents")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MajorHandwashingRepair)
//                         .HasColumnName("major_handwashing_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MajorToiletRepair)
//                         .HasColumnName("major_toilet_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MajorWaterSource)
//                         .HasColumnName("major_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleStaff)
//                         .HasColumnName("male_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleStudent)
//                         .HasColumnName("male_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleTeacher)
//                         .HasColumnName("male_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleUrinalCleanCondn)
//                         .HasColumnName("male_urinal_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleUrinalUsingCondn)
//                         .HasColumnName("male_urinal_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MenstruationRelatedEducationStatus)
//                         .HasColumnName("menstruation_related_education_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmFocalTeacherStatus)
//                         .HasColumnName("mhm_focal_teacher_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmFund)
//                         .HasColumnName("mhm_fund")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmTrainings)
//                         .HasColumnName("mhm_trainings")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorHandwashingRepair)
//                         .HasColumnName("minor_handwashing_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorToiletRepair)
//                         .HasColumnName("minor_toilet_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotUsingToilet)
//                         .HasColumnName("not_using_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotUsingToiletStatus)
//                         .HasColumnName("not_using_toilet_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotWashingWithSoapOtherReason)
//                         .HasColumnName("not_washing_with_soap_other_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotWashingWithSoapReason)
//                         .HasColumnName("not_washing_with_soap_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OpenDefecationFreeStatus)
//                         .HasColumnName("open_defecation_free_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherNotUsingToilet)
//                         .HasColumnName("other_not_using_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherSanitaryPadsDisposalPlc)
//                         .HasColumnName("other_sanitary_pads_disposal_plc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherToiletStudentsUse)
//                         .HasColumnName("other_toilet_students_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherWaterTreatmentType)
//                         .HasColumnName("other_water_treatment_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PartialDamagedPoints)
//                         .HasColumnName("partial_damaged_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhysicallyDisabledStudent)
//                         .HasColumnName("physically_disabled_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhysicallyDisabledTeacher)
//                         .HasColumnName("physically_disabled_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PointsObservedStatus)
//                         .HasColumnName("points_observed_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PointsWithCondnObservedStatus)
//                         .HasColumnName("points_with_condn_observed_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityChemicalContamination)
//                         .HasColumnName("priority_chemical_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RampOutsideToilet)
//                         .HasColumnName("ramp_outside_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededHandwashing)
//                         .HasColumnName("reconstruction_needed_handwashing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededToilet)
//                         .HasColumnName("reconstruction_needed_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RespondentContact)
//                         .HasColumnName("respondent_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReusableProductSkillStatus)
//                         .HasColumnName("reusable_product_skill_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RiskMappingStatus)
//                         .HasColumnName("risk_mapping_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RiskReductionStatus)
//                         .HasColumnName("risk_reduction_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SafeDrinkingWaterStatus)
//                         .HasColumnName("safe_drinking_water_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SafeSecureToilets)
//                         .HasColumnName("safe_secure_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitaryNapkinsAccess)
//                         .HasColumnName("sanitary_napkins_access")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitaryPadsDisposalPlc)
//                         .HasColumnName("sanitary_pads_disposal_plc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolCommunity)
//                         .HasColumnName("school_community")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolFacilities)
//                         .HasColumnName("school_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolGroundAvailability)
//                         .HasColumnName("school_ground_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolHygienePlanStatus)
//                         .HasColumnName("school_hygiene_plan_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLatrineCleaner)
//                         .HasColumnName("school_latrine_cleaner")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLatrinesAvailability)
//                         .HasColumnName("school_latrines_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLevel)
//                         .HasColumnName("school_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolName)
//                         .HasColumnName("school_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto1)
//                         .HasColumnName("school_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto2)
//                         .HasColumnName("school_photo_2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto3)
//                         .HasColumnName("school_photo_3")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AdditionalPhoto1)
//                         .HasColumnName("additional_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2)
//                         .HasColumnName("additional_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3)
//                         .HasColumnName("additional_photo_3")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4)
//                         .HasColumnName("additional_photo_4")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto1Uuid)
//                         .HasColumnName("school_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto2Uuid)
//                         .HasColumnName("school_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto3Uuid)
//                         .HasColumnName("school_photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                         .HasColumnName("additional_photo_1_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                         .HasColumnName("additional_photo_2_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                         .HasColumnName("additional_photo_3_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4Uuid)
//                         .HasColumnName("additional_photo_4_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolRating)
//                         .HasColumnName("school_rating")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolToiletTypeComments)
//                         .HasColumnName("school_toilet_type_comments")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolToiletsCondn)
//                         .HasColumnName("school_toilets_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolToiletsType)
//                         .HasColumnName("school_toilets_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolType)
//                         .HasColumnName("school_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWard)
//                         .HasColumnName("school_ward")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWashPlanStatus)
//                         .HasColumnName("school_wash_plan_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWaterSource)
//                         .HasColumnName("school_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWaterStatus)
//                         .HasColumnName("school_water_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWaterTankAvailability)
//                         .HasColumnName("school_water_tank_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SecretaryGender)
//                         .HasColumnName("secretary_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkillsAvailable)
//                         .HasColumnName("skills_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapWaterAvailabilityInHandwashingStation)
//                         .HasColumnName("soap_water_availability_in_handwashing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapWaterEasyAccessByChildrenForToilet)
//                         .HasColumnName("soap_water_easy_access_by_children_for_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceIfNoSchoolWater)
//                         .HasColumnName("source_if_no_school_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SpecialPeopleAccessToWater)
//                         .HasColumnName("special_people_access_to_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StationPhoto1)
//                         .HasColumnName("station_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StationPhoto2)
//                         .HasColumnName("station_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.StationPhoto1Uuid)
//                         .HasColumnName("station_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StationPhoto2Uuid)
//                         .HasColumnName("station_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StructureConstructedCriteriaStatus)
//                         .HasColumnName("structure_constructed_criteria_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentHygienePractice)
//                         .HasColumnName("student_hygiene_practice")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentHygienePracticeCmnt)
//                         .HasColumnName("student_hygiene_practice_cmnt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentWithOtherDisability)
//                         .HasColumnName("student_with_other_disability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentsActivelyInvolvedStatus)
//                         .HasColumnName("students_actively_involved_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentsPresenceDuringMenstruation)
//                         .HasColumnName("students_presence_during_menstruation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficientToiletSpaceSeat)
//                         .HasColumnName("sufficient_toilet_space_seat")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficientWaterAvailabilityStatus)
//                         .HasColumnName("sufficient_water_availability_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TankSize)
//                         .HasColumnName("tank_size")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.TapForDrinking)
//                         .HasColumnName("tap_for_drinking")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapForWashing)
//                         .HasColumnName("tap_for_washing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeacherProvidedStatus)
//                         .HasColumnName("teacher_provided_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeacherWithOtherDisability)
//                         .HasColumnName("teacher_with_other_disability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToilets)
//                         .HasColumnName("teachers_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToiletsUnused)
//                         .HasColumnName("teachers_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToiletsUsed)
//                         .HasColumnName("teachers_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToiletsWithWater)
//                         .HasColumnName("teachers_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToBringWater)
//                         .HasColumnName("time_to_bring_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletPhoto1)
//                         .HasColumnName("toilet_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ToiletPhoto1Uuid)
//                         .HasColumnName("toilet_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletStudentsUse)
//                         .HasColumnName("toilet_students_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletsCmnts)
//                         .HasColumnName("toilets_cmnts")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletsObserved)
//                         .HasColumnName("toilets_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToilets)
//                         .HasColumnName("total_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletsUnused)
//                         .HasColumnName("total_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletsUsed)
//                         .HasColumnName("total_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletsWithWater)
//                         .HasColumnName("total_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalWaterPoints)
//                         .HasColumnName("total_water_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreasurerGender)
//                         .HasColumnName("treasurer_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UnusedFullyDamagedPoints)
//                         .HasColumnName("unused_fully_damaged_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalBathroomCmnts)
//                         .HasColumnName("urinal_bathroom_cmnts")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalPhoto1)
//                         .HasColumnName("urinal_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UrinalPhoto1Uuid)
//                         .HasColumnName("urinal_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableCommunalHandWashingStation)
//                         .HasColumnName("usable_communal_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToiletWithHygiene)
//                         .HasColumnName("usable_female_toilet_with_hygiene")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToiletWithoutHygiene)
//                         .HasColumnName("usable_female_toilet_without_hygiene")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableHandWashingStationForDisabled)
//                         .HasColumnName("usable_hand_washing_station_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableSeparateBoyHandWashingStation)
//                         .HasColumnName("usable_separate_boy_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableSeparateGirlHandWashingStation)
//                         .HasColumnName("usable_separate_girl_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableToiletForDisabled)
//                         .HasColumnName("usable_toilet_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(256);

//                entity.Property(e => e.WashRepairChargeStatus)
//                         .HasColumnName("wash_repair_charge_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteDumpedStatus)
//                         .HasColumnName("waste_dumped_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteGlassStatus)
//                         .HasColumnName("waste_glass_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteRecycledStatus)
//                         .HasColumnName("waste_recycled_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPointPhoto1)
//                         .HasColumnName("water_point_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPointPhoto2)
//                         .HasColumnName("water_point_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WaterPointPhoto1Uuid)
//                         .HasColumnName("water_point_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPointPhoto2Uuid)
//                         .HasColumnName("water_point_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierAvailability)
//                         .HasColumnName("water_purifier_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierCondition)
//                         .HasColumnName("water_purifier_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityPerception)
//                         .HasColumnName("water_quality_perception")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTestResult)
//                         .HasColumnName("water_test_result")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTestedStatus)
//                         .HasColumnName("water_tested_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentStatus)
//                         .HasColumnName("water_treatment_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentType)
//                         .HasColumnName("water_treatment_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WellUsedPoints)
//                         .HasColumnName("well_used_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WorkingTapsForDisabled)
//                         .HasColumnName("working_taps_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolCode)
//                         .HasColumnName("school_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherStudent)
//                         .HasColumnName("other_student")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherStaff)
//                         .HasColumnName("other_staff")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SeparateMaleUrinal)
//                         .HasColumnName("separate_male_urinal")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SeparateFemaleUrinal)
//                         .HasColumnName("separate_female_urinal")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.IsWqTested)
//                         .HasColumnName("is_wq_tested")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WqReportPhoto)
//                         .HasColumnName("wq_report_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WqReportPhotoUuid)
//                         .HasColumnName("wq_report_photo_uuid")
//                         .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<SolidwasteMngLut>(entity =>
//            {
//                entity.HasKey(e => e.Id).HasName("sw_lut_pkey_id");

//                entity.ToTable("solidwaste_mng_lut", "solidwaste_management");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Label)
//                    .HasColumnType("character varying")
//                    .HasColumnName("label");
//                entity.Property(e => e.LabelDn)
//                    .HasColumnType("character varying")
//                    .HasColumnName("label_dn");
//                entity.Property(e => e.LabelText)
//                    .HasColumnType("character varying")
//                    .HasColumnName("label_text");
//                entity.Property(e => e.Index)
//                    .HasColumnName("index");
//                entity.Property(e => e.Options)
//                    .HasColumnType("character varying")
//                    .HasColumnName("options");
//                entity.Property(e => e.Scope)
//                    .HasColumnType("character varying")
//                    .HasColumnName("scope");
//            });
//            modelBuilder.Entity<WasteMngLut>(entity =>
//            {
//                entity.HasKey(e => e.Id);

//                entity.ToTable("waste_mng_lut", "waste_management_service");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.Label)
//                    .HasColumnType("character varying")
//                    .HasColumnName("label");
//                entity.Property(e => e.LabelDn)
//                    .HasColumnType("character varying")
//                    .HasColumnName("label_dn");
//                entity.Property(e => e.LabelText)
//                    .HasColumnType("character varying")
//                    .HasColumnName("label_text");
//                entity.Property(e => e.Index)
//                    .HasColumnName("index");
//                entity.Property(e => e.Options)
//                    .HasColumnType("character varying")
//                    .HasColumnName("options");
//                entity.Property(e => e.Scope)
//                    .HasColumnType("character varying")
//                    .HasColumnName("scope");
//            });
//            modelBuilder.Entity<TblSchoolOld>(entity =>
//            {
//                entity.ToTable("tbl_school_old", "school");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.UnusedMinorRepairNeededToilet).HasColumnName("unused_minor_repair_needed_toilet");
//                entity.Property(e => e.UnusedMajorRepairNeededToilet).HasColumnName("unused_major_repair_needed_toilet");
//                entity.Property(e => e.AdequacyOfWater)
//                         .HasColumnName("adequacy_of_water")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedDate)
//                    .HasColumnName("edited_date")
//                    .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy)
//                         .HasColumnName("collected_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                         .HasColumnName("app_version")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AvailabilityOfDrinkingWater)
//                         .HasColumnName("availability_of_drinking_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AvailabilityOfDrinkingWaterForChildren)
//                         .HasColumnName("availability_of_drinking_water_for_children")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BathroomCleanCondn)
//                         .HasColumnName("bathroom_clean_condn")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1)
//                        .HasColumnName("additional_photo_1")
//                        .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2)
//                         .HasColumnName("additional_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3)
//                         .HasColumnName("additional_photo_3")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4)
//                         .HasColumnName("additional_photo_4")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                        .HasColumnName("additional_photo_1_uuid")
//                        .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                         .HasColumnName("additional_photo_2_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                         .HasColumnName("additional_photo_3_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4Uuid)
//                         .HasColumnName("additional_photo_4_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.BathroomUsingCondn)
//                         .HasColumnName("bathroom_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BlindStudent)
//                         .HasColumnName("blind_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BlindTeacher)
//                         .HasColumnName("blind_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToilets)
//                         .HasColumnName("boys_separate_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToiletsUnused)
//                         .HasColumnName("boys_separate_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToiletsUsed)
//                         .HasColumnName("boys_separate_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BoysSeparateToiletsWithWater)
//                         .HasColumnName("boys_separate_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChairPersonGender)
//                         .HasColumnName("chair_person_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildClubActiveStatus)
//                         .HasColumnName("child_club_active_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ChildClubStatus)
//                         .HasColumnName("child_club_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClassFiveStatus)
//                         .HasColumnName("class_five_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CleanedRegularly)
//                         .HasColumnName("cleaned_regularly")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CleanlinessActivitiesInvolvedStatus)
//                         .HasColumnName("cleanliness_activities_involved_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClubInWashStatus)
//                         .HasColumnName("club_in_wash_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClubMemberTrainingStatus)
//                         .HasColumnName("club_member_training_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToilets)
//                         .HasColumnName("communal_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToiletsUnused)
//                         .HasColumnName("communal_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToiletsUsed)
//                         .HasColumnName("communal_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunalToiletsWithWater)
//                         .HasColumnName("communal_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CoordinationCommitteeFormedStatus)
//                         .HasColumnName("coordination_committee_formed_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DailyCleanedStatus)
//                         .HasColumnName("daily_cleaned_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                         .HasColumnName("date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFemaleStudent)
//                         .HasColumnName("disabled_female_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFemaleTeacher)
//                         .HasColumnName("disabled_female_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMaleStudent)
//                         .HasColumnName("disabled_male_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMaleTeacher)
//                         .HasColumnName("disabled_male_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledStudentTeacherStatus)
//                         .HasColumnName("disabled_student_teacher_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisasterPreparednessStatus)
//                         .HasColumnName("disaster_preparedness_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DoorLockEasyAccessByChildren)
//                         .HasColumnName("door_lock_easy_access_by_children")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrainageSystem)
//                         .HasColumnName("drainage_system")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterAccessForAll)
//                         .HasColumnName("drinking_water_access_for_all")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DustbinInFemaleToilets)
//                         .HasColumnName("dustbin_in_female_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.ExtraActivityInVacantLandStatus)
//                         .HasColumnName("extra_activity_in_vacant_land_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FecalContamination)
//                         .HasColumnName("fecal_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleStaff)
//                         .HasColumnName("female_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleStudent)
//                         .HasColumnName("female_student")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SchoolCode)
//                        .HasColumnName("school_code")
//                        .HasColumnType("character varying");

//                entity.Property(e => e.FemaleTeacher)
//                         .HasColumnName("female_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleUrinalCleanCondn)
//                         .HasColumnName("female_urinal_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FemaleUrinalUsingCondn)
//                         .HasColumnName("female_urinal_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FullyDamagedPoints)
//                         .HasColumnName("fully_damaged_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToilets)
//                         .HasColumnName("girls_separate_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToiletsUnused)
//                         .HasColumnName("girls_separate_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToiletsUsed)
//                         .HasColumnName("girls_separate_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GirlsSeparateToiletsWithWater)
//                         .HasColumnName("girls_separate_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStation)
//                         .HasColumnName("hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationUsingCondn)
//                         .HasColumnName("hand_washing_station_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStatus)
//                         .HasColumnName("hand_washing_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingWithSoap)
//                         .HasColumnName("hand_washing_with_soap")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneCornerStatus)
//                         .HasColumnName("hygiene_corner_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneRatingStatus)
//                         .HasColumnName("hygiene_rating_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HygieneTaughtStatus)
//                         .HasColumnName("hygiene_taught_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorAvailability)
//                         .HasColumnName("incinerator_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorCleanCondn)
//                         .HasColumnName("incinerator_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorCondition)
//                         .HasColumnName("incinerator_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorUsingCondn)
//                         .HasColumnName("incinerator_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.KeyRespondents)
//                         .HasColumnName("key_respondents")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MajorHandwashingRepair)
//                         .HasColumnName("major_handwashing_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MajorToiletRepair)
//                         .HasColumnName("major_toilet_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MajorWaterSource)
//                         .HasColumnName("major_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleStaff)
//                         .HasColumnName("male_staff")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleStudent)
//                         .HasColumnName("male_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleTeacher)
//                         .HasColumnName("male_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleUrinalCleanCondn)
//                         .HasColumnName("male_urinal_clean_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MaleUrinalUsingCondn)
//                         .HasColumnName("male_urinal_using_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MenstruationRelatedEducationStatus)
//                         .HasColumnName("menstruation_related_education_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmFocalTeacherStatus)
//                         .HasColumnName("mhm_focal_teacher_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmFund)
//                         .HasColumnName("mhm_fund")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MhmTrainings)
//                         .HasColumnName("mhm_trainings")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorHandwashingRepair)
//                         .HasColumnName("minor_handwashing_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MinorToiletRepair)
//                         .HasColumnName("minor_toilet_repair")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotUsingToilet)
//                         .HasColumnName("not_using_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotUsingToiletStatus)
//                         .HasColumnName("not_using_toilet_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotWashingWithSoapOtherReason)
//                         .HasColumnName("not_washing_with_soap_other_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NotWashingWithSoapReason)
//                         .HasColumnName("not_washing_with_soap_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OpenDefecationFreeStatus)
//                         .HasColumnName("open_defecation_free_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherNotUsingToilet)
//                         .HasColumnName("other_not_using_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherSanitaryPadsDisposalPlc)
//                         .HasColumnName("other_sanitary_pads_disposal_plc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherToiletStudentsUse)
//                         .HasColumnName("other_toilet_students_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherWaterTreatmentType)
//                         .HasColumnName("other_water_treatment_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PartialDamagedPoints)
//                         .HasColumnName("partial_damaged_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhysicallyDisabledStudent)
//                         .HasColumnName("physically_disabled_student")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PhysicallyDisabledTeacher)
//                         .HasColumnName("physically_disabled_teacher")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PointsObservedStatus)
//                         .HasColumnName("points_observed_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PointsWithCondnObservedStatus)
//                         .HasColumnName("points_with_condn_observed_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityChemicalContamination)
//                         .HasColumnName("priority_chemical_contamination")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RampOutsideToilet)
//                         .HasColumnName("ramp_outside_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededHandwashing)
//                         .HasColumnName("reconstruction_needed_handwashing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededToilet)
//                         .HasColumnName("reconstruction_needed_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RespondentContact)
//                         .HasColumnName("respondent_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReusableProductSkillStatus)
//                         .HasColumnName("reusable_product_skill_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RiskMappingStatus)
//                         .HasColumnName("risk_mapping_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RiskReductionStatus)
//                         .HasColumnName("risk_reduction_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SafeDrinkingWaterStatus)
//                         .HasColumnName("safe_drinking_water_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SafeSecureToilets)
//                         .HasColumnName("safe_secure_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitaryNapkinsAccess)
//                         .HasColumnName("sanitary_napkins_access")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SanitaryPadsDisposalPlc)
//                         .HasColumnName("sanitary_pads_disposal_plc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolCommunity)
//                         .HasColumnName("school_community")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolFacilities)
//                         .HasColumnName("school_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolGroundAvailability)
//                         .HasColumnName("school_ground_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolHygienePlanStatus)
//                         .HasColumnName("school_hygiene_plan_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLatrineCleaner)
//                         .HasColumnName("school_latrine_cleaner")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLatrinesAvailability)
//                         .HasColumnName("school_latrines_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolLevel)
//                         .HasColumnName("school_level")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolName)
//                         .HasColumnName("school_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto1)
//                         .HasColumnName("school_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto2)
//                         .HasColumnName("school_photo_2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto3)
//                         .HasColumnName("school_photo_3")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SchoolPhoto1Uuid)
//                         .HasColumnName("school_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto2Uuid)
//                         .HasColumnName("school_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolPhoto3Uuid)
//                         .HasColumnName("school_photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolRating)
//                         .HasColumnName("school_rating")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolToiletTypeComments)
//                         .HasColumnName("school_toilet_type_comments")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolToiletsCondn)
//                         .HasColumnName("school_toilets_condn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolToiletsType)
//                         .HasColumnName("school_toilets_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolType)
//                         .HasColumnName("school_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWard)
//                         .HasColumnName("school_ward")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWashPlanStatus)
//                         .HasColumnName("school_wash_plan_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWaterSource)
//                         .HasColumnName("school_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWaterStatus)
//                         .HasColumnName("school_water_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolWaterTankAvailability)
//                         .HasColumnName("school_water_tank_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SecretaryGender)
//                         .HasColumnName("secretary_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SkillsAvailable)
//                         .HasColumnName("skills_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapWaterAvailabilityInHandwashingStation)
//                         .HasColumnName("soap_water_availability_in_handwashing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SoapWaterEasyAccessByChildrenForToilet)
//                         .HasColumnName("soap_water_easy_access_by_children_for_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceIfNoSchoolWater)
//                         .HasColumnName("source_if_no_school_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SpecialPeopleAccessToWater)
//                         .HasColumnName("special_people_access_to_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StationPhoto1)
//                         .HasColumnName("station_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.StationPhoto1Uuid)
//                         .HasColumnName("station_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StationPhoto2)
//                         .HasColumnName("station_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.StationPhoto2Uuid)
//                         .HasColumnName("station_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StructureConstructedCriteriaStatus)
//                         .HasColumnName("structure_constructed_criteria_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentHygienePractice)
//                         .HasColumnName("student_hygiene_practice")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentHygienePracticeCmnt)
//                         .HasColumnName("student_hygiene_practice_cmnt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentWithOtherDisability)
//                         .HasColumnName("student_with_other_disability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentsActivelyInvolvedStatus)
//                         .HasColumnName("students_actively_involved_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StudentsPresenceDuringMenstruation)
//                         .HasColumnName("students_presence_during_menstruation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficientToiletSpaceSeat)
//                         .HasColumnName("sufficient_toilet_space_seat")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SufficientWaterAvailabilityStatus)
//                         .HasColumnName("sufficient_water_availability_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TankSize)
//                         .HasColumnName("tank_size")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.TapForDrinking)
//                         .HasColumnName("tap_for_drinking")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TapForWashing)
//                         .HasColumnName("tap_for_washing")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeacherProvidedStatus)
//                         .HasColumnName("teacher_provided_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeacherWithOtherDisability)
//                         .HasColumnName("teacher_with_other_disability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToilets)
//                         .HasColumnName("teachers_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToiletsUnused)
//                         .HasColumnName("teachers_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToiletsUsed)
//                         .HasColumnName("teachers_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TeachersToiletsWithWater)
//                         .HasColumnName("teachers_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToBringWater)
//                         .HasColumnName("time_to_bring_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletPhoto1)
//                         .HasColumnName("toilet_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ToiletPhoto1Uuid)
//                         .HasColumnName("toilet_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletStudentsUse)
//                         .HasColumnName("toilet_students_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletsCmnts)
//                         .HasColumnName("toilets_cmnts")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletsObserved)
//                         .HasColumnName("toilets_observed")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToilets)
//                         .HasColumnName("total_toilets")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletsUnused)
//                         .HasColumnName("total_toilets_unused")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletsUsed)
//                         .HasColumnName("total_toilets_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletsWithWater)
//                         .HasColumnName("total_toilets_with_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalWaterPoints)
//                         .HasColumnName("total_water_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreasurerGender)
//                         .HasColumnName("treasurer_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UnusedFullyDamagedPoints)
//                         .HasColumnName("unused_fully_damaged_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalBathroomCmnts)
//                         .HasColumnName("urinal_bathroom_cmnts")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UrinalPhoto1)
//                         .HasColumnName("urinal_photo_1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UrinalPhoto1Uuid)
//                         .HasColumnName("urinal_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableCommunalHandWashingStation)
//                         .HasColumnName("usable_communal_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToiletWithHygiene)
//                         .HasColumnName("usable_female_toilet_with_hygiene")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToiletWithoutHygiene)
//                         .HasColumnName("usable_female_toilet_without_hygiene")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableHandWashingStationForDisabled)
//                         .HasColumnName("usable_hand_washing_station_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableSeparateBoyHandWashingStation)
//                         .HasColumnName("usable_separate_boy_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableSeparateGirlHandWashingStation)
//                         .HasColumnName("usable_separate_girl_hand_washing_station")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UsableToiletForDisabled)
//                         .HasColumnName("usable_toilet_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Original_Uuid)
//                         .HasColumnName("original_uuid")
//                         .HasMaxLength(256);
//                entity.Property(e => e.NewUuid)
//                         .HasColumnName("new_uuid")
//                         .HasMaxLength(256);

//                entity.Property(e => e.WashRepairChargeStatus)
//                         .HasColumnName("wash_repair_charge_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteDumpedStatus)
//                         .HasColumnName("waste_dumped_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteGlassStatus)
//                         .HasColumnName("waste_glass_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteRecycledStatus)
//                         .HasColumnName("waste_recycled_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPointPhoto1)
//                         .HasColumnName("water_point_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPointPhoto2)
//                         .HasColumnName("water_point_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WaterPointPhoto1Uuid)
//                         .HasColumnName("water_point_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPointPhoto2Uuid)
//                         .HasColumnName("water_point_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierAvailability)
//                         .HasColumnName("water_purifier_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierCondition)
//                         .HasColumnName("water_purifier_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityPerception)
//                         .HasColumnName("water_quality_perception")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTestResult)
//                         .HasColumnName("water_test_result")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTestedStatus)
//                         .HasColumnName("water_tested_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentStatus)
//                         .HasColumnName("water_treatment_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentType)
//                         .HasColumnName("water_treatment_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WellUsedPoints)
//                         .HasColumnName("well_used_points")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WorkingTapsForDisabled)
//                         .HasColumnName("working_taps_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SchoolCode)
//                         .HasColumnName("school_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherStudent)
//                         .HasColumnName("other_student")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherStaff)
//                         .HasColumnName("other_staff")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SeparateMaleUrinal)
//                         .HasColumnName("separate_male_urinal")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SeparateFemaleUrinal)
//                         .HasColumnName("separate_female_urinal")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.IsWqTested)
//                         .HasColumnName("is_wq_tested")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WqReportPhoto)
//                         .HasColumnName("wq_report_photo")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WqReportPhotoUuid)
//                         .HasColumnName("wq_report_photo_uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<TblUrbanSanitation>(entity =>
//            {
//                entity.ToTable("tbl_urban_sanitation", "urban_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AnnualSewerProblemsNum).HasColumnName("annual_sewer_problems_num");

//                entity.Property(e => e.AverageExpenditure).HasColumnName("average_expenditure");

//                entity.Property(e => e.BiogasExpectedPrice).HasColumnName("biogas_expected_price");

//                entity.Property(e => e.ClosestParkingPlaceDistance)
//                         .HasColumnName("closest_parking_place_distance")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommitteeFemaleNum).HasColumnName("committee_female_num");

//                entity.Property(e => e.CommitteeLeadingGender)
//                         .HasColumnName("committee_leading_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommitteeMaleNum).HasColumnName("committee_male_num");

//                entity.Property(e => e.CompostExpectedPrice).HasColumnName("compost_expected_price");

//                entity.Property(e => e.ContainmentDimension)
//                         .HasColumnName("containment_dimension")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentEmptiedProcess)
//                         .HasColumnName("containment_emptied_process")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentEmptiedReason)
//                         .HasColumnName("containment_emptied_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentEmptyingAccessibility)
//                         .HasColumnName("containment_emptying_accessibility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentLateralDistance)
//                         .HasColumnName("containment_lateral_distance")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentMaterial)
//                         .HasColumnName("containment_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentNotEmptiedReason)
//                         .HasColumnName("containment_not_emptied_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentSystemBuilt)
//                         .HasColumnName("containment_system_built")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentUnitConnection)
//                         .HasColumnName("containment_unit_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentUnitLastEmptied)
//                         .HasColumnName("containment_unit_last_emptied")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DifferentTypeToiletFacilities)
//                         .HasColumnName("different_type_toilet_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DifficultiesUsingToiletForDisabled)
//                         .HasColumnName("difficulties_using_toilet_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMemberStatus)
//                         .HasColumnName("disabled_member_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DryGroundWaterLevelDepth)
//                         .HasColumnName("dry_ground_water_level_depth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.ElevationDifference)
//                         .HasColumnName("elevation_difference")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmptiedSludgeUtilization)
//                         .HasColumnName("emptied_sludge_utilization")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingChargeCalculation)
//                         .HasColumnName("emptying_charge_calculation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingChargePerTrip)
//                         .HasColumnName("emptying_charge_per_trip")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingContainmentPeriod)
//                         .HasColumnName("emptying_containment_period")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingServiceProvider)
//                         .HasColumnName("emptying_service_provider")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingServiceSatisfaction)
//                         .HasColumnName("emptying_service_satisfaction")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EndProductUsagePerception)
//                         .HasColumnName("end_product_usage_perception")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ExpectedSupportForWwm)
//                         .HasColumnName("expected_support_for_wwm")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FaecalSludgeReusedStatus)
//                         .HasColumnName("faecal_sludge_reused_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FamilyHeadGender)
//                         .HasColumnName("family_head_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FamilyType)
//                         .HasColumnName("family_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlooringTypeAboveTank)
//                         .HasColumnName("flooring_type_above_tank")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmAwarenessStatus)
//                         .HasColumnName("fsm_awareness_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmLawsAwarenessStatus)
//                         .HasColumnName("fsm_laws_awareness_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmLawsKnown)
//                         .HasColumnName("fsm_laws_known")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmProgramParticipatingGender)
//                         .HasColumnName("fsm_program_participating_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FsmProgramParticipationStatus)
//                         .HasColumnName("fsm_program_participation_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GreyWaterConnection)
//                         .HasColumnName("grey_water_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhMenstrualWasteMgmt)
//                         .HasColumnName("hh_menstrual_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhOrganicSolidWasteMgmt)
//                         .HasColumnName("hh_organic_solid_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HhWasteSegregation)
//                         .HasColumnName("hh_waste_segregation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HouseNumber)
//                         .HasColumnName("house_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HousePurpose)
//                         .HasColumnName("house_purpose")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.HouseholdType)
//                         .HasColumnName("household_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LeftSludgePortionInFeet)
//                         .HasColumnName("left_sludge_portion_in_feet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LidAndCoverCondition)
//                         .HasColumnName("lid_and_cover_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LocalitySanitationCommittee)
//                         .HasColumnName("locality_sanitation_committee")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MajorDrinkingWaterSource)
//                         .HasColumnName("major_drinking_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManualEmptyingDisposal)
//                         .HasColumnName("manual_emptying_disposal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ManualEmptyingReason)
//                         .HasColumnName("manual_emptying_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MechanicalEmptyingCompletenessStatus)
//                         .HasColumnName("mechanical_emptying_completeness_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoToiletAlternative)
//                         .HasColumnName("no_toilet_alternative")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoToiletReason)
//                         .HasColumnName("no_toilet_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NominalTreatmentForRainwater)
//                         .HasColumnName("nominal_treatment_for_rainwater")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NumOfPeopleUsingToilet)
//                         .HasColumnName("num_of_people_using_toilet")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OnSiteTruckParking)
//                         .HasColumnName("on_site_truck_parking")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentEmptiedProcess)
//                         .HasColumnName("other_containment_emptied_process")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentEmptiedReason)
//                         .HasColumnName("other_containment_emptied_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentMaterial)
//                         .HasColumnName("other_containment_material")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentUnitConnection)
//                         .HasColumnName("other_containment_unit_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherDifficultiesUsingToiletForDisabled)
//                         .HasColumnName("other_difficulties_using_toilet_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherEmptyingChargeCalculation)
//                         .HasColumnName("other_emptying_charge_calculation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherEmptyingServiceProvider)
//                         .HasColumnName("other_emptying_service_provider")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherExpectedSupportForWwm)
//                         .HasColumnName("other_expected_support_for_wwm")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherFlooringTypeAboveTank)
//                         .HasColumnName("other_flooring_type_above_tank")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherGreyWaterConnection)
//                         .HasColumnName("other_grey_water_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherHhMenstrualWasteMgmt)
//                         .HasColumnName("other_hh_menstrual_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherHhOrganicSolidWasteMgmt)
//                         .HasColumnName("other_hh_organic_solid_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherHouseholdType)
//                         .HasColumnName("other_household_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherMajorDrinkingWaterSource)
//                         .HasColumnName("other_major_drinking_water_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherManualEmptyingDisposal)
//                         .HasColumnName("other_manual_emptying_disposal")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherManualEmptyingReason)
//                         .HasColumnName("other_manual_emptying_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherNoToiletAlternative)
//                         .HasColumnName("other_no_toilet_alternative")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherNoToiletReason)
//                         .HasColumnName("other_no_toilet_reason")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherRunoffWaterConnection)
//                         .HasColumnName("other_runoff_water_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherServiceImprovingWays)
//                         .HasColumnName("other_service_improving_ways")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherSolidWasteMgmt)
//                         .HasColumnName("other_solid_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherToiletConnection)
//                         .HasColumnName("other_toilet_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                         .HasColumnName("photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                         .HasColumnName("photo_2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3)
//                         .HasColumnName("photo_3")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4)
//                         .HasColumnName("photo_4")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Uuid)
//                         .HasColumnName("photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Uuid)
//                         .HasColumnName("photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Uuid)
//                         .HasColumnName("photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Uuid)
//                         .HasColumnName("photo_4_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PitDepth).HasColumnName("pit_depth");

//                entity.Property(e => e.PitDiameter).HasColumnName("pit_diameter");

//                entity.Property(e => e.PitKind)
//                         .HasColumnName("pit_kind")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PlaceForGroundwaterRecharge)
//                         .HasColumnName("place_for_groundwater_recharge")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProperSepticTankInvestment).HasColumnName("proper_septic_tank_investment");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainwaterCollectionContainerSize)
//                         .HasColumnName("rainwater_collection_container_size")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RainwaterCollectionStatus)
//                         .HasColumnName("rainwater_collection_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RespondentAge)
//                         .HasColumnName("respondent_age")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RespondentContactNo)
//                         .HasColumnName("respondent_contact_no")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RespondentGender)
//                         .HasColumnName("respondent_gender")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RespondentName)
//                         .HasColumnName("respondent_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RunoffWaterConnection)
//                         .HasColumnName("runoff_water_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SatisfiedWithEmptyingCost)
//                         .HasColumnName("satisfied_with_emptying_cost")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SeparateSystemForWwmStatus)
//                         .HasColumnName("separate_system_for_wwm_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SepticAndHoldingTankDifferenceKnown)
//                         .HasColumnName("septic_and_holding_tank_difference_known")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SepticTankCompartments)
//                         .HasColumnName("septic_tank_compartments")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ServiceImprovingWays)
//                         .HasColumnName("service_improving_ways")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SewerChokesOverflowStatus)
//                         .HasColumnName("sewer_chokes_overflow_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteMgmt)
//                         .HasColumnName("solid_waste_mgmt")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StreetName)
//                         .HasColumnName("street_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SuggestedEmptyingCost).HasColumnName("suggested_emptying_cost");

//                entity.Property(e => e.TankBreadth).HasColumnName("tank_breadth");

//                entity.Property(e => e.TankDepth).HasColumnName("tank_depth");

//                entity.Property(e => e.TankLength).HasColumnName("tank_length");

//                entity.Property(e => e.TankOrPitEmptyingAccessibility)
//                         .HasColumnName("tank_or_pit_emptying_accessibility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletConnection)
//                         .HasColumnName("toilet_connection")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletFacilities)
//                         .HasColumnName("toilet_facilities")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForDisabled)
//                         .HasColumnName("toilet_for_disabled")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ToiletSuperstructure)
//                         .HasColumnName("toilet_superstructure")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Tole)
//                         .HasColumnName("tole")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalFamilyMembers).HasColumnName("total_family_members");

//                entity.Property(e => e.TreatedWaterExpectedPrice).HasColumnName("treated_water_expected_price");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UnpavedLandForRainwater)
//                         .HasColumnName("unpaved_land_for_rainwater")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VisitDate)
//                         .HasColumnName("visit_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ward).HasColumnName("ward");

//                entity.Property(e => e.WasteCollectionChargePerMonth).HasColumnName("waste_collection_charge_per_month");

//                entity.Property(e => e.WasteCollectionPaymentStatus)
//                         .HasColumnName("waste_collection_payment_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WasteMgmtResponsibility)
//                         .HasColumnName("waste_mgmt_responsibility")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterConsumptionQuantity).HasColumnName("water_consumption_quantity");

//                entity.Property(e => e.WaterborneDiseases)
//                         .HasColumnName("waterborne_diseases")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterborneDiseasesStatus)
//                         .HasColumnName("waterborne_diseases_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WetGroundWaterLevelDepth)
//                         .HasColumnName("wet_ground_water_level_depth")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WillingTreatmentAdditionalCharge).HasColumnName("willing_treatment_additional_charge");
//            });

//            modelBuilder.Entity<ToiletConstructionCost>(entity =>
//            {
//                entity.ToTable("toilet_construction_cost", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Cost).HasColumnName("cost");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<ToiletWashPriority>(entity =>
//            {
//                entity.ToTable("toilet_wash_priority", "wash_plan");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('wash_plan.toilet_wash_plan_id_seq'::regclass)");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PlannedStatus)
//                         .HasColumnName("planned_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Topography>(entity =>
//            {
//                entity.ToTable("topography", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AreaHa).HasColumnName("area_ha");

//                entity.Property(e => e.Category)
//                         .HasColumnName("category")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<TubewellPrioritization>(entity =>
//            {
//                entity.ToTable("tubewell_prioritization", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityPc).HasColumnName("priority_pc");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");
//            });

//            modelBuilder.Entity<Tubewells>(entity =>
//            {
//                entity.ToTable("tubewells", "existing_projects");

//                entity.HasIndex(e => e.Uuid)
//                         .HasName("u_uuid")
//                         .IsUnique();

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Condition)
//                         .HasColumnName("condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConsYear).HasColumnName("cons_year");

//                entity.Property(e => e.DepthFt).HasColumnName("depth_ft");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FemalePop).HasColumnName("female_pop");

//                entity.Property(e => e.HhServed)
//                         .HasColumnName("hh_served")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OwnerName)
//                         .HasColumnName("owner_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                         .HasColumnName("photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                         .HasColumnName("photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Uuid)
//                         .HasColumnName("photo1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Uuid)
//                         .HasColumnName("photo2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PlatformCondition)
//                         .HasColumnName("platform_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PopServed)
//                         .HasColumnName("pop_served")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ProjectBeingConstructed).HasColumnName("project_being_constructed");

//                entity.Property(e => e.RecTime).HasColumnName("rec_time");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TubewellType)
//                         .HasColumnName("tubewell_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadTime).HasColumnName("upload_time");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.WardNo).HasColumnName("ward_no");

//                entity.Property(e => e.WsSchemePresent).HasColumnName("ws_scheme_present");
//            });

//            modelBuilder.Entity<TubewellsHistory>(entity =>
//            {
//                entity.ToTable("tubewells_history", "existing_projects_history");

//                entity.HasIndex(e => e.Uuid)
//                         .HasName("u_uuid")
//                         .IsUnique();

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.tubewells_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Condition)
//                         .HasColumnName("condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConsYear).HasColumnName("cons_year");

//                entity.Property(e => e.DepthFt).HasColumnName("depth_ft");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FemalePop).HasColumnName("female_pop");

//                entity.Property(e => e.HhServed)
//                         .HasColumnName("hh_served")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MalePop).HasColumnName("male_pop");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OwnerName)
//                         .HasColumnName("owner_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                         .HasColumnName("photo1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                         .HasColumnName("photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PlatformCondition)
//                         .HasColumnName("platform_condition")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PopServed)
//                         .HasColumnName("pop_served")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ProjectBeingConstructed).HasColumnName("project_being_constructed");

//                entity.Property(e => e.RecTime).HasColumnName("rec_time");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TubewellType)
//                         .HasColumnName("tubewell_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.UploadTime).HasColumnName("upload_time");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.WardNo).HasColumnName("ward_no");

//                entity.Property(e => e.WsSchemePresent).HasColumnName("ws_scheme_present");
//            });

//            modelBuilder.Entity<UnservedCommunity>(entity =>
//            {
//                entity.ToTable("unserved_community", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DalitHh)
//                         .HasColumnName("dalit_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.JanajatiHh)
//                         .HasColumnName("janajati_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MinorityHh)
//                         .HasColumnName("minority_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PresentSource)
//                         .HasColumnName("present_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToFetchWater)
//                         .HasColumnName("time_to_fetch_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalHh)
//                         .HasColumnName("total_hh")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentOfCollectedWater)
//                         .HasColumnName("treatment_of_collected_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WomenHeadedHh)
//                         .HasColumnName("women_headed_hh")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UnservedFiles>(entity =>
//            {
//                entity.ToTable("unserved_files", "unserved_population");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('unserved_population.tbl_files_id_seq'::regclass)");

//                entity.Property(e => e.Description)
//                         .HasColumnName("description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Filename)
//                         .HasColumnName("filename")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UnservedInitialDetails>(entity =>
//            {
//                entity.ToTable("unserved_initial_details", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AffectedByClimate)
//                         .HasColumnName("affected_by_climate")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");

//                entity.Property(e => e.BcHh)
//                         .HasColumnName("bc_hh")
//                         .HasComment("total hh");

//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DalitHh).HasColumnName("dalit_hh");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistanceFromCommunity)
//                         .HasColumnName("distance_from_community")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DroughtVulnerability)
//                         .HasColumnName("drought_vulnerability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.FloodVulnerability)
//                         .HasColumnName("flood_vulnerability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowMeasurement)
//                         .HasColumnName("flow_measurement")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowRegularity)
//                         .HasColumnName("flow_regularity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.JanajatiHh).HasColumnName("janajati_hh");

//                entity.Property(e => e.LandslideVulnerability)
//                         .HasColumnName("landslide_vulnerability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LiftRequired)
//                         .HasColumnName("lift_required")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");
//                entity.Property(e => e.CommunityLongitude).HasColumnName("community_longitude");
//                entity.Property(e => e.CommunityLatitude).HasColumnName("community_latitude");
//                entity.Property(e => e.CommunityElevation).HasColumnName("community_elevation");
//                entity.Property(e => e.CommunityTheGeom).HasColumnName("community_the_geom");
//                entity.Property(e => e.MadesiHh).HasColumnName("madesi_hh");

//                entity.Property(e => e.MinimumYield)
//                         .HasColumnName("minimum_yield")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ObcHh).HasColumnName("obc_hh");

//                entity.Property(e => e.PointDescription)
//                         .HasColumnName("point_description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PotentialPhoto1)
//                         .HasColumnName("potential_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PotentialPhoto2)
//                         .HasColumnName("potential_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.PotentialPhoto1Uuid)
//                         .HasColumnName("potential_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PotentialPhoto2Uuid)
//                         .HasColumnName("potential_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PresentSource)
//                         .HasColumnName("present_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PresentWaterUse)
//                         .HasColumnName("present_water_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.RoundTripTime)
//                         .HasColumnName("round_trip_time")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SettlementAboveSource)
//                         .HasColumnName("settlement_above_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceName)
//                         .HasColumnName("source_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceOwnership)
//                         .HasColumnName("source_ownership")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SystemType)
//                         .HasColumnName("system_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToFetchWater)
//                         .HasColumnName("time_to_fetch_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TotalHh)
//                         .HasColumnName("total_hh")
//                         .HasComment(@"bc hh
//(ordering error)");

//                entity.Property(e => e.TreatmentToCollectedWater)
//                         .HasColumnName("treatment_to_collected_water")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfSource)
//                         .HasColumnName("type_of_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                         .HasColumnName("unique_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UnservedPhoto1)
//                         .HasColumnName("unserved_photo_1")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UnservedPhoto2)
//                         .HasColumnName("unserved_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.UnservedPhoto1Uuid)
//                         .HasColumnName("unserved_photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UnservedPhoto2Uuid)
//                         .HasColumnName("unserved_photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VisitDate)
//                         .HasColumnName("visit_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ward)
//                         .HasColumnName("ward")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQuality)
//                         .HasColumnName("water_quality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WomenHeadedHh).HasColumnName("women_headed_hh");
//            });

//            modelBuilder.Entity<UnservedLut1>(entity =>
//            {
//                entity.ToTable("unserved_lut1", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.QbCols)
//         .HasColumnName("qb_cols")
//         .HasColumnType("character varying")
//         .HasMaxLength(10);
//                entity.Property(e => e.QbLabels)
//         .HasColumnName("qb_labels")
//         .HasColumnType("character varying")
//         .HasMaxLength(256);

//            });
//            modelBuilder.Entity<TblSources>(entity =>
//            {
//                entity.ToTable("tbl_sources", "sources");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AffectedByClimate)
//                         .HasColumnName("affected_by_climate")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//                entity.Property(e => e.CommunityName)
//                         .HasColumnName("community_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                         .HasColumnName("db_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DroughtVulnerability)
//                         .HasColumnName("drought_vulnerability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.FloodVulnerability)
//                         .HasColumnName("flood_vulnerability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowMeasurement)
//                         .HasColumnName("flow_measurement")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowRegularity)
//                         .HasColumnName("flow_regularity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LandslideVulnerability)
//                         .HasColumnName("landslide_vulnerability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PointDescription)
//                         .HasColumnName("point_description")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PresentWaterUse)
//                         .HasColumnName("present_water_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceName)
//                         .HasColumnName("source_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceOwnership)
//                         .HasColumnName("source_ownership")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TypeOfSource)
//                         .HasColumnName("type_of_source")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4)
//                         .HasColumnName("photo4")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                         .HasColumnName("photo1")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo3)
//                         .HasColumnName("photo3")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                         .HasColumnName("photo2")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                         .HasColumnName("upload_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VisitDate)
//                         .HasColumnName("visit_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ward)
//                         .HasColumnName("ward")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WaterQuality)
//                         .HasColumnName("water_quality")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AffectedByPopGrowthAndUrbanization).HasColumnName("affected_by_pop_growth_and_urbanization").HasColumnType("character varying"); ;
//            });
//            modelBuilder.Entity<SourcesLut>(entity =>
//            {
//                entity.ToTable("sources_lut", "sources");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UnservedNewSystem>(entity =>
//            {
//                entity.ToTable("unserved_new_system", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActualExpenditure)
//                         .HasColumnName("actual_expenditure")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CostFromDpr)
//                         .HasColumnName("cost_from_dpr")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DprReportPrepared)
//                         .HasColumnName("dpr_report_prepared")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IniUuid)
//                         .HasColumnName("ini_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewProjectName)
//                         .HasColumnName("new_project_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NewProjectType)
//                         .HasColumnName("new_project_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Population).HasColumnName("population");

//                entity.Property(e => e.ProjectExpTill2020Status)
//                         .HasColumnName("project_exp_till_2020_status")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UnservedOngoingSystem>(entity =>
//            {
//                entity.ToTable("unserved_ongoing_system", "unserved_population");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ActualExpenditure)
//                         .HasColumnName("actual_expenditure")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.ConstructionAgency)
//                         .HasColumnName("construction_agency")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SupportingAgency)
//                         .HasColumnName("supporting_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DprAvailability)
//                         .HasColumnName("dpr_availability")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IniUuid)
//                         .HasColumnName("ini_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Population).HasColumnName("population");

//                entity.Property(e => e.PopulationBenefitedByPrivateTap).HasColumnName("population_benefited_by_private_tap");

//                entity.Property(e => e.ProjectCostAsPerDpr)
//                         .HasColumnName("project_cost_as_per_dpr")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectExpTill2020Status)
//                         .HasColumnName("project_exp_till_2020_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectName)
//                         .HasColumnName("project_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectStartYear)
//                         .HasColumnName("project_start_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProjectType)
//                         .HasColumnName("project_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentPlantAvailability)
//                         .HasColumnName("treatment_plant_availability")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UnservedProjectInfo>(entity =>
//            {
//                entity.ToTable("unserved_project_info", "unserved_population");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('unserved_population.tbl_project_info_id_seq'::regclass)");

//                entity.Property(e => e.AddedBy)
//                         .HasColumnName("added_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddedDate)
//                         .HasColumnName("added_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                         .HasColumnName("district_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MuniCode)
//                         .HasColumnName("muni_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                         .HasColumnName("province_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Remarks)
//                         .HasColumnName("remarks")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UrbanSanitationLut1>(entity =>
//            {
//                entity.ToTable("urban_sanitation_lut1", "urban_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Index)
//                         .HasColumnName("index")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Label)
//                         .HasColumnName("label")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelDn)
//                         .HasColumnName("label_dn")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LabelText)
//                         .HasColumnName("label_text")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Scope)
//                         .HasColumnName("scope")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<UserDocumentation>(entity =>
//            {
//                entity.ToTable("user_documentation", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DocumentPath)
//                         .HasColumnName("document_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DocumentTitle)
//                         .HasColumnName("document_title")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                         .HasColumnName("uploaded_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                         .HasColumnName("uploaded_date")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<Users>(entity =>
//            {
//                entity.HasKey(e => e.UserId)
//                         .HasName("users_pk");

//                entity.ToTable("users", "system");

//                entity.HasIndex(e => e.Email)
//                         .HasName("unq_email")
//                         .IsUnique();

//                entity.Property(e => e.UserId)
//                         .HasColumnName("user_id")
//                         .HasDefaultValueSql("nextval('system.users_user_id_seq1'::regclass)");

//                entity.Property(e => e.AssignedArea)
//                         .HasColumnName("assigned_area")
//                         .HasColumnType("character varying")
//                         .HasComment(@"if
//UserCategory = 2 then LabUuid
//UserCategory = 3 then uuid of project details");

//                entity.Property(e => e.CreatedBy)
//                         .HasColumnName("created_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CreatedDate)
//                         .HasColumnName("created_date")
//                         .HasColumnType("date")
//                         .HasDefaultValueSql("'2073-12-14'::date");

//                entity.Property(e => e.District).HasColumnName("district");

//                entity.Property(e => e.Email)
//                         .HasColumnName("email")
//                         .HasMaxLength(500);

//                entity.Property(e => e.Groups)
//                         .HasColumnName("groups")
//                         .HasComment(@"0 - District Edit
//1 - Admin
//2 - District Admin
//3- ReadOnly
//4 - Project Edit
//5-Municipality Admin
//6-Municipality Edit
//7 - Province Admin
//8- Province Edit");

//                entity.Property(e => e.InvAgency)
//                         .HasColumnName("inv_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.LastLogin).HasColumnName("last_login");

//                entity.Property(e => e.Municipality).HasColumnName("municipality");

//                entity.Property(e => e.Name)
//                         .HasColumnName("name")
//                         .HasMaxLength(500);

//                entity.Property(e => e.Password)
//                         .HasColumnName("password")
//                         .HasMaxLength(500);

//                entity.Property(e => e.Province)
//                         .HasColumnName("province")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Salt)
//                         .HasColumnName("salt")
//                         .HasMaxLength(500);

//                entity.Property(e => e.Status).HasColumnName("status");

//                entity.Property(e => e.TrainingUser)
//                         .HasColumnName("training_user")
//                         .HasDefaultValueSql("0")
//                         .HasComment(@"1-training user
//0-active user");

//                entity.Property(e => e.UserCategory)
//                         .HasColumnName("user_category")
//                         .HasDefaultValueSql("1")
//                         .HasComment(@"1- Wash User
//2 - Lab User
//3 - WSUC User");

//                entity.Property(e => e.UserType)
//                         .HasColumnName("user_type")
//                         .HasMaxLength(500);
//            });

//            modelBuilder.Entity<UsersAccessDistrict>(entity =>
//            {
//                entity.ToTable("users_access_district", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.District).HasColumnName("district");

//                entity.Property(e => e.UserId).HasColumnName("user_id");
//            });

//            modelBuilder.Entity<UsersAccessProCode>(entity =>
//            {
//                entity.ToTable("users_access_pro_code", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.ProCode)
//                         .HasColumnName("pro_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UserId).HasColumnName("user_id");
//            });

//            modelBuilder.Entity<VmwDetails>(entity =>
//            {
//                entity.ToTable("vmw_details", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.VmwName)
//                         .HasColumnName("vmw_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwPhone)
//                         .HasColumnName("vmw_phone")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwSalary)
//                         .HasColumnName("vmw_salary")
//                         .HasMaxLength(500);

//                entity.Property(e => e.VmwToolsEng)
//                         .HasColumnName("vmw_tools_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwToolsNep)
//                         .HasColumnName("vmw_tools_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwTrainedEng)
//                         .HasColumnName("vmw_trained_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwTrainedNep)
//                         .HasColumnName("vmw_trained_nep")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<VmwPayment>(entity =>
//            {
//                entity.ToTable("vmw_payment", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.VmwPaymentImagePath)
//                         .HasColumnName("vmw_payment_image_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.VmwPaymentImagePathUuid)
//                         .HasColumnName("vmw_payment_image_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwPaymentStatusEng)
//                         .HasColumnName("vmw_payment_status_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.VmwPaymentStatusNep)
//                         .HasColumnName("vmw_payment_status_nep")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<Ward>(entity =>
//            {
//                entity.ToTable("ward", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.MunId).HasColumnName("mun_id");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.WardNo).HasColumnName("ward_no");
//            });

//            modelBuilder.Entity<WardLine>(entity =>
//            {
//                entity.ToTable("ward_line", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<WardwisePopulation>(entity =>
//            {
//                entity.ToTable("wardwise_population", "municipality_profile");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AreaHa).HasColumnName("area_ha");

//                entity.Property(e => e.CensusYear).HasColumnName("census_year");

//                entity.Property(e => e.Female).HasColumnName("female");

//                entity.Property(e => e.Household).HasColumnName("household");

//                entity.Property(e => e.Male).HasColumnName("male");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Other).HasColumnName("other");

//                entity.Property(e => e.Total).HasColumnName("total");

//                entity.Property(e => e.WardNo).HasColumnName("ward_no");
//                entity.Property(e => e.EditedBy)
//                     .HasColumnName("edited_by")
//                     .HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("date");
//            });

//            modelBuilder.Entity<WashAgency>(entity =>
//            {
//                entity.ToTable("wash_agency", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.AgencyAcitvity)
//                         .HasColumnName("agency_acitvity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AgencyName)
//                         .HasColumnName("agency_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AgencyUuid)
//                         .HasColumnName("agency_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FundingId).HasColumnName("funding_id");
//            });

//            modelBuilder.Entity<WashFunding>(entity =>
//            {
//                entity.ToTable("wash_funding", "system");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FundingAcitvity)
//                         .HasColumnName("funding_acitvity")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FundingName)
//                         .HasColumnName("funding_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FundingUuid)
//                         .HasColumnName("funding_uuid")
//                         .HasMaxLength(100);
//            });

//            modelBuilder.Entity<WashInPublicToilet>(entity =>
//            {
//                entity.ToTable("wash_in_public_toilet", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Amount)
//                         .HasColumnName("amount")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WaterQualitySample>(entity =>
//            {
//                entity.ToTable("water_quality_sample", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Completed)
//                         .HasColumnName("completed")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.DescPhoto1).HasColumnName("desc_photo1");

//                entity.Property(e => e.DescPhoto2).HasColumnName("desc_photo2");

//                entity.Property(e => e.DescPhoto3).HasColumnName("desc_photo3");

//                entity.Property(e => e.DescPhoto4).HasColumnName("desc_photo4");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.Geom).HasColumnName("geom");

//                entity.Property(e => e.InstrumentsUsed).HasColumnName("instruments_used");

//                entity.Property(e => e.LabTest).HasColumnName("lab_test");

//                entity.Property(e => e.LabUuid)
//                         .HasColumnName("lab_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.Photo1).HasColumnName("photo1");

//                entity.Property(e => e.Photo2).HasColumnName("photo2");

//                entity.Property(e => e.Photo3).HasColumnName("photo3");

//                entity.Property(e => e.Photo4).HasColumnName("photo4");

//                entity.Property(e => e.Photo1Uuid).HasColumnName("photo1_uuid");

//                entity.Property(e => e.Photo2Uuid).HasColumnName("photo2_uuid");

//                entity.Property(e => e.Photo3Uuid).HasColumnName("photo3_uuid");

//                entity.Property(e => e.Photo4Uuid).HasColumnName("photo4_uuid");

//                entity.Property(e => e.PointId).HasColumnName("point_id");

//                entity.Property(e => e.PointType).HasColumnName("point_type");

//                entity.Property(e => e.ProjectUuid).HasColumnName("project_uuid");

//                entity.Property(e => e.SampleCode).HasColumnName("sample_code");

//                entity.Property(e => e.SamplingTime)
//                         .HasColumnName("sampling_time")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.TestingTime)
//                         .HasColumnName("testing_time")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.UserId).HasColumnName("user_id");

//                entity.Property(e => e.Uuid).HasColumnName("uuid");
//            });

//            modelBuilder.Entity<WaterQualityTemplate>(entity =>
//            {
//                entity.ToTable("water_quality_template", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Category).HasColumnName("category");

//                entity.Property(e => e.DataType).HasColumnName("data_type");

//                entity.Property(e => e.LowerRange)
//                         .HasColumnName("lower_range")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.MethodUsed)
//                         .HasColumnName("method_used")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ParameterName).HasColumnName("parameter_name");

//                entity.Property(e => e.Range).HasColumnName("range");

//                entity.Property(e => e.Unit).HasColumnName("unit");

//                entity.Property(e => e.UpperRange)
//                         .HasColumnName("upper_range")
//                         .HasColumnType("numeric");
//            });

//            modelBuilder.Entity<WaterQualityValues>(entity =>
//            {
//                entity.ToTable("water_quality_values", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.LabTest).HasColumnName("lab_test");

//                entity.Property(e => e.ParameterId).HasColumnName("parameter_id");

//                entity.Property(e => e.SampleUuid).HasColumnName("sample_uuid");
//                entity.Property(e => e.MethodUsed).HasColumnName("method_used");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.Value)
//                         .HasColumnName("value")
//                         .HasComment(@"parameter id - 4
//0- Select
//1- Offensive
//2- Non Offensive

//----------------------------------

//parameter id - 29
//0- Select
//1- P
//2- A");
//            });

//            modelBuilder.Entity<WaterSource>(entity =>
//            {
//                entity.ToTable("water_source", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.CollectedBy).HasColumnName("collected_by");

//                entity.Property(e => e.CollectedOn)
//                         .HasColumnName("collected_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");
//                entity.Property(e => e.TubewellDepth).HasColumnName("tubewell_depth");
//                entity.Property(e => e.TrtConsYear).HasColumnName("trt_cons_year");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FlowReg)
//                         .HasColumnName("flow_reg")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IntType)
//                         .HasColumnName("int_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MeaDate)
//                         .HasColumnName("mea_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeaDis).HasColumnName("mea_dis");

//                entity.Property(e => e.MinYield).HasColumnName("min_yield");

//                entity.Property(e => e.NeaCmu)
//                         .HasColumnName("nea_cmu")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Desc)
//                         .HasColumnName("photo3_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Path)
//                         .HasColumnName("photo3_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3PathUuid)
//                         .HasColumnName("photo3_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RegYear).HasColumnName("reg_year");

//                entity.Property(e => e.RtipTime).HasColumnName("rtip_time");

//                entity.Property(e => e.SouCon)
//                         .HasColumnName("sou_con")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouDist).HasColumnName("sou_dist");

//                entity.Property(e => e.SouEqk)
//                         .HasColumnName("sou_eqk")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouLoc)
//                         .HasColumnName("sou_loc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouName)
//                         .HasColumnName("sou_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouPro)
//                         .HasColumnName("sou_pro")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouReg)
//                         .HasColumnName("sou_reg")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouRem)
//                         .HasColumnName("sou_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouType)
//                         .HasColumnName("sou_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouUse)
//                         .HasColumnName("sou_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StaEqk)
//                         .HasColumnName("sta_eqk")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TreReq)
//                         .HasColumnName("tre_req")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.WatQua)
//                         .HasColumnName("wat_qua")
//                         .HasColumnType("character varying");

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.WaterSource)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<WaterSourceCondition>(entity =>
//            {
//                entity.ToTable("water_source_condition", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.ConditionEng)
//                         .HasColumnName("condition_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ConditionNep)
//                         .HasColumnName("condition_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowConditionEng)
//                         .HasColumnName("flow_condition_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.FlowConditionNep)
//                         .HasColumnName("flow_condition_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SourceName)
//                         .HasColumnName("source_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WaterSourceHistory>(entity =>
//            {
//                entity.ToTable("water_source_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.water_source_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.Ele).HasColumnName("ele");

//                entity.Property(e => e.FlowReg)
//                         .HasColumnName("flow_reg")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.IntType)
//                         .HasColumnName("int_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MeaDate)
//                         .HasColumnName("mea_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeaDis).HasColumnName("mea_dis");

//                entity.Property(e => e.MinYield).HasColumnName("min_yield");

//                entity.Property(e => e.NeaCmu)
//                         .HasColumnName("nea_cmu")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Desc)
//                         .HasColumnName("photo3_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Path)
//                         .HasColumnName("photo3_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.RegYear).HasColumnName("reg_year");

//                entity.Property(e => e.RtipTime).HasColumnName("rtip_time");

//                entity.Property(e => e.SouCon)
//                         .HasColumnName("sou_con")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouDist).HasColumnName("sou_dist");

//                entity.Property(e => e.SouEqk)
//                         .HasColumnName("sou_eqk")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouLoc)
//                         .HasColumnName("sou_loc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouName)
//                         .HasColumnName("sou_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouPro)
//                         .HasColumnName("sou_pro")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouReg)
//                         .HasColumnName("sou_reg")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouRem)
//                         .HasColumnName("sou_rem")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouType)
//                         .HasColumnName("sou_type")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SouUse)
//                         .HasColumnName("sou_use")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.StaEqk)
//                         .HasColumnName("sta_eqk")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TreReq)
//                         .HasColumnName("tre_req")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.WatQua)
//                         .HasColumnName("wat_qua")
//                         .HasColumnType("character varying");

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.WaterSourceHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<WaterSourceMeasure>(entity =>
//            {
//                entity.ToTable("water_source_measure", "existing_projects");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MeaDate)
//                         .HasColumnName("mea_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeaDis).HasColumnName("mea_dis");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo1PathUuid)
//                         .HasColumnName("photo1_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.Photo2PathUuid)
//                         .HasColumnName("photo2_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SourceUuid)
//                         .HasColumnName("source_uuid")
//                         .HasMaxLength(100);

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.WaterSourceMeasure)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<WaterSourceMeasureHistory>(entity =>
//            {
//                entity.ToTable("water_source_measure_history", "existing_projects_history");

//                entity.Property(e => e.Id)
//                         .HasColumnName("id")
//                         .HasDefaultValueSql("nextval('existing_projects_history.water_source_measure_id_seq'::regclass)");

//                entity.Property(e => e.ActiveTime)
//                         .HasColumnName("active_time")
//                         .HasColumnType("tstzrange");

//                entity.Property(e => e.EditType)
//                         .HasColumnName("edit_type")
//                         .HasDefaultValueSql("0");

//                entity.Property(e => e.MeaDate)
//                         .HasColumnName("mea_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeaDis).HasColumnName("mea_dis");

//                entity.Property(e => e.Photo1Desc)
//                         .HasColumnName("photo1_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo1Path)
//                         .HasColumnName("photo1_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Desc)
//                         .HasColumnName("photo2_desc")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Path)
//                         .HasColumnName("photo2_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.SourceUuid)
//                         .HasColumnName("source_uuid")
//                         .HasMaxLength(100);

//                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

//                entity.HasOne(d => d.ProUu)
//                         .WithMany(p => p.WaterSourceMeasureHistory)
//                         .HasPrincipalKey(p => p.Uuid)
//                         .HasForeignKey(d => d.ProUuid)
//                         .HasConstraintName("pro_uuid");
//            });

//            modelBuilder.Entity<WatersafeCommunity>(entity =>
//            {
//                entity.ToTable("watersafe_community", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Lat).HasColumnName("lat");

//                entity.Property(e => e.Lon).HasColumnName("lon");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProName)
//                         .HasColumnName("pro_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
//            });

//            modelBuilder.Entity<WgData>(entity =>
//            {
//                entity.ToTable("wg_data", "wash_governance");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.BudgetFromFederal).HasColumnName("budget_from_federal");

//                entity.Property(e => e.BudgetFromIngo).HasColumnName("budget_from_ingo");

//                entity.Property(e => e.BudgetFromProvince).HasColumnName("budget_from_province");

//                entity.Property(e => e.BudgetInHcf).HasColumnName("budget_in_hcf");

//                entity.Property(e => e.BudgetInHh).HasColumnName("budget_in_hh");

//                entity.Property(e => e.BudgetInHygiene).HasColumnName("budget_in_hygiene");

//                entity.Property(e => e.BudgetInSanitation).HasColumnName("budget_in_sanitation");

//                entity.Property(e => e.BudgetInSchool).HasColumnName("budget_in_school");

//                entity.Property(e => e.BudgetInWaterSupply).HasColumnName("budget_in_water_supply");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.EmergencyResponsePlanAvailable)
//                         .HasColumnName("emergency_response_plan_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmergencyResponsePlanFname)
//                         .HasColumnName("emergency_response_plan_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EmergencyResponsePlanPath)
//                         .HasColumnName("emergency_response_plan_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.EnteredBy)
//                         .HasColumnName("entered_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ExpenseInHcf).HasColumnName("expense_in_hcf");

//                entity.Property(e => e.ExpenseInHh).HasColumnName("expense_in_hh");

//                entity.Property(e => e.ExpenseInHygiene).HasColumnName("expense_in_hygiene");

//                entity.Property(e => e.ExpenseInSanitation).HasColumnName("expense_in_sanitation");

//                entity.Property(e => e.ExpenseInSchool).HasColumnName("expense_in_school");

//                entity.Property(e => e.ExpenseInWaterSupply).HasColumnName("expense_in_water_supply");

//                entity.Property(e => e.MisDataForDecisionMaking)
//                         .HasColumnName("mis_data_for_decision_making")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisFocalPersonAvailable)
//                         .HasColumnName("mis_focal_person_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisFocalPersonContact)
//                         .HasColumnName("mis_focal_person_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisFocalPersonName)
//                         .HasColumnName("mis_focal_person_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MisUpdatedThisYear)
//                         .HasColumnName("mis_updated_this_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NoOfVmwTraining).HasColumnName("no_of_vmw_training");

//                entity.Property(e => e.NoOfWashActivityOrganized).HasColumnName("no_of_wash_activity_organized");

//                entity.Property(e => e.SupportAgency)
//                         .HasColumnName("support_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SurveyDate)
//                         .HasColumnName("survey_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SurveyYear).HasColumnName("survey_year");

//                entity.Property(e => e.TotalBudgetInWash).HasColumnName("total_budget_in_wash");

//                entity.Property(e => e.TotalExpenseInWash).HasColumnName("total_expense_in_wash");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashFocalPersonAvailable)
//                         .HasColumnName("wash_focal_person_available")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashFocalPersonContact)
//                         .HasColumnName("wash_focal_person_contact")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashFocalPersonName)
//                         .HasColumnName("wash_focal_person_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyDrinkingWaterRegulationFname)
//                         .HasColumnName("wash_policy_drinking_water_regulation_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyDrinkingWaterRegulationPath)
//                         .HasColumnName("wash_policy_drinking_water_regulation_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyGuidelineToiletConstructionFname)
//                         .HasColumnName("wash_policy_guideline_toilet_construction_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyGuidelineToiletConstructionPath)
//                         .HasColumnName("wash_policy_guideline_toilet_construction_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyOdfGuidelineFname)
//                         .HasColumnName("wash_policy_odf_guideline_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyOdfGuidelinePath)
//                         .HasColumnName("wash_policy_odf_guideline_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyOtherFname)
//                         .HasColumnName("wash_policy_other_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyOtherPath)
//                         .HasColumnName("wash_policy_other_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicySchoolGuidelineFname)
//                         .HasColumnName("wash_policy_school_guideline_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicySchoolGuidelineOthersFname)
//                         .HasColumnName("wash_policy_school_guideline_others_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicySchoolGuidelineOthersPath)
//                         .HasColumnName("wash_policy_school_guideline_others_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicySchoolGuidelinePath)
//                         .HasColumnName("wash_policy_school_guideline_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWashActFname)
//                         .HasColumnName("wash_policy_wash_act_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWashActPath)
//                         .HasColumnName("wash_policy_wash_act_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWashGuidelineFname)
//                         .HasColumnName("wash_policy_wash_guideline_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWashGuidelinePath)
//                         .HasColumnName("wash_policy_wash_guideline_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWaterSafeAuditFname)
//                         .HasColumnName("wash_policy_water_safe_audit_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWaterSafeAuditPath)
//                         .HasColumnName("wash_policy_water_safe_audit_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWaterSafeGuidelineFname)
//                         .HasColumnName("wash_policy_water_safe_guideline_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWaterSafeGuidelinePath)
//                         .HasColumnName("wash_policy_water_safe_guideline_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWqTestGuidelineFname)
//                         .HasColumnName("wash_policy_wq_test_guideline_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashPolicyWqTestGuidelinePath)
//                         .HasColumnName("wash_policy_wq_test_guideline_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashTrainingInstitute)
//                         .HasColumnName("wash_training_institute")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashUnitMun)
//                         .HasColumnName("wash_unit_mun")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpFormulationThisYear)
//                         .HasColumnName("wp_formulation_this_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpImplementation)
//                         .HasColumnName("wp_implementation")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpPoliciyHcfGuidelineFname)
//                         .HasColumnName("wp_policiy_hcf_guideline_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpPoliciyHcfGuidelineOthersFname)
//                         .HasColumnName("wp_policiy_hcf_guideline_others_fname")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpPoliciyHcfGuidelineOthersPath)
//                         .HasColumnName("wp_policiy_hcf_guideline_others_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WpPoliciyHcfGuidelinePath)
//                         .HasColumnName("wp_policiy_hcf_guideline_path")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WqTestingFacility)
//                         .HasColumnName("wq_testing_facility")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WqTempMethodUsed>(entity =>
//            {
//                entity.ToTable("wq_temp_method_used", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Options)
//                         .HasColumnName("options")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WqTempId)
//                         .HasColumnName("wq_temp_id");
//            });

//            modelBuilder.Entity<WpProgressStatus>(entity =>
//            {
//                entity.ToTable("wp_progress_status", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DataCollAgency)
//                         .HasColumnName("data_coll_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataCollStatus)
//                         .HasColumnName("data_coll_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.DataUpdatedBy)
//                         .HasColumnName("data_updated_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MunicipalityApproval)
//                         .HasColumnName("municipality_approval")
//                         .HasColumnType("character varying")
//                         .HasDefaultValueSql("'Unverified'::character varying");

//                entity.Property(e => e.PrioritizationStatus)
//                         .HasColumnName("prioritization_status")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdatedBy)
//                         .HasColumnName("updated_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.UpdatedDate)
//                         .HasColumnName("updated_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashplanAgency)
//                         .HasColumnName("washplan_agency")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WashplanStatus)
//                         .HasColumnName("washplan_status")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WqGeneralLocation>(entity =>
//            {
//                entity.ToTable("wq_general_location", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.DescPhoto1).HasColumnName("desc_photo1");

//                entity.Property(e => e.DescPhoto2).HasColumnName("desc_photo2");

//                entity.Property(e => e.DescPhoto3).HasColumnName("desc_photo3");

//                entity.Property(e => e.DescPhoto4).HasColumnName("desc_photo4");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.IdentityId).HasColumnName("identity_id");

//                entity.Property(e => e.InstrumentsUsed).HasColumnName("instruments_used");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MunCode).HasColumnName("mun_code");

//                entity.Property(e => e.Photo1).HasColumnName("photo1");
//                entity.Property(e => e.Photo2).HasColumnName("photo2");
//                entity.Property(e => e.Photo3).HasColumnName("photo3");
//                entity.Property(e => e.Photo4).HasColumnName("photo4");
//                entity.Property(e => e.Photo1Uuid).HasColumnName("photo1_uuid");
//                entity.Property(e => e.Photo2Uuid).HasColumnName("photo2_uuid");
//                entity.Property(e => e.Photo3Uuid).HasColumnName("photo3_uuid");
//                entity.Property(e => e.Photo4Uuid).HasColumnName("photo4_uuid");

//                entity.Property(e => e.PointType).HasColumnName("point_type");

//                entity.Property(e => e.SamplingTime)
//                         .HasColumnName("sampling_time")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.TestingTime)
//                         .HasColumnName("testing_time")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.UserId).HasColumnName("user_id");

//                entity.Property(e => e.Uuid).HasColumnName("uuid");

//                entity.Property(e => e.WqCode).HasColumnName("wq_code");
//            });

//            modelBuilder.Entity<WqGeneralValues>(entity =>
//            {
//                entity.ToTable("wq_general_values", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.LocationUuid).HasColumnName("location_uuid");

//                entity.Property(e => e.ParameterId).HasColumnName("parameter_id");

//                entity.Property(e => e.Value).HasColumnName("value");
//            });

//            modelBuilder.Entity<WqIdentity>(entity =>
//            {
//                entity.ToTable("wq_identity", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.OrgUuid).HasColumnName("org_uuid");

//                entity.Property(e => e.ProjectName).HasColumnName("project_name");

//                entity.Property(e => e.Uuid).HasColumnName("uuid");
//            });

//            modelBuilder.Entity<Wq_SurveillanceampleDetails>(entity =>
//            {
//                entity.ToTable("wq_sample_details", "water_quality");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AnalysisDate)
//                         .HasColumnName("analysis_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AnalyzedBy)
//                         .HasColumnName("analyzed_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AnalyzedDate)
//                         .HasColumnName("analyzed_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ApprovedBy)
//                         .HasColumnName("approved_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ApprovedDate)
//                         .HasColumnName("approved_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ClientName)
//                         .HasColumnName("client_name")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.CompletionDate)
//                         .HasColumnName("completion_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Dyear).HasColumnName("dyear");

//                entity.Property(e => e.EnteredBy)
//                         .HasColumnName("entered_by")
//                         .HasColumnType("character varying")
//                         .HasComment("Sample result entered by");

//                entity.Property(e => e.Gps)
//                         .HasColumnName("gps")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ReportDate)
//                         .HasColumnName("report_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SampleCollectionDate)
//                         .HasColumnName("sample_collection_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SampleLocation)
//                         .HasColumnName("sample_location")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SampleUuid)
//                         .HasColumnName("sample_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SampledBy)
//                         .HasColumnName("sampled_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SampledByLabUuid)
//                         .HasColumnName("sampled_by_lab_uuid")
//                         .HasColumnType("character varying")
//                         .HasComment("lab uuid");

//                entity.Property(e => e.SamplingPoint)
//                         .HasColumnName("sampling_point")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Status).HasColumnName("status");
//            });

//            modelBuilder.Entity<WqView>(entity =>
//            {
//                entity.HasNoKey();

//                entity.ToTable("wq_view", "water_quality");

//                entity.Property(e => e.Geom).HasColumnName("geom");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.LowerRange)
//                         .HasColumnName("lower_range")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.ParameterId).HasColumnName("parameter_id");

//                entity.Property(e => e.ParameterName).HasColumnName("parameter_name");

//                entity.Property(e => e.Pvalues)
//                         .HasColumnName("pvalues")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.SamplingTime)
//                         .HasColumnName("sampling_time")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.UpperRange)
//                         .HasColumnName("upper_range")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Uuid).HasColumnName("uuid");
//            });

//            modelBuilder.Entity<WsReferenceCost>(entity =>
//            {
//                entity.ToTable("ws_reference_cost", "wash_plan_reference");

//                entity.HasComment("Reference Data row 502 (EXCEL FILE)");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Cost)
//                         .HasColumnName("cost")
//                         .HasColumnType("numeric");

//                entity.Property(e => e.Items)
//                         .HasColumnName("items")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WsTreatmentRef>(entity =>
//            {
//                entity.ToTable("ws_treatment_ref", "wash_plan_reference");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.TreamentItem)
//                         .HasColumnName("treament_item")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentCost).HasColumnName("treatment_cost");

//                entity.Property(e => e.TreatmentType)
//                         .HasColumnName("treatment_type")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WssNewPriority>(entity =>
//            {
//                entity.ToTable("wss_new_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WssOngoingPriority>(entity =>
//            {
//                entity.ToTable("wss_ongoing_priority", "wash_plan");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.MunCode)
//                         .HasColumnName("mun_code")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Priority)
//                         .HasColumnName("priority")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PriorityYear).HasColumnName("priority_year");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WuaAccountKeeping>(entity =>
//            {
//                entity.ToTable("wua_account_keeping", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.AccTypeEng)
//                         .HasColumnName("acc_type_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AccTypeNep)
//                         .HasColumnName("acc_type_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaAgm>(entity =>
//            {
//                entity.ToTable("wua_agm", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.AgmImagePath)
//                         .HasColumnName("agm_image_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AgmImagePathUuid)
//                         .HasColumnName("agm_image_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeetingDate)
//                         .HasColumnName("meeting_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeetingDateAd)
//                         .HasColumnName("meeting_date_ad")
//                         .HasColumnType("date");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaAudit>(entity =>
//            {
//                entity.ToTable("wua_audit", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AuditImagePath)
//                         .HasColumnName("audit_image_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AuditImagePathUuid)
//                         .HasColumnName("audit_image_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AuditStatusEng)
//                         .HasColumnName("audit_status_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AuditStatusNep)
//                         .HasColumnName("audit_status_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaBank>(entity =>
//            {
//                entity.ToTable("wua_bank", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.BankNameEng)
//                         .HasColumnName("bank_name_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BankNameNep)
//                         .HasColumnName("bank_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BankStatusEng)
//                         .HasColumnName("bank_status_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.BankStatusNep)
//                         .HasColumnName("bank_status_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaDetails>(entity =>
//            {
//                entity.ToTable("wua_details", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.WuaAddress)
//                         .HasColumnName("wua_address")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WuaDate)
//                         .HasColumnName("wua_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WuaEmail)
//                         .HasColumnName("wua_email")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WuaNameEng)
//                         .HasColumnName("wua_name_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WuaNameNep)
//                         .HasColumnName("wua_name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.WuaPhone)
//                         .HasColumnName("wua_phone")
//                         .HasColumnType("character varying");
//            });

//            modelBuilder.Entity<WuaIncomeExp>(entity =>
//            {
//                entity.ToTable("wua_income_exp", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.Expenditure)
//                         .HasColumnName("expenditure")
//                         .HasMaxLength(128);

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.OtherDonation)
//                         .HasColumnName("other_donation")
//                         .HasMaxLength(128);

//                entity.Property(e => e.OtherIncome)
//                         .HasColumnName("other_income")
//                         .HasMaxLength(128);

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);

//                entity.Property(e => e.WaterTariff)
//                         .HasColumnName("water_tariff")
//                         .HasMaxLength(500);
//            });

//            modelBuilder.Entity<WuaInsurance>(entity =>
//            {
//                entity.ToTable("wua_insurance", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InsuranceImagePath)
//                         .HasColumnName("insurance_image_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.InsuranceImagePathUuid)
//                         .HasColumnName("insurance_image_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InsuranceStatusEng)
//                         .HasColumnName("insurance_status_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.InsuranceStatusNep)
//                         .HasColumnName("insurance_status_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaMeeting>(entity =>
//            {
//                entity.ToTable("wua_meeting", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeetingDate)
//                         .HasColumnName("meeting_date")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeetingDateAd)
//                         .HasColumnName("meeting_date_ad")
//                         .HasColumnType("date");

//                entity.Property(e => e.MeetingImagePath)
//                         .HasColumnName("meeting_image_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.MeetingImagePathUuid)
//                         .HasColumnName("meeting_image_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.MeetingSubject)
//                         .HasColumnName("meeting_subject")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaSop>(entity =>
//            {
//                entity.ToTable("wua_sop", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");
//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SopImagePath)
//                         .HasColumnName("sop_image_path")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SopImagePathUuid)
//                         .HasColumnName("sop_image_path_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SopStatusEng)
//                         .HasColumnName("sop_status_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.SopStatusNep)
//                         .HasColumnName("sop_status_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });

//            modelBuilder.Entity<WuaStructure>(entity =>
//            {
//                entity.ToTable("wua_structure", "sustainability");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedBy).HasColumnName("edited_by").HasColumnType("character varying");

//                entity.Property(e => e.EditedOn)
//                         .HasColumnName("edited_on")
//                         .HasColumnType("timestamp with time zone");

//                entity.Property(e => e.AddBy)
//                         .HasColumnName("add_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AddDate)
//                         .HasColumnName("add_date")
//                         .HasColumnType("date");

//                entity.Property(e => e.ContactNumber)
//                         .HasColumnName("contact_number")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.DataYear).HasColumnName("data_year");

//                entity.Property(e => e.FiscalYear)
//                         .HasColumnName("fiscal_year")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GenderEng)
//                         .HasColumnName("gender_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.GenderNep)
//                         .HasColumnName("gender_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NameEng)
//                         .HasColumnName("name_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.NameNep)
//                         .HasColumnName("name_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PostEng)
//                         .HasColumnName("post_eng")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PostNep)
//                         .HasColumnName("post_nep")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.ProUuid)
//                         .HasColumnName("pro_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Sno).HasColumnName("sno");

//                entity.Property(e => e.Uuid)
//                         .HasColumnName("uuid")
//                         .HasMaxLength(128);
//            });
//            modelBuilder.Entity<TblHcfOld>(entity =>
//            {
//                entity.ToTable("tbl_hcf_old", "health_care");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.UsableCommunalToilet).HasColumnName("usable_communal_toilet");
//                entity.Property(e => e.UsableFemaleToiletWithoutMhm).HasColumnName("usable_female_toilet_without_mhm");
//                entity.Property(e => e.UnusedMinorRepairNeededToilet).HasColumnName("unused_minor_repair_needed_toilet");
//                entity.Property(e => e.UnusedMajorRepairNeededToilet).HasColumnName("unused_major_repair_needed_toilet");
//                entity.Property(e => e.EditedDate)
//                     .HasColumnName("edited_date")
//                     .HasColumnType("date");
//                entity.Property(e => e.SanitationTrainingStatus)
//                         .HasColumnName("sanitation_training_status")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.WaterAvailabilityDuringSurvey)
//                         .HasColumnName("water_availability_during_survey")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherWasteDisposed)
//                         .HasColumnName("other_waste_disposed")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.SharpWasteMgmtAndTreatment)
//                         .HasColumnName("sharp_waste_mgmt_and_treatment")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.OtherSharpWasteMgmtAndTreatment)
//                         .HasColumnName("other_sharp_waste_mgmt_and_treatment")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy)
//                         .HasColumnName("collected_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AcuteContagiousWasteSeparation)
//                    .HasColumnName("acute_contagious_waste_separation")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1)
//                       .HasColumnName("additional_photo_1")
//                       .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2)
//                         .HasColumnName("additional_photo_2")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3)
//                         .HasColumnName("additional_photo_3")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4)
//                         .HasColumnName("additional_photo_4")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                       .HasColumnName("additional_photo_1_uuid")
//                       .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                         .HasColumnName("additional_photo_2_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                         .HasColumnName("additional_photo_3_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto4Uuid)
//                         .HasColumnName("additional_photo_4_uuid")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AlcoholBasedRubAvailability)
//                    .HasColumnName("alcohol_based_rub_availability")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.AgencyName)
//                         .HasColumnName("agency_name")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AlternativeWaterSource)
//                    .HasColumnName("alternative_water_source")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AlternativeWaterSourceLastingPeriod)
//                    .HasColumnName("alternative_water_source_lasting_period")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                    .HasColumnName("app_version")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.BirthingCenterStatus)
//                    .HasColumnName("birthing_center_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ChildrenAdequateSoap)
//                    .HasColumnName("children_adequate_soap")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ChildrenEasyAccess)
//                    .HasColumnName("children_easy_access")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContactName)
//                    .HasColumnName("contact_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContactNumber)
//                    .HasColumnName("contact_number")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                    .HasColumnName("date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Dbname)
//                    .HasColumnName("dbname")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DeliveryRoomCleanStatus)
//                    .HasColumnName("delivery_room_clean_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DeliveryRoomStatus)
//                    .HasColumnName("delivery_room_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DisabledAccessWater)
//                    .HasColumnName("disabled_access_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFriendlyWorkingTaps)
//                    .HasColumnName("disabled_friendly_working_taps")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                    .HasColumnName("district_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterAccessibleStatus)
//                    .HasColumnName("drinking_water_accessible_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterStationStatus)
//                    .HasColumnName("drinking_water_station_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DrinkingWaterTank)
//                    .HasColumnName("drinking_water_tank")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DustbinInFemaleToilet)
//                    .HasColumnName("dustbin_in_female_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DustbinNumber)
//                    .HasColumnName("dustbin_number")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DustbinOther)
//                    .HasColumnName("dustbin_other")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DustbinWithLidInFemaleToilet)
//                    .HasColumnName("dustbin_with_lid_in_female_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DustbinsLabelled)
//                    .HasColumnName("dustbins_labelled")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.EnvironmentalSanitationProtocol)
//                    .HasColumnName("environmental_sanitation_protocol")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EnvironmentalSanitationStaff)
//                    .HasColumnName("environmental_sanitation_staff")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FecalContamination)
//                    .HasColumnName("fecal_contamination")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FemalePatient)
//                    .HasColumnName("female_patient")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FemaleStaff)
//                    .HasColumnName("female_staff")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationCondition)
//                    .HasColumnName("hand_washing_station_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationConditionInDr)
//                    .HasColumnName("hand_washing_station_condition_in_dr")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationConditionInOpd)
//                    .HasColumnName("hand_washing_station_condition_in_opd")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationInDr)
//                    .HasColumnName("hand_washing_station_in_dr")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationInOpd)
//                    .HasColumnName("hand_washing_station_in_opd")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingStationNearToilet)
//                    .HasColumnName("hand_washing_station_near_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HazardousWasteIncineratorCondition)
//                    .HasColumnName("hazardous_waste_incinerator_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfDrinkingWaterInsideStatus)
//                    .HasColumnName("hcf_drinking_water_inside_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfDrinkingWaterStatus)
//                    .HasColumnName("hcf_drinking_water_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfSourceOfWater)
//                    .HasColumnName("hcf_source_of_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfSourceOfWaterStatus)
//                    .HasColumnName("hcf_source_of_water_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfSourceOfWaterStatusPlan)
//                    .HasColumnName("hcf_source_of_water_status_plan")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfToilstatus)
//                    .HasColumnName("hcf_toilstatus")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfType)
//                    .HasColumnName("hcf_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfTypeOther)
//                    .HasColumnName("hcf_type_other")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HcfWaterSufficientStatus)
//                    .HasColumnName("hcf_water_sufficient_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HealthCareKind)
//                    .HasColumnName("health_care_kind")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorAvailabilityForMhm)
//                    .HasColumnName("incinerator_availability_for_mhm")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorCondition)
//                    .HasColumnName("incinerator_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.IncineratorForHazardousWaste)
//                    .HasColumnName("incinerator_for_hazardous_waste")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.KeyRespondent)
//                    .HasColumnName("key_respondent")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MajorHandwashingRepair)
//                    .HasColumnName("major_handwashing_repair")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MajorTapsRepair)
//                    .HasColumnName("major_taps_repair")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MajorToiletRepair)
//                    .HasColumnName("major_toilet_repair")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MalePatient)
//                    .HasColumnName("male_patient")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MaleStaff)
//                    .HasColumnName("male_staff")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MinorHandwashingRepair)
//                    .HasColumnName("minor_handwashing_repair")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MinorTapsRepair)
//                    .HasColumnName("minor_taps_repair")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MinorToiletRepair)
//                    .HasColumnName("minor_toilet_repair")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                    .HasColumnName("muni_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NameOfCommunity)
//                    .HasColumnName("name_of_community")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NameOfHcf)
//                    .HasColumnName("name_of_hcf")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoOfPatientsDaily)
//                    .HasColumnName("no_of_patients_daily")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoOfUrinal)
//                    .HasColumnName("no_of_urinal")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OrganisationComitteeStatus)
//                    .HasColumnName("organisation_comittee_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OrganisationComitteeWork)
//                    .HasColumnName("organisation_comittee_work")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OwnBuilding)
//                    .HasColumnName("own_building")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoDustbin1)
//                    .HasColumnName("photo_dustbin_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet1)
//                    .HasColumnName("photo_female_toilet_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet2)
//                    .HasColumnName("photo_female_toilet_2")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToiletDustbin1)
//                    .HasColumnName("photo_female_toilet_dustbin_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationOpd1)
//                    .HasColumnName("photo_hand_washing_station_opd_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationToilet1)
//                    .HasColumnName("photo_hand_washing_station_toilet_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf1)
//                    .HasColumnName("photo_hcf1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf2)
//                    .HasColumnName("photo_hcf2")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf3)
//                    .HasColumnName("photo_hcf3")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu1)
//                    .HasColumnName("photo_toilet_mdu_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu2)
//                    .HasColumnName("photo_toilet_mdu_2")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletRamp1)
//                    .HasColumnName("photo_toilet_ramp_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterStation1)
//                    .HasColumnName("photo_water_station_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterTank1)
//                    .HasColumnName("photo_water_tank_1")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.PhotoDustbin1Uuid)
//                    .HasColumnName("photo_dustbin_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet1Uuid)
//                    .HasColumnName("photo_female_toilet_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToilet2Uuid)
//                    .HasColumnName("photo_female_toilet_2_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoFemaleToiletDustbin1Uuid)
//                    .HasColumnName("photo_female_toilet_dustbin_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationOpd1Uuid)
//                    .HasColumnName("photo_hand_washing_station_opd_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHandWashingStationToilet1Uuid)
//                    .HasColumnName("photo_hand_washing_station_toilet_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf1Uuid)
//                    .HasColumnName("photo_hcf1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf2Uuid)
//                    .HasColumnName("photo_hcf2_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoHcf3Uuid)
//                    .HasColumnName("photo_hcf3_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu1Uuid)
//                    .HasColumnName("photo_toilet_mdu_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletMdu2Uuid)
//                    .HasColumnName("photo_toilet_mdu_2_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoToiletRamp1Uuid)
//                    .HasColumnName("photo_toilet_ramp_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterStation1Uuid)
//                    .HasColumnName("photo_water_station_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PhotoWaterTank1Uuid)
//                    .HasColumnName("photo_water_tank_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PriorityChemicalContamination)
//                    .HasColumnName("priority_chemical_contamination")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                    .HasColumnName("province_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RampOutsideToilet)
//                    .HasColumnName("ramp_outside_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ReasonForNoToilet)
//                    .HasColumnName("reason_for_no_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededHandwashing)
//                    .HasColumnName("reconstruction_needed_handwashing")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededTaps)
//                    .HasColumnName("reconstruction_needed_taps")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ReconstructionNeededToilet)
//                    .HasColumnName("reconstruction_needed_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ResuableMedicalInstrumentsCleaned)
//                    .HasColumnName("resuable_medical_instruments_cleaned")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SalnalCondition)
//                    .HasColumnName("salnal_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SalnalCovered)
//                    .HasColumnName("salnal_covered")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SalnalStatus)
//                    .HasColumnName("salnal_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SalnalType)
//                    .HasColumnName("salnal_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SalnalVentilator)
//                    .HasColumnName("salnal_ventilator")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SeparateFemaleToilet)
//                    .HasColumnName("separate_female_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SoapWaterInHandwashingStation)
//                    .HasColumnName("soap_water_in_handwashing_station")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.StatusOfToilet)
//                    .HasColumnName("status_of_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SufficientSpaceInToilet)
//                    .HasColumnName("sufficient_space_in_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TankSize)
//                    .HasColumnName("tank_size")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToBringWater)
//                    .HasColumnName("time_to_bring_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleanSchedule)
//                    .HasColumnName("toilet_clean_schedule")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAll)
//                    .HasColumnName("toilet_for_all")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAllUnused)
//                    .HasColumnName("toilet_for_all_unused")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAllUsed)
//                    .HasColumnName("toilet_for_all_used")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForAllWithWater)
//                    .HasColumnName("toilet_for_all_with_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatient)
//                    .HasColumnName("toilet_for_patient")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatientUnused)
//                    .HasColumnName("toilet_for_patient_unused")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatientUsed)
//                    .HasColumnName("toilet_for_patient_used")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForPatientWithWater)
//                    .HasColumnName("toilet_for_patient_with_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaff)
//                    .HasColumnName("toilet_for_staff")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaffUnused)
//                    .HasColumnName("toilet_for_staff_unused")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaffUsed)
//                    .HasColumnName("toilet_for_staff_used")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForStaffWithWater)
//                    .HasColumnName("toilet_for_staff_with_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletHygiene)
//                    .HasColumnName("toilet_hygiene")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletInDr)
//                    .HasColumnName("toilet_in_dr")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletLockSystem)
//                    .HasColumnName("toilet_lock_system")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletSecurity)
//                    .HasColumnName("toilet_security")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TotalToilet)
//                    .HasColumnName("total_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletUnused)
//                    .HasColumnName("total_toilet_unused")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletUsed)
//                    .HasColumnName("total_toilet_used")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TotalToiletWithWater)
//                    .HasColumnName("total_toilet_with_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfDustbins)
//                    .HasColumnName("type_of_dustbins")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfLatrine)
//                    .HasColumnName("type_of_latrine")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfLatrineOther)
//                    .HasColumnName("type_of_latrine_other")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                    .HasColumnName("unique_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                    .HasColumnName("upload_date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                    .HasColumnName("uploaded_by")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UrinalStatus)
//                    .HasColumnName("urinal_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsableDisabledFriendlyToilet)
//                    .HasColumnName("usable_disabled_friendly_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToilet)
//                    .HasColumnName("usable_female_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsableFemaleToiletWithMhm)
//                    .HasColumnName("usable_female_toilet_with_mhm")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsableHandwashingStation)
//                    .HasColumnName("usable_handwashing_station")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsableMaleToilet)
//                    .HasColumnName("usable_male_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsableStaffToilet)
//                    .HasColumnName("usable_staff_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NewUuid)
//                    .HasColumnName("new_uuid")
//                    .HasMaxLength(256);

//                entity.Property(e => e.OriginalUuid)
//                    .HasColumnName("original_uuid")
//                    .HasMaxLength(256);

//                entity.Property(e => e.WardNumber)
//                    .HasColumnName("ward_number")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WasteDisposed)
//                    .HasColumnName("waste_disposed")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WasteNirmulikaran)
//                    .HasColumnName("waste_nirmulikaran")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterInsufficient)
//                    .HasColumnName("water_insufficient")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterManaged)
//                    .HasColumnName("water_managed")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierAvailability)
//                    .HasColumnName("water_purifier_availability")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurifierCondition)
//                    .HasColumnName("water_purifier_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityTestedResult)
//                    .HasColumnName("water_quality_tested_result")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterQualityTestedStatus)
//                    .HasColumnName("water_quality_tested_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterSafeToDrink)
//                    .HasColumnName("water_safe_to_drink")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterStorageTank)
//                    .HasColumnName("water_storage_tank")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankCoveredStatus)
//                    .HasColumnName("water_tank_covered_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentStatus)
//                    .HasColumnName("water_treatment_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentType)
//                    .HasColumnName("water_treatment_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterTreatmentTypeOther)
//                    .HasColumnName("water_treatment_type_other")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WhoCleansLatrineHp)
//                    .HasColumnName("who_cleans_latrine_hp")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WorkingTaps)
//                    .HasColumnName("working_taps")
//                    .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<PublicToiletOld>(entity =>
//            {
//                entity.ToTable("public_toilet_old", "public_toilet");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedDate)
//                     .HasColumnName("edited_date")
//                     .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.CollectedBy)
//                         .HasColumnName("collected_by")
//                         .HasColumnType("character varying");
//                entity.Property(e => e.AgencyName)
//                    .HasColumnName("agency_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                    .HasColumnName("app_version")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AvailableFund)
//                    .HasColumnName("available_fund")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContactNumber)
//                    .HasColumnName("contact_number")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DailyCollection)
//                    .HasColumnName("daily_collection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                    .HasColumnName("date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Dbname)
//                    .HasColumnName("dbname")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DisableAccessible)
//                    .HasColumnName("disable_accessible")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                    .HasColumnName("district_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DustbinFacility)
//                    .HasColumnName("dustbin_facility")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.AdditionalPhoto1Uuid)
//                    .HasColumnName("additional_photo_1_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AdditionalPhoto2Uuid)
//                    .HasColumnName("additional_photo_2_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AdditionalPhoto3Uuid)
//                    .HasColumnName("additional_photo_3_uuid")
//                    .HasColumnType("character varying");


//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.FemaleToilet)
//                    .HasColumnName("female_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FundCollection)
//                    .HasColumnName("fund_collection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingBasin)
//                    .HasColumnName("hand_washing_basin")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingFacilitySections)
//                    .HasColumnName("hand_washing_facility_sections")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingPlaceAccess)
//                    .HasColumnName("hand_washing_place_access")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HaveToPayToUse)
//                    .HasColumnName("have_to_pay_to_use")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Image1)
//                    .HasColumnName("image1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Image2)
//                    .HasColumnName("image2")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Image3)
//                    .HasColumnName("image3")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.Image1Uuid)
//                   .HasColumnName("image1_uuid")
//                   .HasColumnType("character varying");

//                entity.Property(e => e.Image2Uuid)
//                    .HasColumnName("image2_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Image3Uuid)
//                    .HasColumnName("image3_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LockSystem)
//                    .HasColumnName("lock_system")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MaleToilet)
//                    .HasColumnName("male_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MaterialCost)
//                    .HasColumnName("material_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                    .HasColumnName("muni_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Name)
//                    .HasColumnName("name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoOfPublicToilet)
//                    .HasColumnName("no_of_public_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoOfUsers)
//                    .HasColumnName("no_of_users")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoOfUsersAccessAtATime)
//                    .HasColumnName("no_of_users_access_at_a_time")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Odour)
//                    .HasColumnName("odour")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OperatorCost)
//                    .HasColumnName("operator_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PadAvailability)
//                    .HasColumnName("pad_availability")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                    .HasColumnName("province_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ProvisionOfToiletForChildren)
//                    .HasColumnName("provision_of_toilet_for_children")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ProvisionOfToiletForDisabled)
//                    .HasColumnName("provision_of_toilet_for_disabled")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletCondition)
//                    .HasColumnName("public_toilet_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletInUse)
//                    .HasColumnName("public_toilet_in_use")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletNotInUseReason)
//                    .HasColumnName("public_toilet_not_in_use_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PublicToiletState)
//                    .HasColumnName("public_toilet_state")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RepairCost)
//                    .HasColumnName("repair_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RunningPt)
//                    .HasColumnName("running_pt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RunningPtOther)
//                    .HasColumnName("running_pt_other")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SeparateLatrine)
//                    .HasColumnName("separate_latrine")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ShopRunning)
//                    .HasColumnName("shop_running")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SoapAvailableInBasin)
//                    .HasColumnName("soap_available_in_basin")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SpaceForShop)
//                    .HasColumnName("space_for_shop")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SufficientWaterSupply)
//                    .HasColumnName("sufficient_water_supply")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletChildFriendly)
//                    .HasColumnName("toilet_child_friendly")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConnection)
//                    .HasColumnName("toilet_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletLocated)
//                    .HasColumnName("toilet_located")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletLocatedOther)
//                    .HasColumnName("toilet_located_other")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletName)
//                    .HasColumnName("toilet_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUseAmount)
//                    .HasColumnName("toilet_use_amount")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUseAmountForUrination)
//                    .HasColumnName("toilet_use_amount_for_urination")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToleName)
//                    .HasColumnName("tole_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentFacility)
//                    .HasColumnName("treatment_facility")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TypeOfFacility)
//                    .HasColumnName("type_of_facility")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                    .HasColumnName("unique_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                    .HasColumnName("upload_date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                    .HasColumnName("uploaded_by")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Urinal)
//                    .HasColumnName("urinal")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UrinalFemale)
//                    .HasColumnName("urinal_female")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UrinalMale)
//                    .HasColumnName("urinal_male")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NewUuid)
//                    .HasColumnName("new_uuid")
//                    .HasMaxLength(128);

//                entity.Property(e => e.OriginalUuid)
//                    .HasColumnName("original_uuid")
//                    .HasMaxLength(128);

//                entity.Property(e => e.Ventilated)
//                    .HasColumnName("ventilated")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WardNumber)
//                    .HasColumnName("ward_number")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterFacilityAvailable)
//                    .HasColumnName("water_facility_available")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankAvailability)
//                    .HasColumnName("water_tank_availability")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterTankSufficiency)
//                    .HasColumnName("water_tank_sufficiency")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WithoutHandWashingFacilitySections)
//                    .HasColumnName("without_hand_washing_facility_sections")
//                    .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<TblHouseholdOld>(entity =>
//            {
//                entity.ToTable("tbl_household_old", "household");

//                entity.Property(e => e.Id).HasColumnName("id");
//                entity.Property(e => e.EditedOn)
//                     .HasColumnName("edited_on")
//                     .HasColumnType("date");
//                entity.Property(e => e.EditedBy)
//                         .HasColumnName("edited_by")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.AccessibilityOfWater)
//                    .HasColumnName("accessibility_of_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AgencyName)
//                    .HasColumnName("agency_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AppVersion)
//                    .HasColumnName("app_version")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.AvailabilityOfSoapWater)
//                    .HasColumnName("availability_of_soap_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.BoyBelow5Num)
//                    .HasColumnName("boy_below_5_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.CleaningFacilities)
//                    .HasColumnName("cleaning_facilities")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContactNo)
//                    .HasColumnName("contact_no")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.CoverForPit)
//                    .HasColumnName("cover_for_pit")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Date)
//                    .HasColumnName("date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                    .HasColumnName("db_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Defecation)
//                    .HasColumnName("defecation")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DisabledFriendlyToilet)
//                    .HasColumnName("disabled_friendly_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMemberNum)
//                    .HasColumnName("disabled_member_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DishWasteWaterDest)
//                    .HasColumnName("dish_waste_water_dest")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                    .HasColumnName("district_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DryDishesInSunStatus)
//                    .HasColumnName("dry_dishes_in_sun_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DryDishesPlace)
//                    .HasColumnName("dry_dishes_place")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.FaecalSludgeTreatment)
//                    .HasColumnName("faecal_sludge_treatment")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FaecalWasteTransportation)
//                    .HasColumnName("faecal_waste_transportation")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FamHeadContactNo)
//                    .HasColumnName("fam_head_contact_no")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FamHeadEthnicity)
//                    .HasColumnName("fam_head_ethnicity")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FamHeadName)
//                    .HasColumnName("fam_head_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FamNo)
//                    .HasColumnName("fam_no")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FemaleBelow18Num)
//                    .HasColumnName("female_below_18_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FemaleFamHeadStatus)
//                    .HasColumnName("female_fam_head_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FemaleNum)
//                    .HasColumnName("female_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FemaleUsingToiletDuringPeriodStatus)
//                    .HasColumnName("female_using_toilet_during_period_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FixedDishWashStation)
//                    .HasColumnName("fixed_dish_wash_station")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FullTankPeriod)
//                    .HasColumnName("full_tank_period")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.GirlBelow5Num)
//                    .HasColumnName("girl_below_5_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingFacilities)
//                    .HasColumnName("hand_washing_facilities")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HandWashingTimeWithSoap)
//                    .HasColumnName("hand_washing_time_with_soap")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HouseCleanlinessObserved)
//                    .HasColumnName("house_cleanliness_observed")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HouseCleanlinessStatus)
//                    .HasColumnName("house_cleanliness_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HouseholdsUsingTubewell)
//                    .HasColumnName("households_using_tubewell")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.InformerAge)
//                    .HasColumnName("informer_age")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.InformerEthnicity)
//                    .HasColumnName("informer_ethnicity")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.InformerGender)
//                    .HasColumnName("informer_gender")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.InformerName)
//                    .HasColumnName("informer_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.LandFieldDistanceFromCommunity)
//                    .HasColumnName("land_field_distance_from_community")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.LandFieldLocation)
//                    .HasColumnName("land_field_location")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LatrineFloorType)
//                    .HasColumnName("latrine_floor_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MainFamIncomeSource)
//                    .HasColumnName("main_fam_income_source")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MaleBelow18Num)
//                    .HasColumnName("male_below_18_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MaleNum)
//                    .HasColumnName("male_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                    .HasColumnName("muni_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NumUsingToilet)
//                    .HasColumnName("num_using_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherIncomeSource)
//                    .HasColumnName("other_income_source")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherNum)
//                    .HasColumnName("other_num")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherWaterPurificationMethod)
//                    .HasColumnName("other_water_purification_method")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                    .HasColumnName("photo_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                    .HasColumnName("photo_2")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo3)
//                    .HasColumnName("photo_3")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo4)
//                    .HasColumnName("photo_4")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo5)
//                    .HasColumnName("photo_5")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo6)
//                    .HasColumnName("photo_6")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.Photo1Uuid)
//                         .HasColumnName("photo_1_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo2Uuid)
//                         .HasColumnName("photo_2_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo3Uuid)
//                         .HasColumnName("photo_3_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo4Uuid)
//                         .HasColumnName("photo_4_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo5Uuid)
//                         .HasColumnName("photo_5_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.Photo6Uuid)
//                         .HasColumnName("photo_6_uuid")
//                         .HasColumnType("character varying");

//                entity.Property(e => e.PitLeakageStatus)
//                    .HasColumnName("pit_leakage_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PitLineStatus)
//                    .HasColumnName("pit_line_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PopulationUsingTubewell)
//                    .HasColumnName("population_using_tubewell")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PresenceOfWaterInToilet)
//                    .HasColumnName("presence_of_water_in_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PrivateToilet)
//                    .HasColumnName("private_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ProvinceCode)
//                    .HasColumnName("province_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PublicSpaceForSludgeTreatment)
//                    .HasColumnName("public_space_for_sludge_treatment")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RecyclableNonrecyclableSeparation)
//                    .HasColumnName("recyclable_nonrecyclable_separation")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SeparateWasteMgmt)
//                    .HasColumnName("separate_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ServiceSatisfaction)
//                    .HasColumnName("service_satisfaction")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SoapHandWashingFacilities)
//                    .HasColumnName("soap_hand_washing_facilities")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SoapInHandWashingStation)
//                    .HasColumnName("soap_in_hand_washing_station")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteTransportCost)
//                    .HasColumnName("solid_waste_transport_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteTransportFacility)
//                    .HasColumnName("solid_waste_transport_facility")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteTransporter)
//                    .HasColumnName("solid_waste_transporter")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SourceOfWater)
//                    .HasColumnName("source_of_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SpaceForPitConstruction)
//                    .HasColumnName("space_for_pit_construction")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TankCleaner)
//                    .HasColumnName("tank_cleaner")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TankCleaningCost)
//                    .HasColumnName("tank_cleaning_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.TimeToBringWater)
//                    .HasColumnName("time_to_bring_water")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletAvailability)
//                    .HasColumnName("toilet_availability")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletCleanlinessObserved)
//                    .HasColumnName("toilet_cleanliness_observed")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConnection)
//                    .HasColumnName("toilet_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConstructionCost)
//                    .HasColumnName("toilet_construction_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletConstructionYrMnth)
//                    .HasColumnName("toilet_construction_yr_mnth")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletGasPipeUsed)
//                    .HasColumnName("toilet_gas_pipe_used")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletPitCleaner)
//                    .HasColumnName("toilet_pit_cleaner")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletRenovationStatus)
//                    .HasColumnName("toilet_renovation_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletRenovationType)
//                    .HasColumnName("toilet_renovation_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletRoofMaterial)
//                    .HasColumnName("toilet_roof_material")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletSuperstructureType)
//                    .HasColumnName("toilet_superstructure_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletType)
//                    .HasColumnName("toilet_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletTypeUsed)
//                    .HasColumnName("toilet_type_used")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUsedByNeighbours)
//                    .HasColumnName("toilet_used_by_neighbours")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletUsedStatus)
//                    .HasColumnName("toilet_used_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletWallMaterial)
//                    .HasColumnName("toilet_wall_material")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TreatmentLandArea)
//                    .HasColumnName("treatment_land_area")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellArsenicContamination)
//                    .HasColumnName("tubewell_arsenic_contamination")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellArsenicTest)
//                    .HasColumnName("tubewell_arsenic_test")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellArsenicTestStatus)
//                    .HasColumnName("tubewell_arsenic_test_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellClothesStained)
//                    .HasColumnName("tubewell_clothes_stained")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellCondition)
//                    .HasColumnName("tubewell_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellConstructedYear)
//                    .HasColumnName("tubewell_constructed_year")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellConstructionCost)
//                    .HasColumnName("tubewell_construction_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellDepth)
//                    .HasColumnName("tubewell_depth")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellFecalContamination)
//                    .HasColumnName("tubewell_fecal_contamination")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPhoto)
//                    .HasColumnName("tubewell_photo")
//                    .HasColumnType("character varying");
//                entity.Property(e => e.TubewellPhotoUuid)
//                    .HasColumnName("tubewell_photo_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPipeSysProjectStatus)
//                    .HasColumnName("tubewell_pipe_sys_project_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellPlatform)
//                    .HasColumnName("tubewell_platform")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellTreatmentSystem)
//                    .HasColumnName("tubewell_treatment_system")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellType)
//                    .HasColumnName("tubewell_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterAdequacy)
//                    .HasColumnName("tubewell_water_adequacy")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterColor)
//                    .HasColumnName("tubewell_water_color")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterEffectOnTeeth)
//                    .HasColumnName("tubewell_water_effect_on_teeth")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterSmell)
//                    .HasColumnName("tubewell_water_smell")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterTaste)
//                    .HasColumnName("tubewell_water_taste")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TubewellWaterTurbidity)
//                    .HasColumnName("tubewell_water_turbidity")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UniqueCode)
//                    .HasColumnName("unique_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadDate)
//                    .HasColumnName("upload_date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                    .HasColumnName("uploaded_by")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UsedWaterDrinkablePerception)
//                    .HasColumnName("used_water_drinkable_perception")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NewUuid)
//                    .HasColumnName("new_uuid")
//                    .HasMaxLength(256);

//                entity.Property(e => e.OriginalUuid)
//                    .HasColumnName("original_uuid")
//                    .HasMaxLength(256);

//                entity.Property(e => e.Village)
//                    .HasColumnName("village")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WardNo)
//                    .HasColumnName("ward_no")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WasteTransportPeriod)
//                    .HasColumnName("waste_transport_period")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Water12mnthsAvailability)
//                    .HasColumnName("water_12mnths_availability")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterInHandWashingStation)
//                    .HasColumnName("water_in_hand_washing_station")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurificationDone)
//                    .HasColumnName("water_purification_done")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterPurificationMethod)
//                    .HasColumnName("water_purification_method")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterSourceDistanceFromPit)
//                    .HasColumnName("water_source_distance_from_pit")
//                    .HasColumnType("character varying");
//            });
//            modelBuilder.Entity<TblUrbanSanitationOld>(entity =>
//            {
//                entity.ToTable("tbl_urban_sanitation_old", "urban_sanitation");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.AnnualSewerProblemsNum).HasColumnName("annual_sewer_problems_num");

//                entity.Property(e => e.AverageExpenditure).HasColumnName("average_expenditure");

//                entity.Property(e => e.BiogasExpectedPrice).HasColumnName("biogas_expected_price");

//                entity.Property(e => e.ClosestParkingPlaceDistance)
//                    .HasColumnName("closest_parking_place_distance")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.CommitteeFemaleNum).HasColumnName("committee_female_num");

//                entity.Property(e => e.CommitteeLeadingGender)
//                    .HasColumnName("committee_leading_gender")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.CommitteeMaleNum).HasColumnName("committee_male_num");

//                entity.Property(e => e.CompostExpectedPrice).HasColumnName("compost_expected_price");

//                entity.Property(e => e.ContainmentDimension)
//                    .HasColumnName("containment_dimension")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentEmptiedProcess)
//                    .HasColumnName("containment_emptied_process")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentEmptiedReason)
//                    .HasColumnName("containment_emptied_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentEmptyingAccessibility)
//                    .HasColumnName("containment_emptying_accessibility")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentLateralDistance)
//                    .HasColumnName("containment_lateral_distance")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentMaterial)
//                    .HasColumnName("containment_material")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentNotEmptiedReason)
//                    .HasColumnName("containment_not_emptied_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentSystemBuilt)
//                    .HasColumnName("containment_system_built")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentUnitConnection)
//                    .HasColumnName("containment_unit_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ContainmentUnitLastEmptied)
//                    .HasColumnName("containment_unit_last_emptied")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DbName)
//                    .HasColumnName("db_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DifferentTypeToiletFacilities)
//                    .HasColumnName("different_type_toilet_facilities")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DifficultiesUsingToiletForDisabled)
//                    .HasColumnName("difficulties_using_toilet_for_disabled")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DisabledMemberStatus)
//                    .HasColumnName("disabled_member_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DistrictCode)
//                    .HasColumnName("district_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.DryGroundWaterLevelDepth)
//                    .HasColumnName("dry_ground_water_level_depth")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Elevation).HasColumnName("elevation");

//                entity.Property(e => e.ElevationDifference)
//                    .HasColumnName("elevation_difference")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EmptiedSludgeUtilization)
//                    .HasColumnName("emptied_sludge_utilization")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingChargeCalculation)
//                    .HasColumnName("emptying_charge_calculation")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingChargePerTrip)
//                    .HasColumnName("emptying_charge_per_trip")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingContainmentPeriod)
//                    .HasColumnName("emptying_containment_period")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingServiceProvider)
//                    .HasColumnName("emptying_service_provider")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EmptyingServiceSatisfaction)
//                    .HasColumnName("emptying_service_satisfaction")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.EndProductUsagePerception)
//                    .HasColumnName("end_product_usage_perception")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ExpectedSupportForWwm)
//                    .HasColumnName("expected_support_for_wwm")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FaecalSludgeReusedStatus)
//                    .HasColumnName("faecal_sludge_reused_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FamilyHeadGender)
//                    .HasColumnName("family_head_gender")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FamilyType)
//                    .HasColumnName("family_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FlooringTypeAboveTank)
//                    .HasColumnName("flooring_type_above_tank")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FsmAwarenessStatus)
//                    .HasColumnName("fsm_awareness_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FsmLawsAwarenessStatus)
//                    .HasColumnName("fsm_laws_awareness_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FsmLawsKnown)
//                    .HasColumnName("fsm_laws_known")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FsmProgramParticipatingGender)
//                    .HasColumnName("fsm_program_participating_gender")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.FsmProgramParticipationStatus)
//                    .HasColumnName("fsm_program_participation_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.GreyWaterConnection)
//                    .HasColumnName("grey_water_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HhMenstrualWasteMgmt)
//                    .HasColumnName("hh_menstrual_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HhOrganicSolidWasteMgmt)
//                    .HasColumnName("hh_organic_solid_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HhWasteSegregation)
//                    .HasColumnName("hh_waste_segregation")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HouseNumber)
//                    .HasColumnName("house_number")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HousePurpose)
//                    .HasColumnName("house_purpose")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.HouseholdType)
//                    .HasColumnName("household_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Latitude).HasColumnName("latitude");

//                entity.Property(e => e.LeftSludgePortionInFeet)
//                    .HasColumnName("left_sludge_portion_in_feet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.LidAndCoverCondition)
//                    .HasColumnName("lid_and_cover_condition")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.LocalitySanitationCommittee)
//                    .HasColumnName("locality_sanitation_committee")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Longitude).HasColumnName("longitude");

//                entity.Property(e => e.MajorDrinkingWaterSource)
//                    .HasColumnName("major_drinking_water_source")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ManualEmptyingDisposal)
//                    .HasColumnName("manual_emptying_disposal")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ManualEmptyingReason)
//                    .HasColumnName("manual_emptying_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MechanicalEmptyingCompletenessStatus)
//                    .HasColumnName("mechanical_emptying_completeness_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.MuniCode)
//                    .HasColumnName("muni_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoToiletAlternative)
//                    .HasColumnName("no_toilet_alternative")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NoToiletReason)
//                    .HasColumnName("no_toilet_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NominalTreatmentForRainwater)
//                    .HasColumnName("nominal_treatment_for_rainwater")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NumOfPeopleUsingToilet)
//                    .HasColumnName("num_of_people_using_toilet")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OnSiteTruckParking)
//                    .HasColumnName("on_site_truck_parking")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentEmptiedProcess)
//                    .HasColumnName("other_containment_emptied_process")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentEmptiedReason)
//                    .HasColumnName("other_containment_emptied_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentMaterial)
//                    .HasColumnName("other_containment_material")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherContainmentUnitConnection)
//                    .HasColumnName("other_containment_unit_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherDifficultiesUsingToiletForDisabled)
//                    .HasColumnName("other_difficulties_using_toilet_for_disabled")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherEmptyingChargeCalculation)
//                    .HasColumnName("other_emptying_charge_calculation")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherEmptyingServiceProvider)
//                    .HasColumnName("other_emptying_service_provider")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherExpectedSupportForWwm)
//                    .HasColumnName("other_expected_support_for_wwm")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherFlooringTypeAboveTank)
//                    .HasColumnName("other_flooring_type_above_tank")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherGreyWaterConnection)
//                    .HasColumnName("other_grey_water_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherHhMenstrualWasteMgmt)
//                    .HasColumnName("other_hh_menstrual_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherHhOrganicSolidWasteMgmt)
//                    .HasColumnName("other_hh_organic_solid_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherHouseholdType)
//                    .HasColumnName("other_household_type")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherMajorDrinkingWaterSource)
//                    .HasColumnName("other_major_drinking_water_source")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherManualEmptyingDisposal)
//                    .HasColumnName("other_manual_emptying_disposal")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherManualEmptyingReason)
//                    .HasColumnName("other_manual_emptying_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherNoToiletAlternative)
//                    .HasColumnName("other_no_toilet_alternative")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherNoToiletReason)
//                    .HasColumnName("other_no_toilet_reason")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherRunoffWaterConnection)
//                    .HasColumnName("other_runoff_water_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherServiceImprovingWays)
//                    .HasColumnName("other_service_improving_ways")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherSolidWasteMgmt)
//                    .HasColumnName("other_solid_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OtherToiletConnection)
//                    .HasColumnName("other_toilet_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo1)
//                    .HasColumnName("photo_1")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo2)
//                    .HasColumnName("photo_2")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo3)
//                    .HasColumnName("photo_3")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Photo4)
//                    .HasColumnName("photo_4")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PitDepth).HasColumnName("pit_depth");

//                entity.Property(e => e.PitDiameter).HasColumnName("pit_diameter");

//                entity.Property(e => e.PitKind)
//                    .HasColumnName("pit_kind")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.PlaceForGroundwaterRecharge)
//                    .HasColumnName("place_for_groundwater_recharge")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ProperSepticTankInvestment).HasColumnName("proper_septic_tank_investment");

//                entity.Property(e => e.ProvinceCode)
//                    .HasColumnName("province_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RainwaterCollectionContainerSize)
//                    .HasColumnName("rainwater_collection_container_size")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RainwaterCollectionStatus)
//                    .HasColumnName("rainwater_collection_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RespondentAge)
//                    .HasColumnName("respondent_age")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RespondentContactNo)
//                    .HasColumnName("respondent_contact_no")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RespondentGender)
//                    .HasColumnName("respondent_gender")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RespondentName)
//                    .HasColumnName("respondent_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.RunoffWaterConnection)
//                    .HasColumnName("runoff_water_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SatisfiedWithEmptyingCost)
//                    .HasColumnName("satisfied_with_emptying_cost")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SeparateSystemForWwmStatus)
//                    .HasColumnName("separate_system_for_wwm_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SepticAndHoldingTankDifferenceKnown)
//                    .HasColumnName("septic_and_holding_tank_difference_known")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SepticTankCompartments)
//                    .HasColumnName("septic_tank_compartments")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ServiceImprovingWays)
//                    .HasColumnName("service_improving_ways")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SewerChokesOverflowStatus)
//                    .HasColumnName("sewer_chokes_overflow_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SolidWasteMgmt)
//                    .HasColumnName("solid_waste_mgmt")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.StreetName)
//                    .HasColumnName("street_name")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.SuggestedEmptyingCost).HasColumnName("suggested_emptying_cost");

//                entity.Property(e => e.TankBreadth).HasColumnName("tank_breadth");

//                entity.Property(e => e.TankDepth).HasColumnName("tank_depth");

//                entity.Property(e => e.TankLength).HasColumnName("tank_length");

//                entity.Property(e => e.TankOrPitEmptyingAccessibility)
//                    .HasColumnName("tank_or_pit_emptying_accessibility")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

//                entity.Property(e => e.ToiletConnection)
//                    .HasColumnName("toilet_connection")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletFacilities)
//                    .HasColumnName("toilet_facilities")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletForDisabled)
//                    .HasColumnName("toilet_for_disabled")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.ToiletSuperstructure)
//                    .HasColumnName("toilet_superstructure")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Tole)
//                    .HasColumnName("tole")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.TotalFamilyMembers).HasColumnName("total_family_members");

//                entity.Property(e => e.TreatedWaterExpectedPrice).HasColumnName("treated_water_expected_price");

//                entity.Property(e => e.UniqueCode)
//                    .HasColumnName("unique_code")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UnpavedLandForRainwater)
//                    .HasColumnName("unpaved_land_for_rainwater")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadedBy)
//                    .HasColumnName("uploaded_by")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.UploadedDate)
//                    .HasColumnName("uploaded_date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Username)
//                    .HasColumnName("username")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.NewUuid)
//                    .HasColumnName("new_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.OriginalUuid)
//                    .HasColumnName("original_uuid")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.VisitDate)
//                    .HasColumnName("visit_date")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.Ward).HasColumnName("ward");

//                entity.Property(e => e.WasteCollectionChargePerMonth).HasColumnName("waste_collection_charge_per_month");

//                entity.Property(e => e.WasteCollectionPaymentStatus)
//                    .HasColumnName("waste_collection_payment_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WasteMgmtResponsibility)
//                    .HasColumnName("waste_mgmt_responsibility")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterConsumptionQuantity).HasColumnName("water_consumption_quantity");

//                entity.Property(e => e.WaterborneDiseases)
//                    .HasColumnName("waterborne_diseases")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WaterborneDiseasesStatus)
//                    .HasColumnName("waterborne_diseases_status")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WetGroundWaterLevelDepth)
//                    .HasColumnName("wet_ground_water_level_depth")
//                    .HasColumnType("character varying");

//                entity.Property(e => e.WillingTreatmentAdditionalCharge).HasColumnName("willing_treatment_additional_charge");
//            });


//            modelBuilder.HasSequence("users_user_id_seq", "system");

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}