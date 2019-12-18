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
        [FunctionName("TestFunction")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
             log.Info("C# HTTP trigger function processed a request.");
     string result = "- -";
            if (req.Content.IsMimeMultipartContent())
            {
                var provider = new MultipartMemoryStreamProvider();
                req.Content.ReadAsMultipartAsync(provider).Wait();
                foreach (HttpContent ctnt in provider.Contents)
                {
                    //now read individual part into STREAM
                     var stream = ctnt.ReadAsStreamAsync();
                     return req.CreateResponse(HttpStatusCode.OK, "Stream Length " + stream.Result.Length);

                        using (var ms = new MemoryStream())
                        {
                            //do something with the stream
                        }

                }
            }
            if (req.Content.IsFormData())
            {
                NameValueCollection col = req.Content.ReadAsFormDataAsync().Result;
                return req.CreateResponse(HttpStatusCode.OK, $" {col[0]}");
            }

            // dynamic data = await req.Content.ReadAsFormDataAsync();

            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "Doesn't get anything " + result);
        }
    }
}
