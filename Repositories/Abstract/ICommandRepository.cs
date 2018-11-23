namespace Repositories.Abstract
{
    public interface ICommandRepository : ICudRepository
    {
        void Save();
    }
}