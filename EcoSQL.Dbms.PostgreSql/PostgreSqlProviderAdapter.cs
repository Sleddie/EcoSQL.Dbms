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
    public override NpgsqlConnectionStringBuilder GetDbConnectionStringBuilder() =>
        new();

    /// <inheritdoc/>
    public override bool ValidateConnectionStringParameters(ConnectionStringParameters parameters)
    {
        string validationMessage = "";
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(parameters.DataSource))
        {
            validationMessage += $"Hostname or ip-address of the server should be specified " +
                $"in the {parameters.DataSource} property.{Environment.NewLine}";
            isValid = false;
        }

        if (parameters.Port is null or < 0)
        {
            parameters.Port = 5432;
            validationMessage += $"Port is not specified. The default port 5432 will be used.";
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(parameters.Database))
        {
            parameters.Database = "postgres";
            validationMessage += $"Database name is not specified. The default database \'postgres\' name will be used.";
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(parameters.Username))
        {
            parameters.Username = "postgres";
            validationMessage += $"User name is not specified. The default username \'postgres\' will be used.";
            isValid = false;
        }

        return isValid;
    }

    /// <inheritdoc/>
    public override string GetConnectionString(ConnectionStringParameters parameters)
    {
        if (!ValidateConnectionStringParameters(parameters))
            return "";

        var connectionStringBuilder = GetDbConnectionStringBuilder();
        connectionStringBuilder.Host = parameters.DataSource;

        if (parameters.Port is int port)
            connectionStringBuilder.Port = port;

        connectionStringBuilder.Database = parameters.Database;
        connectionStringBuilder.Username = parameters.Username;
        connectionStringBuilder.Password = parameters.Password;

        if (parameters.Timeout is int connectionTimeout)
            connectionStringBuilder.Timeout = connectionTimeout;

        return connectionStringBuilder.ConnectionString;
    }
}
