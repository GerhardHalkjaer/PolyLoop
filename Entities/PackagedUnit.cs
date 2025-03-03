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
        public SpecificType SpecificType { get; set; } 
        public Packaging Packaging { get; set; } //TODO change to object Packaging
        public int weight { get; set; }
        public string ImagePath { get; set; }
        public DateTime ProcessedDate { get; set; }

        public PackagedUnit()
        {
            ImagePath = string.Empty;   
            SpecificType = new SpecificType();
            Packaging = new Packaging();
            ProcessedDate = new DateTime();
        }

        public PackagedUnit(PackagedUnit InpackagedUnit)
        {
            Id = InpackagedUnit.Id;
            SpecificType = InpackagedUnit.SpecificType;
            Packaging = InpackagedUnit.Packaging;
            weight = InpackagedUnit.weight;
            ImagePath = InpackagedUnit.ImagePath;
            ProcessedDate = InpackagedUnit.ProcessedDate;
        }
    }
}
