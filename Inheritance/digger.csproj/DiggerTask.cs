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
                    if (x<Game.MapWidth-1) return new CreatureCommand() {DeltaX=1 };break;
                case System.Windows.Forms.Keys.Left:
                    if (x > 0) return new CreatureCommand() { DeltaX = -1 }; break;
                case System.Windows.Forms.Keys.Up:
                    if (y > 0) return new CreatureCommand() { DeltaY = -1 }; break;
                case System.Windows.Forms.Keys.Down:
                    if (y < Game.MapHeight-1) return new CreatureCommand() { DeltaY = 1 }; break;
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.GetImageFileName() != "Monster.png") return false;
            return true;
        }

        public int GetDrawingPriority()
        {
            return 0;
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
            return true;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    class Sack : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            if (Game.Map[x,y].GetImageFileName==)
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
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
            throw new NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            throw new NotImplementedException();
        }

        public int GetDrawingPriority()
        {
            throw new NotImplementedException();
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
