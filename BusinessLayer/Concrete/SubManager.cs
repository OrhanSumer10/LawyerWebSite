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
    public class SubManager : IGenericService<SubScribe>
    {
        IGenericDal<SubScribe> genericDal;

        public SubManager(IGenericDal<SubScribe> genericDal)
        {
            this.genericDal = genericDal;
        }

        public SubScribe GetByID(int ID)
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

        public List<SubScribe> GetList()
        {
            return genericDal.GetListAll();
        }

        public void TAdd(SubScribe t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(SubScribe t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(SubScribe t)
        {
            throw new NotImplementedException();
        }
    }
}
