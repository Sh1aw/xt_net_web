using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Game
{
    class Game
    {
        Field BattleField = new Field(100, 100);
        List<Obstacle> obstclList = new List<Obstacle>();
        List<Enemy> enemyList = new List<Enemy>();
        List<Bonus> bonusList = new List<Bonus>();
        Player p1 = new Player(100,new Position(0,0));
    }
}
