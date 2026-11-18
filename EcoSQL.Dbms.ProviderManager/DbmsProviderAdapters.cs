using EcoSQL.Dbms.MsSqlServer;
using EcoSQL.Dbms.PostgreSql;
using System.Data.Common;

namespace EcoSQL.Dbms;

public static class DbmsProviderAdapters
{
    public static DbmsProviderAdapter? GetDbmsProviderAdapter(DbmsName dbms) =>
        dbms switch
        {
            DbmsName.PostgreSql => new PostgreSqlProviderAdapter(),
            DbmsName.MsSqlServer => new MsSqlServerProviderAdapter(),
            _ => null
        };

    public static DbProviderFactory? GetDbProviderFactory(DbmsName dbms) =>
        GetDbmsProviderAdapter(dbms)?.GetDbProviderFactory();
}