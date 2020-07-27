using FictiousCompany.Models;
using FictiousCompany.Services;
using FictiousCompany.Services.Concrete;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FictiousCompany.Foundational
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Context _context;

        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ISellRepository _sellRepository;
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => GetFieldValue<Product, IProductRepository, ProductRepository>(ref _productRepository);
        public ICategoryRepository CategoryRepository => GetFieldValue<Category, ICategoryRepository, CategoryRepository>(ref _categoryRepository);
        public ISellRepository SellRepository => GetFieldValue<Sell, ISellRepository, SellRepository>(ref _sellRepository);


        private TInterface GetFieldValue<TEntity, TInterface, TRepository>(ref TInterface field) where TEntity : class, new() where TInterface : IRepository<TEntity> where TRepository : Repository<TEntity>, TInterface
        {
            if (field == null)
                field = (TRepository)Activator.CreateInstance(typeof(TRepository), _context);

            return field;
        }
        #region IDisposable implement

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable implement

        #region public methods

        public IDbContextTransaction BeginTransaction()
        {
            return _context?.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion public methods


    }
}
