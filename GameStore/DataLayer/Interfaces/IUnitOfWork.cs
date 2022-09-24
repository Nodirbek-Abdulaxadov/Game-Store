namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameCategoryInterface GameCategories { get; }
        IGameInterface Games { get; }

        Task SaveAsync();
    }
}
