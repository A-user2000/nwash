using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models.QueryTables;

namespace Wq_Surveillance.Functionality
{
    public class CalFunctionality
    {
        public CalFunctionality()
        {

        }

        public Dictionary<string, object> CalculateSchemeFunctionality(List<FuncTapDetails> TapDetails, List<FuncWSDetails> WsDetails, List<FuncStrDetails> StrDetails)
        {
            var totalTaps = TapDetails.Count;
            var functionalTaps = 0;
            var totalPopulation = 0;
            var popServedByFunctionalTap = 0;
            var communityTap = 0.0;
            var yardTaps = 0.0;
            var InsTaps = 0.0;
            var noOfVMW = TapDetails[0].no_of_vmw;
            var vmwAdequateTools = TapDetails[0].vmw_tools_adequate;


            for (int i = 0; i < totalTaps; i++)
            {
                /*
                 *  Checking Tap Condition for Each Taps
                 */
                var cond1 = "";
                var cond2 = "";
                var cond3 = "";

                if (TapDetails[i].tap_flow_con == "Sufficient for drinking and cooking and washing" || TapDetails[i].tap_flow_con == "Sufficient for all daily needs" || TapDetails[i].tap_flow_con == "Just sufficient for drinking")
                {
                    cond1 = "Y";
                }
                else
                {
                    cond1 = "N";
                }

                if (TapDetails[i].tap_water_quality == "No turbidity" || TapDetails[i].tap_water_quality == "Turbid water during rainy season")
                {
                    cond2 = "Y";
                }
                else
                {
                    cond2 = "N";
                }

                if (TapDetails[i].tap_fhours >= 2)
                {
                    cond3 = "Y";
                }
                else
                {
                    cond3 = "N";
                }

                /*
                 *  If all of the above condition is 'Yes', then the tap is functional
                 */

                if (cond1 == "Y" && cond2 == "Y" && cond3 == "Y")
                {
                    functionalTaps++;
                    popServedByFunctionalTap += (TapDetails[i].male_pop + TapDetails[i].female_pop);
                }

                totalPopulation += (TapDetails[i].male_pop + TapDetails[i].female_pop);

                if (TapDetails[i].tap_type == "Community")
                {
                    communityTap++;
                }
                else if (TapDetails[i].tap_type == "Yard")
                {
                    yardTaps++;
                }
                else if (TapDetails[i].tap_type == "Institutional")
                {
                    InsTaps++;
                }
            }
            /*
             *   F1A Calculation
             */
            var f1aCal = 0.00;
            var f1aScore = 0.00;
            var f1aRemarks = "";

            if (totalPopulation != 0)
            {
                f1aCal = Math.Round(((double)popServedByFunctionalTap / (double)totalPopulation * 100.00), 2);

                if (f1aCal == 100.00)
                {
                    f1aScore = 30.00;
                    f1aRemarks = "Population Served by Functional Taps: " + popServedByFunctionalTap + "<br/> Total Population: " + totalPopulation;
                }
                else if (f1aCal == 0.00)
                {
                    f1aScore = 0.00;
                    f1aRemarks = "Population Served by Functional Taps: " + popServedByFunctionalTap + "<br/> Total Population: " + totalPopulation;
                }
                else
                {
                    f1aScore = Math.Round((f1aCal * 30.0 / 100.0), 2);
                    f1aRemarks = "Population Served by Functional Taps: " + popServedByFunctionalTap + "<br/> Total Population: " + totalPopulation;
                }
            }
            else
            {
                f1aCal = 0.00;
                f1aScore = 0.00;
                f1aRemarks = "Population Served by Functional Taps: 0; Total Population: 0";
            }

            /*
             *  F2A Calculation 
             */
            var f2aCal = 0.0;
            var f2aScore = 0.0;
            var f2aRemarks = "";

            if (totalTaps != 0)
            {
                f2aCal = Math.Round(((double)functionalTaps / (double)totalTaps * 100.0), 2);

                if (f2aCal == 100.0)
                {
                    f2aScore = 30.0;
                    f2aRemarks = "Functional Taps: " + functionalTaps + "<br/> Total Taps:" + totalTaps;
                }
                else if (f2aCal == 0.0)
                {
                    f2aScore = 0.0;
                    f2aRemarks = "Functional Taps: " + functionalTaps + "<br/> Total Taps:" + totalTaps;
                }
                else
                {
                    f2aScore = Math.Round((f2aCal * 30.0 / 100.0), 2);
                    f2aRemarks = "Functional Taps: " + functionalTaps + "<br/> Total Taps:" + totalTaps;
                }
            }
            /*
             * F3A Calculation
             * F3A-a . N/A for Calculation
             * F3A-b. Conditions:
             *                  At least 1 VMW per 200 community taps
             *                  At least 1 VMW per 1000 yard taps
             */

            var f3aCal = 0.0;
            var f3aScore = 0.0;
            var f3aRemarks = "";

            f3aCal = Math.Round(((communityTap / 200) + ((yardTaps + InsTaps) / 1000.00)), 2);

            if (f3aCal <= noOfVMW)
            {
                f3aScore = 8.0;
                f3aRemarks = "No of VMW: " + noOfVMW + "<br/> Community Taps: " + communityTap + "<br/> Yard Taps: " + yardTaps;
            }
            else
            {
                f3aScore = Math.Round((8.0 / f3aCal * noOfVMW), 2);
                f3aRemarks = "No of VMW: " + noOfVMW + "<br/> Community Taps: " + communityTap + "<br/> Yard Taps: " + yardTaps;
            }

            /*
             * F3B Calculations
             */

            var f3bCal = 0.0;
            var f3bScore = 0.0;
            var f3bRemarks = "";

            if (f3aCal != 0.0)
            {
                f3bCal = Math.Round((vmwAdequateTools / f3aCal * 100.0), 2);

                if (f3bCal >= 100.0)
                {
                    f3bCal = 100.0;
                    f3bScore = 7.0;
                    f3bRemarks = "No of VWM: " + noOfVMW + "<br/> VMW Adequacy: Yes";
                }
                else if (f3bCal == 0.0)
                {
                    f3bScore = 0.0;
                    f3bRemarks = "No of VWM: " + noOfVMW + "<br/> VMW Adequacy: No";
                }
                else
                {
                    f3bScore = Math.Round((f3bCal * 7 / 100.0), 2);
                    f3bRemarks = "No of VWM: " + noOfVMW + "<br/> VMW Adequacy: Partial";
                }
            }
            else
            {
                f3bCal = 0.0;
                f3bScore = 0.0;
                f3bRemarks = "No of VWM: 0<br/> VMW Adequacy: 0";
            }

            /*
             * F4A Calculations
             */
            var f4aCal = 0.0;
            var f4aScore = 0.0;
            var f4aRemarks = "";

            var sumDischarge = 0.0;
            var sumproductWS = 0.0;
            var noOfSources = WsDetails.Count;

            for (int j = 0; j < noOfSources; j++)
            {
                sumDischarge += WsDetails[j].min_yield;
                sumproductWS += (WsDetails[j].adj_month * WsDetails[j].min_yield);
            }

            if (sumDischarge != 0)
            {
                f4aCal = Math.Round(sumproductWS / sumDischarge, 2);

                if (f4aCal == 12.00)
                {
                    f4aScore = 7.0;
                    f4aRemarks = "No of Month in which Water Source is Available: " + f4aCal + "<br/> No of Water Source: " + noOfSources;
                }
                else if (f4aCal >= 11.0)
                {
                    f4aScore = 5.0;
                    f4aRemarks = "No of Month in which Water Source is Available: " + f4aCal + "<br/> No of Water Source: " + noOfSources;
                }
                else
                {
                    f4aScore = 0.0;
                    f4aRemarks = "No of Month in which Water Source is Available: " + f4aCal + "<br/> No of Water Source: " + noOfSources;
                }
            }
            else
            {
                f4aCal = 0.0;
                f4aScore = 0.0;
                f4aRemarks = "No of Month in which Water Source is Available: 0<br/> No of Water Source: 0";
            }

            /*
             * F4B-i calculations
             */

            var f4bICal = 0.0;
            var f4bIScore = 0.0;
            var f4bIRemarks = "";
            var noOfStructures = StrDetails[0].no_of_sources + StrDetails[0].no_of_intakes + StrDetails[0].no_of_rvt;

            if (noOfStructures != 0)
            {
                f4bICal = Math.Round((double)(StrDetails[0].cond_major_rep + StrDetails[0].cond_reconstruction + StrDetails[0].int_major + StrDetails[0].int_reconstruction + StrDetails[0].no_intake_str + StrDetails[0].rvt_major + StrDetails[0].rvt_reconstruction) / noOfStructures * 100.00, 2);

                if (f4bICal > 50.00)
                {
                    f4bIScore = 0.0;
                    f4bIRemarks = "No. of Structure: " + noOfStructures + "<br/> No of Structure Needing Major Repair: " + (StrDetails[0].cond_major_rep + StrDetails[0].int_major + StrDetails[0].rvt_major) + "<br/> No of Structure Needing Reconstruction: " + +(StrDetails[0].cond_reconstruction + StrDetails[0].int_reconstruction + StrDetails[0].no_intake_str + StrDetails[0].rvt_reconstruction);
                }
                else
                {
                    f4bIScore = Math.Round((100.00 - f4bICal) * 11 / 100.00, 2);
                    f4bIRemarks = "No. of Structure: " + noOfStructures + "<br/> No of Structure Needing Major Repair: " + (StrDetails[0].cond_major_rep + StrDetails[0].int_major + StrDetails[0].rvt_major) + "<br/> No of Structure Needing Reconstruction: " + +(StrDetails[0].cond_reconstruction + StrDetails[0].int_reconstruction + StrDetails[0].no_intake_str + StrDetails[0].rvt_reconstruction);
                }
            }
            else
            {
                f4bICal = 0.0;
                f4bIScore = 0.0;
                f4bIRemarks = "No of Structures:  0<br/> No of Structure Needing Major Repair:  0<br/> No of Structure Needing Reconstruction: 0";
            }

            /*
             * F4B II Calculation
             */
            var f4bIICal = 0.0;
            var f4bIIScore = 0.0;
            var f4bIIRemarks = "";

            var lenTransmission = Math.Round(StrDetails[0].length_trn / 1000.00, 2);
            var lenDistribution = Math.Round(StrDetails[0].length_dis / 1000.00, 2);

            var totalPipeLen = Math.Round(lenDistribution + lenTransmission, 2);

            var mjrLeakageTransmission = StrDetails[0].trn_major;
            var mjrLeakageDistribution = StrDetails[0].dis_major;

            if (totalPipeLen != 0.0)
            {
                f4bIICal = 2 * Math.Round(((double)mjrLeakageTransmission + (double)mjrLeakageDistribution) / totalPipeLen, 2);

                if (f4bIICal > 1.00)
                {
                    f4bIIScore = 0.00;
                    f4bIIRemarks = "No of Major Leakage (Transmission): " + mjrLeakageTransmission + "<br/> No of Major Leakage (Distribution): " + mjrLeakageDistribution + "<br/> Total Pipeline Length: " + totalPipeLen + " KM";
                }
                else
                {
                    f4bIIScore = 7 - (7 - 5) * f4bIICal;
                    f4bIIRemarks = "No of Major Leakage (Transmission): " + mjrLeakageTransmission + "<br/> No of Major Leakage (Distribution): " + mjrLeakageDistribution + "<br/> Total Pipeline Length: " + totalPipeLen + " KM";
                }
            }
            else
            {
                f4bIICal = 0.0;
                f4bIIScore = 0.0;
                f4bIIRemarks = "No of Major Leakage (Transmission): 0<br/> No of Major Leakage (Distribution): 0<br/> Total Pipeline Length:  0";
            }
            /*
             * Input Score - F3 + F4
             * Output Score - F1 + F2
             * Output Score - % of Population Served by Functional Taps
             */
            var inputScore = Math.Round((f3aScore + f3bScore + f4aScore + f4bIScore + f4bIIScore) / 40 * 100.00);
            var outputScore = Math.Round((f1aScore + f2aScore) / 60 * 100.00);
            var effect = Math.Round(f1aCal);

            var totalScore = Math.Round((f1aScore + f2aScore + f3aScore + f3bScore + f4aScore + f4bIScore + f4bIIScore), 2);

            Dictionary<string, object> FuncScoreDict = new Dictionary<string, object>();

            FuncScoreDict.Add("proCode", TapDetails[0].pro_code);
            FuncScoreDict.Add("proName", TapDetails[0].pro_name);

            FuncScoreDict.Add("F1aCal", f1aCal);
            FuncScoreDict.Add("F1aScore", f1aScore);
            FuncScoreDict.Add("F1aRemark", f1aRemarks);

            FuncScoreDict.Add("F2aCal", f2aCal);
            FuncScoreDict.Add("F2aScore", f2aScore);
            FuncScoreDict.Add("F2aRemark", f2aRemarks);

            FuncScoreDict.Add("F3aCal", f3aCal);
            FuncScoreDict.Add("F3aScore", f3aScore);
            FuncScoreDict.Add("F3aRemark", f3aRemarks);

            FuncScoreDict.Add("F3bCal", f3bCal);
            FuncScoreDict.Add("F3bScore", f3bScore);
            FuncScoreDict.Add("F3bRemark", f3bRemarks);

            FuncScoreDict.Add("F4aCal", f4aCal);
            FuncScoreDict.Add("F4aScore", f4aScore);
            FuncScoreDict.Add("F4aRemark", f4aRemarks);

            FuncScoreDict.Add("F4bICal", f4bICal);
            FuncScoreDict.Add("F4bIScore", f4bIScore);
            FuncScoreDict.Add("F4bIRemark", f4bIRemarks);

            FuncScoreDict.Add("F4bIICal", f4bIICal);
            FuncScoreDict.Add("F4bIIScore", f4bIIScore);
            FuncScoreDict.Add("F4bIIRemark", f4bIIRemarks);

            FuncScoreDict.Add("totalScore", totalScore);

            FuncScoreDict.Add("inputScore", inputScore);
            FuncScoreDict.Add("outputScore", outputScore);
            FuncScoreDict.Add("effect", effect);


            return FuncScoreDict;

        }


    }
}
