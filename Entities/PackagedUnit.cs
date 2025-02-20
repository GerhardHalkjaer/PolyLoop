using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PackagedUnit
    {
        public int Id { get; set; }
        public int SpecificTypeId { get; set; }
        public int PackagingId { get; set; }
        public int weight { get; set; }
        public string ImagePath { get; set; }

        public PackagedUnit()
        {
            ImagePath = string.Empty;   
        }

        public PackagedUnit(PackagedUnit InpackagedUnit)
        {
            Id = InpackagedUnit.Id;
            SpecificTypeId = InpackagedUnit.SpecificTypeId;
            PackagingId = InpackagedUnit.PackagingId;
            weight = InpackagedUnit.weight;
            ImagePath = InpackagedUnit.ImagePath;
        }
    }
}
