using Npgsql;
using System.Data.Common;

namespace EcoSQL.Dbms.PostgreSql;

public class PostgreSqlProviderAdapter : DbmsProviderAdapter
{
    public override DbProviderFactory GetDbProviderFactory() =>
        NpgsqlFactory.Instance;
}