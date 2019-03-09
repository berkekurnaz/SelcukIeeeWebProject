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
        /// <summary>
        /// Butun Bloglari Liste Seklinde Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Id Numarasina Gore Tek Bir Blog Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Icerisine Verilen Blog Sinifini Veritabanina Ekler.
        /// </summary>
        public void Add(Blogs entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                items.Insert(entity);
            }
        }

        /* Bir Blog Silme */
        /// <summary>
        /// Icerisine Verilen Id Numarasina Gore Blogu Veritabanindan Siler.
        /// </summary>
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Blogs>("Blogs");
                items.Delete(id);
            }
        }

        /* Bir Blog Guncelleme */
        /// <summary>
        /// Icerisine Verilen Blog Sinifini Veritabanindan Gunceller.
        /// </summary>
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
