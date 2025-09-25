using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ConnectionString
    {
        public static string ConString { get; } = @";Database=PolyLoop;
                                                    User Id=api_user;Password=StrongPassword123!;
                                                    TrustServerCertificate=True;";

    }
}
