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
    public class MakaleManager : IGenericService<Makale>
    {
        IGenericDal<Makale> genericDal;

        public MakaleManager(IGenericDal<Makale> genericDal)
        {
            this.genericDal = genericDal;
        }

        public Makale GetByID(int ID)
        {
            return genericDal.GetById(ID);
        }

        public List<Makale> GetCategoryList()
        {
            return genericDal.GetCategoryList();
        }

        public List<Makale> GetCategoryListStatus()
        {
            return genericDal.GetCategoryListStatus();
        }

        public List<Makale> GetCategoryListStatusLast3()
        {
            return genericDal.GetCategoryListStatusLast3();
        }

        public List<Dava> GetDava(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Dava> GetDavaListStatus()
        {
            throw new NotImplementedException();
        }

        public List<Makale> GetList()
        {
            return genericDal.GetListAll();
        }
        public List<Makale> GetMakID(int ID)
        {
            return genericDal.GetListAll(x => x.MakaleID == ID);
        }
        public void TAdd(Makale t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(Makale t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(Makale t)
        {
            genericDal.Update(t);
        }
    }
}
