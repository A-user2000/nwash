using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data.Entity;

namespace Wq_Surveillance
{
    internal static class AppConfiguration
    {
        internal static string DefaultConnection;
        internal static string NwashConnection;

        public static void LoadConfig(WebApplicationBuilder builder)
        {
            DefaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            NwashConnection = builder.Configuration.GetConnectionString("NwashConnection");           
        }
    }
}
