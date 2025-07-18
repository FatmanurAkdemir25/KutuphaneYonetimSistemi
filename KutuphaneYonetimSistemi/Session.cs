using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneYonetimSistemi
{
    public class Session
    {
        public static int KullaniciID { get; set; }
        public static string AdSoyad { get; set; }
        public static int YetkiSeviyesi { get; set; }
        
    }
}
//Bu yapı bellekte tutulur uygulama kapanınca bilgiler sıfırlanır . kullanıcı bilgilerine her formdan kolay erişim sağlar