using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace UMP.DocumentFlow.Dtos.Mappers.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NpgsqlDataSourceBuilder dataSourceBuilder = new NpgsqlDataSourceBuilder();

            dataSourceBuilder.ConnectionStringBuilder.Host = "srv-pg2";
            dataSourceBuilder.ConnectionStringBuilder.Port = 5432;
            dataSourceBuilder.ConnectionStringBuilder.Database = "ump_nightly";
            dataSourceBuilder.ConnectionStringBuilder.Username = "u_59968";
            dataSourceBuilder.ConnectionStringBuilder.Password = "123456";
            dataSourceBuilder.ConnectionStringBuilder.ClientEncoding = "WIN1251";

            dataSourceBuilder.UseJsonNet(new[] { typeof(DocumentFullInfoDTO) });

            using (var dataSource = dataSourceBuilder.Build())
            {
                using (var conn = dataSource.OpenConnection())
                {
                    using (var command = dataSource.CreateCommand())
                    {
                        command.CommandText =
                            "select document_json from loodsman_integration.service_notes_uploading_queue where document_json is not null limit 1";

                        var jsonReader = command.ExecuteReader();

                        if (jsonReader.Read())
                        {
                            var documentFullInfoDto = jsonReader.GetFieldValue<DocumentFullInfoDTO>(0);

                            Console.WriteLine(documentFullInfoDto);
                        }
                    }
                }
            }
        }
    }
}
