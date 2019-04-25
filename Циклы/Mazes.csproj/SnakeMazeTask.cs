namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            bool down = false, left = false;
            robot.MoveTo(Direction.Right);
            while (!robot.Finished) if (down) down = MoveDown(robot, true);
                else
                {
                    down = robot.X == 1 || robot.X == width - 2;
                    if (down) left = !(robot.X == 1);
                    else robot.MoveTo(OneStepToLeftOrRight(1, left));
                }
        }

        public static bool MoveDown(Robot robot, bool down)
        {
            DoubleDown(robot);
            robot.MoveTo(OneStepToLeftOrRight(robot.X,false));
            return !down;
        }

        public static Direction OneStepToLeftOrRight(int x,bool left)
        {
            if (x == 1 && !left) return Direction.Right;
            return Direction.Left;
        }

        public static void DoubleDown(Robot robot)
        {
            robot.MoveTo(Direction.Down);
            robot.MoveTo(Direction.Down);
        }
	}
}