using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrintho.Scripts
{
    public class SpawnPoint : Draw
    {
        private new static Brush brush = new SolidBrush(Color.Red);
        private new static float height = 1;
        private new static float width = 1;

        public SpawnPoint(int position_X, int position_Y) : base(position_X, position_Y, width, height, brush, Labyrintho.Properties.Resources.ladder_down)
        {
            //Default
        }
    }
}
