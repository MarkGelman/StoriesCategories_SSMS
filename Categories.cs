using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30122020_SSMS_EXAMEN
{
    class Categories
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }

        public Categories(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
