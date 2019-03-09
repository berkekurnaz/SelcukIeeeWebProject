using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.DataAccessLayer
{
    public class EtkinlikFotografOperations
    {

        /* Bütün Etkinlik Fotograflarinin Listelenmesi */
        public List<EtkinlikFotografs> GetAll()
        {
            var list = new List<EtkinlikFotografs>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                foreach (var item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Belirli Etkinlige Ait Butun Fotograflarin Getirilmesi */
        public List<EtkinlikFotografs> GetAllByEtkinlik(int id)
        {
            var list = new List<EtkinlikFotografs>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                foreach (var item in items.Find(x => x.EtkinlikId == id))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Id Numarasına Gore Tek Etkinlik Fotografinin Getirilmesi */
        public EtkinlikFotografs GetById(int id)
        {
            var result = new EtkinlikFotografs();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                result = items.Find(x => x.Id == id).FirstOrDefault();
            }
            return result;
        }

        /* Yeni Bir Etkinlik Fotografi Ekleme */
        public void Add(EtkinlikFotografs entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                items.Insert(entity);
            }
        }

        /* Bir Etkinlik Fotografi Silme */
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                items.Delete(id);
            }
        }

        /* Bir Etkinlik Fotografi Guncelleme */
        public void Update(EtkinlikFotografs entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                items.Update(entity);
            }
        }

    }
}
