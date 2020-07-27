using FictiousCompany.Infrastructure;
using FictiousCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Services
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Add(Category category, int userId);

        void Delete(int id, int userId);

        IEnumerable<Category> GetAll( params string[] includes);

        IEnumerable<Category> GetAll( int take, ref int pageNumber, string columnOrder, SortOrderType orderType, out int count);

        void Update(Category category, int userId);
    }
}
