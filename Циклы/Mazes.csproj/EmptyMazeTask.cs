namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            while (!robot.Finished)
            {
                if (RightOrDown(robot.X, robot.Y, width, height) == Direction.Up) break;
                else robot.MoveTo(RightOrDown(robot.X, robot.Y, width, height));
            }
        }
        public static Direction RightOrDown(int x, int y,int width, int height)
        {
            return (x < width - 2) ? Direction.Right : (y < height - 2) ? Direction.Down : Direction.Up;
        }
	}
}