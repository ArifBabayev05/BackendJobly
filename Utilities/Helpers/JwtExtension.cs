using System;
using Microsoft.AspNetCore.Http;

namespace Utilities.Helpers
{
    public static class JwtExtension
    {
        public static void AddAplicationError(this HttpResponse response ,string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control", "*");
            response.Headers.Add("Access-Control", "Application Error");
        }
    }
}

