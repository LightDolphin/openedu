using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.


    class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            switch (Game.KeyPressed)
            {
                case System.Windows.Forms.Keys.Right:
                    if (x<Game.MapWidth-1 && !(Game.Map[x+1,y] is Sack))
                        return new CreatureCommand() {DeltaX=1 };
                    break;
                case System.Windows.Forms.Keys.Left:
                    if (x > 0 && !(Game.Map[x-1, y] is Sack))
                        return new CreatureCommand() { DeltaX = -1 };
                    break;
                case System.Windows.Forms.Keys.Up:
                    if (y > 0 && !(Game.Map[x, y-1] is Sack))
                        return new CreatureCommand() { DeltaY = -1 };
                    break;
                case System.Windows.Forms.Keys.Down:
                    if (y < Game.MapHeight-1 && !(Game.Map[x, y+1] is Sack))
                        return new CreatureCommand() { DeltaY = 1 };
                    break;
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Sack;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

    class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Player;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    public class Sack : ICreature
    {
        private int count=0;
        public CreatureCommand Act(int x, int y)
        {
            if ((count>1) && 
                (
                (y == Game.MapHeight - 1) || 
                (Game.Map[x, y + 1] != null && !(Game.Map[x, y + 1] is Player))
                )
                )
                return new CreatureCommand() { TransformTo = new Gold() };
            if (y < Game.MapHeight - 1)
            {
                if (Game.Map[x, y + 1] == null || (Game.Map[x, y + 1] is Player && count > 0))
                {
                    count++;
                    return new CreatureCommand() { DeltaY = 1 };
                }
                else if (count < 2) count = 0;
            }

            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 4;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }

    class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
            {
                Game.Scores += 10;
                return true;
            }
            return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }
}
