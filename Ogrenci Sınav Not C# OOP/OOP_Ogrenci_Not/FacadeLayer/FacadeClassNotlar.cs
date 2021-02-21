using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;


namespace FacadeLayer
{
    public class FacadeClassNotlar
    {
        public static bool GUNCELLE(EntityClassNotlar entNotlar)
        {
            SqlCommand cm1 = new SqlCommand("NOTGUNCELLE",ConnectionClass.cn);
            cm1.CommandType = CommandType.StoredProcedure;
            if (cm1.Connection.State != ConnectionState.Open)
            {
                cm1.Connection.Open();
            }
            cm1.Parameters.AddWithValue("SINAV1", entNotlar.SINAV1);
            cm1.Parameters.AddWithValue("SINAV2", entNotlar.SINAV2);
            cm1.Parameters.AddWithValue("SINAV3", entNotlar.SINAV3);
            cm1.Parameters.AddWithValue("PROJE", entNotlar.PROJE);
            cm1.Parameters.AddWithValue("ORTALAMA", entNotlar.ORTALAMA);
            cm1.Parameters.AddWithValue("DURUM", entNotlar.DURUM);
            cm1.Parameters.AddWithValue("OGRID", entNotlar.OGRID);
            return cm1.ExecuteNonQuery() > 0;
        }
        public static List<EntityClassNotlar> NOTLISTESI()
        {
            List<EntityClassNotlar> values = new List<EntityClassNotlar>();
            SqlCommand cm2 = new SqlCommand("NOTLISTESI",ConnectionClass.cn);
            cm2.CommandType = CommandType.StoredProcedure;
            if (cm2.Connection.State != ConnectionState.Open)
            {
                cm2.Connection.Open();
            }
            SqlDataReader dr = cm2.ExecuteReader();
            while (dr.Read())
            {
                EntityClassNotlar ent = new EntityClassNotlar();
                ent.OGRID = Convert.ToInt16(dr["OGRID"]);
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.SINAV1 = Convert.ToUInt16(dr["SINAV1"]);
                ent.SINAV2 = Convert.ToUInt16(dr["SINAV2"]);
                ent.SINAV3 = Convert.ToInt16(dr["SINAV3"]);
                ent.PROJE = Convert.ToUInt16(dr["PROJE"]);
                ent.ORTALAMA = Convert.ToDouble(dr["ORTALAMA"]);
                ent.DURUM = dr["DURUM"].ToString();
                values.Add(ent);
            }
            dr.Close();
            return values;
        }
    }
}
