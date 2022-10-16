using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLil.Abstraction;

namespace TestLil.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
    }
}
