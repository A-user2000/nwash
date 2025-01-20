using Wq_Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Service;

namespace Wq_Surveillance.Service
{
    public class TubewellData : ITubewellData
    {
        private readonly WqsContext _wqsContext;
        public TubewellData(WqsContext nwash_dnContext)
        {
            _wqsContext = nwash_dnContext;
        }

        public List<Tubewell> GetTubewellData(string MunCode)
        {
            var hhData = _wqsContext.Tubewells
                            .Where(s => (s.MunCode == MunCode))
                            .OrderByDescending(item => item.Id).ToList();
            return hhData;
        }

        public Tubewell TubewellDetailList(string uuid)
        {
            var hhData = _wqsContext.Tubewells
                            .Where(s => (s.Uuid == uuid))
                            .FirstOrDefault();
            return hhData;
        }

        public Tubewell UpdateTubewellData(Tubewell tData)
        {
            var getData = _wqsContext.Tubewells
                            .Where(s => s.Uuid == tData.Uuid)
                            .FirstOrDefault();

            if (getData != null)
            {
                getData.OwnerName = tData.OwnerName;
                getData.CommunityName = tData.CommunityName;
                getData.WardNo = tData.WardNo;
                getData.TubewellType = tData.TubewellType;
                getData.MalePop = tData.MalePop;
                getData.FemalePop = tData.FemalePop;
                getData.DepthFt = tData.DepthFt;
                getData.ConsYear = tData.ConsYear;
                getData.Condition = tData.Condition;
                getData.PlatformCondition = tData.PlatformCondition;

                if (tData.WsSchemePresentVal == "Yes")
                {
                    getData.WsSchemePresent = true;
                }
                else
                {
                    getData.WsSchemePresent = false;
                }

                if (tData.ProjectBeingConstructedVal == "Yes")
                {
                    getData.ProjectBeingConstructed = true;
                }
                else
                {
                    getData.ProjectBeingConstructed = false;
                }
                _wqsContext.Update(getData);
                _wqsContext.SaveChanges();
                return getData;
            }
            else
            {
                return new Tubewell();
            }
        }

        public int DeleteTubewellData(string uuid)
        {
            var delData = _wqsContext.Tubewells
                            .Where(s => (s.Uuid == uuid))
                            .FirstOrDefault();
            var delValue = 0;

            if (delData != null)
            {
                _wqsContext.Tubewells.Remove(delData);
                delValue = _wqsContext.SaveChanges();
            }

            return delValue;
        }
    }
}
