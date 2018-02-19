using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Labyrintho.Scripts
{
    internal class Floor : Draw
    {
        private new static SolidBrush brush = new SolidBrush(Color.BlueViolet);
        private new static int height = 1;
        private new static int width = 1;

        public Floor(int position_X, int position_Y) : base(position_X, position_Y, width, height, brush, Properties.Resources.floor_tile_1)
        {
            //Default
        }

    }
}
