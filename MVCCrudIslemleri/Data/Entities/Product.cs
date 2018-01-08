using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrudIslemleri.Data.Entities
{



  
    public class Product:EntityBase
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        
        public int CategoryId { get; set; }

        
        public virtual Category Category { get; set; }

        
    }
}