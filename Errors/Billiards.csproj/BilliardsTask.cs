using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directionRadians">Угол направелния движения шара</param>
        /// <param name="wallInclinationRadians">Угол</param>
        /// <returns></returns>
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            //TODO
            //wallInclinationRadians += 90;
            //directionRadians += 180;

            double r = (directionRadians + 180 + 2 * (wallInclinationRadians + 90 - directionRadians - 180) + 360 * 5)%360;
            if (r > 180)
            {
                r -= 360;
            }

            return r;
        }
    }
}