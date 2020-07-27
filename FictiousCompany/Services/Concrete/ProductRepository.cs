using FictiousCompany.Foundational;
using FictiousCompany.Infrastructure;
using FictiousCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Services.Concrete
{
   
        public class ProductRepository : Repository<Product>, IProductRepository
        {
            public ProductRepository(Context context)
                : base(context)
            {
            }

            public void Add(Product product, int userId)
            {

            if (Exists(p => p.Code == product.Code))
            {
                Update(product);
            }
            else
            {

                _context.Products.Add(product);
            }
            }

            public void Delete(int id, int userId)
            {
                var product = SingleOrDefault(t => t.Id == id );

                if (product != null)
                {
                product.Deleted = true;
                }                        
                

            }

            public bool Exists(int ownerId, int productId)
            {
                return Exists(e => e.Id == productId );
            }

            public IEnumerable<Product> GetAll(int ownerId, params string[] includes)
            {
                return GetAll(p => !p.Deleted ,includes: includes);
            }

            public IEnumerable<Product> GetAll(int ownerId, int take, ref int pageNumber, string columnOrder, SortOrderType orderType, out int count)
            {
                var query = GetAll(ownerId, "Categories.Category", "Company");

                string column = columnOrder.ToLower();

                if (column == "name")
                    query = Order(query, t => t.Name, orderType);
                else if (column == "price")
                    query = Order(query, t => t.Price, orderType);
                

                return  GetAll(query, take, ref pageNumber, out count);
            }

         
            public Product GetFullInfo(int id, int userId)
            {
                return _context.Products.Include("MainCategory")
                                         .FirstOrDefault(a =>  a.Id == id);
            }

           

            public void Update(Product product, string imageStr, int userId)
            {
               
                var entity = SingleOrDefault(t => t.Id == product.Id );

                if (entity != null)
                {
                product.Description = product.Description;
                }
            _context.Products.Update(product);
                
            }

            public bool IsAvailable(int id)
            {


                 return _context.Products.FirstOrDefault(p => p.Id == id) == null ? false : true;
            }

            public Product GetProductFullInfo(int id)
            {
                var product = _context.Products .FirstOrDefault(p => p.Id == id);

                return IsAvailable(id) ? product : null;
            }
        }
    }

