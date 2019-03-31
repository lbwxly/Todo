using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Todo.Infrastructure
{
    public class RequestMonitorHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.WriteLine($"Receive request, url:{request.RequestUri.PathAndQuery}.");
            var watch = new Stopwatch();
            watch.Start();
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            watch.Stop();
            Trace.WriteLine(
                $"Completed handling request, url:{request.RequestUri.PathAndQuery}, Status Code:{response.StatusCode}, Time Elapse:{watch.ElapsedMilliseconds} Milliseconds!");
            return response;
        }
    }
}