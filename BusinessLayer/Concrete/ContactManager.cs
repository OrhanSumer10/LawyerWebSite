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
    public class ContactManager : IGenericService<Contact>
    {
        IGenericDal<Contact> genericDal;

        public ContactManager(IGenericDal<Contact> genericDal)
        {
            this.genericDal = genericDal;
        }

        public Contact GetByID(int ID)
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

        public List<Contact> GetList()
        {
            return genericDal.GetListAll();
        }

        public void TAdd(Contact t)
        {
            genericDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            genericDal.Delete(t);
        }

        public void TUpdate(Contact t)
        {
            genericDal.Update(t);
        }
    }
}
