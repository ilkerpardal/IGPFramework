using System;
using System.Collections.Generic;
using System.Text;

namespace IgpFramework.Data.Kullanici
{
    public class KullaniciBilgileri
    {
        public decimal Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifresi { get; set; }
        public string CepTelefonu { get; set; }
        public string Eposta { get; set; }
        public decimal TcKimlikNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public int Cinsiyeti { get; set; }
    }
}
