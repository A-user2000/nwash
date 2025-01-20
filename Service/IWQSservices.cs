using Wq_Surveillance.Models;

namespace Wq_Surveillance.Service
{
    public interface IWQSservices
    {
        public List<Province> GetProvince();

        public string ExtractNumber(string input);
        public Dictionary<string, int> GetHH(string munCode);
        public Dictionary<string, int> GetPop(string munCode);

        public Form1a UpdateWQSDataFA(Form1a WData);
        public Form1b UpdateWQSDataFB(Form1b WData);
        public Form2 UpdateWQSDataF2(Form2 WData);
        public string UpdateWQSDataF3(Form3 WData);
        public ReservoirSanitary UpdateWQSDataRes(ReservoirSanitary WData);
        public SourceSanitary UpdateWQSDataSou(SourceSanitary WData);
        public StructureSanitary UpdateWQSDataStr(StructureSanitary WData);
        public TapSanitary UpdateWQSDataTap(TapSanitary WData);
        public (int?, decimal?) GetPopandHH(string ProCode);
        public Dictionary<string, string> GetFormId(string munCode);
        public Dictionary<string, string> GetAddress(string munCode);
        public int DeleteFA(string FormId);
        public int DeleteFB(string FormId);
        public int Delete2(string FormId);
        public int Delete3(string FormId);
        public int DeleteRes(string FormId);
        public int DeleteSou(string FormId);
        public int DeleteStr(string FormId);
        public int DeleteTap(string FormId);





    }
}
