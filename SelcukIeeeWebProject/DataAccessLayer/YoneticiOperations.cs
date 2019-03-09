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
        public void Add(Yoneticis entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                items.Insert(entity);
            }
        }

        /* Bir Yonetici Silme */
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                items.Delete(id);
            }
        }

        /* Bir Yonetici Guncelleme */
        public void Update(Yoneticis entity)
        {
            using (var db = new LiteDatabase(@"myDatabase.db"))
            {
                var items = db.GetCollection<Yoneticis>("Yoneticis");
                items.Update(entity);
            }
        }

        /* Bir Yoneticinin Sisteme Giris Yapmasi */
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
