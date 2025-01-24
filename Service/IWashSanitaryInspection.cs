using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Service
{
    public interface IWashSanitaryInspection
    {
        public List<ProjectDetail> SanitaryInspectionList(string proCode);
        public List<SanitaryInspection> GetSanitaryInceptionDetails(string Uuid, string Email, string PointId, string prouuid, string PointType);
    }
}
