using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolanaClassLibrary.DataAccess
{
    public class DA_GetFees
    {
        public string GetJsonGetFees()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var client = new RestClient("https://testnet.solana.com");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"jsonrpc\":\"2.0\",\"id\":1, \"method\":\"getFees\"}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string s = response.Content;
                return s;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                return s;
            }
        }
    }
}
