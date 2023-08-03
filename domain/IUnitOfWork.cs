namespace domain
{
    public interface IUnitOfWork:IDisposable
    {
        Task<bool> CommitAsync();
    }
}
