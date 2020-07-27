using FictiousCompany.Infrastructure;
using FictiousCompany.Infrastructure.Types;
using FictiousCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Models
{
    public class Product
    {
        
      
       
        [Required]
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int MinQty { get; set; }
        public bool Deleted { get; set; }
        public ProductStatus Status { get; set; }

        

        public static explicit operator Product(ProductEntryVM v)
        {
            throw new NotImplementedException();
        }
    }
}
