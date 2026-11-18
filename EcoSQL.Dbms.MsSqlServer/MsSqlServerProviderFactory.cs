using EcoSQL.Connect;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace EcoSQL.Dbms.MsSqlServer;

public class MsSqlServerProviderAdapter : DbmsProviderAdapter
{
    /// <inheritdoc/>
    public override DbProviderFactory GetDbProviderFactory() =>
        SqlClientFactory.Instance;

    /// <inheritdoc/>
    public override string GetConnectionString(ConnectionStringParameters parameters) =>
        throw new NotImplementedException();
}