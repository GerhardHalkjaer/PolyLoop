namespace Entities
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        


        public MaterialType()
        {
            Name = string.Empty;
            IconPath = string.Empty;
            Id = -1;
        }

        public MaterialType(MaterialType InMatType)
        {
            Id = InMatType.Id;
            Name = InMatType.Name;
            IconPath = InMatType.IconPath;
        
        }
    }
}
