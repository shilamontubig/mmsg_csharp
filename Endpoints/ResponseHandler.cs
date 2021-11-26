using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace mmsg_csharp{

    public class ResponseHandler {


        public string getJsonElement(IRestResponse response, string path) {
            JObject content = JObject.Parse(response.Content);
            return (string)content[path];
        }

       public OBJ GetContent<OBJ>(IRestResponse response) {
            OBJ deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<OBJ>(response.Content);
            return deserializeObject;
        }

        public OBJ GetContent<OBJ>(string strResponse) {
            OBJ deserializeObject = Newtonsoft.Json.JsonConvert.DeserializeObject<OBJ>(strResponse);
            return deserializeObject;
        }

        public String ConvertToJson<O>(O obj){
            string jsonString = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore});
            return jsonString;
        }

    }
}