using JobER.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobER.Domain.Exceptions;
using JobER.Domain;

namespace JobER.API.Infrastructure {
    public class SessionHandler : DelegatingHandler {
        public const string AUTHENTICATION_TOKEN_HEADER = "Api-Auth-Token";
        //public const string CULTURE_CODE_HEADER = "Api-Culture-Code";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            IEnumerable<string> headers;

            if (request.Headers.TryGetValues(AUTHENTICATION_TOKEN_HEADER, out headers)) {
                var token = headers.FirstOrDefault();

                if (!string.IsNullOrEmpty(token)) {
                    var service = DependencyResolver.Current.GetService<ISessionService>();
                    try {
                        service.ValidateToken(token);
                        HttpContext.Current.User = JobErSession.Current;
                    } catch (InvalidSessionTokenException) { }
                }
            }

            return base.SendAsync(request, cancellationToken).ContinueWith(task => {
                var response = task.Result;
                return response;
            });
        }
    }
}