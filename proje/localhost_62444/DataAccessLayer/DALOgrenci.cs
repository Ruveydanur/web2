using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;
using DataAccessLayer;

namespace DataAccessLayer
{
   public class DALOgrenci
    {
       public static int OgrenciEkle (EntityOgrenci parametre)
       {
           SqlCommand komut1 = new SqlCommand("insert into tbl_ogr(ogr_ad,ogr_soyad,ogr_numara,ogr_foto,ogr_sifre) values (@p1,@p2,@p3,@p4,@p5)",Baglanti.bgl);
           if(komut1.Connection.State != ConnectionState.Open)
           {
               komut1.Connection.Open();
           }

           komut1.Parameters.AddWithValue("@p1", parametre.AD);
           komut1.Parameters.AddWithValue("@p2", parametre.SOYAD);
           komut1.Parameters.AddWithValue("@p3", parametre.NUMARA );
           komut1.Parameters.AddWithValue("@p4", parametre.FOTOGRAF);
           komut1.Parameters.AddWithValue("@p5", parametre.SIFRE);
           return komut1.ExecuteNonQuery();

       }

       public static List<EntityOgrenci> OgrenciListesi()
       {
           List<EntityOgrenci> degerler = new List<EntityOgrenci>();
           SqlCommand komut2 = new SqlCommand("select * from tbl_ogr", Baglanti.bgl);
           if (komut2.Connection.State != ConnectionState.Open)
           {
               komut2.Connection.Open();
           }
           SqlDataReader dr = komut2.ExecuteReader();
           while(dr.Read())
           {
               EntityOgrenci ent = new EntityOgrenci();
               ent.ID = Convert.ToInt32(dr["ogr_id"].ToString());
               ent.AD = dr["ogr_ad"].ToString();
               ent.SOYAD = dr["ogr_soyad"].ToString();
               ent.NUMARA = dr["ogr_numara"].ToString();
               ent.FOTOGRAF = dr["ogr_foto"].ToString();
               ent.SIFRE = dr["ogr_sifre"].ToString();
               ent.BAKIYE = Convert.ToDouble(dr["ogr_bakiye"].ToString());
               degerler.Add(ent);
           }
           dr.Close();
           return degerler;
       }

       public static bool OgrenciSil(int parametre)
       {
           SqlCommand komut3 = new SqlCommand("Delete from tbl_ogr where ogr_id=@p1",Baglanti.bgl);
           if(komut3.Connection.State!=ConnectionState.Open)
           {
               komut3.Connection.Open();
           }
           komut3.Parameters.AddWithValue("@p1",parametre);
           return komut3.ExecuteNonQuery() > 0;

       }

       public static List<EntityOgrenci> OgrenciDetay(int id)
       {
           List<EntityOgrenci> degerler = new List<EntityOgrenci>();
           SqlCommand komut4 = new SqlCommand("select * from tbl_ogr where ogr_id=@p1", Baglanti.bgl);
           komut4.Parameters.AddWithValue("@p1",id);
           if (komut4.Connection.State != ConnectionState.Open)
           {
               komut4.Connection.Open();
           }
           SqlDataReader dr = komut4.ExecuteReader();
           while (dr.Read())
           {
               EntityOgrenci ent = new EntityOgrenci();
               ent.AD = dr["ogr_ad"].ToString();
               ent.SOYAD = dr["ogr_soyad"].ToString();
               ent.NUMARA = dr["ogr_numara"].ToString();
               ent.FOTOGRAF = dr["ogr_foto"].ToString();
               ent.SIFRE = dr["ogr_sifre"].ToString();
               ent.BAKIYE = Convert.ToDouble(dr["ogr_bakiye"].ToString());
               degerler.Add(ent);
           }
           dr.Close();
           return degerler;
       }

       public static bool OgrenciGuncelle(EntityOgrenci deger)
       {
           SqlCommand komut5 = new SqlCommand("update tbl_ogr set ogr_ad=@p1, ogr_soyad=@p2, ogr_numara=@p3, ogr_foto=@p4, ogr_sifre=@p5 where ogr_id=@p6",Baglanti.bgl);
           if (komut5.Connection.State != ConnectionState.Open)
           {
               komut5.Connection.Open();
           }
           komut5.Parameters.AddWithValue("@p1", deger.AD);
           komut5.Parameters.AddWithValue("@p2", deger.SOYAD);
           komut5.Parameters.AddWithValue("@p3", deger.NUMARA);
           komut5.Parameters.AddWithValue("@p4", deger.FOTOGRAF);
           komut5.Parameters.AddWithValue("@p5", deger.SIFRE);
           komut5.Parameters.AddWithValue("@p6", deger.ID);
           return komut5.ExecuteNonQuery() > 0;

       }
    }
}
