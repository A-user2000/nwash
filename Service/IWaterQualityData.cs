
using Wq_Surveillance.Models.WaterQuality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wq_Surveillance.Service.WaterQuality
{
    public interface IWaterQualityData
    {
        public WQSufficientTapPopulation GetParameterData(string proCode, int parId);

        // parameter wise summary

        public WqParameterData GetProjectParameterData(string proCode, int parameter, int dyear);
        public WqParameterData GetMunParameterData(string munCode, int parameter, int dyear);
        public WqParameterData GetDistrictParameterData(string dCode, int parameter, int dyear);
        public WqParameterData GetProvinceParameterData(string province, int parameter, int dyear);

    }
}
