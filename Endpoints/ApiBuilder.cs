using System;
using System.Collections.Generic;
using RestSharp;

namespace mmsg_csharp.Endpoints {

    public class ApiBuilder {

        public RestClient _restClient;
        public RestRequest _restRequest;

        public RestClient SetUrl(string baseUrl, string resourceUrl) {
            var url = baseUrl+resourceUrl;
            Console.WriteLine(url);
            _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest CreatePostRequest(string payload, List<KeyValuePair<string, string>> headers=null) {
            var defHeaders = headers == null ? DefaultHeaders() : headers;
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeaders(defHeaders)
                        .AddJsonBody(payload);
            return _restRequest; 
        }

        public RestRequest CreatePatchRequest(string payload, List<KeyValuePair<string, string>> headers=null) {
            var defHeaders = headers == null ? DefaultHeaders() : headers;
            _restRequest = new RestRequest(Method.PATCH);
            _restRequest.AddHeaders(defHeaders)
                        .AddJsonBody(payload);
            return _restRequest; 
        }

        public RestRequest CreateGetRequest(IDictionary<string, string> filters=null, List<KeyValuePair<string, string>> headers = null) {
            _restRequest = new RestRequest(Method.GET);
            
            //check if headers are available
            var defHeaders = headers == null ? DefaultHeaders() : headers;
             _restRequest.AddHeaders(defHeaders);

             //add get parameters if filters are available
            if(filters != null ){
                    foreach(var f in filters){
                    _restRequest.AddParameter(f.Key, f.Value, ParameterType.QueryString);
                }
            }
            return _restRequest; 
        }

        public RestRequest CreateDeleteRequest(List<KeyValuePair<string, string>> headers=null) {
            var defHeaders = headers == null ? DefaultHeaders() : headers;
            _restRequest = new RestRequest(Method.DELETE);
            _restRequest.AddHeaders(defHeaders);
            return _restRequest; 
        }

        public IRestResponse GetResponse(RestClient _restClient, RestRequest _restRequest) {
            return _restClient.Execute(_restRequest);
        }

        private List<KeyValuePair<string, string>> DefaultHeaders() {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Accept", "application/json"));
            headers.Add(new KeyValuePair<string, string>("Content-Type", "application/json"));
            return headers;
        }

    }

}

