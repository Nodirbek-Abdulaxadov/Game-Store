namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameCategoryInterface GameCategories { get; }
        IGameInterface Games { get; }
        ICommentInterface Comments { get; }
        Task SaveAsync();
    }
}
