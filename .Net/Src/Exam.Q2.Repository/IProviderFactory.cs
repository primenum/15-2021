namespace Exam.Q2.Repository
{
    public interface IProviderFactory
    {
        IRepositoryProvider GetProvider<T>() where T : IRepositoryProvider;
    }
}