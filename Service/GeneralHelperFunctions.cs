namespace Wq_Surveillance.Services
{
    public class GeneralHelperFunctions
    {
        public string ImgGetUUid(string tblname) //generate uuid for images
        {
            var uuid = (Guid.NewGuid()).ToString("D").ToLower(); var result = 0; var count = 0;
            return uuid;
        }
    }
}
