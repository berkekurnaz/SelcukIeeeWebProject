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
        public void Add(Duyurulars entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                items.Insert(entity);
            }
        }

        /* Bir Duyuru Silme */
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Duyurulars>("Duyurulars");
                items.Delete(id);
            }
        }

        /* Bir Duyuru Guncelleme */
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
