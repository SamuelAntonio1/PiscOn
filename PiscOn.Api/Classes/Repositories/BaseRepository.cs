using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using System.Text;

namespace PiscOn.Api.Classes.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected IConfiguration Configuration { get; set; }

        protected BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected void Executar(TEntity entity, StringBuilder sql) 
        {
            using (var conexao = new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                conexao.Execute(sql.ToString(), entity);
            }
        }

        protected TEntity Recuperar(object codigo, StringBuilder sql)
        {
            using (var conexao = new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                return conexao.QueryFirstOrDefault<TEntity>(sql.ToString(), codigo);
            }
        }

        protected IEnumerable<TEntity> Lista(StringBuilder sql, object param = null)
        {
            using (var conexao = new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                conexao.Open();
                return conexao.Query<TEntity>(sql.ToString(), param);
            }
        }
    }
}
