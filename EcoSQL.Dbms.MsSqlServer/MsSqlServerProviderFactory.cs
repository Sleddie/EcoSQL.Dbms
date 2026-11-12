using EcoSQL.Request;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace EcoSQL.Dbms.MsSqlServer;

public class MsSqlServerProviderAdapter : DbmsProviderAdapter
{
    public override DbProviderFactory GetDbProviderFactory() =>
        SqlClientFactory.Instance;
}