using SaoDomingos.Dominio.Contracts.Repositories;
using System;

namespace SaoDomingos.Dados.EF
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private AppContexto _ctx = null;

        private DiarioRepositoryEF _DiarioRepositoryEF = null;
        private UsuarioRepositoryEF _UsuarioRepositoryEF = null;
        private ParticipanteRepositoryEF _ParticipanteRepositoryEF = null;
        private PlanoContasRepositoryEF _PlanoContasRepositoryEF = null;


        public IDiarioRepository Diarios
        {
            get
            {
                if (_DiarioRepositoryEF ==null)
                {
                    _DiarioRepositoryEF = new DiarioRepositoryEF(_ctx);
                }
                return _DiarioRepositoryEF;
            }
        }
        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_UsuarioRepositoryEF == null)
                {
                    _UsuarioRepositoryEF = new UsuarioRepositoryEF(_ctx);
                }
                return _UsuarioRepositoryEF;
            }
        }
        public IParticipanteRepository Participantes
        {
            get
            {
                if (_ParticipanteRepositoryEF == null)
                {
                    _ParticipanteRepositoryEF = new ParticipanteRepositoryEF(_ctx);
                }
                return _ParticipanteRepositoryEF;
            }
        }
        public IPlanoContasRepository PlanosContas
        {
            get
            {
                if (_PlanoContasRepositoryEF == null)
                {
                    _PlanoContasRepositoryEF = new PlanoContasRepositoryEF(_ctx);
                }
                return _PlanoContasRepositoryEF;
            }
        }

        public UnitOfWork()
        {
            _ctx = new AppContexto();
        }
        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public bool IsConnect()
        {
            try
            {
                _ctx.Database.Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}
