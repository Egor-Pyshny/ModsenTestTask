using Aplication.Interfaces;
using AutoMapper;
using Infrastructure.Data.Queries;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.Common;
using System.IO;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository userRepository { get; }
        public IEventRepository eventRepository { get; }
        public IImageRepository imageRepository { get; }
        public IFileSystemAccessor fileAccessor { get; }
        private AppDbContext dbContext { get; }

        public UnitOfWork(AppDbContext dbContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dbContext;
            this.userRepository = new UserRepository(dbContext, mapper);
            this.fileAccessor = new FileSystemAccessor(hostEnvironment);
            this.eventRepository = new EventRepository(dbContext, mapper);
            this.imageRepository = new ImageRepository(dbContext);
        }

        public void Save()
        {
            try
            {
                dbContext.SaveChanges();
            } catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException is PostgresException postgresException)
                {
                    throw new DataBaseException(postgresException.Message);
                }
                else { throw ex; }
            }
        }

        public void Refresh()
        {
            RefreshView.Refresh(dbContext);
        }

        private bool disposed = false;
         
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
