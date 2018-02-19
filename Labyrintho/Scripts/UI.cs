using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Labyrintho.Screens;

namespace Labyrintho.Scripts
{
    internal static class UI
    {
        public static int timer { get; set; }
        public static int opacity { get; set; }
        private static string text { get; set; }
        private static GameScreen screen { get; set; }

        public static void GameScreenSetup(GameScreen s)
        {
            screen = s;
        }

        public static void DisplayMessage(Graphics g)
        {
            String message = text;
            Font font = new Font("Times New Roman", 18);
            SolidBrush brush = new SolidBrush(Color.FromArgb(opacity, Color.White));
            PointF draw_location = new PointF(0F, 615.0F);
            g.DrawString(message, font, brush, draw_location);
        }

        public static void Message(string text_m)
        {
            screen.messageTimer.Stop();
            screen.messageTimer.Start();
            timer = 0;
            opacity = 255;
            text = text_m;
        }

        public static void FadeMessage()
        {
            timer++;
            if (timer > 25 && opacity > 1) //Prevents color going to negative and crashing the whole game
            {
                opacity -= 2;
            }
            else if (opacity <= 1)
            {
                screen.messageTimer.Stop();
            }
        }
    }

}
