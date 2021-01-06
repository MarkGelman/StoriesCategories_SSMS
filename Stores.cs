using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30122020_SSMS_EXAMEN
{
    class Stores
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public long Category_Id { get; set; }

        public Stores(long id, string name,int floor,long category_id)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Category_Id = category_id;
        }

    }
}
