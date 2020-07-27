using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.ViewModels
{
    public class ProductSellVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public int Quantity { get; set; }
        public string ClientName  { get; set; }
        public string FactorNo { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
