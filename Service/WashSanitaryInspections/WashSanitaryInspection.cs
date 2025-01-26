using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Service.WashSanitaryInspections
{
    public class WashSanitaryInspection : IWashSanitaryInspection
    {
        private readonly WqsContext _wqsContext;
        public WashSanitaryInspection(WqsContext context)
        {
            _wqsContext = context;
        }
        public List<ProjectDetail> SanitaryInspectionList(string proCode)
        {
            var sTbl = from s in _wqsContext.SanitaryInspections
                       join u in _wqsContext.Users on Convert.ToInt32(s.UserId) equals u.UserId
                       join p in _wqsContext.ProjectDetails on s.ProjectUuid equals p.Uuid
                       where proCode == p.ProCode
                       select new ProjectDetail
                       {
                           //Id = s.Id,
                           AddDate = s.Time.HasValue ? DateOnly.FromDateTime(s.Time.Value) : null,
                           Photo5Desc = s.ProjectUuid,
                           Uuid = s.Uuid,
                           Photo3Path = u.Name,
                           Photo1Desc = s.ProjectUuid,
                           AddBy = s.PointId,
                           ProCodeNmip = s.PointType
                       };
            return sTbl.ToList();
        }

        public List<SanitaryInspection> GetSanitaryInceptionDetails(string Uuid, string Email, string PointId, string prouuid, string PointType)
        {

            var sTbl2 = from s in _wqsContext.SanitaryInspections
                        join u in _wqsContext.Users on Convert.ToInt32(s.UserId) equals u.UserId
                        join p in _wqsContext.ProjectDetails on s.ProjectUuid equals p.Uuid
                        join v in _wqsContext.SanitaryInspectionValues on s.Uuid equals v.SampleUuid
                        join t in _wqsContext.SanitaryInspectionTemplates on v.QuestionId equals t.Id

                        where s.ProjectUuid == prouuid && PointId == s.PointId && PointType == s.PointType
                        orderby s.Time

                        select new SanitaryInspection
                        {
                            Time = s.Time,
                            PointId = t.Question,
                            UserId = v.Value,
                        };


            return sTbl2.ToList();
        }



    }
}
