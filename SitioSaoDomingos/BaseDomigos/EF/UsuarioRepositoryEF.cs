using SaoDomingos.Dominio.Contracts.Repositories;
using SaoDomingos.Dominio.Entities;

namespace SaoDomingos.Dados.EF
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(AppContexto context): base(context)
        {

        }
    }
}
