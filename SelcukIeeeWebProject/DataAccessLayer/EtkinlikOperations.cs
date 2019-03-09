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
        /// <summary>
        /// Butun Etkinlikleri Liste Seklinde Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Id Numarasina Gore Tek Bir Etkinlik Geri Dondurur.
        /// </summary>
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
        /// <summary>
        /// Icerisine Verilen Etkinlik Sinifini Veritabanina Ekler.
        /// </summary>
        public void Add(Etkinliks entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                items.Insert(entity);
            }
        }

        /* Bir Etkinlik Silme */
        /// <summary>
        /// Icerisine Verilen Id Numarasina Gore Etkinligi Veritabanindan Siler.
        /// </summary>
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Etkinliks>("Etkinliks");
                items.Delete(id);
            }
        }

        /* Bir Etkinlik Guncelleme */
        /// <summary>
        /// Icerisine Verilen Etkinlik Sinifini Veritabanindan Gunceller.
        /// </summary>
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
