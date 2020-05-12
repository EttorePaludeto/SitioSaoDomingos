using SaoDomingos.Dominio.Contracts.Repositories;
using SaoDomingos.Dominio.Entities;

namespace SaoDomingos.Dados.EF
{
    public class ParticipanteRepositoryEF : RepositoryEF<Participante>, IParticipanteRepository
    {
        public ParticipanteRepositoryEF(AppContexto context): base(context)
        {

        }
    }
}
