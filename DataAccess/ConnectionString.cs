using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ConnectionString
    {
        public static string ConString { get; } = @"Server=CV-2025-0284\MSSQLSERVER01;
                                                    Database=PolyLoop;
                                                    User Id=api_user;Password=StrongPassword123!;
                                                    TrustServerCertificate=True;";

    }
}
