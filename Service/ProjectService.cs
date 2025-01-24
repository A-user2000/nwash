using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Service
{
    public class ProjectService : IProjectService
    {
        private readonly WqsContext _wqsContext;
        private readonly IHttpContextAccessor _sessionData;

        public ProjectService(WqsContext wqsContext, IHttpContextAccessor contextAccessor)
        {
            _wqsContext = wqsContext;
            _sessionData = contextAccessor;
        }
        public List<Province> GetProvince()
        {
            return _wqsContext.Provinces.OrderBy(item => item.ProvinceCode).ToList();
        }
        public List<District> GetSelDistricts(string province)
        {
            return _wqsContext.Districts
                    .Where(s => s.ProvinceCode == province)
                    .OrderBy(item => item.DistrictCode).ToList();
        }
        public List<Municipality> GetSelMunicipality(string district)
        {
            return _wqsContext.Municipalities
                    .Where(s => s.DistrictCode == district)
                    .OrderBy(item => item.MunCode).ToList();
        }

        public List<Organization> GetInventoryAgency()
        {
            return _wqsContext.Organizations
                    .OrderBy(item => item.OrgName).ToList();
        }

        public int AddProject(ProjectDetail project)
        {
            var proName = project.ProName;
            var uuid = CreateUUID();
            project.Uuid = uuid;

            _wqsContext.Add(project);
            var resultVal = _wqsContext.SaveChanges();

            return resultVal;
        }

        private string CreateUUID()
        {
            Guid g = Guid.NewGuid();
            var uuid = g.ToString();

            var checkExisitingUUID = _wqsContext.ProjectDetails
                                       .Where(s => s.Uuid == uuid)
                                       .FirstOrDefault();

            if (checkExisitingUUID != null)
            {
                CreateUUID();
            }
            return uuid;
        }

        public List<ProjectList> GetLastPcode(string munCode)
        {
            var query = @"select pd.uuid,pd.pro_name,pd.pro_name_nep,pd.pro_code,pd.inv_agency,pd.province_code,pd.district_code,pd.municipality_code,p.province_name,d.district_name,m.mun_name
	                        from existing_projects.project_details pd
	                        left join system.district d on d.district_code=pd.district_code
	                        left join system.municipality m on m.mun_code=pd.municipality_code
				            left join system.province p on p.province_code=pd.province_code
	                        where pd.municipality_code='" + munCode + @"'
                            order by pd.pro_code desc
                            LIMIT 1";
            var ProjectListVal = _wqsContext.ProjectList
                               .FromSqlRaw(query)
                               .ToList();
            return ProjectListVal;
        }

        public List<ProjectList> GetProjectList(string munCode)
        {
            var query = @"select pd.uuid,pd.pro_name,pd.pro_name_nep,pd.pro_code,pd.inv_agency,pd.province_code,pd.district_code,pd.municipality_code,p.province_name,d.district_name,m.mun_name
	                        from existing_projects.project_details pd
	                        left join system.district d on d.district_code=pd.district_code
	                        left join system.municipality m on m.mun_code=pd.municipality_code
				            left join system.province p on p.province_code=pd.province_code
	                        where pd.municipality_code='" + munCode + @"'
                            order by pd.pro_code";

            var ProjectListVal = _wqsContext.ProjectList
                               .FromSqlRaw(query)
                               .ToList();

            if (ProjectListVal == null)
            {
                return new List<ProjectList>();
            }

            return ProjectListVal;
        }

        public List<ProjectList> IndividualProjectDetail(string uuid)
        {
            var query = @"select pd.uuid,pd.pro_name,pd.pro_name_nep,pd.pro_code,pd.inv_agency,pd.province_code,pd.district_code,pd.municipality_code,p.province_name,d.district_name,m.mun_name
	                        from existing_projects.project_details pd
	                        left join system.district d on d.district_code=pd.district_code
	                        left join system.municipality m on m.mun_code=pd.municipality_code
				            left join system.province p on p.province_code=pd.province_code
	                        where pd.uuid='" + uuid + @"'";

            var ProjectListVal = _wqsContext.ProjectList
                               .FromSqlRaw(query)
                               .ToList();

            return ProjectListVal;
        }

        public bool UpdateProjectData(string pCode, string pName, string pNameNep, string invAgency, int suid)
        {
            var checkPcode = _wqsContext.ProjectDetails
                            .FirstOrDefault(m => m.ProCode == pCode);

            int result = 0;

            if (checkPcode != null)
            {
                checkPcode.ProName = pName;
                checkPcode.ProNameNep = pNameNep;
                checkPcode.InvAgency = invAgency;
                result = _wqsContext.SaveChanges();
            }

            if (result == 1)
            {
                //_crudtracker.Project(pCode, "Edit", suid);
                return true;

            }
            else
            {
                return false;
            }
        }




        //public int AddAgency(Organization org)
        //{
        //    var uuid = CreateOrgUUID();
        //    var SName = _sessionData.HttpContext.Session.GetString("SName");
        //    DateTime date = DateTime.Now; // will give the date for today

        //    org.OrgUuid = uuid;
        //    org.AddBy = SName;
        //    org.AddDate = Convert.ToDateTime(date);

        //    _wqsContext.Add(org);
        //    var returnVal = _wqsContext.SaveChanges();
        //    return returnVal;
        //}

        //private string CreateOrgUUID()
        //{
        //    Guid g = Guid.NewGuid();
        //    var uuid = g.ToString();

        //    var checkExisitingUUID = _wqsContext.Organizations
        //                               .Where(s => s.OrgUuid == uuid)
        //                               .FirstOrDefault();

        //    if (checkExisitingUUID != null)
        //    {
        //        CreateOrgUUID();
        //    }
        //    return uuid;
        //}

        //public bool UpdateAgencyData(string OrgName, string PrgShortName, string Address, string Uuid)
        //{
        //    var getAgencyData = _wqsContext.Organizations
        //                            .Where(s => s.OrgUuid == Uuid)
        //                            .FirstOrDefault();
        //    var preval = getAgencyData.OrgName;
        //    int result = 0;
        //    if (getAgencyData != null)
        //    {
        //        var SName = _sessionData.HttpContext.Session.GetString("SName");
        //        getAgencyData.OrgName = OrgName;
        //        getAgencyData.PrgShortName = PrgShortName;
        //        getAgencyData.Address = Address;
        //        getAgencyData.AddBy = SName;
        //        result = UpdateUserTblAgency(OrgName, preval);
        //        result = UpdateWpStatusTblAgency(OrgName, preval);
        //        result = UpdateProjectAgency(OrgName, preval);

        //    }

        //    if (result == 1)
        //    {
        //        _wqsContext.SaveChanges();
        //        AddAgencyColDict();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void AddAgencyColDict()
        //{
        //    var orglist = _wqsContext.Organizations.OrderBy(s => s.PrgShortName).Select(s => s.PrgShortName).ToList();
        //    string orgConcat = string.Join("||", orglist);
        //    var extcoldictData = _wqsContext.ColumnDictionary.Where(s => s.PostgresCol == "cons_agency_id" || s.PostgresCol == "cons_agency" || s.PostgresCol == "sup_agency" || s.PostgresCol == "rehab_agency").ToList();
        //    foreach (var item in extcoldictData)
        //    {
        //        item.Options = orgConcat;
        //        _wqsContext.Update(item);
        //    }
        //    _wqsContext.SaveChanges();
        //}

        //public int UpdateUserTblAgency(string OrgName, string preval)
        //{
        //    try
        //    {
        //        var usertbl = _wqsContext.Users.Where(s => s.InvAgency == preval).OrderBy(s => s.UserId).ToList();
        //        if (usertbl != null)
        //        {
        //            foreach (var item in usertbl)
        //            {
        //                item.InvAgency = OrgName;
        //                _wqsContext.Update(item);
        //            }
        //        }
        //        _wqsContext.SaveChanges();
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        //public int UpdateWpStatusTblAgency(string OrgName, string preval)
        //{
        //    try
        //    {
        //        var wpstatus = _wqsContext.WpProgressStatus.Where(s => s.WashplanAgency == preval).OrderBy(s => s.Id).ToList();
        //        if (wpstatus != null)
        //        {
        //            foreach (var item in wpstatus)
        //            {
        //                item.WashplanAgency = OrgName;
        //                _wqsContext.Update(item);
        //            }
        //        }
        //        _wqsContext.SaveChanges();
        //        var wpstatus2 = _wqsContext.WpProgressStatus.Where(s => s.DataCollAgency == preval).OrderBy(s => s.Id).ToList();
        //        if (wpstatus2 != null)
        //        {
        //            foreach (var item in wpstatus2)
        //            {
        //                item.DataCollAgency = OrgName;
        //                _wqsContext.Update(item);
        //            }
        //        }
        //        _wqsContext.SaveChanges();
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        public int UpdateProjectAgency(string OrgName, string preval)
        {
            try
            {
                var projecttbl = _wqsContext.ProjectDetails.Where(s => s.InvAgency == preval).OrderBy(s => s.Id).ToList();
                if (projecttbl != null)
                {
                    foreach (var item in projecttbl)
                    {
                        item.InvAgency = OrgName;
                        _wqsContext.Update(item);
                    }
                }
                _wqsContext.SaveChanges();
                var projecttbl2 = _wqsContext.ProjectDetails.Where(s => s.SupAgency == preval).OrderBy(s => s.Id).ToList();
                if (projecttbl2 != null)
                {
                    foreach (var item in projecttbl2)
                    {
                        item.SupAgency = OrgName;
                        _wqsContext.Update(item);
                    }
                }
                _wqsContext.SaveChanges();
                var projecttbl3 = _wqsContext.ProjectDetails.Where(s => s.RehabAgency == preval).OrderBy(s => s.Id).ToList();
                if (projecttbl3 != null)
                {
                    foreach (var item in projecttbl3)
                    {
                        item.RehabAgency = OrgName;
                        _wqsContext.Update(item);
                    }
                }
                _wqsContext.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        //public void Deletion(string uuid)
        //{
        //    junction(uuid);
        //    pipe(uuid);
        //    pipe_drawn_route(uuid);
        //    pipe_route_point(uuid);
        //    reservoir(uuid);
        //    structure(uuid);
        //    tap(uuid);
        //    water_source(uuid);
        //    sanitation(uuid);
        //    project_coverage(uuid);
        //    other_water_usage(uuid);
        //    vmw_details(uuid);
        //    vmw_payment(uuid);
        //    water_source_condition(uuid);
        //    wua_account_keeping(uuid);
        //    wua_agm(uuid);
        //    wua_audit(uuid);
        //    wua_bank(uuid);
        //    wua_details(uuid);
        //    wua_income_exp(uuid);
        //    wua_insurance(uuid);
        //    wua_meeting(uuid);
        //    wua_sop(uuid);
        //    wua_structure(uuid);
        //    leftouttap(uuid);
        //    projectdetail(uuid);
        //}

        //public void junction(string uuid)
        //{

        //    var bs = _wqsContext.Junction.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.Junction.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void pipe(string uuid)
        //{
        //    var bs = _wqsContext.Pipe.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void pipe_drawn_route(string uuid)
        //{
        //    var bs = _wqsContext.PipeDrawnRoute.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void pipe_route_point(string uuid)
        //{
        //    var bs = _wqsContext.PipeRoutePoint.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}
        //public void reservoir(string uuid)
        //{
        //    var bs = _wqsContext.Reservoir.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChangesAsync();
        //    }
        //}
        //public void structure(string uuid)
        //{
        //    var bs = _wqsContext.Structure.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void tap(string uuid)
        //{
        //    var bs = _wqsContext.Tap.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void water_source(string uuid)
        //{
        //    var bs = _wqsContext.WaterSource.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void sanitation(string uuid)
        //{
        //    var bs = _wqsContext.Sanitation.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void project_coverage(string uuid)
        //{
        //    var bs = _wqsContext.ProjectCoverage.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void other_water_usage(string uuid)
        //{
        //    var bs = _wqsContext.OtherWaterUsage.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void vmw_details(string uuid)
        //{
        //    var bs = _wqsContext.VmwDetails.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void vmw_payment(string uuid)
        //{
        //    var bs = _wqsContext.VmwPayment.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void water_source_condition(string uuid)
        //{
        //    var bs = _wqsContext.WaterSourceCondition.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_account_keeping(string uuid)
        //{
        //    var bs = _wqsContext.WuaAccountKeeping.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_agm(string uuid)
        //{
        //    var bs = _wqsContext.WuaAgm.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_audit(string uuid)
        //{
        //    var bs = _wqsContext.WuaAudit.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_bank(string uuid)
        //{
        //    var bs = _wqsContext.WuaBank.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_details(string uuid)
        //{
        //    var bs = _wqsContext.WuaDetails.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_income_exp(string uuid)
        //{
        //    var bs = _wqsContext.WuaIncomeExp.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_insurance(string uuid)
        //{
        //    var bs = _wqsContext.WuaInsurance.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}
        //public void wua_meeting(string uuid)
        //{
        //    var bs = _wqsContext.WuaMeeting.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}
        //public void wua_sop(string uuid)
        //{
        //    var bs = _wqsContext.WuaSop.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}

        //public void wua_structure(string uuid)
        //{
        //    var bs = _wqsContext.WuaStructure.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}
        //public void leftouttap(string uuid)
        //{
        //    var bs = _wqsContext.LeftoutTaps.Where(s => s.ProUuid == uuid).ToList();
        //    if (bs.Count() != 0)
        //    {
        //        _wqsContext.RemoveRange(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}


        //public void projectdetail(string uuid)
        //{
        //    var bs = _wqsContext.ProjectDetails.Where(s => s.Uuid == uuid).OrderBy(S => S.Id).FirstOrDefault();
        //    if (bs != null)
        //    {
        //        _wqsContext.Remove(bs);
        //        _wqsContext.SaveChanges();
        //    }
        //}


    }
}
