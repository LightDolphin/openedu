namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            int mr = (width % height > 4)? width / height + 1: width / height;
            int md = (height % width > 4)? height / width + 1: height / width;
            bool isDown = (md >= mr)?true:false;
            while (!robot.Finished)
            {
                if (isDown) Move(robot, Direction.Down, md);
                else Move(robot, Direction.Right, mr);
                isDown = !isDown;
            }
        }

        public static void Move(Robot robot,Direction direction, int count)
        {
            for (int i = 0; i < count; i++) robot.MoveTo(direction);
        }
	}
}