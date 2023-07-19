using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Domain;
using ApiDevsuCMunoz.Infrestructure.Persistence;

namespace ApiDevsuCMunoz.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApiDevsuCMunozDbContext context) : base(context)
        {
        }

    }
}
