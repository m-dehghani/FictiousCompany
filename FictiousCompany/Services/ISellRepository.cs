using FictiousCompany.Infrastructure;
using FictiousCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Services
{
    public interface ISellRepository: IRepository<Sell>
    {
        void Add(Sell sell, int userId);

        void Delete(int id, int userId);

        IEnumerable<Sell> GetAll(params string[] includes);

        IEnumerable<Sell> GetAll(int take, ref int pageNumber, string columnOrder, SortOrderType orderType, out int count);

        void Update(Category category, int userId);
    }
}
