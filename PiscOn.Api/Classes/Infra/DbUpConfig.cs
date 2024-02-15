using DbUp;
using System.Reflection;

namespace PiscOn.Api.Classes.Infra
{
    public class DbUpConfig
    {
        public static void ExecuteScripts(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .PostgresqlDatabase(connectionString)
                    //.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithScriptsFromFileSystem("Scripts")
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("Falha na execução das migrações do banco de dados", result.Error);
            }
        }
    }

}
