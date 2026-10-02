using Newtonsoft.Json;
using RestSharp;

namespace Comments2026
{
    public class SanitizeService
    {
        public static readonly string SANITIZE_URL = "http://www.purgomalum.com/service/";

        public static string SanitizeTextJSON(string rawValue)
        {
            var client = new RestClient(SANITIZE_URL + "json");
            var request = new RestRequest();

            request.AddParameter("text", rawValue);
            var response = client.Execute(request);
            if(!string.IsNullOrWhiteSpace(response.Content))
            {
                string receivedJSON = response.Content;
                PurgoMalumJSON? sanitizedResponse = JsonConvert.DeserializeObject<PurgoMalumJSON>(receivedJSON);
                return sanitizedResponse?.result;
            }
            return string.Empty;
        }
    }



    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.purgomalum.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.purgomalum.com", IsNullable = false)]
    public partial class PurgoMalum
    {

        private string resultField;

        /// <remarks/>
        public string result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }


    public class PurgoMalumJSON
    {
        public string result { get; set; }
    }



}
