using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FictiousCompany;
using FictiousCompany.Models;
using FictiousCompany.Foundational;
using FictiousCompany.Infrastructure;
using FictiousCompany.Infrastructure.Types;
using FictiousCompany.ViewModels;

namespace FictiousCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiBaseController
    {
        

        public ProductsController(IUnitOfWork unitOfWork)
             : base(unitOfWork)
        {
        }
       
        
        [HttpGet("ListProducts")]
        public ActionResult<DoneResult> ListProducts([FromQuery] CollectionRequest request)
        {
            int pageNumber = request.PageNumber;
            var products = UnitOfWork.ProductRepository.GetAll(CurrentUserId, request.Take, ref pageNumber, request.SortField, request.SortOrder, out int totalCount).ToList();
            return new DoneResult(ResultType.Successful, data: products);
        }

        // GET: api/Products
        [HttpGet]
        public DoneResult GetProducts()
        {
            try
            {
                string[] includes = {  "Category" };
                var products =  UnitOfWork.ProductRepository.GetAll(CurrentUserId, includes).Select(p => (ProductVM)p).ToList();
                
                return new DoneResult(ResultType.Successful, data: products);
            }
            catch (Exception ex)
            {
                return Common.Instance.GetExceptionResult(ex);
            }

        }

        // GET: api/Products/5
        [HttpGet("{code}")]
        public async Task<ActionResult<Product>> GetProduct(int code)
        {
            var product = UnitOfWork.ProductRepository.Get(p => p.Code == code);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{code}")]
        public async Task<IActionResult> PutProduct(int code, Product product)
        {
            if (code != product.Code)
            {
                return BadRequest();
            }
            UnitOfWork.ProductRepository.Update(product);
           
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            UnitOfWork.ProductRepository.Add(product);
           
            return CreatedAtAction("GetProduct", new { id = product.Code }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            UnitOfWork.ProductRepository.Delete(id, GetUserId());
           
        }

        private bool ProductExists(int code)
        {
            return UnitOfWork.ProductRepository.Exists(p => p.Code == code);
        }

        [HttpPost("ProductEntry")]
        public void ProductEntry([FromBody] ProductEntryVM productEntryVM)
        {
            UnitOfWork.ProductRepository.Update((Product)productEntryVM);
        
        }

         



    }
}
