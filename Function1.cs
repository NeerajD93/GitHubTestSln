using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace GitHubTestSln
{
    public static class Function1
    {
        [FunctionName("TestFunctionFn")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
             log.Info("C# HTTP trigger function processed a request.");

            /*// parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            // Get request body
            dynamic data = await req.Content.ReadAsStringAsync();

            // Set name to query string or body data
            name = name ?? data?.name; */

            //return name == null
              //  ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
           return req.CreateResponse(HttpStatusCode.OK, "Hi Neeraj");
        }
    }
}
