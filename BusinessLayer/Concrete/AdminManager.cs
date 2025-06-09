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
    public class AdminManager : IGenericService<Admin>
    {
        IGenericDal<Admin> genericDal;

        public AdminManager(IGenericDal<Admin> genericDal)
        {
            this.genericDal = genericDal;
        }

        public Admin GetByID(int ID)
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

        public List<Admin> GetList()
        {
            return genericDal.GetListAll();
        }

        public void TAdd(Admin t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(Admin t)
        {
            genericDal.Update(t);
        }
    }
}
