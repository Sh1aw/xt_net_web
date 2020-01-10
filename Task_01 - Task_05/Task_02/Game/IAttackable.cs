using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    public interface IAttackable
    {
        void Attack(IMovable imv, int strength);
    }
}
