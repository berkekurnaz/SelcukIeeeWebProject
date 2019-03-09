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
        /// <summary>
        /// Butun Etkinlik Fotograflarini Liste Seklinde Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Id Numarasina Gore Belirli Bir Etkinligin Fotograflarini Liste Seklinde Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Id Numarasina Gore Tek Bir Etkinlik Fotografi Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Icerisine Verilen Etkinlik Fotograf Sinifini Veritabanina Ekler.
        /// </summary>
        public void Add(EtkinlikFotografs entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                items.Insert(entity);
            }
        }

        /* Bir Etkinlik Fotografi Silme */
        /// <summary>
        /// Icerisine Verilen Id Numarasina Gore Etkinlik Fotografini Veritabanindan Siler.
        /// </summary>
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<EtkinlikFotografs>("EtkinlikFotografs");
                items.Delete(id);
            }
        }

        /* Bir Etkinlik Fotografi Guncelleme */
        /// <summary>
        /// Icerisine Verilen Etkinlik Fotograf Sinifini Veritabanindan Gunceller.
        /// </summary>
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
