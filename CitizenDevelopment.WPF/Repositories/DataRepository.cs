using CitizenDevelopment.WPF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CitizenDevelopment.WPF.Repositories
{
    internal class DataRepository
    {
        private readonly SQLiteConnection _connection;

        public DataRepository() 
        { 
            _connection = new SQLiteConnection(
                ConfigurationManager
                .ConnectionStrings["SQLiteConnectionString"]
                .ConnectionString);
            _connection.Open();

            CreateDataTableIfNotExists();
        }

        public async Task<bool> TryCreateDataAsync(DataModel data)
        {
            try
            {
                using (var command = new SQLiteCommand(_connection))
                {
                    command.CommandText = $@"INSERT INTO data 
                        (user_name, application_name, comment)
                        VALUES('{data.UserName}', '{data.ApplicationName}', '{data.Comment}');";
                    await command.ExecuteNonQueryAsync();

                    return true;
                }
            } 
            catch(Exception exception)
            {
                //must have a add record of fatal error to log file
                return false;
            }
        }

        public async Task<bool> TryUpdateDataAsync(DataModel data)
        {
            try
            {
                using (var command = new SQLiteCommand(_connection))
                {
                    command.CommandText = $@"UPDATE data 
                        SET user_name = '{data.UserName}',
                        application_name = '{data.ApplicationName}',
                        comment = '{data.Comment}'
                        WHERE data_id = {data.Id};";
                    await command.ExecuteNonQueryAsync();

                    return true;
                }
            }
            catch (Exception exception)
            {
                //must have a add record of fatal error to log file
                return false;
            }
        }

        public async Task<IEnumerable<DataModel>> GetDataListAsync()
        {
            using (var command = new SQLiteCommand(_connection))
            {
                command.CommandText = @"SELECT * FROM data;";
                var reader = await command.ExecuteReaderAsync();

                var results = new List<DataModel>();

                while (reader.Read())
                {
                    results.Add(
                        new DataModel 
                        { 
                            Id = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            ApplicationName = reader.GetString(2),
                            Comment= reader.GetString(3),
                        });
                }

                return results;
            }
        }

        private async void CreateDataTableIfNotExists()
        {
            using (var command = new SQLiteCommand(_connection))
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS [data] (
                        [data_id] integer PRIMARY KEY AUTOINCREMENT,
                        [user_name] char(50) NOT NULL,
                        [application_name] char(50) NOT NULL,
                        [comment] char(250) NOT NULL
                        );";
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
