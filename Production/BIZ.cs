using Entities;

namespace Production
{
    public class BIZ : IBIZ
    {
        /// <summary>
        /// used as a reference to the current unit of work
        /// </summary>
        public PackagedUnit packagedUnit { get; set; } = new PackagedUnit();


        
    }
}
