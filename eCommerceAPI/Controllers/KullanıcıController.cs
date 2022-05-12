using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace eCommerceAPI.Controllers
{
    public class KullanıcıController:ApiController
    {
        ürünlerEntities4 _ent = new ürünlerEntities4(); 

        [HttpGet]

        public List<KullaniciTip> UrunleriGetir()
        {
            return _ent.Urun.Where(p => p.StokAdedi == 0).Select(p => new KullaniciTip()
            {
                Adi = p.Adi,
                Fiyati = p.Fiyati,
                UrunID = p.UrunID
            }).ToList();
        }
    }
    public class KullaniciTip
    {
        public int UrunID { get; set; }
        public string Adi { get; set; }
        public double Fiyati { get; set; }
        public int StokAdedi { get; set; }

    }
}