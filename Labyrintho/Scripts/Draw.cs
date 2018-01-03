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
