using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBasvuruFormu
    {
        private int basvuruid;

        public int BASVURUİD
        {
            get { return basvuruid; }
            set { basvuruid = value; }
        }
        private int basdersid;

        public int BASDERSİD
        {
            get { return basdersid; }
            set { basdersid = value; }
        }
        private int basogrid;

        public int BASOGRİD
        {
            get { return basogrid; }
            set { basogrid = value; }
        }
    }
}
