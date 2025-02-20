using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Packaging
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int PackagingWeight { get; set; }

        public Packaging()
        {
            Name = string.Empty;
            IconPath = string.Empty;
        }

        public Packaging(Packaging InPackaging)
        {
            Id = InPackaging.Id;
            Name = InPackaging.Name;
            IconPath = InPackaging.IconPath;
            PackagingWeight = InPackaging.PackagingWeight;
        }

    }
}
