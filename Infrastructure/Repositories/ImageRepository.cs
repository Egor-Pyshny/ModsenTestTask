using Aplication.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private AppDbContext _dbContext;

        public ImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Create(string path, Guid eventId)
        {
            var _event = (from e in _dbContext.Events.Include(t => t.Images)
                          where e.Id == eventId
                          select e).FirstOrDefault()
                          ?? throw new NotFoundException($"Event with id={eventId} not Found");
            var newImage = new ImageDbModel();
            newImage.Path = path;
            newImage.Id = Guid.NewGuid();
            newImage.EventId = eventId;
            newImage.Event = _event;
            _event.Images!.Add(newImage);
            _dbContext.Images.Add(newImage);
            return newImage.Id; 
        }

        public int Delete(Guid imageId)
        {
            int res = _dbContext.Images.Where(i => i.Id == imageId).ExecuteDelete();
            return res;
        }

        public string GetPath(Guid imageId)
        {
            var image = (from i in _dbContext.Images
                         where i.Id == imageId
                         select i).FirstOrDefault() 
                         ?? throw new NotFoundException($"Image with id={imageId} not Found");
            return image.Path;
        }
    }
}
