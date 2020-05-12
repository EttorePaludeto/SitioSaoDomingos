using SaoDomingos.Dados.EF;
using SaoDomingos.Dominio.Contracts.Repositories;
using SaoDomingos.Dominio.Entities;
using System.Collections.Generic;

namespace SaoDomingos.Business
{
    public class DiarioServices
    {
        private readonly IUnitOfWork uow;

        public DiarioServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<Diario> GetAll()
        {
            return uow.Diarios.GetAll();
        }

        public Diario GetById(int id)
        {
            return uow.Diarios.GetBy(c => c.Id == id);
        }
    }
}
