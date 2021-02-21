using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;

namespace BLLKulup
{
    public class LogicClassNotlar
    {
        public static bool GUNCELLE(EntityClassNotlar entNotlar)
        {
            if (entNotlar.OGRID > 0 && entNotlar.ORTALAMA >= 0 && entNotlar.ORTALAMA <= 100 &&
                entNotlar.SINAV1 <= 100 && entNotlar.SINAV2 <= 100 && entNotlar.SINAV3 <= 100
                && entNotlar.SINAV1 >= 0 && entNotlar.SINAV2 >= 0 && entNotlar.SINAV3 >= 0
                && entNotlar.PROJE >= 0 && entNotlar.PROJE <= 0)
            {
                return FacadeClassNotlar.GUNCELLE(entNotlar);
            }
            return false;
        }
        public static List<EntityClassNotlar> LISTELE()
        {
           return FacadeClassNotlar.NOTLISTESI();
        }
    }
}
