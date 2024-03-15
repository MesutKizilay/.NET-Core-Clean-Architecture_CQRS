using Core.CrossCuttingConcerns.SeriLog.ConfigurationModels;
using Core.CrossCuttingConcerns.SeriLog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.SeriLog.Logger
{
    public class MsSqlLogger : LoggerServiceBase
    {

        public MsSqlLogger(IConfiguration configuration)
        {
            MsSqlConfiguration logConfiguration = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
                ?? throw new Exception(SeriLogMessages.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions = new MSSqlServerSinkOptions()
            {
                TableName = logConfiguration.TableName,
                AutoCreateSqlTable = logConfiguration.AutoCreateSqlTable,
            };


            ColumnOptions columnOptions = new ColumnOptions();

            global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration().WriteTo
                .MSSqlServer(connectionString: logConfiguration.ConnectionString,
                             sinkOptions: sinkOptions,
                             columnOptions: columnOptions)
                .CreateLogger();

            Logger = seriLogConfig;
        }
    }
}