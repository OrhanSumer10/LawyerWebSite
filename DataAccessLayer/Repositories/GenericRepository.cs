using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int ID)
        {
            using var c = new Context();
            return c.Set<T>().Find(ID)!;
        }

        public List<Makale> GetCategoryList()
        {
            using var c = new Context();
            return c.makales!.Include(x => x.category).ToList();

        }

        public List<Makale> GetCategoryListStatus()
        {
            using var c = new Context();
            return c.makales!
                .Include(x => x.category)
                .Where(t => t.MakaleStatus == true)
                .ToList();
        }

        public List<Makale> GetCategoryListStatusLast3()
        {
            using var c = new Context();


            return c.makales!
                .Include(x => x.category)
                .Where(t => t.MakaleStatus == true)
                .OrderByDescending(s => s).Take(3)
                .ToList();

        }

        public List<Dava> GetDavaListStatus()
        {
            using var c = new Context();

            // Null kontrolü ve DavaStatus'u true olanları listeleme
            return c.davas?.Where(t => t.DavaStatus).ToList() ?? new List<Dava>();
        }

        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList(); // filterdan gelen değere göre liseteleme
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
