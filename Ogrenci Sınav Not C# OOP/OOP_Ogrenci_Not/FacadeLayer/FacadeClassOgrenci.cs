using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;

namespace FacadeLayer
{
    public class FacadeClassOgrenci
    {
        public static int EKLE(EntityClassOgrenci entOgrenci)
        {
            SqlCommand cm1 = new SqlCommand("OGRENCIEKLE", ConnectionClass.cn);
            cm1.CommandType = CommandType.StoredProcedure;
            if (cm1.Connection.State != ConnectionState.Open)
            {
                cm1.Connection.Open();
            }
            cm1.Parameters.AddWithValue("AD", entOgrenci.AD);
            cm1.Parameters.AddWithValue("SOYAD", entOgrenci.SOYAD);
            cm1.Parameters.AddWithValue("@FOTOGRAF", entOgrenci.KULUPID);
            cm1.Parameters.AddWithValue("KULUPID", entOgrenci.KULUPID);
            return cm1.ExecuteNonQuery();
        }
        public static bool SIL(int entOgrenci)
        {
            SqlCommand cm2 = new SqlCommand("OGRENCISIL", ConnectionClass.cn);
            cm2.CommandType = CommandType.StoredProcedure;
            if (cm2.Connection.State != ConnectionState.Open)
            {
                cm2.Connection.Open();
            }
            cm2.Parameters.AddWithValue("ID", entOgrenci);
            return cm2.ExecuteNonQuery() > 0;
        }
        public static bool GUNCELLE(EntityClassOgrenci entOgrenci)
        {
            SqlCommand cm3 = new SqlCommand("OGRENCIGUNCELLE", ConnectionClass.cn);
            cm3.CommandType = CommandType.StoredProcedure;
            if (cm3.Connection.State != ConnectionState.Open)
            {
                cm3.Connection.Open();
            }
            cm3.Parameters.AddWithValue("ID", entOgrenci.ID);
            cm3.Parameters.AddWithValue("AD", entOgrenci.AD);
            cm3.Parameters.AddWithValue("SOYAD", entOgrenci.SOYAD);
            cm3.Parameters.AddWithValue("@FOTOGRAF", entOgrenci.KULUPID);
            cm3.Parameters.AddWithValue("KULUPID", entOgrenci.KULUPID);
            return cm3.ExecuteNonQuery() > 0;
        }
        public static List<EntityClassOgrenci> OgrenciLıstesi()
        {
            List<EntityClassOgrenci> values = new List<EntityClassOgrenci>();
            SqlCommand cm4 = new SqlCommand("OGRENCILISTESI", ConnectionClass.cn);
            cm4.CommandType = CommandType.StoredProcedure;
            if (cm4.Connection.State != ConnectionState.Open)
            {
                cm4.Connection.Open();
            }
            SqlDataReader dr = cm4.ExecuteReader();
            while (dr.Read())
            {
                EntityClassOgrenci ent = new EntityClassOgrenci();
                ent.ID = Convert.ToInt32(dr["ID"].ToString());
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.FOTOGRAF = dr["FOTOGRAF"].ToString();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"].ToString());
                values.Add(ent);
            }
            dr.Close();
            return values;
        }
    }
}
