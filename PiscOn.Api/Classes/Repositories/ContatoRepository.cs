using PiscOn.Api.Classes.Models;
using System.Text;

namespace PiscOn.Api.Classes.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>
    {
        public ContatoRepository(IConfiguration configuration) : base(configuration)
        {
        }
        
        public List<Contato> Lista()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT \"CodigoContato\", \"Nome\", \"Celular\", \"CPF\", \"Email\" ");
            sql.AppendLine("  FROM public.\"Contato\" ");
            sql.AppendLine(" ORDER BY \"Nome\" ");

            return Lista(sql).ToList(); 
        }
        
        public void Inserir(Contato contato) 
        {
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO public.\"Contato\" (\"CodigoContato\", \"Nome\", \"Celular\", \"CPF\", \"Email\")");
            sql.AppendLine("VALUES(nextval('\"Contato_CodigoContato_seq\"'::regclass), @Nome, @Celular, @CPF, @Email) ");

            Executar(contato, sql);
        }

        public void Atualizar(Contato contato) {
            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE public.\"Contato\" ");
            sql.AppendLine("    SET \"Nome\"=@Nome, \"Celular\" = @Celular, \"CPF\" = @CPF, \"Email\" = @Email ");
            sql.AppendLine("  WHERE \"CodigoContato\" = @CodigoContato ");

            Executar(contato, sql);
        }

        public Contato Recuperar(int codigo)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT \"CodigoContato\", \"Nome\", \"Celular\", \"CPF\", \"Email\" ");
            sql.AppendLine("   FROM public.\"Contato\" ");
            sql.AppendLine("  WHERE \"CodigoContato\" = @CodigoContato ");

            return Recuperar(new { CodigoContato = codigo }, sql);
        }

        public void Excluir(Contato contato)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" DELETE FROM public.\"Contato\" WHERE \"CodigoContato\" = @CodigoContato ");

            Executar(contato, sql);
        }
    }
}
