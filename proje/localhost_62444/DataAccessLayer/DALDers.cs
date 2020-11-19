using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;


namespace DataAccessLayer
{
    public class DALDers
    {
        public static List<EntityDers> DersListesi()
        {
            List<EntityDers> degerler = new List<EntityDers>();
            SqlCommand komut2 = new SqlCommand("select * from tbl_dersler", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityDers ent = new EntityDers();
                ent.ID = Convert.ToInt32(dr["ders_id"].ToString());
                ent.DERSAD = dr["ders_ad"].ToString();
                ent.MIN = int.Parse(dr["ders_MinKontenjan"].ToString());
                ent.MAX = int.Parse(dr["ders_MaxKontenjan"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;

        }
        public static int TalepEkle(EntityBasvuruFormu parametre)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_basvuruformu(ogrenciid,dersid) values (@p1,@p2)",Baglanti.bgl);
            komut.Parameters.AddWithValue("@p1",parametre.BASOGRİD);
            komut.Parameters.AddWithValue("@p2", parametre.BASDERSİD);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            return komut.ExecuteNonQuery();

        }
    }
}
