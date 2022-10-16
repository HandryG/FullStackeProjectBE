using System.ComponentModel;

namespace TestLil.Entities
{
    public class Producto : Entity
    {
        public string name { get; set; } 
        public int stock { get; set; }
        
        public enum KdState
        {
            [Description("Inactive")]
            Inactive = 0,
            [Description("Active")]
            Active = 0,
        }
    }
}