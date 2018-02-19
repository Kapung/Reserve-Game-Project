using System.Drawing;


namespace Labyrintho
{
    public abstract class Draw
    {
        // Variables for drawables
        public float height;
        public float width;
        public Image source;
        public Brush brush;
        public Location location;

        //Default
        public Draw(float position_X, float position_Y, float x_width, float x_height) : this(position_X, position_Y, x_width, x_height, new SolidBrush(Color.DarkSeaGreen), null)
        {

        }

        //Draw
        public Draw(float position_X, float position_Y, float width, float height, Brush brush, Image src)
        {
            location = new Location(position_X, position_Y);
            this.width = width;
            this.height = height;
            this.brush = brush;
            source = src;
        }
    }
}
