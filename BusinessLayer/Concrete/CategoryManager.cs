using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : IGenericService<Category>
    {
        IGenericDal<Category> genericDal;

        public CategoryManager(IGenericDal<Category> genericDal)
        {
            this.genericDal = genericDal;
        }

        public Category GetByID(int ID)
        {
            return genericDal.GetById(ID);
        }

        public List<Makale> GetCategoryList()
        {
            throw new NotImplementedException();
        }

        public List<Makale> GetCategoryListStatus()
        {
            throw new NotImplementedException();
        }

        public List<Makale> GetCategoryListStatusLast3()
        {
            throw new NotImplementedException();
        }

        public List<Dava> GetDava(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Dava> GetDavaListStatus()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetList()
        {
            return genericDal.GetListAll();
        }

        public void TAdd(Category t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            genericDal.Update(t);
        }
    }
}
