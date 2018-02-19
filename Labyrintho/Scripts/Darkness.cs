using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrintho.Scripts
{
    public static class Darkness
    {
        public static float DarkLevel(Lightning light, Draw d)
        {
            //Variables for darkness
            float minus_X = 0F;
            float minus_Y = 0F;
            float positive_X = light.location.x - d.location.x;
            float positive_Y = light.location.y - d.location.y;
            float size = 0;

            int radius = light.radius;

            //Calculates X
            if (positive_X > 0)
            {
                minus_X = positive_X / radius;
            }
            else if (positive_X < 0)
            {
                minus_X = -positive_X / radius;
            }

            //Calculates Y
            if (positive_Y > 0)
            {
                minus_Y = positive_Y / radius;
            }
            else if (positive_Y < 0)
            {
                minus_Y = -positive_Y / radius;
            }

            // 0 Dark / 1 Lit
            size = 1 - minus_Y - minus_X + 0.2F;
            return size;
        }

        public static bool CalculateSize(Lightning l, Draw d)
        {
            return d.location.x < l.location.x + l.radius 
                && d.location.y < l.location.y + l.radius 
                && d.location.x > l.location.x - l.radius 
                && d.location.y > l.location.y - l.radius;
        }
    }
}
