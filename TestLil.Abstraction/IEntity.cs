using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLil.Abstraction
{
    public interface IEntity
    {
        int Id { get; set; }
        string Code { get; set; }
        int State { get; set; }
    }
}
