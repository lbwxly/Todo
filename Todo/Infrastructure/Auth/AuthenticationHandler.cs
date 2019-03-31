using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Todo.Infrastructure.Auth
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            DoAuthentication(request);
            return base.SendAsync(request, cancellationToken);
        }

        private void DoAuthentication(HttpRequestMessage request)
        {
            if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme.Equals("Basic", StringComparison.CurrentCultureIgnoreCase))
            {
                string credential = request.Headers.Authorization.Parameter;
                string rawCredential = Encoding.Default.GetString(Convert.FromBase64String(credential));
                string[] credentialElements = rawCredential.Split(':');
                if (credentialElements.Length == 2 && credentialElements[0] == "jensenw" && credentialElements[1] == "123456")
                {
                    HttpContext.Current.User = new GenericPrincipal(new GenericIdentity("jensen"), new[] {"admin"});
                }
            }
        }
    }
}