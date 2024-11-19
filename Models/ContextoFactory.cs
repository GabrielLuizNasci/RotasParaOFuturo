using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RotasParaOFuturo.Models
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            // Configuração da string de conexão (substitua pela sua string de conexão real)
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseSqlServer("conexao");  // Substitua com sua string de conexão

            // Retorna uma instância do seu DbContext com a configuração necessária
            return new Contexto(optionsBuilder.Options);
        }
    }
}
