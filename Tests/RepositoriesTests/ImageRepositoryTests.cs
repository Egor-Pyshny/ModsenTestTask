using Infrastructure.Data;
using Infrastructure.Data.DataBaseModels;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.RepositoriesTests
{
    [TestFixture]
    public class ImageRepositoryTests
    {
        [Test]
        public void Create_Should_CreateNewImageAndReturnImageId()
        {
            var dbContext = CreateMockDbContext();
            var repository = new ImageRepository(dbContext);   
        }

        private IQueryable<ImageDbModel> GetMockImageData()
        {
            var imageData = new List<ImageDbModel>
            {
                new ImageDbModel { Id = Guid.NewGuid(), Path = "image1.jpg" },
                new ImageDbModel { Id = Guid.NewGuid(), Path = "image2.jpg" },
            };
            return imageData.AsQueryable();
        }

        private IQueryable<EventDbModel> GetMockEventData()
        {
            var eventData = new List<EventDbModel>
            {
                new EventDbModel { Id = Guid.NewGuid(), Images = new List<ImageDbModel>() },
                new EventDbModel { Id = Guid.NewGuid(), Images = new List<ImageDbModel>() },
            };
            return eventData.AsQueryable();
        }

        private AppDbContext CreateMockDbContext()
        {
            var mockImageDbSet = new Mock<DbSet<ImageDbModel>>();
            mockImageDbSet.As<IQueryable<ImageDbModel>>().Setup(m => m.Provider)
                .Returns(GetMockImageData().Provider);
            mockImageDbSet.As<IQueryable<ImageDbModel>>().Setup(m => m.Expression)
                .Returns(GetMockImageData().Expression);
            mockImageDbSet.As<IQueryable<ImageDbModel>>().Setup(m => m.ElementType)
                .Returns(GetMockImageData().ElementType);
            mockImageDbSet.As<IQueryable<ImageDbModel>>().Setup(m => m.GetEnumerator())
                .Returns(() => GetMockImageData().GetEnumerator());

            var mockEventDbSet = new Mock<DbSet<EventDbModel>>();
            mockEventDbSet.As<IQueryable<EventDbModel>>().Setup(m => m.Provider)
                .Returns(GetMockEventData().Provider);
            mockEventDbSet.As<IQueryable<EventDbModel>>().Setup(m => m.Expression)
                .Returns(GetMockEventData().Expression);
            mockEventDbSet.As<IQueryable<EventDbModel>>().Setup(m => m.ElementType)
                .Returns(GetMockEventData().ElementType);
            mockEventDbSet.As<IQueryable<EventDbModel>>().Setup(m => m.GetEnumerator())
                .Returns(() => GetMockEventData().GetEnumerator());

            var mockDbContext = new Mock<AppDbContext>();
            mockDbContext.Setup(c => c.Images).Returns(mockImageDbSet.Object);
            mockDbContext.Setup(c => c.Events).Returns(mockEventDbSet.Object);
            return mockDbContext.Object;
        }
    }
}
