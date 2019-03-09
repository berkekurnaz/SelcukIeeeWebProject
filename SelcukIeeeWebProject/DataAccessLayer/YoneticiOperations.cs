using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.DataAccessLayer
{
    public class YoneticiOperations
    {

        /* Bütün Yoneticilerin Listelenmesi */
        /// <summary>
        /// Butun Yoneticileri Liste Seklinde Geri Dondurur.
        /// </summary>
        public List<Yoneticis> GetAll()
        {
            var list = new List<Yoneticis>();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                foreach (var item in items.FindAll())
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /* Id Numarasına Gore Tek Yoneticinin Getirilmesi */
        /// <summary>
        /// Id Numarasina Gore Tek Bir Yonetici Geri Dondurur.
        /// </summary>
        public Yoneticis GetById(int id)
        {
            var result = new Yoneticis();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                result = items.Find(x => x.Id == id).FirstOrDefault();
            }
            return result;
        }

        /* Yeni Bir Yonetici Ekleme */
        /// <summary>
        /// Icerisine Verilen Yonetici Sinifini Veritabanina Ekler.
        /// </summary>
        public void Add(Yoneticis entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                items.Insert(entity);
            }
        }

        /* Bir Yonetici Silme */
        /// <summary>
        /// Icerisine Verilen Id Numarasina Gore Yoneticiyi Veritabanindan Siler.
        /// </summary>
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                items.Delete(id);
            }
        }

        /* Bir Yonetici Guncelleme */
        /// <summary>
        /// Icerisine Verilen Yonetici Sinifini Veritabanindan Gunceller.
        /// </summary>
        public void Update(Yoneticis entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                items.Update(entity);
            }
        }

        /* Bir Yoneticinin Sisteme Giris Yapmasi */
        /// <summary>
        /// Icerisine Verilen Yonetici Sinifini Sisteme Giris Etmeye Yarar.
        /// </summary>
        public Yoneticis Login(Yoneticis entity)
        {
            var result = new Yoneticis();
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                result = items.Find(x => x.KullaniciAdi == entity.KullaniciAdi && x.Sifre == entity.Sifre).FirstOrDefault();
            }
            return result;
        }

    }
}
