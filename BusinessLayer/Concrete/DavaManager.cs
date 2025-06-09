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
    public class DavaManager : IGenericService<Dava>
    {
        IGenericDal<Dava> genericDal;

        public DavaManager(IGenericDal<Dava> genericDal)
        {
            this.genericDal = genericDal;
        }

        public Dava GetByID(int ID)
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
            return genericDal.GetListAll(x => x.DavaID == ID);
        }

        public List<Dava> GetDavaListStatus()
        {
            return genericDal.GetDavaListStatus();
        }

        public List<Dava> GetList()
        {
         return  genericDal.GetListAll();
        }

        public void TAdd(Dava t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(Dava t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(Dava t)
        {
            genericDal.Update(t);
        }
    }
}
