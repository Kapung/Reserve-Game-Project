using System;
using System.Drawing;
using System.Collections.Generic;

namespace Labyrintho.Scripts
{
    internal class Wall : Draw
    {
        private new static float height = 1;
        private new static float width = 1;
        private new static Brush brush = new SolidBrush(Color.Red);


        public Wall(int position_x, int position_y) : base(position_x, position_y, width, height, brush, Labyrintho.Properties.Resources.wall_tile02)
        {
            //Default
        }

        public void checkErrors(List<Draw> Wall_tiles)
        {
            foreach (Draw Wall in Wall_tiles)
            {
                if (this.location.x == Wall.location.x && Wall is Wall && (this.location.y + 1) == Wall.location.y)
                {
                    this.source = Labyrintho.Properties.Resources.wall_tile02;
                }
            }
        }
    }
}
