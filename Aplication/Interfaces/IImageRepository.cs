namespace Aplication.Interfaces
{
    public interface IImageRepository
    {
        Guid Create(string path, Guid eventId);
        int Delete(Guid imageId);
        string GetPath(Guid imageId);
    }
}
