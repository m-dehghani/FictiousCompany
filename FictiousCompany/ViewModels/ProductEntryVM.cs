using FictiousCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.ViewModels
{
    public class ProductEntryVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string FactorNo { get; set; }
        public DateTime Date { get; set; }
    }
}
