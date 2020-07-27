using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Models
{
    public class Category
    {
        public Category()
        {

            Products = new HashSet<CategoryProduct>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required, MaxLength(100)]
        public string Title { get; set; }

        public virtual ICollection<CategoryProduct> Products { get; set; }

    }
}
