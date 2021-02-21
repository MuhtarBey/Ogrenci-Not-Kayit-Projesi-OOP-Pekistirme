using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;



namespace BLLKulup
{
    public class LogicClassKulup
    {
        public static int EKLE(EntityClassKulup entKulup)
        {
            if (entKulup.KULUPAD != "")
            {
                return FacadeClassKulup.EKLE(entKulup);
            }
            else
            {
                return -1;
            }
        }
        public static bool GUNCELLE (EntityClassKulup entKulup)
        {
            if(entKulup.KULUPAD!="")
            {
                return FacadeClassKulup.GUNCELLE(entKulup);
            }
            else
            {
                return false;
            }
        }
        public static List<EntityClassKulup> LISTELE()
        {
            return FacadeClassKulup.KULUPLISTESI();
        }
    }
}
