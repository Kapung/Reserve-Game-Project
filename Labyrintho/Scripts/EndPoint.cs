using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Labyrintho.Scripts
{
    public class EndPoint : Draw
    {
        private new static Brush brush = new SolidBrush(Color.Blue);
        private new static float height = 1;
        private new static float width = 1;

        public EndPoint(int position_X, int position_Y) : base(position_X, position_Y, width, height, brush, Labyrintho.Properties.Resources.ladder_up)
        {
            //Default
        }
    }
}
