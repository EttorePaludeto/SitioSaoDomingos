namespace SaoDomingos.Dominio.Contracts.Repositories
 {
    public interface IUnitOfWork
    {
        IDiarioRepository Diarios { get; }
        IUsuarioRepository Usuarios { get; }
        IParticipanteRepository Participantes { get; }
        IPlanoContasRepository PlanosContas { get; }
       
        bool IsConnect();

        void Commit();
    }
}

