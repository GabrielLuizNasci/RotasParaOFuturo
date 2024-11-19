using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RotasParaOFuturo.Models
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            // Cria a configuração para ler o arquivo appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Define o diretório de onde o arquivo de configuração será lido
                .AddJsonFile("appsettings.json")  // Lê o arquivo appsettings.json
                .Build();

            // Obtém a string de conexão do arquivo appsettings.json
            var connectionString = configuration.GetConnectionString("conexao");

            // Cria o DbContextOptionsBuilder com a string de conexão
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseSqlServer(connectionString);  // Usando a string de conexão

            // Retorna uma instância do Contexto com as opções configuradas
            return new Contexto(optionsBuilder.Options);
        }
    }
}
