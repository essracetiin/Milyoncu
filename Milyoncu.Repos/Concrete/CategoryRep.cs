using Milyoncu.Core;
using Milyoncu.Dal;
using Milyoncu.Entity.Concrete;
using Milyoncu.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milyoncu.Repos.Concrete
{
    public class CategoryRep<T> : BaseRepository<Category>, ICategoryRep where T : class
    {
        public MilyoncuContext _db;
       
        public CategoryRep(MilyoncuContext db) : base(db)
        {
            _db = db;
        }

        public Category CreateCategory(Category category)
        {
            _db.Set<Category>().Add(category);
            return category;
        }

        public Category DeleteCategory(Category category)
        {
            _db.Set<Category>().Remove(category);
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategoryById(int CategoryId)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == CategoryId);
        }

        public Category UpdateCategory(Category category)
        {
            _db.Set<Category>().Update(category);
            return category;

        }
    }
}
