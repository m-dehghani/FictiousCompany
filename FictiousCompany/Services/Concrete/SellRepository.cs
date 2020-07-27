using FictiousCompany.Foundational;
using FictiousCompany.Infrastructure;
using FictiousCompany.Infrastructure.Types;
using FictiousCompany.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Services.Concrete
{
    public class SellRepository : Repository<Sell>, ISellRepository
    {
        public SellRepository(Context context)
         : base(context)
        {
        }
        public void Add(Sell sell, int userId)
        {
            foreach (var p in sell.SoldProducts)
            {
                var prod = _context.Products.FirstOrDefault(prop => prop.Code == p.ProductCode);
                if (prod == null || prod.Quantity - p.Qty <= prod.MinQty) return;
                else
                {
                    prod.Quantity -= p.Qty;
                    _context.Sells.Add(sell);
                    if (prod.Quantity <= prod.MinQty) prod.Status = ProductStatus.UnAvailable;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Sell> GetAll(params string[] includes)
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Sell> GetAll(int take, ref int pageNumber, string columnOrder, SortOrderType orderType, out int count)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
