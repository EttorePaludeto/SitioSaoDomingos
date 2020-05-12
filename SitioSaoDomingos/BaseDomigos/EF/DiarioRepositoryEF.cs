using SaoDomingos.Dominio.Contracts.Repositories;
using SaoDomingos.Dominio.Entities;

namespace SaoDomingos.Dados.EF
{
    public class DiarioRepositoryEF: RepositoryEF<Diario>, IDiarioRepository
    {
        public DiarioRepositoryEF(AppContexto context): base(context)
        {

        }
    }
}
