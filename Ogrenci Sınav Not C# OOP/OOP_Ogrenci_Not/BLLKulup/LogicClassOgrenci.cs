using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;


namespace BLLKulup
{
    public class LogicClassOgrenci
    {
        public static int EKLE (EntityClassOgrenci entOgrenci)
        {
            if (entOgrenci.AD != "" && entOgrenci.SOYAD != "" && entOgrenci.KULUPID>0 && entOgrenci.FOTOGRAF.Length>=1)
            {
                return FacadeClassOgrenci.EKLE(entOgrenci);
            }
            return -1;
        }
        public static bool GUNCELLE(EntityClassOgrenci entOgrenci)
        {
            if(entOgrenci.ID >0 && entOgrenci.AD != "" && entOgrenci.SOYAD != "" && entOgrenci.KULUPID > 0)
            {
                return FacadeClassOgrenci.GUNCELLE(entOgrenci);
            }
            return false;
        }
        public static bool SIL(int entOgrenci)
        {
            if (entOgrenci >0)
            {
                return FacadeClassOgrenci.SIL(entOgrenci);
            }
            else
            {
                return false;
            }
        }
        public static List<EntityClassOgrenci> LISTELE()
        {
            return FacadeClassOgrenci.OgrenciLıstesi();
        }
    }
}
