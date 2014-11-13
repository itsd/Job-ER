﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace JobER.API {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Error += (e, a) => {
                System.Diagnostics.Debug.WriteLine(e);
            };
        }
    }
}