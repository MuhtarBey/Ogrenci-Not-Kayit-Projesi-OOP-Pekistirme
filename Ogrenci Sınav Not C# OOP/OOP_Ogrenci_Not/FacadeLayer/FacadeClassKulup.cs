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
    public class FacadeClassKulup
    {
        public static int EKLE (EntityClassKulup entKulup)
        {
            SqlCommand cm1 = new SqlCommand("KULUPEKLE", ConnectionClass.cn);
            cm1.CommandType = CommandType.StoredProcedure;
            if (cm1.Connection.State != ConnectionState.Open)
            {
                cm1.Connection.Open();
            }
            cm1.Parameters.AddWithValue("KULUPAD", entKulup.KULUPAD);
            return cm1.ExecuteNonQuery();
        }
        public static bool SIL(int entKulup)
        {
            SqlCommand cm2 = new SqlCommand("KULUPSIL", ConnectionClass.cn);
            cm2.CommandType = CommandType.StoredProcedure;
            if (cm2.Connection.State != ConnectionState.Open)
            {
                cm2.Connection.Open();
            }
            cm2.Parameters.AddWithValue("KULUPID", entKulup);
            return cm2.ExecuteNonQuery() > 0;
        }
        public static bool GUNCELLE(EntityClassKulup entKulup)
        {
            SqlCommand cm3 = new SqlCommand("KULUPGUNCELLE", ConnectionClass.cn);
            cm3.CommandType = CommandType.StoredProcedure;
            if (cm3.Connection.State != ConnectionState.Open)
            {
                cm3.Connection.Open();
            }
            cm3.Parameters.AddWithValue("KULUPID", entKulup.KULUPID);
            cm3.Parameters.AddWithValue("KULUPAD", entKulup.KULUPAD);
            return cm3.ExecuteNonQuery() > 0;
        }
        public static List<EntityClassKulup> KULUPLISTESI()
        {
            List<EntityClassKulup> values = new List<EntityClassKulup>();
            SqlCommand cm4 = new SqlCommand("KULUPLISTESI", ConnectionClass.cn);
            cm4.CommandType = CommandType.StoredProcedure;
            if (cm4.Connection.State != ConnectionState.Open)
            {
                cm4.Connection.Open();
            }
            SqlDataReader dr = cm4.ExecuteReader();
            while (dr.Read())
            {
                EntityClassKulup ent = new EntityClassKulup();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"]);
                ent.KULUPAD = dr["KULUPAD"].ToString();
                values.Add(ent);
            }
            dr.Close();
            return values;
        }
    }
}
