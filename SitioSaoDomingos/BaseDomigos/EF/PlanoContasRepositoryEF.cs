using SaoDomingos.Dominio.Contracts.Repositories;
using SaoDomingos.Dominio.Entities;

namespace SaoDomingos.Dados.EF
{
    public class PlanoContasRepositoryEF : RepositoryEF<PlanoContas>, IPlanoContasRepository
    {
        public PlanoContasRepositoryEF(AppContexto context): base(context)
        {

        }
    }
}
