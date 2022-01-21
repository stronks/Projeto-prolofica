using Repositorio.Interfaces;

namespace AEC.Repositorio
{
    public class ConexaoBancoDadosRepositorio : IConexaoBancoDadosRepositorio
    {

        private readonly string ConnectionString;

        public ConexaoBancoDadosRepositorio( string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConectionString()
        {
            return ConnectionString;
        }
      
    }
}
