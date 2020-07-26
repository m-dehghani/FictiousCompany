using FictiousCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool Deleted { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }

        public static explicit operator ProductVM(Product v)
        {
            throw new NotImplementedException();
        }
    }
}
