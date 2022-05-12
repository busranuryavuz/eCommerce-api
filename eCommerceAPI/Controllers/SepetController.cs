using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace eCommerceAPI.Controllers
{
    public class SepetController:ApiController
    {
        ürünlerEntities4 _ent = new ürünlerEntities4();

        [HttpGet]
        public List<SepetTip> SepetiGetir()
        {
            return _ent.Sepet.Select(p => new SepetTip()
            {
                UrunAdi = p.Urun.Adi,
                Adet = p.Adet,
                ToplamFiyat = p.Adet * p.Urun.Fiyati,
                SepetID = p.SepetID,
            }).ToList();
        }

        [HttpPost]
        public void SepeteYeniKayıtEkle(SepetTip veri)
        {
                Sepet s = new Sepet();
                s.UrunID = veri.UrunID;
                s.Adet = veri.Adet;
                _ent.Sepet.Add(s);
            _ent.SaveChanges();
        }

        [HttpGet]
        public List<SepetTip> SepetSil(int SepetID)
        {
            _ent.Sepet.Remove(_ent.Sepet.Find(SepetID));
            _ent.SaveChanges();
            return SepetiGetir();
        }
    }

    public class SepetTip
    {
        public int SepetID { get; set; }
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public float UrunFiyati { get; set; }
        public double ToplamFiyat { get; set; }
        public int Adet { get; set; }

    }
}