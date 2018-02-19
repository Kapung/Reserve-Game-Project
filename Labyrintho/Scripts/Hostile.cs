using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrintho.Scripts
{
    public abstract class Hostile : Draw
    {
        public Hostile(int position_X, int position_Y, Image image) : base(position_X, position_Y, 1, 1, new SolidBrush(Color.Blue), image)
        {
            //Default
        }

        public abstract void Hit(Player player);

        public abstract void Move(List<Draw> solid);
    }
}
