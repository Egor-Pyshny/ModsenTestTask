namespace Aplication.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IEventRepository eventRepository { get; }
        IImageRepository imageRepository { get; }
        IFileSystemAccessor fileAccessor { get; }

        void Save();
        void Refresh();
    }
}
