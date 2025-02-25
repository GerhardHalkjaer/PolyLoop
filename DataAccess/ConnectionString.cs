using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ConnectionString
    {
        public static string ConString { get; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PolyLoop;
                                    Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                    Trust Server Certificate=False;Application Intent=ReadWrite;
                                    Multi Subnet Failover=False";

    }
}
