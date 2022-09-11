using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public abstract class BaseService // Need to think about more meaningful name)
    {
        // Camel case)
        public IEnumerable<ProductEntity> SearchbyName(string name, IDataContext context)
        {
            // 1. Do we really need 'Select' operator?
            return context.Products.Where(p => p.Name.ToLower().Contains(name.ToLower())).Select(p => p);
            
            // 2. Try to not make complicated linq queries better to split like this
            // Func<ProductEntity,bool> searchRule = p => p.Name.ToLower().Contains(name.ToLower());
            //
            // return context.Products
            //     .Where(searchRule)
            //     .Select(p => p);
        }
    }
}
