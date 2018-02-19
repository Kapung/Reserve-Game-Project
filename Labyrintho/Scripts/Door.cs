using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Labyrintho.Scripts
{
    internal class Door : Draw 
    {
        private new static Brush brush = new SolidBrush(Color.Blue);
        private new static float height = 1;
        private new static float width = 1;
        public string door_name { get; private set; }

        public Door(int position_X, int position_Y, string name) : base(position_X, position_Y, width, height, brush, Properties.Resources.door)
        {
            door_name = name;
        }
                                                        // Put doors only when between two walls and not corners FIX THIS LATER
        public void checkErrors(List<Draw>Tile)
        {
            foreach(Draw t in Tile)
            {
                if ((location.x + 1) == t.location.x && location.y == t.location.y && t is Wall)
                {
                    source = Properties.Resources.door2;
                }
            }
        } 
    }
}
