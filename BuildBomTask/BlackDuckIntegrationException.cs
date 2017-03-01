﻿using System;
using System.Net.Http;

namespace Com.Blackducksoftware.Integration.Hub.Nuget
{
    class BlackDuckIntegrationException : Exception
    {

        public BlackDuckIntegrationException(): base()
        {

        }

        public BlackDuckIntegrationException(string message) : base(message)
        {
        }

        public BlackDuckIntegrationException(HttpResponseMessage content) : base($"Response returned with: {content.ReasonPhrase}")
        {
       
        }
    }
}