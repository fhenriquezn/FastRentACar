using FastRentACar.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace FastRentACar.DataAccess
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        public TContext Context { get; }


        #region Public Constructor

        public UnitOfWork(TContext context)
        {
            Context = context;
        }

        #endregion

        /// <inheritdoc/>
        public int Commit()
        => Context.SaveChanges();

        /// <inheritdoc/>
        public Task<int> CommitAsync()
        => Context.SaveChangesAsync();

        /// <inheritdoc/>
        public void RollBack()
        => Context.Database.RollbackTransaction();

        public IDbContextTransaction BeginTransaction()
        => Context.Database.BeginTransaction();

        /// <inheritdoc/>
        public void CommitTransaction()
        => Context.Database.CommitTransaction();

        public IExecutionStrategy CreateStrategy()
        => Context.Database.CreateExecutionStrategy();

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Protected Methods

        protected bool _isDisposed;

        protected void CheckDisposed()
        {
            if (_isDisposed) throw new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                    }
                }
            }
            _isDisposed = true;
        }

        #endregion
    }
}
