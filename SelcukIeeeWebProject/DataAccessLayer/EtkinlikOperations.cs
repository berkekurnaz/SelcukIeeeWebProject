using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.DataAccessLayer
{
    public class EtkinlikOperations
    {

        /* Bütün Etkinliklerin Listelenmesi */
        public List<Etkinliks> GetAll()
        {
            var list = new List<Etkinliks>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                foreach (var item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Id Numarasına Gore Tek Etkinligin Getirilmesi */
        public Etkinliks GetById(int id)
        {
            var result = new Etkinliks();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                result = items.Find(x => x.Id == id).FirstOrDefault();
            }
            return result;
        }

        /* Yeni Bir Etkinlik Ekleme */
        public void Add(Etkinliks entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                items.Insert(entity);
            }
        }

        /* Bir Etkinlik Silme */
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                items.Delete(id);
            }
        }

        /* Bir Etkinlik Guncelleme */
        public void Update(Etkinliks entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                items.Update(entity);
            }
        }

    }
}
