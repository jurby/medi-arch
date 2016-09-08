using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediArch.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>() where T : class;
    }
}
