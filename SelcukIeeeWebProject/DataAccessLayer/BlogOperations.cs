using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.DataAccessLayer
{
    public class BlogOperations
    {

        /* Bütün Bloglarin Listelenmesi */
        public List<Blogs> GetAll()
        {
            var list = new List<Blogs>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                foreach (var item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Id Numarasına Gore Tek Blogun Getirilmesi */
        public Blogs GetById(int id)
        {
            var result = new Blogs();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                result = items.Find(x => x.Id == id).FirstOrDefault();
            }
            return result;
        }

        /* Yeni Bir Blog Ekleme */
        public void Add(Blogs entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                items.Insert(entity);
            }
        }

        /* Bir Blog Silme */
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                items.Delete(id);
            }
        }

        /* Bir Blog Guncelleme */
        public void Update(Blogs entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                items.Update(entity);
            }
        }

    }
}
