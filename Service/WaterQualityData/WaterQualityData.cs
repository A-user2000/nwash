using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models;
using Wq_Surveillance.Models.WaterQuality;

namespace Wq_Surveillance.Service.WaterQualityData
{
    public class WaterQualityData : IWaterQualityData
    {
        private readonly WqsContext _wqsContext;
        public WaterQualityData(WqsContext wqsContext)
        {
            _wqsContext = wqsContext;
        }
        public WQSufficientTapPopulation GetParameterData(string proCode, int parId)
        {
            var query = @"select a.pro_code, sum(a.sample_total_pop)sample_total_pop,water_quality.scheme_total_pop('" + proCode + @"'), count(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id= " + parId + @" THEN 1
									ELSE NULL::INTEGER
									END) AS sufficient_value, coalesce(sum(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id=" + parId + @" THEN a.sample_total_pop
									ELSE NULL::INTEGER
									END),0) AS sufficient_val_pop
							 from
							( 
								select distinct on (s.point_id) point_id, p.pro_code,s.point_type,wv.parameter_id,
									CASE WHEN wv.value = '-999' or wv.value ='' THEN '0'
										ELSE coalesce(wv.value,'0')
										END AS value,
									coalesce(sum(t.male_pop + t.female_pop),0) sample_total_pop,water_quality.check_upper_range(" + parId + @") u_range,water_quality.check_lower_range(" + parId + @") l_range
									from existing_projects.project_details p	
									left join water_quality.water_quality_sample s on s.project_uuid = p.uuid
									left join existing_projects.tap t on s.point_id=t.uuid
									join water_quality.water_quality_values wv on wv.sample_uuid = s.uuid

									where p.pro_code='" + proCode + @"'
									group by p.pro_code,s.point_type,wv.parameter_id,wv.value,s.point_id
							) a
							group by a.pro_code";

            var wqData = _wqsContext.WQSufficientTapPopulation
                              .FromSqlRaw(query).OrderBy(s => s.pro_code)
                              .FirstOrDefault();
            return wqData;
        }

        public WqParameterData GetProjectParameterData(string proCode, int parameter, int dyear)
        {
            var dyear1 = "%" + dyear + "%";
            var query = @"select a.pro_code pcode, water_quality.scheme_total_pop('" + proCode + @"') total_pop,sum(a.sample_total_pop) sample_pop, count(point_id) sampling_points,samples_in_year, count(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id= " + parameter + @" THEN 1
									ELSE NULL::INTEGER
									END) AS sufficient_data_available, coalesce(sum(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id=" + parameter + @" THEN a.sample_total_pop
									ELSE NULL::INTEGER
									END),0) AS sufficient_data_pop,
									0 complying_samples,0 ph_complied_pop,0 ph_not_complied_pop
							 from
							( 
								select distinct on (s.point_id) point_id, p.pro_code,s.point_type,wv.parameter_id,
									CASE WHEN wv.value = '-999' or wv.value ='' THEN '0'
									ELSE coalesce(wv.value,'0')
									END AS value,coalesce(sum(t.male_pop + t.female_pop),0) sample_total_pop,water_quality.check_upper_range(" + parameter + @") u_range,water_quality.check_lower_range(" + parameter + @") l_range,
									water_quality.scheme_samples_in_year('" + proCode + @"','" + dyear1 + @"') samples_in_year
									from existing_projects.project_details p	
									left join water_quality.water_quality_sample s on s.project_uuid = p.uuid
									left join existing_projects.tap t on s.point_id=t.uuid
									join water_quality.water_quality_values wv on wv.sample_uuid = s.uuid
									where p.pro_code='" + proCode + @"'
									group by p.pro_code,s.point_type,wv.parameter_id,wv.value,s.point_id
							) a
							group by a.pro_code,samples_in_year";
            var wqData = _wqsContext.WqParameterData
                              .FromSqlRaw(query).OrderBy(s => s.pcode)
                              .FirstOrDefault();
            return wqData;
        }

        public WqParameterData GetMunParameterData(string munCode, int parameter, int dyear)
        {
            var dyear1 = "%" + dyear + "%";
            var query = @"select a.municipality_code pcode, water_quality.mun_total_pop('" + munCode + @"') total_pop,sum(a.sample_total_pop) sample_pop, count(point_id) sampling_points,samples_in_year, count(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id= " + parameter + @" THEN 1
									ELSE NULL::INTEGER
									END) AS sufficient_data_available, coalesce(sum(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id=" + parameter + @" THEN a.sample_total_pop
									ELSE NULL::INTEGER
									END),0) AS sufficient_data_pop,
									0 complying_samples,0 ph_complied_pop,0 ph_not_complied_pop
							 from
							( 
								select distinct on (s.point_id) point_id, p.municipality_code,s.point_type,wv.parameter_id,
									CASE WHEN wv.value = '-999' or wv.value ='' THEN '0'
									ELSE coalesce(wv.value,'0')
									END AS value,
									coalesce(sum(t.male_pop + t.female_pop),0) sample_total_pop,water_quality.check_upper_range(" + parameter + @") u_range,water_quality.check_lower_range(" + parameter + @") l_range,
									water_quality.mun_samples_in_year('" + munCode + @"','" + dyear1 + @"') samples_in_year
									from existing_projects.project_details p	
									left join water_quality.water_quality_sample s on s.project_uuid = p.uuid
									left join existing_projects.tap t on s.point_id=t.uuid
									join water_quality.water_quality_values wv on wv.sample_uuid = s.uuid
									where p.municipality_code='" + munCode + @"'
									group by p.municipality_code,s.point_type,wv.parameter_id,wv.value,s.point_id
							) a
							group by a.municipality_code,samples_in_year";
            var wqData = _wqsContext.WqParameterData
                              .FromSqlRaw(query).OrderBy(s => s.pcode)
                              .FirstOrDefault();
            return wqData;
        }

        public WqParameterData GetDistrictParameterData(string dCode, int parameter, int dyear)
        {
            var dyear1 = "%" + dyear + "%";
            var query = @"select a.district_code pcode, water_quality.district_total_pop('" + dCode + @"') total_pop,sum(a.sample_total_pop) sample_pop, count(point_id) sampling_points,samples_in_year, count(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id= " + parameter + @" THEN 1
									ELSE NULL::INTEGER
									END) AS sufficient_data_available, coalesce(sum(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id=" + parameter + @" THEN a.sample_total_pop
									ELSE NULL::INTEGER
									END),0) AS sufficient_data_pop,
									0 complying_samples,0 ph_complied_pop,0 ph_not_complied_pop
							 from
							( 
								select distinct on (s.point_id) point_id, p.district_code,s.point_type,wv.parameter_id,wv.value,coalesce(sum(t.male_pop + t.female_pop),0) sample_total_pop,water_quality.check_upper_range(" + parameter + @") u_range,water_quality.check_lower_range(" + parameter + @") l_range,
									water_quality.district_samples_in_year('" + dCode + @"','" + dyear1 + @"') samples_in_year
									from existing_projects.project_details p	
									left join water_quality.water_quality_sample s on s.project_uuid = p.uuid
									left join existing_projects.tap t on s.point_id=t.uuid
									join water_quality.water_quality_values wv on wv.sample_uuid = s.uuid
									where p.district_code='" + dCode + @"'
									group by p.district_code,s.point_type,wv.parameter_id,wv.value,s.point_id
							) a
							group by a.district_code,samples_in_year";
            var wqData = _wqsContext.WqParameterData
                              .FromSqlRaw(query).OrderBy(s => s.pcode)
                              .FirstOrDefault();
            return wqData;
        }

        public WqParameterData GetProvinceParameterData(string province, int parameter, int dyear)
        {
            var dyear1 = "%" + dyear + "%";
            var query = @"select a.province_code pcode, water_quality.province_total_pop('" + province + @"') total_pop,sum(a.sample_total_pop) sample_pop, count(point_id) sampling_points,samples_in_year, count(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id= " + parameter + @" THEN 1
									ELSE NULL::INTEGER
									END) AS sufficient_data_available, coalesce(sum(
									CASE WHEN a.value::numeric >= a.l_range and a.value::numeric <= u_range and parameter_id=" + parameter + @" THEN a.sample_total_pop
									ELSE NULL::INTEGER
									END),0) AS sufficient_data_pop,
									0 complying_samples,0 ph_complied_pop,0 ph_not_complied_pop
							 from
							( 
								select distinct on (s.point_id) point_id, p.province_code,s.point_type,wv.parameter_id,wv.value,coalesce(sum(t.male_pop + t.female_pop),0) sample_total_pop,water_quality.check_upper_range(" + parameter + @") u_range,water_quality.check_lower_range(" + parameter + @") l_range,
									water_quality.province_samples_in_year('" + province + @"','" + dyear1 + @"') samples_in_year
									from existing_projects.project_details p	
									left join water_quality.water_quality_sample s on s.project_uuid = p.uuid
									left join existing_projects.tap t on s.point_id=t.uuid
									join water_quality.water_quality_values wv on wv.sample_uuid = s.uuid
									where p.province_code='" + province + @"'
									group by p.province_code,s.point_type,wv.parameter_id,wv.value,s.point_id
							) a
							group by a.province_code,samples_in_year";
            var wqData = _wqsContext.WqParameterData
                              .FromSqlRaw(query).OrderBy(s => s.pcode)
                              .FirstOrDefault();
            return wqData;
        }

    }
}
