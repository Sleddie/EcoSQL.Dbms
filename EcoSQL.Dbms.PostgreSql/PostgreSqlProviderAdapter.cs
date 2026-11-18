using EcoSQL.Connect;
using Npgsql;
using System.Data.Common;

namespace EcoSQL.Dbms.PostgreSql;

public class PostgreSqlProviderAdapter : DbmsProviderAdapter
{
    /// <inheritdoc/>
    public override DbProviderFactory GetDbProviderFactory() =>
        NpgsqlFactory.Instance;

    /// <inheritdoc/>
    public override string GetConnectionString(ConnectionStringParameters parameters) =>
        throw new NotImplementedException();
}