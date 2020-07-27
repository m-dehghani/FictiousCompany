using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Models
{
    public class CategoryProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductCode { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        

        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }

    }
}
