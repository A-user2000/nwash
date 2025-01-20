using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wq_Surveillance.Models;

namespace Wq_Surveillance.Service
{
    public interface ITubewellData
    {
        public List<Tubewell> GetTubewellData(string MunCode);
        public Tubewell TubewellDetailList(string uuid);
        public Tubewell UpdateTubewellData(Tubewell tData);
        public int DeleteTubewellData(string uuid);
    }
}
