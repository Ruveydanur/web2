using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLDers
    {
        public static List<EntityDers> BllListele()
        {
            return DALDers.DersListesi();
        }
        public static int TalepEkleBLL(EntityBasvuruFormu p)
        {
            if (p.BASOGRİD != null && p.BASDERSİD != null)
            {
                return DALDers.TalepEkle(p);
            }
            return -1;
        }
      
    }
}
