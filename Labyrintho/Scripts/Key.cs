using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Labyrintho.Scripts
{
    internal class Key : Draw 
    {
        private new static Brush brush = new SolidBrush(Color.Purple);
        private new static float height = 1;
        private new static float width = 1;
        public new Image source { get; private set; }
        public Door door { get; private set; }
        public bool hasIt { get; private set; }
            
        public Key (int position_X, int position_Y, Door d) : base(position_X, position_Y, width, height, brush, Properties.Resources.key)
        {
            hasIt = false;
            door = d;
        }

        public void PickUp(Player p, List<Draw>hostiles)
        {
            p.inventory.add_item(this);
            hostiles.Remove(this);
            hasIt = true;
            UI.Message($"Picked up {door.door_name} key");

        }
    }
}
