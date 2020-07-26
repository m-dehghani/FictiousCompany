using FictiousCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Services
{
    public interface IProductRepository : IRepository<Product>
    {
        void Add(Product product, string imageStr, int userId);

        void Delete(int id, int userId);

        bool Exists(int ownerId, int productId);

        IEnumerable<Product> GetAll(int ownerId, params string[] includes);

        IEnumerable<Product> GetAll(int ownerId, int take, ref int pageNumber, string columnOrder, SortOrderType orderType, out int count);

       
        Product GetFullInfo(int id, int userId);

        void Update(Product product, List<int> allergicStuffsId, string imageStr, int userId);

        bool IsAvailable(int id);

        Product GetProductFullInfo(int id);
    }
}
