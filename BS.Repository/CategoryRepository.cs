
namespace BS.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using BS.Models;
    using BS.DataAccessLayer;
    using System;
    using PagedList;

    public class CategoryRepository : ICategory
    {

        private BookDbContext dBContext;
        public CategoryRepository(BookDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public ICollection<Category> GetAll()
        {
            return dBContext.Categories.ToList();
        }

        public Category GetById(object id)
        {
            if (id != null && int.TryParse(id.ToString(), out int categoryId))
            {
                return dBContext.Categories.FirstOrDefault(x => x.CateId == categoryId);
            }

            return null; // or handle the case when id is null or not convertible
        }


        public void Insert(Category t)
        {
            dBContext.Categories.Add(t);
        }

        public void Update(Category t)
        {
            dBContext.Entry<Category>(t).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            var category = dBContext.Categories.Where(x => x.CateId == id).SingleOrDefault();
            dBContext.Categories.Remove(category);
        }
        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Category> GetPartial()
        {
            return dBContext.Categories.Take(6).ToList();
        }

        public int CountAll()
        {
            int result = dBContext.Categories.ToList().Count;
            return result;
        }

        public IEnumerable<Category> ListAllPaging(string search,int page, int pageSize)
        {
            IQueryable<Category> model = dBContext.Categories;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.CateName.Contains(search));
            }
            return model.OrderBy(x=>x.CateId).ToPagedList(page,pageSize);
        }
    }
}
