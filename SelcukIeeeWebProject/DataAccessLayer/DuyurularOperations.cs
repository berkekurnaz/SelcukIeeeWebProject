using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.DataAccessLayer
{
    public class DuyurularOperations
    {

        /* Bütün Duyurularin Listelenmesi */
        /// <summary>
        /// Butun Duyurulari Liste Seklinde Geri Dondurur.
        /// </summary>
        public List<Duyurulars> GetAll()
        {
            var list = new List<Duyurulars>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                foreach (var item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Id Numarasına Gore Tek Duyurunun Getirilmesi */
        /// <summary>
        /// Id Numarasina Gore Tek Bir Duyuru Geri Dondurur.
        /// </summary>
        public Duyurulars GetById(int id)
        {
            var result = new Duyurulars();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                result = items.Find(x => x.Id == id).FirstOrDefault();
            }
            return result;
        }

        /* Yeni Bir Duyuru Ekleme */
        /// <summary>
        /// Icerisine Verilen Duyurular Sinifini Veritabanina Ekler.
        /// </summary>
        public void Add(Duyurulars entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                items.Insert(entity);
            }
        }

        /* Bir Duyuru Silme */
        /// <summary>
        /// Icerisine Verilen Id Numarasina Gore Duyuruyu Veritabanindan Siler.
        /// </summary>
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                items.Delete(id);
            }
        }

        /* Bir Duyuru Guncelleme */
        /// <summary>
        /// Icerisine Verilen Duyurular Sinifini Veritabanindan Gunceller.
        /// </summary>
        public void Update(Duyurulars entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                items.Update(entity);
            }
        }

    }
}
