using System.Xml.Serialization;
using Newtonsoft.Json;
using RestSharp;

namespace Comments2026;

public class SanitizeService
{
    public static readonly string SANITIZE_URL = "http://www.purgomalum.com/service/";

    public static string SanitizeTextJSON(string rawValue)
    {
        var client = new RestClient(SANITIZE_URL + "json");
        var request = new RestRequest();
        
        request.AddParameter("text", rawValue);
        var response = client.Execute(request);
        if (!string.IsNullOrWhiteSpace(response.Content))
        {
            string receivedJson = response.Content;
            PurgoMalumJSON? sanitizedResponse = JsonConvert.DeserializeObject<PurgoMalumJSON>(receivedJson);
            return sanitizedResponse?.result;
        }
        return string.Empty;
    }

    public static string SanitizeTextXML(string rawValue)
    {
        var client = new RestClient(SANITIZE_URL + "xml");
        var request = new RestRequest();
        
        request.AddParameter("text", rawValue);
        var response = client.Execute(request);
        if (!string.IsNullOrWhiteSpace(response.Content))
        {
            string receivedXML = response.Content;
            var serializer = new XmlSerializer(typeof(PurgoMalum));
            using (StringReader sr = new(response.Content))
            {
                PurgoMalum? sanitizedtext = (PurgoMalum?)serializer.Deserialize(sr);
                return sanitizedtext.result;
            }
        }
        return string.Empty;
    }
}

//Class generated from JSON
public class PurgoMalumJSON
{
    public string result { get; set; }
}

//Class generated from XML
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
