using FictiousCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Models
{
    public class Sell
    {

        public int Id { get; set; }
        public string FactorNO { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public string DocumentDate { get; set; }
        public string DocumentNo { get; set; }
        public double TotalPrice { get;  }
        public IEnumerable<SellProducts> SoldProducts { get; set; }

        public static explicit operator Sell(ProductSellVM v)
        {
            throw new NotImplementedException();
        }
    }
}
