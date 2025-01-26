using Wq_Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Service.Project
{
    public interface IProjectService
    {
        public List<Province> GetProvince();
        public List<District> GetSelDistricts(string province);
        public List<Municipality> GetSelMunicipality(string district);
        public List<Organization> GetInventoryAgency();
        public int AddProject(ProjectDetail project);
        public List<ProjectList> GetLastPcode(string munCode);
        public List<ProjectList> GetProjectList(string munCode);
        public List<ProjectList> IndividualProjectDetail(string uuid);
        public bool UpdateProjectData(string pCode, string pName, string pNameNep, string invAgency, int suid);
        //public MunDistrictDetail GetGaupalikaDetail(string munCode);
        //public List<ProjectExtent> GetProjectExtent(string proUuid);
        //public List<MuniExtent> GetMunicipalityExtent(string munCode);
        //public List<DistrictExtent> GetDistrictExtent(string dcode);
        //public List<ProvinceExtent> GetProvinceExtent(string province);
        //public void AddAgencyColDict();
        //public List<ProjectExtent> GetTapExtents(string tapUuid);           //same model of project

        /*
         * Agency
         */

        //public int AddAgency(Organization org);
        //public bool UpdateAgencyData(string OrgName, string PrgShortName, string Address, string Uuid);

        //public void Deletion(string uuid);

    }
}
