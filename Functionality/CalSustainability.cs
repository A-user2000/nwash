
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models.QueryTables;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Functionality
{
    public class CalSustainability
    {
        public CalSustainability()
        {

        }

        public Dictionary<string, object> CalculateSchemeSustainability(List<ProjectBasicDetails> BasicProjectDetail, List<WaterSource> WsDetails, List<SustainabilityDetails> SusDetails, List<WSIncomeDetails> IncomeDetail)
        {
            /*
             * S1A 
             */

            var s1aVal = SusDetails[0].func_population;
            var s1aScore = Math.Round((s1aVal / 100.00 * 50), 2);
            var s1aRemarks = "Population served by functional taps: " + s1aVal;

            /*
             * S2A
             */

            var s2aVal = SusDetails[0].no_of_meetings;
            var s2aScore = 0;
            var s2aRemarks = "";

            if (s2aVal >= 4)
            {
                s2aScore = 5;
                s2aRemarks = "Number of meetings with decision recorded per year: " + s2aVal;
            }
            else if (s2aVal == 3)
            {
                s2aScore = 4;
                s2aRemarks = "Number of meetings with decision recorded per year: " + s2aVal;
            }
            else if (s2aVal == 2)
            {
                s2aScore = 3;
                s2aRemarks = "Number of meetings with decision recorded per year: " + s2aVal;
            }
            else
            {
                s2aScore = 0;
                s2aRemarks = "Number of meetings with decision recorded per year: " + s2aVal;
            }

            /*
             * S2B
             */

            var s2bCal = SusDetails[0].no_of_agm;
            var s2bVal = "";
            var s2bScore = 0;
            var s2bRemarks = "";

            if (s2bCal >= 1)
            {
                s2bScore = 5;
                s2bVal = "Yes";
                s2bRemarks = "Annual general meeting conducted with decision recorded: " + s2bVal;
            }
            else
            {
                s2bScore = 0;
                s2bVal = "No";
                s2bRemarks = "Annual general meeting conducted with decision recorded: " + s2bVal;
            }

            /*
             * S2C
             */

            var s2cVal = "";
            var s2cScore = 0;
            var s2cRemarks = "";

            if (SusDetails[0].accountant >= 1 && SusDetails[0].self == 0)
            {
                s2cScore = 4;
                s2cVal = "Always by Accountant";
                s2cRemarks = "Account is always looked after by accountant";
            }
            else if (SusDetails[0].accountant >= 1 && SusDetails[0].self == 1)
            {
                s2cScore = 3;
                s2cVal = "Some months by accountant and rest by WSUC";
                s2cRemarks = "Account is looked after Some months by accountant and rest by WSUC";
            }
            else if (SusDetails[0].accountant == 0 && SusDetails[0].self >= 1)
            {
                s2cScore = 2;
                s2cVal = "Only by WSUC";
                s2cRemarks = "Account is looked after Only by WSUC";
            }
            else
            {
                s2cScore = 0;
                s2cVal = "None is responsible";
                s2cRemarks = "None is responsible";
            }

            var s2Total = s2aScore + s2bScore + s2cScore;

            /*
             * S3A and S4A
             */

            var s3aMarks = 0;
            var s3aCal = 0;
            var s3aCon1 = 0;
            var s3aCon2 = 0;
            var s3aCon3 = 0;
            var s3aCon4 = 0;
            var s3aScore = 0.0;

            var s4aMarks = 0;
            var s4aCal = 0;
            var s4aCon1 = 0;
            var s4aCon2 = 0;
            var s4aCon3 = 0;
            var s4aCon4 = 0;
            var s4aScore = 0.0;

            var noOfSource = WsDetails.Count;

            for (int i = 0; i < noOfSource; i++)
            {
                if (WsDetails[i].WatQua == "Appropriate treatment facility exists and working")
                {
                    s3aMarks = 4;
                    s3aCon1++;
                }
                else if (WsDetails[i].WatQua == "Clean round the year/treatment may or may not needed")
                {
                    s3aMarks = 3;
                    s3aCon2++;
                }
                else if (WsDetails[i].WatQua == "Turbid/dirty in rainy season/Minor treatment needed")
                {
                    s3aMarks = 2;
                    s3aCon3++;
                }
                else if (WsDetails[i].WatQua == "Turbid/dirty round the year/major treatment needed")
                {
                    s3aMarks = 0;
                    s3aCon4++;
                }


                if (WsDetails[i].SouReg == "Source registered and no obligations")
                {
                    s4aMarks = 5;
                    s4aCon1++;
                }
                else if (WsDetails[i].SouReg == "Source registered, in public land & obstructed by local community")
                {
                    s4aMarks = 4;
                    s4aCon2++;
                }
                else if (WsDetails[i].SouReg == "Source in private land & obstructed by owner")
                {
                    s4aMarks = 3;
                    s4aCon3++;
                }
                else if (WsDetails[i].SouReg == "Source not registered, in public land & obstructed by local community")
                {
                    s4aMarks = 0;
                    s4aCon4++;
                }

                s3aCal += s3aMarks;
                s4aCal += s4aMarks;
            }

            if (noOfSource != 0)
            {
                s3aScore = Math.Round((double)s3aCal / (double)noOfSource, 2);
                s4aScore = Math.Round((double)s4aCal / (double)noOfSource, 2);
            }
            else
            {
                s3aScore = 0;
                s4aScore = 0;
            }

            var s3aRemarks = "No of Source: " + noOfSource +
                                "<br/> Appropriate treatment facility exists and working: " + s3aCon1 +
                                "<br/> Clean round the year/treatment may or may not needed:  " + s3aCon2 +
                                "<br/> Turbid/dirty in rainy season/Minor treatment needed:  " + s3aCon3 +
                                "<br/> Turbid/dirty round the year/major treatment needed: " + s3aCon4;

            var s4aRemarks = "No of Source: " + noOfSource +
                                "<br/> Source registered and no obligations: " + s4aCon1 +
                                "<br/> Source not registered but no obligations/obstructions:  " + s4aCon2 +
                                "<br/> Source in private land and obstructed by owner:  " + s4aCon3 +
                                "<br/> Source not registered, in public land & obstructed by local community: " + s4aCon4;

            /*
             * S3B
             */

            var s3bScore = 0;
            var s3bVal = "";
            var s3bRemarks = "";


            if (SusDetails[0].sop_status_eng == "Yes")
            {
                s3bScore = 4;
                s3bVal = "Yes";
                s3bRemarks = "Standard Operation Procedure (SOP) of regular inspection prepared and followed";
            }
            else
            {
                s3bScore = 0;
                s3bVal = "No";
                s3bRemarks = "Standard Operation Procedure (SOP) of regular inspection not prepared and not followed";

            }

            var s3Total = s3aScore + s3bScore;

            /*
            * S4B
            */

            var s4bScore = 0;
            var s4bRemarks = "";

            if (SusDetails[0].water_usage_eng == "Less than 10%")
            {
                s4bScore = 0;
                s4bRemarks = "Less than 10%";
            }
            else if (SusDetails[0].water_usage_eng == "10%-30%")
            {
                s4bScore = 1;
                s4bRemarks = "10%-30%";
            }
            else if (SusDetails[0].water_usage_eng == "30%-50%")
            {
                s4bScore = 2;
                s4bRemarks = "30%-50%";
            }
            else if (SusDetails[0].water_usage_eng == "More than 50%")
            {
                s4bScore = 3;
                s4bRemarks = "More than 50%";
            }

            /*
             * S4C
             */

            var femaleMember = SusDetails[0].female_member;
            var femaleMemberKeyPost = SusDetails[0].female_member_in_key_post;
            var totalMember = SusDetails[0].no_of_members;
            var femaleMemberPC = 0.00;
            var s4cScore = 0;
            var s4cRemarks = "";

            if (totalMember != 0)
            {
                femaleMemberPC = Math.Round(((double)femaleMember / (double)totalMember) * 100, 2);

                if (femaleMemberPC >= 33 && femaleMemberKeyPost >= 1)
                {
                    s4cScore = 4;
                }
                else if (femaleMemberPC >= 33 && femaleMemberKeyPost >= 0)
                {
                    s4cScore = 3;
                }
                else if (femaleMemberPC >= 20 && femaleMemberKeyPost >= 1)
                {
                    s4cScore = 3;
                }
                else if (femaleMemberPC >= 20 && femaleMemberKeyPost >= 0)
                {
                    s4cScore = 2;
                }
                else
                {
                    s4cScore = 0;
                }
                s4cRemarks = "No of Members in Committee: " + totalMember +
                            "<br/> No of Women Representation On Committee:" + femaleMember +
                            "<br/> No of Women in Key Position:" + femaleMemberKeyPost;
            }
            else
            {
                femaleMemberPC = 0.0;
                s4cScore = 0;
                s4cRemarks = "No of Members in Committee:  0<br/> No of Women Representation On Committee: 0<br/> No of Women in Key Position:  0";
            }

            var s4Total = s4aScore + s4bScore + s4cScore;

            /*
             * S5A
             */

            var s5aScore = 0;
            var s5aVal = "";
            var s5aRemarks = "";

            if (SusDetails[0].audit_yes >= 1)
            {
                s5aScore = 3;
                s5aVal = "Yes";
                s5aRemarks = "Presence of Financial Auditing System";
            }
            else
            {
                s5aScore = 0;
                s5aVal = "No";
                s5aRemarks = "Absence of Financial Auditing System";
            }

            /*
             * s5B 
             */

            var noOfVmw = SusDetails[0].no_of_vmw;
            var VmwPaid = SusDetails[0].vmw_being_paid;

            var s5bScore = 0;
            var s5bVal = "";
            var s5bCal = 0.0;
            var s5bRemarks = "";

            if (noOfVmw != 0)
            {
                s5bCal = Math.Round((double)(VmwPaid / noOfVmw) * 100, 2);

                if (s5bCal > 50)
                {
                    s5bVal = "Yes";
                    s5bScore = 4;
                    s5bRemarks = "Presence of provision of remuneration for VMW";
                }
                else
                {
                    s5bVal = "No";
                    s5bScore = 0;
                    s5bRemarks = "Absence of provision of remuneration for VMW";
                }
            }
            else
            {
                s5bVal = "No";
                s5bScore = 0;
                s5bRemarks = "Absence of provision of remuneration for VMW";
            }

            /*
             * S5C
             */
            var s5cScore = 0;
            var s5cVal = "";
            var s5cRemarks = "";

            if (SusDetails[0].insuarance_yes >= 1)
            {
                s5cVal = "Yes";
                s5cScore = 2;
                s5cRemarks = "Presence of provision of water supply system insurance";
            }
            else
            {
                s5cVal = "No";
                s5cScore = 0;
                s5cRemarks = "Absence of provision of water supply system insurance";
            }

            /*
             * S5D
             */

            var s5dScore = 0;
            var s5dVal = 0.0;
            var s5dRemarks = "";
            var totalIncome = 0.0;
            var totalExpenditure = 0.0;

            int numI = 0;
            decimal numD = 0;

            foreach (var IncomeVar in IncomeDetail)
            {
                if ((decimal.TryParse(IncomeVar.water_tariff, out numD)) || (int.TryParse(IncomeVar.water_tariff, out numI)))
                {
                    totalIncome += double.Parse(IncomeVar.water_tariff);
                }

                if ((decimal.TryParse(IncomeVar.expenditure, out numD)) || (int.TryParse(IncomeVar.expenditure, out numI)))
                {
                    totalExpenditure += double.Parse(IncomeVar.expenditure);
                }
            }

            if (totalIncome != 0.0)
            {
                s5dVal = Math.Round(totalExpenditure / totalIncome * 100, 2);

                if (s5dVal < 75.00)
                {
                    s5dScore = 6;
                }
                else if (s5dVal >= 75.00 && s5dVal < 100.00)
                {
                    s5dScore = 4;
                }
                else if (s5dVal >= 100)
                {
                    s5dScore = 2;
                }
                else
                {
                    s5dScore = 0;
                }

                s5dRemarks = "Total Income: " + totalIncome + "<br/> Total Expenditure: " + totalExpenditure;
            }
            else
            {
                s5dVal = 0.0;
                s5dScore = 0;
                s5dRemarks = "Total Income: 0<br/> Total Expenditure: 0";
            }

            var s5Total = s5aScore + s5bScore + s5cScore + s5dScore;

            /*
             * Input Score: S2 - S5;
             * Output Score: S1;
             */

            var inputScore = Math.Round((double)(s2Total + s3Total + s4Total + s5Total) / 50 * 100.00);
            var outputScore = Math.Round((double)s1aScore / 50 * 100.00);
            var totalScore = Math.Round((s1aScore + s2Total + s3Total + s4Total + s5Total), 2);

            Dictionary<string, object> SusScoreDict = new Dictionary<string, object>();

            SusScoreDict.Add("S1aVal", s1aVal);
            SusScoreDict.Add("S1aScore", s1aScore);
            SusScoreDict.Add("S1aRemarks", s1aRemarks);

            SusScoreDict.Add("S2aVal", s2aVal);
            SusScoreDict.Add("S2aScore", s2aScore);
            SusScoreDict.Add("S2aRemarks", s2aRemarks);

            SusScoreDict.Add("S2bVal", s2bVal);
            SusScoreDict.Add("S2bScore", s2bScore);
            SusScoreDict.Add("S2bRemarks", s2bRemarks);

            SusScoreDict.Add("S2cVal", s2cVal);
            SusScoreDict.Add("S2cScore", s2cScore);
            SusScoreDict.Add("S2cRemarks", s2cRemarks);

            SusScoreDict.Add("S2Total", s2Total);

            SusScoreDict.Add("S3aScore", s3aScore);
            SusScoreDict.Add("S3aRemarks", s3aRemarks);

            SusScoreDict.Add("S3bVal", s3bVal);
            SusScoreDict.Add("S3bScore", s3bScore);
            SusScoreDict.Add("S3bRemarks", s3bRemarks);

            SusScoreDict.Add("S3Total", s3Total);

            SusScoreDict.Add("S4aScore", s4aScore);
            SusScoreDict.Add("S4aRemarks", s4aRemarks);

            SusScoreDict.Add("S4bScore", s4bScore);
            SusScoreDict.Add("S4bRemarks", s4bRemarks);

            SusScoreDict.Add("S4cVal", femaleMemberPC);
            SusScoreDict.Add("S4cScore", s4cScore);
            SusScoreDict.Add("S4cRemarks", s4cRemarks);

            SusScoreDict.Add("S4Total", s4Total);

            SusScoreDict.Add("S5aVal", s5aVal);
            SusScoreDict.Add("S5aScore", s5aScore);
            SusScoreDict.Add("S5aRemarks", s5aRemarks);

            SusScoreDict.Add("S5bVal", s5bVal);
            SusScoreDict.Add("S5bScore", s5bScore);
            SusScoreDict.Add("S5bRemarks", s5bRemarks);

            SusScoreDict.Add("S5cVal", s5cVal);
            SusScoreDict.Add("S5cScore", s5cScore);
            SusScoreDict.Add("S5cRemarks", s5cRemarks);

            SusScoreDict.Add("S5dVal", s5dVal);
            SusScoreDict.Add("S5dScore", s5dScore);
            SusScoreDict.Add("S5dRemarks", s5dRemarks);

            SusScoreDict.Add("S5Total", s5Total);

            SusScoreDict.Add("totalScore", totalScore);
            SusScoreDict.Add("inputScore", inputScore);
            SusScoreDict.Add("outputScore", outputScore);

            return SusScoreDict;
        }
    }
}
