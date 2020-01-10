using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    public interface ILocatable
    {
        Position CurrentPosition { get; set; }
    }
}
