using System.Collections.Generic;
using System.Drawing;
using OOP;

namespace GeometryPainting
{
    //Напишите здесь код, который заставит работать методы segment.GetColor и segment.SetColor
    public static class SegmentExtensions
    {
        static readonly Dictionary<Segment,Color> Colors = new Dictionary<Segment, Color>();
        public static void SetColor(this Segment segment, Color c)
        {
            if (Colors.ContainsKey(segment)) Colors[segment] = c;
            else Colors.Add(segment, c);
        }

        public static Color GetColor(this Segment segment)
        {
            if (Colors.ContainsKey(segment)) return Colors[segment];
            return Color.Black;
        }
    }
}
