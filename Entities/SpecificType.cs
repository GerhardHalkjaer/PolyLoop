
namespace Entities
{
    public class SpecificType
    {
        public int Id { get; set; }
        public MaterialType MatType { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }


        public SpecificType()
        {
            MatType = new MaterialType();
            Name = string.Empty;
            IconPath = string.Empty;
            Id = -1;
        }


        public SpecificType(SpecificType InspecificType)
        {
            Id = InspecificType.Id;
            MatType = new MaterialType(InspecificType.MatType);
            Name = InspecificType.Name;
            IconPath = InspecificType.IconPath;
        }

    }
}
