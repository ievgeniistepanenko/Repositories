using System.Threading.Tasks;

namespace Repositories.Abstract
{
    public interface ICommandRepositoryAsync : ICommandRepository
    {
        Task SaveAsync();
    }
}