using System.Drawing;

namespace Labyrintho.Scripts
{
    public abstract class Lightning : Draw
    {
        //Light radius
        public int radius { get; set; }

        //OL constructor
        public Lightning(float position_x, float position_y, float width, float height, Image src, int radius) : base (position_x, position_y, width, height, new SolidBrush(Color.Green), src)
        {
            this.radius = radius;
        }
    }
}
