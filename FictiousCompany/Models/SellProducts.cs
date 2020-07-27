using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Models
{
    public class SellProducts
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        [ForeignKey("Product")]
        public virtual int ProductCode { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Sell")]
        public virtual int SellId { get; set; }
        public virtual  Sell Sell { get; set; }


    }
}
