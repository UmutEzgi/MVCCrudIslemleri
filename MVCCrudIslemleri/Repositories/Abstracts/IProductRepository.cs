using MVCCrudIslemleri.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudIslemleri.Repositories.Abstracts
{
    public interface IProductRepository:IRepository<Product>
    {
        //ek işlem varsa buraya yazılır    
    }
}
