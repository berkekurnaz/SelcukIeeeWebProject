using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.DataAccessLayer
{
    public class IletisimOperations
    {

        /* Bütün Mesajlarin Listelenmesi */
        public List<Iletisims> GetAll()
        {
            var list = new List<Iletisims>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Iletisims>("Iletisims");
                foreach (var item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Id Numarasına Gore Tek Mesajin Getirilmesi */
        public Iletisims GetById(int id)
        {
            var result = new Iletisims();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Iletisims>("Iletisims");
                result = items.Find(x => x.Id == id).FirstOrDefault();
            }
            return result;
        }

        /* Yeni Bir Mesaj Ekleme */
        public void Add(Iletisims entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Iletisims>("Iletisims");
                items.Insert(entity);
            }
        }

        /* Bir Mesaj Silme */
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Iletisims>("Iletisims");
                items.Delete(id);
            }
        }

        /* Bir Mesaj Guncelleme */
        public void Update(Iletisims entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Iletisims>("Iletisims");
                items.Update(entity);
            }
        }

    }
}
