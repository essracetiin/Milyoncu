using Milyoncu.Core;
using Milyoncu.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Abstract
{
    public interface ICategoryRep : IBaseRepository<Category>
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        Category DeleteCategory(Category category);
        public bool DeleteCategoryById(int categoryId);
    }
}
