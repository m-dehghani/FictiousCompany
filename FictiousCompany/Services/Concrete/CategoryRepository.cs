using FictiousCompany.Foundational;
using FictiousCompany.Infrastructure;
using FictiousCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Services.Concrete
{
    public class CategoryRepository:  Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context)
           : base(context)
        {
        }
        public void Add(Category category,  int userId)
        {
            
            var entity = new Category() { Title = category.Title };
            Add(entity);
            
        }

        public void Delete(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Category> GetAll(params string[] includes)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Category> GetAll(int take, ref int pageNumber, string columnOrder, SortOrderType orderType, out int count)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
