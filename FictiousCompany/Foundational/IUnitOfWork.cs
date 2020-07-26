using FictiousCompany.Models;
using FictiousCompany.Services;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Foundational
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IDbContextTransaction BeginTransaction();


        void Rollback();

        int SaveChanges();

        Task<int> SaveChangesAsync();

    }
}
